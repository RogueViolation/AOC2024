namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("input.txt");
            Console.WriteLine(parser.DoStuff());
            Console.WriteLine(parser.DoStuff2());
        }
    }
}
