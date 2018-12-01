using System;
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

            while ((line = reader.ReadLine()) != null)
            {
                int delta = 0;
                if (Int32.TryParse(line, out delta))
                {
                    frequency += delta;
                }
            }

            Console.WriteLine("End frequency: {0}", frequency);
            Console.ReadKey();
        }
    }
}
