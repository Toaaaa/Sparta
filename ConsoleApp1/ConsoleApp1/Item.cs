using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    struct Item
    {
        public Item(string? name, int value)
        {
            Name = name;
            Value = value;
        }

        public string? Name { get; set; }
        public int Value { get; set; }
    }
}
