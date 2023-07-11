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
            Console.WriteLine(Hashing.hashPassowrd("pass1234"));
        }
    }
}