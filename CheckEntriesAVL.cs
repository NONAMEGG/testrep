namespace CheckEntriesAVL
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

    public class CheckEntriesAVL
    {
        public static void Main(string[] args)
        {
            List<string> words = new List<string>();
            string input;
            using (StreamReader sr = new StreamReader("C:\\Users\\TNV.22\\source\\repos\\CheckEntriesAVL\\CheckEntriesAVL\\engwiki_ascii.txt"))
            {
                while ((input = sr.ReadLine()) != null)
                {
                    List<string> strings = input.Split(new char[] { ' ', ',', '.', '!', '?' }).ToList<string>();
                    foreach (var w in strings)
                    {
                        words.Add(w);
                    }
                }
            }
            
            AVLTree avlTree = new AVLTree();

            foreach (var word in words)
            {
                avlTree.Insert(word.ToLower());
            }

            avlTree.PrintWordCounts();
        }
    }
}
