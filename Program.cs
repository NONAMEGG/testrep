namespace FindeEntries
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var dictList = new List<KeyValuePair<string, int>>();

            using (StreamReader sr = new StreamReader("C:\\Users\\TNV.22\\source\\repos\\FindeEntries\\FindeEntries\\txt.txt"))
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
                        int ind = words.BinarySearch(s);
                        if (ind < 0)
                        {
                            ind = ~ind;
/*                            var tempList = new List<string>();
                            tempList.AddRange(words.GetRange(0, ind));
                            tempList.Add(s);
                            tempList.AddRange(words.GetRange(ind, words.Count - ind));
                            words = tempList;*/
                            words.Insert(ind, s);

                            dictList.Insert(ind, new KeyValuePair<string, int>(s, 1));
                        }
                        else
                        {
                            dictList[ind] = new KeyValuePair<string, int>(dictList[ind].Key, dictList[ind].Value + 1);
                        }
                    }
                }
            }
            using (StreamReader sr = new StreamReader("C:\\Users\\TNV.22\\source\\repos\\FindeEntries\\FindeEntries\\check.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (var s in dictList)
                    {
                        if (line == s.Key)
                        {
                            Console.WriteLine(s.Key + ": " + s.Value);
                        }
                    }
                }
            }
        }
    }
}
