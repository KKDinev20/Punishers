using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TemplateRepository
    {
        public static void CreateTemplate(Template template)
        {
            using AibestdbContext context = new();

            context.Add(template);
            context.SaveChanges();
        }

        public static Template GetTemplateById(int id)
        {
            using AibestdbContext context = new();
            return context.Templates.Where(x => x.Id == id).First();
        }

        public static List<Template> GetAllTemplates()
        {
            using AibestdbContext context = new();

            return context.Templates.ToList();
        }

        public static void UpdateTemplate(Template template)
        {
            using AibestdbContext context = new AibestdbContext();

            Template t = context
                .Templates
                .Where(x => x.Id == template.Id)
                .First();
            t = template;

            context.Update(t);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Template template)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Templates.Remove(template);
            context.SaveChanges();
        }
    }
}
