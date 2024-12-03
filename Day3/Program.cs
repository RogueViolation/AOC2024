namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parser = new CorruptParser("input.txt");
            Console.WriteLine(parser.DoParse().Sum());
        }
    }
}
