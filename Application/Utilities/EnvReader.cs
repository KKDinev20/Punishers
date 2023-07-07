using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class EnvReader
    {
        public static Dictionary<string, string> Read(string filePath, bool isInStartDir) 
        {
            // Checks whether function call is in Start or Debug folder and moves up certain number of times
            if (!isInStartDir)
            {
                string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

                filePath = Path.Combine(solutionDir, filePath);
                Console.WriteLine(filePath);
            }
            else 
            {
                filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, filePath);
            }
            if(!File.Exists(filePath)) 
            {
                throw new FileNotFoundException($"Environment file not found\n{filePath}");
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
