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
            AibestdbContext context = new AibestdbContext();

            List<User> users = UserRepository.GetAllUsers();

            foreach(var user in users) 
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}