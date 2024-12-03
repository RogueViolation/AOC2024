using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    public class CorruptParser
    {
        private const string _regexString = "(mul\\()\\d+,\\d+(\\))";
        private const string _dont = "don't\\(\\)";
        private const string _do = "do\\(\\)";
        private readonly string _path;
        public CorruptParser(string path) { _path = path; }
        //dont don't\(\)
        //do do\(\)
        public List<int> DoParse()
        {
            return RegexInput(ReadFile());
        }
        public List<int> DoParse2()
        {
            return RegexInputMore(ReadFile());
        }
        private string ReadFile()
        {
            var sb = new StringBuilder();
            using (StreamReader file = new StreamReader(File.OpenRead(_path)))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    sb.Append(ln);
                }
            }
            return sb.ToString();
        }

        private List<int> RegexInputMore(string input)
        {
            var list = new List<int>();
            input = input.Insert(0, "do()");
            var doo = Regex.Split(input, _do);
            var dont = Regex.Split(doo[1], _dont);
            foreach (var regex in Regex.Split(input, _do))
            {
                list.AddRange(RegexInput(Regex.Split(regex, _dont)[0]));

            }
            return list;
        }

        private List<int> RegexInput(string input)
        {
            var list = new List<int>();
            var regex = Regex.Matches(input, _regexString);
            foreach (Match match in regex) 
            {
                list.Add(Mul(Array.ConvertAll(match.Value.Replace("mul(","").Replace(")", "").Split(","), int.Parse)));
            }
            return list;
        }

        private int Mul(int[] numbers)
        {
            return numbers[0]*numbers[1];
        }
    }
}
