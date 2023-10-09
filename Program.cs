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
            public Node<T> head;
            public Node<T> CurElement;
            int size = 0;
            public int Count { get { return size; } }

            public T this[int index] {
                get
                {
                    var element = head;
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
                    if (index == size - 1)
                    {
                        
                        return;
                    }

                    int count = 0;
                    var element = head;
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
                if(head != null)
                {
                    return false;
                }
                return true;
            }

            public void Clear()
            {
                var element = head;
                Node<T> temp = null;

                head = null;
                while (element.next != default)
                {
                    temp = element.next;
                    element = null;
                    element = temp;
                }
                size = 0;
                CurElement = default;
            }

            public T First()
            {
                return head.data;
            }

            public T Last()
            {
                var element = head;
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
                if (CurElement == default)
                {
                    head = new Node<T>(value);
                    CurElement = head;
                    CurElement.next = new Node<T>(default);
                    return;
                }

                CurElement.next = new Node<T>(value);
                CurElement = CurElement.next;
                CurElement.next = new Node<T>(default);
            }

            public void PushFront(T value)
            {
                head = new Node<T>(value, head);
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
                var element = head;
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

                CurElement.next = null;
                CurElement = new Node<T>(default);
                var element = head;
                while(element.next != default)
                {
                    CurElement = element;
                    element = element.next;
                }
            }

            public void PopFront()
            {
                if (size == 0)
                {
                    throw new Exception("Empty List Exception");
                }
                var temp = head;
                head = null;
                head = temp.next;
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
                var element = head;
                Node<T> prevel;
                Node<T> curel;
                while (element.next != default)
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
                for (int i = 0; i < size; i++)
                    yield return this[i];
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
                // вывод списка на экран с помощью l[i], метод доступа get 
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
            /*            *//* SLList<int> llist = new SLList<int>();*//*
                         llist.PushBack(1);
                         llist.PushBack(2);
                         llist.PushBack(3);
                         llist.Insert(3, 52);
                         llist.PushFront(34);*/



            /*             var cur = llist.head;
                         for(int i = 0; i < llist.Count; i++)
                         {
                             Console.Write(cur.data + " -> ");
                             if (cur.next == default)
                             {
                                 break;
                             }
                             cur = cur.next;
                         }
             */
            /*            for (int i = 0; i < 4; i++)
                        {
                            Console.Write(cur.data + " -> ");
                            if (cur.next == null)
                            {
                                break;
                            }
                            cur = cur.next;
                        }*/

            /*llist.head = new Node(1);
            Node n1 = new Node(2);
            Node n2 = new Node(3);

            llist.head.next = n1;
            n2.next = null;

            Node curr = llist.head;
            for(int i = 0; i < 10; i++)
            {
                Console.Write(curr.data + " -> ");
                if (curr.next == null)
                {
                    break;
                }
                curr = curr.next;
            }
            Console.WriteLine();*/

        }
    }
}