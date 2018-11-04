using LawyerApp.Areas.LawyerAdminPanel.Models;
using LawyerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class AccountController:Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly LawyerDbContext lawyerDbContext;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,LawyerDbContext lawyerDbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.lawyerDbContext = lawyerDbContext;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<UserDto> users = userManager.Users.Select(m => new UserDto
                                                                            {
                                                                               Id=m.Id,
                                                                               Name=m.Name,
                                                                            });
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser appUser = new AppUser
                    {
                        UserName = userViewModel.Username,
                        Name = userViewModel.Name,
                        Email = userViewModel.Email,
                    };

                    IdentityResult identityResult= await userManager.CreateAsync(appUser, userViewModel.Password);

                    if (identityResult.Succeeded)
                    {
                        AppUser user = await userManager.FindByNameAsync(appUser.UserName);
                        IdentityResult result=  await userManager.AddToRoleAsync(user, "Admin");

                        if(result.Succeeded)
                            return RedirectToAction(nameof(Index));
                        else
                        {
                            AddErrors(identityResult);

                            if (ModelState.ErrorCount != 0)
                                return View(userViewModel);
                        }
                    }
                    else
                    {
                        AddErrors(identityResult);

                        if (ModelState.ErrorCount != 0)
                            return View(userViewModel);
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Some error occured. Please try again.");
                }
            }

            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required][FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser appUser = await userManager.FindByIdAsync(id);

                    if (appUser == null)
                        throw new NullReferenceException();

                    return View(new UserEditModel
                    {
                         Id=appUser.Id,
                         Username=appUser.UserName,
                         Name=appUser.Name,
                         Email=appUser.Email,
                    });
                }
                catch { }
               
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required][FromForm] string id, UserEditModel userEditModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser appUser = await userManager.FindByIdAsync(id);

                    if (appUser == null)
                        throw new NullReferenceException();

                    appUser.Email = userEditModel.Email;
                    appUser.Name = userEditModel.Name;
                    appUser.UserName = userEditModel.Username;
                    appUser.PasswordHash =  (!String.IsNullOrWhiteSpace(userEditModel.Password)) ? userManager.PasswordHasher.HashPassword(appUser, userEditModel.Password) :appUser.PasswordHash;

                    IdentityResult result= await userManager.UpdateAsync(appUser);

                    if (result.Succeeded)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        AddErrors(result);

                        if (ModelState.ErrorCount != 0)
                            return View(userEditModel);
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Some error occured. Please try again");
                }
            }
            return View(userEditModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Required][FromForm] string id)
        {
            if (ModelState.IsValid)
            {
                IDbContextTransaction transaction = null;
                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();

                    AppUser user = await userManager.FindByIdAsync(id);

                    if (user == null)
                        throw new NullReferenceException();

                    IdentityResult identityResult= await userManager.RemoveFromRoleAsync(user, "Admin");

                    if (!identityResult.Succeeded)
                        throw new Exception();

                    IdentityResult result= await userManager.DeleteAsync(user);

                    if (!result.Succeeded)
                        throw new Exception();

                    transaction.Commit();
                    return Json(new
                    {
                        status = HttpStatusCode.OK
                    });
                }
                catch
                {
                    transaction.Rollback();
                }
                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }
            return Json(new
            {
                status = HttpStatusCode.NotFound
            });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new SignInModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    AppUser appUser = await userManager.FindByEmailAsync(signInModel.Email);

                    if (appUser != null)
                    {
                        bool checkPassword = await userManager.CheckPasswordAsync(appUser, signInModel.Password);

                        if (checkPassword)
                        {
                            await signInManager.SignInAsync(appUser, false);
                            return RedirectToAction("index", "home");
                        }
                        else
                        {
                            ModelState.AddModelError("password", "Password is not correct.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("email", "This email does not exist.");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Some error occured. Please try again.");
                }
            }

            return View(signInModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return RedirectToAction(nameof(Login));
            }
            catch { }
            
            return RedirectToAction("index", "home");
        }
    }
}
