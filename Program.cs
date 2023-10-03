namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 0, 2, 2, 2, 2, 3, 4, 5, 6
            // 1, 1
            var lst = new MyList<int>();
            // var lst = new MyList<int>();
            lst.Add(1); //0 
            lst.Add(2); //1
            lst.Add(9); //2
            lst.Add(4); //3

            var index =
            lst.FindIndex(0, lst.Count - 1, a => a % 3 == 0);
            Console.WriteLine();
            Console.WriteLine(index);
            Console.WriteLine();
            lst.Insert(0, 0);

            lst.ForEach(x => Console.WriteLine(x * x));
            Console.WriteLine();
            lst.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(lst.Find(a => a % 3 == 0));
            Console.WriteLine();

            foreach (var item in lst)
                Console.WriteLine(item);
        }
    }
}
