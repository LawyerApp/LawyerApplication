using LawyerApp.Areas.LawyerAdminPanel.Models;
using LawyerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Infrastructures
{
    public static class DbContextExtension
    {
        public async static Task<IEnumerable<TeamMemberDto>> GetTeamMembersViewAsync(this LawyerDbContext lawyerDbContext)
        {
            var viewName = (from tm in lawyerDbContext.TeamMembers
                            join t in lawyerDbContext.Texts on tm.NameKey equals t.Key
                            select new { t.TextContent, tm.Img, t.LanguageId, tm.SurnameKey, tm.DescriptionKey, tm.Id, tm.Begin,tm.End});

            var viewSurname = from vn in viewName
                              join t in lawyerDbContext.Texts on vn.SurnameKey equals t.Key
                              where t.LanguageId==vn.LanguageId
                              select new { vn.Id, vn.Img, vn.LanguageId, vn.DescriptionKey, vn.Begin, vn.End, Name = vn.TextContent, Surname = t.TextContent };

            var viewResult = (from vs in viewSurname
                             join t in lawyerDbContext.Texts on vs.DescriptionKey equals t.Key
                             where t.LanguageId==vs.LanguageId
                             select new TeamMemberDto { Id = vs.Id, Name = vs.Name, Begin=vs.Begin, End=vs.End, Surname = vs.Surname, Description = t.TextContent,LanguageId=vs.LanguageId, Img = vs.Img, }).ToListAsync();

            return  await viewResult;
        }

        public async static Task<IEnumerable<AreaDto>> GetAreaViewAsync( this LawyerDbContext lawyerDbContext)
        {
            var viewName = from a in lawyerDbContext.Areas
                           join t in lawyerDbContext.Texts on a.NameKey equals t.Key
                           select new {Name= t.TextContent, t.LanguageId, a.Id, a.DescriptionKey };

            var viewResult = (from vn in viewName
                             join t in lawyerDbContext.Texts on vn.DescriptionKey equals t.Key
                             where t.LanguageId == vn.LanguageId
                             select new AreaDto { Id = vn.Id, Name = vn.Name, Description = t.TextContent, LanguageId = vn.LanguageId }).ToListAsync();

            return await viewResult;
        }

        public async static Task<IEnumerable<ContactDto>> GetContactViewAsync(this LawyerDbContext lawyerDbContext)
        {
            return await (from s in lawyerDbContext.StaticDatas
                          join t in lawyerDbContext.Texts on s.ContactAdressKey equals t.Key
                          select new ContactDto { Id=s.Id, ContactEmail=s.ContactEmail, ContactNumber=s.ContactNumber, ContactAdress=t.TextContent, LanguageId=t.LanguageId }).ToListAsync();
        }

        public async static Task<IEnumerable<FirmDto>> GetFirmViewAsync(this LawyerDbContext lawyerDbContext)
        {
            var viewTitle = from s in lawyerDbContext.StaticDatas
                            join t in lawyerDbContext.Texts on s.OurFirmTitleKey equals t.Key
                            select new { s.Id, s.OurFirmDescriptionKey, Title=t.TextContent, s.OurFirmImg,t.LanguageId };

            var viewResult =   (from vt in viewTitle
                                join t in lawyerDbContext.Texts on vt.OurFirmDescriptionKey equals t.Key
                                where t.LanguageId==vt.LanguageId
                                select new FirmDto { Id = vt.Id, Title = vt.Title, Description = t.TextContent, Img = vt.OurFirmImg, LanguageId = vt.LanguageId }).ToListAsync();

            return await viewResult;
        }

        public async static Task<IEnumerable<TeamServicesDto>> GetTeamServicesViewAsync(this LawyerDbContext lawyerDbContext)
        {
            var viewDescription = (from s in lawyerDbContext.StaticDatas
                                   join t in lawyerDbContext.Texts on s.OurTeamDescriptionKey equals t.Key
                                   select new { s.Id, s.ServicesDescriptionKey, TeamDescription = t.TextContent, t.LanguageId });

            var viewResult = (from vd in viewDescription
                              join t in lawyerDbContext.Texts on vd.ServicesDescriptionKey equals t.Key
                              where t.LanguageId == vd.LanguageId
                              select new TeamServicesDto { Id = vd.Id, TeamDescription = vd.TeamDescription, ServicesDescription = t.TextContent, LanguageId = vd.LanguageId }).ToListAsync();

            return await viewResult;

        }
    }
}
