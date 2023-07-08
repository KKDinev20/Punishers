using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using Utilities;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Template> templates = TemplateRepository.GetAllTemplates();

            foreach (var template in templates) 
            {
                Console.WriteLine(template.TemplateName);
            }
        }
    }
}