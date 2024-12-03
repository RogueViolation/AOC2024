using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Parser
    {
        public static List<Item> ParseInput(string path)
        {
            List<Item> items = new List<Item>();
            List<int> items1 = new List<int>();
            List<int> items2 = new List<int>();
            using (StreamReader file = new StreamReader(File.OpenRead(path)))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    var split = ln.Split("   ");
                    items1.Add(Int32.Parse(split[0]));
                    items2.Add(Int32.Parse(split[1]));
                }
                items = items1.Order().Zip(items2.Order(), (x, y) => new Item { first = x, second = y }).ToList();
            }
            return items;
        }
    }

    public class Item
    {
        public int first { get; set;}
        public int second { get; set;}
    }
}
