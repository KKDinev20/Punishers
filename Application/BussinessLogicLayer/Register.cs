using System;
using System.Data.SqlClient;
using DataAccessLayer.Repositories;
using DataAccessLayer.Models;

namespace BussinessLogicLayer
{
    public class Register
    {
        public static void RegisterUser(int id, string username, string email, string password)
        {
            Hashing.ToSHA256(password);
            User user = new User(id, username, email, password);
            UserRepository.CreateUser(user);
        }
    }
}
