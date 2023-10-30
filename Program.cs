namespace ConsoleApp4
{
    using System.Collections;
    using System.Linq.Expressions;

    internal class Program
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node(int value)
            {
                data = value;
                left = null;
                right = null;
            }
        }

        public class BinaryTree
        {
            public Node root;
            int size = 0;

            public int Count { get { return size; } }

            public void Add(int value)
            {
                if (root == null)
                {
                    root = new Node(value);
                    return;
                }
                if (root.left == null || root.right == null)
                {
                    if (root.data > value)
                    {
                        root.left = new Node(value);
                        return;

                    }
                    else if (root.data < value)
                    {
                        root.right = new Node(value);
                        return;
                    }
                }

                var element = root;
                var prevel = new Node(0);
                while (element != null)
                {
                    prevel = element;
                    if (element.data == value)
                    {
                        return;
                    }
                    else if (element.data > value)
                    {
                        element = element.left;

                    }
                    else
                    {
                        element = element.right;
                    }

                }

                element = new Node(value);

                if (prevel.data > value)
                {
                    prevel.left = element;
                }else
                {
                    prevel.right = element;
                }


            }

            public int MinValueIterative()
            {
                var element = root.left;
                while (element.left != null)
                {
                    element = element.left;
                }
                return element.data;
            }

            public int MinValueRecursive()
            {
                var element = root;

                return MinValue(element).left.data;
            }

            private Node MinValue(Node element)
            {
                if (element.left != null)
                {
                    element = element.left;
                    MinValue(element);
                }
                return element;

            }

        }

        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            bt.Add(5);
            bt.Add(3);
            bt.Add(7);
            bt.Add(9);
            bt.Add(1);
            bt.Add(2);
            bt.Add(6);

            Console.WriteLine(bt.MinValueIterative());
            Console.WriteLine(bt.MinValueRecursive());


        }
    }
}
