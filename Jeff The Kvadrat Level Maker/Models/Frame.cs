using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public class Frame
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public Bitmap Image { get; set; }
        public Sprite Sprite { get; set; }
        public Sprite SpriteMirrored { get; set; }

        public Frame(int width, int height, string name, Bitmap image, Sprite sprite, Sprite spriteMirrored)
        {
            Width = width;
            Height = height;
            Name = name;
            Image = image;
            Sprite = sprite;
            SpriteMirrored = spriteMirrored;
        }
    }
}
