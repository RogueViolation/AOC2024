using Day1;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ints = new List<int>();
            var parser = new Parser("input.txt");
            var items = parser.GetParsedItems();
            foreach (var item in items)
            {
                ints.Add(
                    items.Count(x => item.first == x.second) * item.first
                    );
            }

            Console.WriteLine(ints.Sum());
        }
    }
}
