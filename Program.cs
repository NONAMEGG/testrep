namespace ConsoleApp4
{
    using System.Collections;
    using System.Linq.Expressions;

    internal class Program
    {
        public class Node<T>
        {
            public T data;
            public Node<T> left;
            public Node<T> right;
            public Node(T value)
            {
                data = value;
                left = null;
                right = null;
            }
        }

        public class BinaryTree<T>
        {
            public Node<T> root;
            int size = 0;

            public int Count { get { return size; } }
            IComparer<T> comparer = Comparer<T>.Default;

            public void Add(T value)
            {
                if (root == null)
                {
                    root = new Node<T>(value);
                    return;
                }
                if (root.left == null || root.right == null)
                {
                    if (comparer.Compare(root.data, value) > 0)
                    {
                        root.left = new Node<T>(value);
                        return;

                    }
                    else if (comparer.Compare(root.data, value) < 0)
                    {
                        root.right = new Node<T>(value);
                        return;
                    }
                }

                var element = root;
                var prevel = new Node<T>(default);
                while (element != null)
                {
                    prevel = element;
                    if (comparer.Compare(element.data, value) == 0)
                    {
                        return;
                    }
                    else if (comparer.Compare(element.data, value) > 0)
                    {
                        element = element.left;

                    }
                    else
                    {
                        element = element.right;
                    }

                }

                element = new Node<T>(value);

                if (comparer.Compare(prevel.data, value) > 0)
                {
                    prevel.left = element;
                }else
                {
                    prevel.right = element;
                }


            }

            public T MinValueIterative()
            {
                var element = root.left;
                while (element.left != null)
                {
                    element = element.left;
                }
                return element.data;
            }

            public T MinValueRecursive()
            {
                var element = root;

                return MinValue(element).left.data;
            }

            private Node<T> MinValue(Node<T> element)
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
            BinaryTree<int> bt = new BinaryTree<int>();
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
