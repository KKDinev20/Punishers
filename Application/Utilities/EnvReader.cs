using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class EnvReader
    {
        public static Dictionary<string, string> Read(string fileName) 
        {
            string solutionDir = Directory
                .GetCurrentDirectory()
                .Split(@"/Application")[0] + @"/Application/";
            string filePath = solutionDir + fileName;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Environment file not found\n{filePath}");
            }

            Dictionary<string, string> EnvValues = new();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] kvp = line.Split('=');
                    EnvValues.Add(kvp[0], kvp[1]);
                }
            }

            return EnvValues;
        }
    }
}
