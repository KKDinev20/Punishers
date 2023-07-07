using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LanguageRepository
    {
        public static void CreateLanguage(Language language)
        {
            using AibestdbContext context = new();

            context.Add(language);
            context.SaveChanges();
        }

        public static Language GetLanguageById(int id)
        {
            using AibestdbContext context = new();
            return context.Languages.Where(x => x.Id == id).First();
        }

        public static List<Language> GetAllLanguages()
        {
            using AibestdbContext context = new();

            return context.Languages.ToList();
        }

        public static void UpdateLanguage(Language language)
        {
            using AibestdbContext context = new AibestdbContext();

            Language l = context
                .Languages
                .Where(x => x.Id == language.Id)
                .First();
            l = language;

            context.Update(l);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Language language)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Languages.Remove(language);
            context.SaveChanges();
        }
    }
}
