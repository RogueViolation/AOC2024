using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Parser
    {
        private readonly string _path;
        public Parser(string path) { _path = path; }

        public int DoStuff()
        {
            return SafetyPathCount(ParseFile());
        }

        public int DoStuff2()
        {
            return SafetyPathCount2(ParseFile());
        }

        private List<ItemObject> ParseFile()
        {
            var itms = new List<ItemObject>();
            using (StreamReader file = new StreamReader(File.OpenRead(_path)))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    var numbers = ln.Split(" ");
                    var diff = numbers.Zip(numbers.Skip(1), (x, y) => Int32.Parse(y) - Int32.Parse(x));
                    itms.Add(new ItemObject { Items = diff.ToList(), Raw = numbers.Select(x => Int32.Parse(x)) });
                }
            }
            return itms;
        }

        private int SafetyPathCount(List<ItemObject> items)
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item.Items.All(x => x > 0 && x < 4)) count++;
                if (item.Items.All(x => x > -4 && x < 0)) count++;
            }
            return count;
        }

        private int SafetyPathCount2(List<ItemObject> items)
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item.Items.All(x => x > 0 && x < 4)) count++;
                else if (item.Items.All(x => x > -4 && x < 0)) count++;
                else
                {
                    for (int i = 0; i < item.Raw.Count(); i++)
                    {
                        var itms = item.Raw.ToList();
                        itms.RemoveAt(i);
                        var diff = itms.Zip(itms.Skip(1), (x, y) => y - x);
                        if (diff.All(x => x > 0 && x < 4))
                        {
                            count++;
                            break;
                        }
                        if (diff.All(x => x > -4 && x < 0))
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            return count;
        }

        private class ItemObject
        {
            public IEnumerable<int> Items { get; set; }
            public IEnumerable<int> Raw { get; set; }
        }
    }
}
