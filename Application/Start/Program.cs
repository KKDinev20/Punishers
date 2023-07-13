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
            Resume res = new();
            res.UserId = 40;
            res.Title = "Test";
            res.CreationDate = DateTime.Now;
            res.LastModifiedDate = DateTime.Now;

            ResumeRepository.CreateResume(res);
        }
    }
}