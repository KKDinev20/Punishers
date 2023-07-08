using System;
namespace BussinessLogicLayer;
using BCryptNet = BCrypt.Net.BCrypt;

public static class Hashing
{
    public static string EncryptPassword(string password)
    {
        string salt = BCryptNet.GenerateSalt();
        string hashedPassword = BCryptNet.HashPassword(password, salt);
        return hashedPassword;
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCryptNet.Verify(password, hashedPassword);
    }
}