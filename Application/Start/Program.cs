using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using Utilities;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            AibestdbContext context = new AibestdbContext();

            //User user = new();
            //user.Username = "test";
            //user.Email = "test";
            //user.Password = "test";

            //context.Users.Add(user);

            //context.SaveChanges();

            User retrieved = context.Users.Where(x => x.Id == 1).First();

            Console.WriteLine(retrieved.Email);
        }
    }
}