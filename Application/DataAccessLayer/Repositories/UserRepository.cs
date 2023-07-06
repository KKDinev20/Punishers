using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository
    {
        public static void CreateUser(User user) 
        {
            using AibestdbContext context = new AibestdbContext();

            context.Add(user);
            context.SaveChanges();
        }

        public static User GetUserById(int id) 
        {
            using AibestdbContext context = new AibestdbContext();

            return context.Users.Where(x => x.Id == id).First();
        }

        public static List<User> GetAllUsers() 
        {
            using AibestdbContext context = new AibestdbContext();

            return context.Users.ToList();
        }

        public static void UpdateUser(User user)
        {
            using AibestdbContext context = new AibestdbContext();

            User u = context.Users.Where(x => x.Id == user.Id).First();
            u = user;

            context.Update(user);
            context.SaveChanges();
        }
    }
}
