using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PersonalInfoRepository
    {
        public static void CreatePersonalinfo(Personalinfo personalInfo)
        {
            using AibestdbContext context = new();

            context.Add(personalInfo);
            context.SaveChanges();
        }

        public static Personalinfo GetPersonalinfoById(int id)
        {
            using AibestdbContext context = new();
            return context.Personalinfos.Where(x => x.Id == id).First();
        }

        public static List<Personalinfo> GetAllPersonalinfos()
        {
            using AibestdbContext context = new();

            return context.Personalinfos.ToList();
        }

        public static void UpdatePersonalinfo(Personalinfo personalInfo)
        {
            using AibestdbContext context = new AibestdbContext();

            Personalinfo wp = context
                .Personalinfos
                .Where(x => x.Id == personalInfo.Id)
                .First();
            wp = personalInfo;

            context.Update(wp);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Personalinfo personalInfo)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Personalinfos.Remove(personalInfo);
            context.SaveChanges();
        }
    }
}
