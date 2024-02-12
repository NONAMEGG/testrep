namespace ConsoleApp12
{
    internal class Program
    {
        

        public class TreeNode
        {
            public char key;
            public bool flag;
            public SortedDictionary<int, TreeNode> children;
            public int entries;
            public TreeNode(char Key)
            {
                key = Key;
                children = new SortedDictionary<int, TreeNode>();
            }

            public int LeafCount()
            {
                int count = 0;
                if (flag)
                {
                    count++;
                }
                if (children.Count == 0)
                {
                    return 1;
                }

                for (int i = 0; i < 26; i++)
                {
                    if (children.ElementAt(i).Value != null)
                    {
                        count += children.ElementAt(i).Value.LeafCount();
                    }
                }
                return count;
            }
        }

        public class Trie
        {
            public TreeNode root;

            int Count;

            public Trie()
            {
                root = new TreeNode(' ');
                Count=0;
            }

            public void Insert(string word)
            {
                var curr = root;
                foreach (var ch in word)
                {
                    int index = -1;
                    for (int i = 0; i < curr.children.Count; i++)
                    {
                        if (ch == curr.children.ElementAt(i).Value.key)
                        {
                            index = i; break;
                        }

                    }
                    if (index >= 0)
                    {
                        curr = curr.children.ElementAt(index).Value;
                    }
                    else
                    {
                        
                        curr.children.Add(Count, new TreeNode(ch));
                        curr = curr.children.Last().Value;
                    }
                    Count++;
                }

                curr.flag = true;
                curr.entries++;
            }

            public bool Contains(string word)
            {
                var curr = root;
                foreach (var ch in word)
                {
                    int index = -1;
                    for (int i = 0; i < root.children.Count; i++)
                    {
                        if (ch == curr.children.ElementAt(i).Value.key)
                        {
                            index = i; break;
                        }
                    }

                    if (index >= 0)
                    {
                        curr = curr.children.ElementAt(index).Value;
                    }
                    else
                    {
                        return false;
                    }
                }

                return curr.flag;
            }



            public int LeafCount()
            {
                return root.LeafCount();
            }

            public int CountEntries(string word)
            {
                var curr = root;

                if (Contains(word))
                {
                    foreach (var ch in word)
                    {
                        int index = -1;
                        for (int i = 0; i < root.children.Count; i++)
                        {
                            if (ch == curr.children.ElementAt(i).Value.key)
                            {
                                index = i; break;
                            }
                        }

                        if (index >= 0)
                        {
                            curr = curr.children.ElementAt(index).Value;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                return curr.entries;

            }

        }


        static void Main(string[] args)
        {
            string str = "are they the most fun and these are a fun and";
            List<string> words = new List<string>();

            Trie tr = new Trie();

            foreach (var word in str.Split(' '))
            {
                words.Add(word);
                tr.Insert(word);
            }

            List<string> temp = new List<string>();
            foreach (var w in words)
            {
                if (!temp.Contains(w))
                {
                    Console.WriteLine(w + ": " + tr.CountEntries(w));
                    temp.Add(w);
                }
                else continue;

            }
            Console.ReadLine();
        }
    }

}
