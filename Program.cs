using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Runtime.Serialization;
using System.Reflection.Metadata.Ecma335;

namespace LlistProject
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
                prev = default;
                next = default;
            }

            public Node(T value, Node<T> Previous, Node<T> Next = default)
            {
                data = value;
                prev = Previous;
                next = Next;
            }

            public Node(T data, Node<T> next) : this(data)
            {
                this.next = next;
            }
        }

        public class DLList<T> : IEnumerable<T>
        {
            public Node<T> root;
            public Node<T> tail;
            int size = 0;

            public int Count { get { return size; } }

            public void Add(T value)
            {
                size++;

                if (size == 1)
                {
                    tail = new Node<T>(default);
                    root = new Node<T>(value, tail);
                    tail.prev = root;
                    return;
                }
                else if (size == 2)
                {
                    tail.data = value;
                    return;
                }

                var temp = tail;
                tail = new Node<T>(value, temp, default);
                temp.next = tail;

            }

            public void Insert(T value, int index)
            {
                size++;
                if (index == 0)
                {
                    var temp = root;
                    root = new Node<T>(value, temp);
                    return;
                }
                else if (index > size)
                {
                    throw new StackOverflowException();
                }

                if (index <= (size) / 2)
                {
                    int count = 0;
                    var element = root;
                    while (count != index)
                    {
                        element = element.next;
                        count++;
                    }
                    Node<T> temp = new Node<T>(value, element.prev, element);
                    element.prev.next = temp;
                    element.prev = temp;

                }
                else
                {
                    int count = size - 1;
                    var element = tail;
                    while (count != index)
                    {
                        count--;
                        element = element.prev;
                    }
                    Node<T> temp = new Node<T>(value, element, element.next);
                    element.next = temp;
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

            public T this[int index]
            {
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
                }
            }

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
                for (int i = 0; i < size - 1; i++)
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
                while (element.next != sentinel.next)
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
                if (index == -1)
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
                        Node<T> temp = new Node<T>(value, element);
                        prevel.next = temp;
                        break;
                    }
                }
                size++;
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
            System.Diagnostics.Stopwatch watch;

            SLList<int> sl = new SLList<int>();
            DLList<int> dl = new DLList<int>();

            Random rnd = new Random(1);

            long elapsedMs;
            int n = 20000;

            int[] A = new int[n];
            for (int i = 0, count = n; i < n; i++, count++)
                A[i] = rnd.Next(0, count);

            for (int i = 0; i < n; i++)
            {
                dl.Add(i);
                sl.PushBack(i);
            }

            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                dl.Insert(-1, A[i]);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time for duoble linked list: " + elapsedMs);

            watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                sl.Insert(A[i], -1);
            }
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time for linked list: " + elapsedMs);
        }
    }
}
