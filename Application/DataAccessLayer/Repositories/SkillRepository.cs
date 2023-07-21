using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SkillRepository
    {
        public static void CreateSkill(Skill skill)
        {
            using AibestdbContext context = new();

            context.Add(skill);
            context.SaveChanges();
        }

        public static Skill GetSkillById(int id)
        {
            using AibestdbContext context = new();
            return context.Skills.Where(x => x.Id == id).First();
        }

        public static List<Skill> GetAllSkills()
        {
            using AibestdbContext context = new();

            return context.Skills.ToList();
        }

        public static void UpdateSkill(Skill skill)
        {
            using AibestdbContext context = new AibestdbContext();

            Skill s = context
                .Skills
                .Where(x => x.Id == skill.Id)
                .First();
            s = skill;

            context.Update(s);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Skill skill)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Skills.Remove(skill);
            context.SaveChanges();
        }
    }
}
