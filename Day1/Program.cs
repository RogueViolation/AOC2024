namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("input.txt");
            var input = parser.GetSortedInput();
            var diff = new List<int>();
            foreach (var item in input) {
                diff.Add(Math.Abs(item.first - item.second));
            }
            Console.WriteLine(diff.Sum());

            diff.Clear();
            var items = parser.GetParsedItems();
            foreach (var item in items)
            {
                diff.Add(
                    items.Count(x => item.first == x.second) * item.first
                    );
            }

            Console.WriteLine(diff.Sum());
        }
    }
}
