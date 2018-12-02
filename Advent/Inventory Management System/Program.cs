using System;
using System.Collections.Generic;
using System.IO;

namespace Inventory_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Input.txt";
            StreamReader reader = new StreamReader(input);

            string line = null;
            int twoCount, threeCount;
            twoCount = threeCount = 0;

            while ((line = reader.ReadLine()) != null)
            {
                bool two, three;
                two = three = false;
                List<char> characters = new List<char>(line.ToCharArray());
                Dictionary<char, int> charCounts = new Dictionary<char, int>();
                for (int i = 0; i < characters.Count; i++)
                {
                    if (!charCounts.ContainsKey(characters[i]))
                    {
                        charCounts.Add(characters[i], 0);
                    }
                    charCounts[characters[i]] += 1;
                }
                foreach (var kvp in charCounts)
                {
                    switch (kvp.Value)
                    {
                        case 2:
                            if (!two)
                            {
                                twoCount++;
                            }
                            two = true;
                            break;
                        case 3:
                            if (!three)
                            {
                                threeCount++;
                            }
                            three = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine("Number of IDs with exactly two of a character: {0}", twoCount);
            Console.WriteLine("Number of IDs with exactly three of a character: {0}", threeCount);
            Console.WriteLine("Checksum of two and three character IDs: {0}", twoCount * threeCount);
            Console.ReadKey();
        }
    }
}
