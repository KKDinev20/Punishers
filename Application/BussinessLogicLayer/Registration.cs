using System;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BussinessLogicLayer
{
	public class Registration
	{
		public static void UserCreation(int id = 0, string username = "",
			string email = "",string password = "")
		{
			
				string hashedPassword = Hashing.EncryptPassword(password);

				User user = new User(id, username, email, hashedPassword);

				UserRepository.CreateUser(user);
			
        }
	}
}

