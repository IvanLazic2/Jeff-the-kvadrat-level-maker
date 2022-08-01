using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public class Platform1
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }

        public Platform1(int x, int y, int size)
        {
            X = x;
            Y = y;
            Size = size;
        }
    }
}
