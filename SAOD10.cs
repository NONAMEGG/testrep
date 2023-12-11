using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace HashTable
{
    internal class Program
    {

        public class AVLNode
        {
            public string Word;
            public int Count;
            public int Height;
            public AVLNode Left;
            public AVLNode Right;

            public AVLNode(string word)
            {
                Word = word;
                Count = 1;
                Height = 1;
            }
        }

        public class AVLTree
        {
            private AVLNode _root;

            private int GetHeight(AVLNode node)
            {
                if (node == null)
                    return 0;
                return node.Height;
            }

            private int GetBalance(AVLNode node)
            {
                if (node == null)
                    return 0;
                return GetHeight(node.Left) - GetHeight(node.Right);
            }

            private AVLNode RightRotate(AVLNode y)
            {
                AVLNode x = y.Left;
                AVLNode T2 = x.Right;

                x.Right = y;
                y.Left = T2;

                y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
                x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

                return x;
            }

            private AVLNode LeftRotate(AVLNode x)
            {
                AVLNode y = x.Right;
                AVLNode T2 = y.Left;

                y.Left = x;
                x.Right = T2;

                x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
                y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

                return y;
            }

            public AVLNode Insert(AVLNode node, string word)
            {
                if (node == null)
                    return new AVLNode(word);

                if (string.Compare(word, node.Word, StringComparison.Ordinal) < 0)
                    node.Left = Insert(node.Left, word);
                else if (string.Compare(word, node.Word, StringComparison.Ordinal) > 0)
                    node.Right = Insert(node.Right, word);
                else
                    node.Count++;

                node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

                int balance = GetBalance(node);

                if (balance > 1 && string.Compare(word, node.Left.Word, StringComparison.Ordinal) < 0)
                    return RightRotate(node);

                if (balance < -1 && string.Compare(word, node.Right.Word, StringComparison.Ordinal) > 0)
                    return LeftRotate(node);

                if (balance > 1 && string.Compare(word, node.Left.Word, StringComparison.Ordinal) > 0)
                {
                    node.Left = LeftRotate(node.Left);
                    return RightRotate(node);
                }

                if (balance < -1 && string.Compare(word, node.Right.Word, StringComparison.Ordinal) < 0)
                {
                    node.Right = RightRotate(node.Right);
                    return LeftRotate(node);
                }

                return node;
            }

            public void Insert(string word)
            {
                _root = Insert(_root, word);
            }

            public void InOrderTraversal(AVLNode node)
            {
                if (node != null)
                {
                    InOrderTraversal(node.Left);
                    Console.WriteLine($"{node.Word}: {node.Count}");
                    InOrderTraversal(node.Right);
                }
            }

            public void PrintWordCounts()
            {
                InOrderTraversal(_root);
            }
        }

     

        public class TrieNode
        {
            public char key;
            public SortedDictionary<int, TrieNode> children;
            public bool flag;
            public TrieNode(char Key)
            {
                key = Key;
                children = new SortedDictionary<int, TrieNode>();
            }
        }

/*        public class TrieNode
        {
            public char Value { get; set; }
            public bool IsEndOfWord { get; set; }
            public Dictionary<char, TrieNode> Children { get; set; }

            public TrieNode(char value)
            {
                Value = value;
                IsEndOfWord = false;
                Children = new Dictionary<char, TrieNode>();
            }
        }*/

        public class Trie
        {
            public TrieNode root;

            int Count;

            public Trie()
            {
                root = new TrieNode(' ');
                Count = 0;
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

                        curr.children.Add(Count, new TrieNode(ch));
                        curr = curr.children.Last().Value;
                    }
                    Count++;
                    curr.flag = true;
                }
            }


            public bool Search(string word)
            {
                TrieNode currentNode = root;
                foreach (char c in word)
                {
                    if (!currentNode.children.ContainsKey(c))
                    {
                        return false;
                    }
                    currentNode = currentNode.children[c];
                }
                return currentNode.flag;
            }

        }

        public class HashTable
        {
            private Trie trie;
            private Dictionary<string, string> values;

            public HashTable()
            {
                trie = new Trie();
                values = new Dictionary<string, string> ();
            }

            public void Add(string value)
            {
                string hash = CalculateMD5Hash(value.ToString());
                string hashedKey = $"{hash}";
                Console.WriteLine(hashedKey);
                trie.Insert(hashedKey);
                values[hashedKey] = value;
            }

            public bool Contains(string key)
            {
                string hash = CalculateMD5Hash(key);
                string hashedKey = $"{hash}";
                return trie.Search(hashedKey);
            }

            public object GetValue(string key)
            {
                string hash = CalculateMD5Hash(key);
                string hashedKey = $"{hash}";
                string temp;
                values.TryGetValue(hashedKey, out temp);
                return temp;
            }

            public static string CalculateMD5Hash(string input)
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        builder.Append(hashBytes[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }

            public void PrintStats()
            {
                List<double> allValues = new List<double>();
                foreach (KeyValuePair<string, string> entry in values)
                {

                    allValues.Add(double.Parse(entry.Value, System.Globalization.NumberStyles.Any));
                }

                allValues.Sort();
                int n = allValues.Count;

                double min = allValues[0]*1.5;
                double max = allValues[n - 1] * 1.5;

                int lqIndex = (int)(n * 0.25);
                int medianIndex = (int)(n * 0.5);
                int uqIndex = (int)(n * 0.75);

                double mean = allValues.Sum() / n;

                double sumSquaredDeviations = 0;
                foreach (int value in allValues)
                {
                    double deviation = value - mean;
                    sumSquaredDeviations += deviation * deviation;
                }
                double stddev = Math.Sqrt(sumSquaredDeviations / n);

                Console.WriteLine($"min: {min}. Коэффициент 1.5.");
                Console.WriteLine($"lq: {allValues[lqIndex]}");
                Console.WriteLine($"median: {(n % 2 == 0 ? (allValues[medianIndex] + allValues[medianIndex - 1]) / 2.0 : allValues[medianIndex])}");
                Console.WriteLine($"mean: {mean}");
                Console.WriteLine($"stddev: {stddev}");
                Console.WriteLine($"uq: {allValues[uqIndex]}");
                Console.WriteLine($"max: {max}. Коэффициент 1.5.");

                List<double> outliers = new List<double>();
                for (int i = 0; i < lqIndex; i++)
                {
                    if (allValues[i] < min * 1.5 || allValues[i] > max * 1.5)
                    {
                        outliers.Add(allValues[i]);
                    }
                }


                for (int i = n-1; i >= uqIndex; i--)
                {
                    if (allValues[i] < min * 1.5 || allValues[i] > max * 1.5)
                    {
                        outliers.Add(allValues[i]);
                    }
                }

                Console.WriteLine($"out: {string.Join(", ", outliers)}");
                Console.WriteLine($"amin: {(int)(min/1.5)}");
                Console.WriteLine($"amax: {(int)(max/1.5)}");
            }
        }

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch watch;
            long elapsedMs;
            HashTable hashTable = new HashTable();
            AVLTree aVLTree = new AVLTree();
            Trie trie = new Trie();
            List<string> values = new List<string>();

            using (StreamReader sr = new StreamReader("C:\\Users\\student\\Desktop\\eee.txt"))
            {
                string line = sr.ReadLine();
                while(line != null)
                {
                    values.Add(line);
                    line = sr.ReadLine();
                }
            }
            watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (string line in values)
            {
                hashTable.Add(line);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time for #: " + elapsedMs);
            watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (string line in values)
            {
                aVLTree.Insert(line);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time for AVL: " + elapsedMs);
            watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (string line in values)
            {
                trie.Insert(line);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time for Trie: " + elapsedMs);
            Console.WriteLine();
            hashTable.PrintStats();
            Console.ReadLine();
        }
    }
}
