using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class MyStack<T>
    {
        T[] array;
        int size = 0;

        const int defaultcapacity = 10;

        public int Count { get { return size; } private set { } }

        public MyStack()
        {
            array = new T[defaultcapacity];
        }


        public void Push(T o)
        {
            if (size == array.Length)
            {
                T[] newArray = new T[array.Length * 2];
                Array.Copy(array, newArray, size);
                array = newArray;
            }
            array[size] = o;
            size++;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new Exception("Cant Pop, stack is empty");   
            }
            size--;
            T o = array[size];
            return o;
        }

        public T Peek()
        {
            return array[--size];
        }
    }
}
