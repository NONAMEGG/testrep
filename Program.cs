using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictList = new List<KeyValuePair<string, int>>();

            using (StreamReader sr = new StreamReader("C:\\Users\\student\\Desktop\\engwiki_ascii.txt"))
            {
                string line;
                List<string> words = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> strings = line.Split(' ').ToList<string>();

                    foreach (string s1 in strings)
                    {
                        string s = s1.Split(',')[0];
                        s = s.Split('.')[0];
                        s = s.Split('!')[0];
                        s = s.Split('?')[0];

                        if (!words.Contains(s))
                        {
                            int ind = ~words.BinarySearch(s);

                            var tempList = new List<string>();
                            tempList.AddRange(words.GetRange(0, ind));
                            tempList.Add(s);
                            tempList.AddRange(words.GetRange(ind, words.Count - ind));
                            words = tempList;


                            dictList.Insert(ind, new KeyValuePair<string, int>(s, 1));
                        }
                        else
                        {
                            int ind = words.BinarySearch(s);
                            dictList[ind] = new KeyValuePair<string, int>(dictList[ind].Key, dictList[ind].Value + 1);
                        }
                    }
                }
            }
            using (StreamReader sr = new StreamReader("C:\\Users\\student\\Desktop\\check.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (var s in dictList)
                    {
                        if (line == s.Key)
                        {
                            Console.WriteLine(s.Key + " : " + s.Value);
                        }
                    }
                }
            }
        }
    }
}
