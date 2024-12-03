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
        private readonly string _path;
        public CorruptParser(string path) { _path = path; }

        public List<int> DoParse()
        {
            return RegexInput(ReadFile(), "(mul\\()\\d+,\\d+(\\))");
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

        private List<int> RegexInput(string input, string pattern)
        {
            var list = new List<int>();
            var regex = Regex.Matches(input, pattern);
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
