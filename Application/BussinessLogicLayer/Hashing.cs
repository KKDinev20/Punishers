using System;
using System.Security.Cryptography;
using System.Text;

namespace BussinessLogicLayer
{
    using BC = BCrypt.Net.BCrypt;
    public static class Hashing
    {
        public static string HashPassowrd(string unhashedPassword)
        {
            return BC.HashPassword(unhashedPassword);
        }

        public static bool ValidatePassword(string unhashedPassword, string passwordHash)
        {
            return BC.Verify(unhashedPassword, passwordHash);
        }
    }
}

