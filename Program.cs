namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> symbList = new MyStack<int>();
            Console.Write("Введите количество строк матрицы: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество столбцов матрицы: ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.Write("Каким символом будет производиться заливка: ");
            char symb = Convert.ToChar(Console.ReadLine());

            Console.Write("Введите число n, (от 1 до 9) для заполнения матрицы символом + с вероятностью n / 10: ");
            int k = Convert.ToInt32(Console.ReadLine());

            char[,] data = generate(n, m, k);


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write("Введите координату заливки(x): ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите координату заливки(y): ");
            int y = Convert.ToInt32(Console.ReadLine());


            betterFill(symbList, x, y, n, m, data, symb);
            //fill(x, y, symb, n, m, data);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(data[i, j]);
                }
                Console.WriteLine();
            }

        }

        static char[,] generate(int n, int m, int k)
        {
            Random rnd = new Random();
            char[,] data = new char[n, m];
            int temp = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    temp = rnd.Next(k, 11);
                    if (temp <= k)
                    {
                        data[i, j] = '+';
                    }
                    else
                    {
                        data[i, j] = ' ';
                    }
                }
            }
            return data;
        }

        static void betterFill(MyStack<int> symbList, int x, int y, int n, int m, char[,] data, char symb)
        {
            symbList.Push(x);
            symbList.Push(y);
            while (symbList.Count > 0)
            {
               

                y = symbList.Pop(); x = symbList.Pop();
                if (x >= 0 && y >= 0 && x < n && y < m && data[x, y] == ' ')
                {
                    data[x, y] = symb;
                    if (x > 0)
                    {
                        symbList.Push(x - 1);
                        symbList.Push(y);
                    }
                    if (x < n - 1)
                    {
                        symbList.Push(x + 1);
                        symbList.Push(y);
                    }
                    if (y > 0)
                    {
                        symbList.Push(x);
                        symbList.Push(y - 1);
                    }
                    if (y < m - 1)
                    {
                        symbList.Push(x);
                        symbList.Push(y + 1);
                    }
                }
            }
        }
        static void fill(int x, int y, char symb, int n, int m, char[,] data)
        {
            if (x >= 0 && y >= 0 && x < n && y < m && data[x, y] == ' ')
            {
                data[x, y] = symb;
                fill(x - 1, y, symb, n, m, data);
                fill(x, y - 1, symb, n, m, data);
                fill(x, y + 1, symb, n, m, data);
                fill(x + 1, y, symb, n, m, data);
            }
        }
    }
}
