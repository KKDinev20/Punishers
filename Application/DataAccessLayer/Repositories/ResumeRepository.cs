using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ResumeRepository
    {
        public static void CreateResume(Resume resume)
        {
            using AibestdbContext context = new();

            context.Add(resume);
            context.SaveChanges();
        }

        public static Resume GetResumeById(int id)
        {
            using AibestdbContext context = new();
            return context.Resumes.Where(x => x.Id == id).First();
        }

        public static List<Resume> GetAllResumes()
        {
            using AibestdbContext context = new();

            return context.Resumes.ToList();
        }

        public static void UpdateResume(Resume resume)
        {
            using AibestdbContext context = new AibestdbContext();

            Resume r = context
                .Resumes
                .Where(x => x.Id == resume.Id)
                .First();
            r = resume;

            context.Update(r);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Resume resume)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Resumes.Remove(resume);
            context.SaveChanges();
        }
    }
}
