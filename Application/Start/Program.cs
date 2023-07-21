using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using BussinessLogicLayer;
using System.Net.Mail;
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
            Attachment attachment = new("/Users/alexandraivanova/Desktop/Punishers/ApplicationemailCredentials.env");
            MailSender.SendMail("PSStefanov19@codingburgas.bg", attachment);
        }
    }
}