using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Parser
    {
        private readonly string _path;
        public Parser(string path) { _path = path; }
        public List<Item> GetSortedInput()
        {
            return ParsedItems(SortInput(ParseInput()));
        }

        public List<Item> GetParsedItems() { return ParsedItems(ParseInput()); }
        private List<Item> ParsedItems(ItemObject obj) { return obj.Items1.Zip(obj.Items2, (x, y) => new Item { first = x, second = y }).ToList(); }
        private ItemObject SortInput(ItemObject obj)
        {
            obj.Items1.Sort(); obj.Items2.Sort();
            return obj;
        }

        private ItemObject ParseInput()
        {
            List<Item> items = new List<Item>();
            List<int> items1 = new List<int>();
            List<int> items2 = new List<int>();
            using (StreamReader file = new StreamReader(File.OpenRead(_path)))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    var split = ln.Split("   ");
                    items1.Add(Int32.Parse(split[0]));
                    items2.Add(Int32.Parse(split[1]));
                }
            }
            return new ItemObject { Items1 = items1, Items2 = items2 };
        }
    }

    public class Item
    {
        public int first { get; set;}
        public int second { get; set;}
    }

    internal class ItemObject
    {
        public List<int> Items1 { get; set;}
        public List<int> Items2 { get; set; }
    }
}
