using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class MyList<T> : IEnumerable<T>
    {
        T[] array;
        int DefaultCapacity = 4;
        int size = 0;
        public int Count { get { return size; } private set { } }

        public MyList() 
        {
            array = new T[DefaultCapacity];
        }

        public void Add(T element)
        {
            if (array.Length == size)
            {
                T[] newArray = new T[array.Length * 2];
                Array.Copy(array, newArray, size);
                array = newArray;
            }
            array[size] = element;
            size++;
        }

        public void Insert(int index, T element)
        {
            if (array.Length == size || array.Length < index)
            {
                T[] newArray = new T[array.Length * 2];
                Array.Copy(array, newArray, size);
                array = newArray;
            }

            if (index < size)
            {
                Array.Copy(array, index, array, index + 1, size - index);
            }
            array[index] = element;
            size++;
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match == null)
            {
                throw new Exception("give me predicate");
            }

            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (match(array[i])) return i;
            }
            return -1;
        }

        public T? Find(Predicate<T> match)
        {
            if (match == null)
            {
                throw new Exception("give me predicate");
            }

            for (int i = 0; i < size; i++)
            {
                if (match(array[i]))
                {
                    return array[i];
                }
            }
            return default;
        }

        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new Exception("give me function");
            }

            for (int i = 0; i < size; i++) action(array[i]);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < size; i++)
                yield return array[i];
        }


    }
}
