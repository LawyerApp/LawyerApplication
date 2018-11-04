using System.Linq;
using LawyerApp.Models;
using System;

namespace LawyerApp.Infrastructures
{
    public static class DbContextService
    {
        public static int? GetLanguageIdByShortName(LawyerDbContext dbContext, string langShortName="en-US")
        {
            return dbContext.Languages
                                     .SingleOrDefault(m => m.LangShort == langShortName)?.Id;
        }

        public static string GenerateKey(string keyValue = "key")
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss") + keyValue;
        }
    }
}
