using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CertificateRepository
    {
        public static void CreateCertificate(Certificate certificate)
        {
            using AibestdbContext context = new();

            context.Add(certificate);
            context.SaveChanges();
        }

        public static Certificate GetCertificateById(int id)
        {
            using AibestdbContext context = new();
            return context.Certificates.Where(x => x.Id == id).First();
        }

        public static List<Certificate> GetAllCertificates()
        {
            using AibestdbContext context = new();

            return context.Certificates.ToList();
        }

        public static void UpdateCertificate(Certificate certificate)
        {
            using AibestdbContext context = new AibestdbContext();

            Certificate c = context
                .Certificates
                .Where(x => x.Id == certificate.Id)
                .First();
            c = certificate;

            context.Update(c);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Certificate certificate)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Certificates.Remove(certificate);
            context.SaveChanges();
        }
    }
}
