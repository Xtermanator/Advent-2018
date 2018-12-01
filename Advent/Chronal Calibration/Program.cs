using System;
using System.Collections.Generic;
using System.IO;

namespace Chronal_Calibration
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = "Input.txt";

            if (!File.Exists(input))
            {
                return;
            }

            int frequency = 0;
            string line = string.Empty;
            StreamReader reader = new StreamReader(input);

            int? dup = null;
            List<int> dupCheck = new List<int>();
            dupCheck.Add(frequency);

            while ((line = reader.ReadLine()) != null || dup == null)
            {
                if (line == null)
                {
                    reader.DiscardBufferedData();
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                }

                int delta = 0;
                if (Int32.TryParse(line, out delta))
                {
                    frequency += delta;
                    if (dupCheck.Contains(frequency))
                    {
                        dup = frequency;
                        break;
                    }
                    dupCheck.Add(frequency);
                }
            }

            Console.WriteLine("End frequency: {0}", frequency);
            Console.WriteLine("First duplicate frequency: {0}", dup);
            Console.ReadKey();
        }
    }
}
