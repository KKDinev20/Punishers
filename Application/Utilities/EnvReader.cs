using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class EnvReader
    {
        public static Dictionary<string, string> Read(string filePath) 
        {
            if(!File.Exists(filePath)) 
            {
                throw new FileNotFoundException("Environment file not found");
            }

            Dictionary<string, string> EnvValues = new();

            using (StreamReader sr = new StreamReader(filePath)) 
            {
                string line;

                while((line = sr.ReadLine()) != null) 
                {
                    string[] kvp = line.Split('=');
                    EnvValues.Add(kvp[0], kvp[1]);
                }
            }

            return EnvValues;
        }
    }
}
