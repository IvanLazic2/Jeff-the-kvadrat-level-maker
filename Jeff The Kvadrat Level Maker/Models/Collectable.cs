using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public enum CollectableType
    {
        Coin,
        Life,
        Unknown
    }

    public class Collectable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CollectableType Type { get; set; }

        public Collectable(int x, int y, CollectableType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public static CollectableType GetCollectableTypeByColor(Color c)
        {
            CollectableType result = CollectableType.Unknown;

            if (c.R == 255 && c.G == 215 && c.B == 0) // gold
                result = CollectableType.Coin;
            else if (c.R == 255 && c.G == 20 && c.B == 147) // deep pink
                result = CollectableType.Life;

            return result;
        }
    }
}
