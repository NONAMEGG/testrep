using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Collections;

namespace LlistProject
{
    internal class Program
    {

        public class Node<T>
        {
            public T data;
            public Node<T> next;
            public Node(T value) 
            {
                data = value;
                next = default;
            }

            public Node(T data, Node<T> next) : this(data)
            {
                this.next = next;
            }
        }

        public class SLList<T> : IEnumerable<T>
        {
            public Node<T> root;
            public Node<T> sentinel;
            public Node<T> service = new Node<T>(default);
            int size = 0;

            public int Count { get { return size; } }

            public SLList()
            {
                root = new Node<T>(default);
                sentinel = new Node<T>(default);
                service.next = null;
                sentinel.next = service;
                root.next = service;
            }

            public T this[int index] {
                get
                {
                    var element = root;
                    int count = 0;

                    for (int i = 0; i < size; i++)
                    {
                        if (index == count)
                        {
                            return element.data;
                        }
                        element = element.next;
                        count++;
                        
                    } 
                    throw new Exception("Index was out of range");
                }
                set 
                {
                    int count = 0;
                    var element = root;
                    for (int i = 0; i < size; i++)
                    {
                        if (count == index)
                        {
                            element.data = value;
                            break;
                        }
                        count++;
                        element = element.next;
                    }
                } }

            public bool Empty()
            {
                return size == 0;
            }

            public void Clear()
            {
                var element = root;
                Node<T> temp = null;

                root = new Node<T>(default);
                root.next = service;
                while (element.next != sentinel.next)
                {
                    temp = element.next;
                    element = null;
                    element = temp;
                }
                size = 0;
            }

            public T First()
            {
                return root.data;
            }

            public T Last()
            {
                var element = root;
                for (int i = 0; i < size-1; i++)
                {
                    element = element.next;
                    element = element;
                }

                return element.data;
            }

            public void PushBack(T value)
            {
                size++;
                if (size == 1)
                {
                    root = new Node<T>(value);
                    root.next = service;
                    return;
                }

                var element = root;
                while(element.next != sentinel.next)
                {
                    element = element.next;
                }
                element.next = new Node<T>(value, service);
            }

            public void PushFront(T value)
            {
                root = new Node<T>(value, root);
                size++;
            }

            public void Insert(int index, T value)
            {
                if (index == size)
                {
                    PushBack(value);
                    return;
                }
                
                if (index == 0)
                {
                    PushFront(value);
                    return;
                }

                int count = 0;
                var element = root;
                Node<T> prevel;
                while (element.next != default)
                {
                    count++;
                    prevel = element;
                    element = element.next;
                    if (count == index)
                    {
                        Node<T> temp = new Node<T>(value, element.next);
                        prevel.next = temp; 
                        break;
                    }
                }
            }

            public void PopBack()
            {
                if (size == 0)
                {
                    throw new Exception("Empty List Exception");
                }
                size--;

                var element = root;
                while (element.next != sentinel.next)
                {
                    element = element.next;
                }
                element = service;
                element.next = default;
            }

            public void PopFront()
            {
                if (size == 0)
                {
                    throw new Exception("Empty List Exception");
                }
                var temp = root;
                root = null;
                root = temp.next;
                temp = null;
                size--;
            }

            public void RemoveAt(int index)
            {
                if (size == 0)
                {
                    throw new Exception("Empty List Exception");
                }
                
                if (index == 0)
                {
                    PopFront();
                    return;
                }

                size--;
                int count = 0;
                var element = root;
                Node<T> prevel;
                Node<T> curel;
                while (element.next != sentinel.next)
                {
                    count++;
                    prevel = element;
                    curel = element.next;
                    element = curel;
                    if (count == index)
                    {
                        prevel.next = curel.next;
                        curel = null;
                        break;
                    }
                    
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IEnumerator<T> GetEnumerator()
            {
                var element = root;
                for (int i = 0; i < size; i++)
                {
                    yield return element.data;
                    element = element.next;
                }
                    
            }
        }

        


        static void Main(string[] args)
        {
            void print_lst(SLList<char> l)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    Console.Write(l[i] + " -> ");
                }
                Console.WriteLine();
            }

            var lst = new SLList<char>(); // ваш список
            Console.WriteLine(lst.Count + " " + lst.Empty());

           for (int i = 0; i < 5; i++)
                lst.PushBack((char)(i + 97));
            print_lst(lst);

            for (int i = 0; i < 5; i++)
                lst.Insert(0, (char)(122 - i));
            print_lst(lst);

            for (int i = 0; i < lst.Count; i++)
                lst[i] = (char)(i + 97); // методы доступа set
            print_lst(lst);

            lst.PopBack();
            lst.PopFront();

            print_lst(lst);

             lst.RemoveAt(5);
             lst.Insert(3, 'o');

            print_lst(lst);

            lst.Clear();

            lst.PushBack('q');
            lst.PushFront('a');
            lst.PushBack('w');

            print_lst(lst);

            Console.WriteLine(lst.First() + " " + lst.Last());
            Console.WriteLine(lst.Count + " " + lst.Empty());

            foreach(var el in lst)
            {
                Console.WriteLine(el);
            }
        }
    }
}
