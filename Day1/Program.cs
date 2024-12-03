namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = [3,4,2,1,3,3]; int[] arr2 = [4,3,5,3,9,3];
            arr1 = [.. arr1.OrderDescending()];
            arr2 = [.. arr2.OrderDescending()];
            var parser = new Parser("input.txt");
            var input = parser.ParseInput();
            var diff = new List<int>();
            foreach (var item in input) {
                diff.Add(Math.Abs(item.first - item.second));
            }
            Console.WriteLine(diff.Sum());
        }
    }
}
