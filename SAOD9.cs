using System;
using System.Collections;
using System.Collections.Generic;

namespace SAOD9
{
    internal class Program
    {
        public class Node<T>
        {
            public T data;
            public Node<T> next;
            public Node<T> prev;
            public Node(T value)
            {
                data = value;
                next = null;
            }
            public Node()
            {
                next = null;
            }
            public Node(T value, bool f)
            {
                data = value;
                next = null;
                prev = null;
            }
        }
        public class LinkedArray<T> : IEnumerable<T>
        {
            public Node<T> front;
            public int Count { get; private set; }
            public T this[int index]
            {
                get
                {
                    var current = front;
                    for (int i = 0; i < index; i++)
                        current = current.next;
                    if (current.next != null) return current.data;
                    else throw new Exception("Выход за пределы листа");
                }
                set
                {
                    var current = front;
                    for (int i = 0; i < index; i++)
                        current = current.next;
                    if (current.next != null) current.data = value;
                    else throw new Exception("Выход за пределы листа");
                }
            }
            public LinkedArray()
            {
                front = new Node<T>();
            }
            public void PushBack(T value) // добавляет элемент в конец списка;
            {
                if (value == null) throw new Exception("Добавление null в конец списка");
                if (Count == default)
                {
                    front = new Node<T>(value);
                    front.next = new Node<T>();
                    Count++;
                    return;
                }
                var current = front;
                for (int i = 0; i < Count - 1; i++)
                {
                    current = current.next;
                }
                current.next = new Node<T>(value);
                current.next.next = new Node<T>();
                Count++;
            }
            public void PushFront(T value)
            {
                if (value == null) throw new Exception("Добавление null в начало списка");
                if (Count == default)
                {
                    front = new Node<T>(value);
                    front.next = new Node<T>();
                    Count++;
                    return;
                }
                var current = new Node<T>(value);
                current.next = front;
                front = current;
                current = front.next;
                Count++;
            }
            public void Insert(int index, T value)
            {

                var current = front;
                if (index > Count) throw new Exception("Insert: index больше кол-ва элементов");
                if (index < 0) throw new Exception("Insert: index не может быть отрицательным");
                if (index == 0) { PushFront(value); return; }
                if (index == Count) { PushBack(value); return; }
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                var temp = current.next;
                current.next = new Node<T>(value);
                current = current.next;
                current.next = temp;
                Count++;
            }
            public void PopBack()
            {
                var current = front;
                if (Count == 0) throw new Exception("PopBack: лист пуст");
                for (int i = 0; i < Count - 2; i++)
                {
                    current = current.next;
                }
                current.next = new Node<T>();
                Count--;
            }
            public void PopFront()
            {
                if (Count == 0) throw new Exception("PopFront: лист пуст");
                var current = front.next;
                front = current;
                Count--;
            }
            public void RemoveAt(int index)
            {
                var current = front;
                if (index == 0) { PopFront(); return; }
                if (index == Count) { PopBack(); return; }
                if (index >= Count) throw new Exception("RemoveAt: index больше кол-ва элементов");
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                current.next = current.next.next;
                Count--;
            }
            public bool Empty()
            {
                return Count <= 0;
            }
            public void Clear()
            {
                front = null;
                Count = 0;
            }
            public T First()
            {
                return front.data;
            }
            public T Last()
            {
                var current = front;
                for (int i = 0; i < Count - 1; i++)
                    current = current.next;
                return current.data;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<T> GetEnumerator()
            {
                var current = front;
                for (int i = 0; i < Count; i++)
                {
                    yield return current.data;
                    current = current.next;
                }
            }
        }

        public class TreeNode
        {
            public char key;
            public bool flag;
            public LinkedArray<TreeNode> children;
            public int entries;
            public TreeNode(char Key)
            {
                key = Key;
                children = new LinkedArray<TreeNode>();
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
                    if (children[i] != null)
                    {
                        count += children[i].LeafCount();
                    }
                }
                return count;
            }
        }

        public class Trie
        {
            public TreeNode root;
            public Trie()
            {
                root = new TreeNode(' ');
            }

            public void Insert(string word)
            {
                var curr = root;
                foreach (var ch in word)
                {
                    int index = -1;
                    for (int i = 0; i < curr.children.Count; i++)
                    {
                        if (ch == curr.children[i].key)
                        {
                            index = i; break;
                        }

                    }
                    if (index >= 0)
                    {
                        curr = curr.children[index];
                    }
                    else
                    {
                        curr.children.PushBack(new TreeNode(ch));
                        curr = curr.children.Last();
                    }
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
                        if (ch == curr.children[i].key)
                        {
                            index = i; break;
                        }
                    }

                    if (index >= 0)
                    {
                        curr = curr.children[index];
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
                            if (ch == curr.children[i].key)
                            {
                                index = i; break;
                            }
                        }

                        if (index >= 0)
                        {
                            curr = curr.children[index];
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
