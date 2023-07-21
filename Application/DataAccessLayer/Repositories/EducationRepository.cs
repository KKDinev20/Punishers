using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EducationRepository
    {
        public static void CreateEducation(Education education)
        {
            using AibestdbContext context = new();

            context.Add(education);
            context.SaveChanges();
        }

        public static Education GetEducationById(int id)
        {
            using AibestdbContext context = new();
            return context.Educations.Where(x => x.Id == id).First();
        }

        public static List<Education> GetAllEducations()
        {
            using AibestdbContext context = new();

            return context.Educations.ToList();
        }

        public static void UpdateEducation(Education education)
        {
            using AibestdbContext context = new AibestdbContext();

            Education ed = context
                .Educations
                .Where(x => x.Id == education.Id)
                .First();
            ed = education;

            context.Update(ed);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Education education)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Educations.Remove(education);
            context.SaveChanges();
        }
    }
}
