using DataAccessLayer.Data;
using DataAccessLayer.Models;
using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WorkExperienceRepository
    {
        public static void CreateWorkexperience(Workexperience workexperience) 
        {
            using AibestdbContext context = new();

            context.Add(workexperience);
            context.SaveChanges();
        }

        public static Workexperience GetWorkexperienceById(int id) 
        {
            using AibestdbContext context = new();
            return context.Workexperiences.Where(x => x.Id == id).First();
        }

        public static List<Workexperience> GetAllWorkexperiences() 
        {
            using AibestdbContext context = new();

            return context.Workexperiences.ToList();
        }

        public static void UpdateWorkexperience(Workexperience workexperience) 
        {
            using AibestdbContext context = new AibestdbContext();

            Workexperience wp = context
                .Workexperiences
                .Where(x => x.Id == workexperience.Id)
                .First();
            wp = workexperience;

            context.Update(wp);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Workexperience workexperience) 
        {
            using AibestdbContext context = new AibestdbContext();

            context.Workexperiences.Remove(workexperience);
            context.SaveChanges();
        }
    }
}
