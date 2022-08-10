using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public class Sprite
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public SpritePart[,] Array { get; set; }

        public Sprite(int width, int height)
        {
            Width = width;
            Height = height;

            Array = new SpritePart[height, width];
        }
    }
}
