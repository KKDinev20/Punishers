using System;
using System.Data.SqlClient;
using DataAccessLayer.Repositories;
using System.Security.Policy;
using DataAccessLayer.Models;
using MySql.Data.MySqlClient;
using BCryptNet = BCrypt.Net.BCrypt;

namespace BussinessLogicLayer
{
	public class Login
	{

		public void LoginMethod(string loginUsername = "", string loginPassword = "")
		{
            
                string connectionString =
                    "server=localhost;port=3306;UID=AIBESTUser;PWD=DevPass;DATABASE=AIBESTDB;persistsecurityinfo=True";

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();


                

                string query = "SELECT password FROM users WHERE @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@username", loginUsername);
            bool isMatch = BCryptNet.Verify(loginPassword, );

            int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    Console.WriteLine("Access granted!");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }

            connection.Close();
            }
        }
	}