using LawyerApp.Areas.LawyerAdminPanel.Models;
using LawyerApp.Infrastructures;
using LawyerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Model= LawyerApp.Models;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class SliderController:Controller
    {
        private readonly LawyerDbContext lawyerDbContext;

        public SliderController(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await lawyerDbContext.Sliders.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new SliderCreateModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateModel slider)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = await FileService.UploadImageAsync(slider.Img, "Uploads");
                    await lawyerDbContext.Sliders.AddAsync(new Slider
                    {
                        Img = fileName
                    });
                    await lawyerDbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentNullException exp)
                {
                    ModelState.AddModelError("img", exp.Message);
                }

                catch (InvalidContentTypeException exp)
                {
                    ModelState.AddModelError("img", exp.Message);
                }
                catch
                {
                    ModelState.AddModelError("", "Some error occured. Please try again.");
                }
            }
            return View(slider);
        }

        [HttpGet]
        public async Task<IActionResult>Edit([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                Slider slider = await lawyerDbContext.Sliders.FindAsync(id);

                return View(new SliderEditModel
                {
                    Id = id,
                    FileName = slider.Img
                });
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required][FromForm] int id,SliderEditModel slider)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Slider _slider = await lawyerDbContext.Sliders.FindAsync(id);

                    string _oldFileName = _slider.Img;

                    _slider.Img = await FileService.UploadImageAsync(slider.Img, "Uploads");

                    await lawyerDbContext.SaveChangesAsync();

                    FileService.DeleteFile(_oldFileName, "Uploads");

                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentNullException exp)
                {
                    ModelState.AddModelError("img", exp.Message);
                }
                catch (InvalidContentTypeException exp)
                {
                    ModelState.AddModelError("img", exp.Message);
                }
                catch
                {
                    ModelState.AddModelError("", "Some error occured. Please try again.");
                }
            }
            return View(new SliderEditModel
            {
                Id = id,
                FileName = slider.FileName
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Required][FromForm] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Slider slider = await lawyerDbContext.Sliders.FindAsync(id);

                    if (slider == null)
                        throw new NullReferenceException();

                    lawyerDbContext.Sliders.Remove(slider);
                    await lawyerDbContext.SaveChangesAsync();

                    FileService.DeleteFile(slider.Img, "Uploads");

                    return Json(new
                    {
                        status = HttpStatusCode.OK
                    });
                }
                catch { }
            }
            return Json(new
            {
                status = HttpStatusCode.NotFound
            });
        }
    }
}
