using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using Utilities;
using BussinessLogicLayer;
namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            Login login = new Login();
            AibestdbContext context = new AibestdbContext();

            List<User> users = UserRepository.GetAllUsers();
            
            string username = Console.ReadLine();
            
            string password = Console.ReadLine();

            login.LoginMethod(username, password);
        }
    }
}