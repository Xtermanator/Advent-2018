#define PARTTWO

using System;
using System.IO;

namespace Inventory_Management_System
{
    class Program
    {
        static int Similarities(string s1, string s2, out string sOut)
        {
            string output = string.Empty;
            int count = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    output += s1[i];
                }
                else
                {
                    count++;
                }
            }

            if (count == 1)
            {
                sOut = output;
            }
            else
            {
                sOut = null;
            }

            return count;
        }

        static void Main(string[] args)
        {
            string input = "Input.txt";
            StreamReader reader = new StreamReader(input);

#if PARTONE && !PARTTWO
            string line = null;
            int twoCount, threeCount;
            twoCount = threeCount = 0;
            while ((line = reader.ReadLine()) != null)
            {
                bool two, three;
                two = three = false;
                Dictionary<char, int> charCounts = new Dictionary<char, int>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (!charCounts.ContainsKey(line[i]))
                    {
                        charCounts.Add(line[i], 0);
                    }
                    charCounts[line[i]] += 1;
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
#endif
#if PARTTWO && !PARTONE
            string[] lines = reader.ReadToEnd().Split('\n');
            string correctBox = null;

            for (int i = 0; i < lines.Length; i++)
            {
                if (correctBox != null)
                {
                    break;
                }
                for (int j = 0; j < lines.Length; j++)
                {
                    if (i == 0)
                    {
                        lines[j] = lines[j].Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                    }
                    if (Similarities(lines[i], lines[j], out correctBox) == 1)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("The correct box with the similarity removed is: {0}", correctBox);
#endif
            Console.ReadKey();
        }
    }
}
