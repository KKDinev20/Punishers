using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using BussinessLogicLayer;
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

            int id = 0;
            string username = Console.ReadLine();
            string email = Console.ReadLine();
            string password = Console.ReadLine();
            password = Hashing.ToSHA256(password);

            Console.WriteLine(password);
            //User user = new User(id, username, email, password);

           // Register.RegisterUser(id, username, email, password);
            //users.Add(user);

            //foreach (var item in users) 
            //{
            //    Console.WriteLine($"{item.Username}, {item.Id}, {item.Password}");
            //}
        }
    }
}