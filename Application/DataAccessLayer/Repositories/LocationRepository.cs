using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class LocationRepository
    {
        public static void CreateLocation(Location location)
        {
            using AibestdbContext context = new();

            context.Add(location);
            context.SaveChanges();
        }

        public static Location GetLocationById(int id)
        {
            using AibestdbContext context = new();
            return context.Locations.Where(x => x.Id == id).First();
        }

        public static List<Location> GetAllLocations()
        {
            using AibestdbContext context = new();

            return context.Locations.ToList();
        }

        public static void UpdateLocation(Location location)
        {
            using AibestdbContext context = new AibestdbContext();

            Location l = context
                .Locations
                .Where(x => x.Id == location.Id)
                .First();
            l = location;

            context.Update(l);
            context.SaveChanges();
        }

        public static void DeleteWorkeperience(Location location)
        {
            using AibestdbContext context = new AibestdbContext();

            context.Locations.Remove(location);
            context.SaveChanges();
        }
    }
}
