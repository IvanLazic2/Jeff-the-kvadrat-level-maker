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
        Ammo,
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
            else if (c.R == 128 && c.G == 0 && c.B == 128) // purple
                result = CollectableType.Ammo;

            return result;
        }

        public static Pen GetPenByType(CollectableType type)
        {
            Pen pen = Pens.White;

            switch (type)
            {
                case CollectableType.Coin:
                    pen = Pens.Gold;
                    break;
                case CollectableType.Life:
                    pen = Pens.DeepPink;
                    break;
                case CollectableType.Ammo:
                    pen = Pens.Purple;
                    break;
                case CollectableType.Unknown:
                    pen = Pens.White;
                    break;
                default:
                    break;
            }

            return pen;
        }

        public static Brush GetBrushByType(CollectableType type)
        {
            Brush brush = Brushes.White;

            switch (type)
            {
                case CollectableType.Coin:
                    brush = Brushes.Gold;
                    break;
                case CollectableType.Life:
                    brush = Brushes.DeepPink;
                    break;
                case CollectableType.Ammo:
                    brush = Brushes.Purple;
                    break;
                case CollectableType.Unknown:
                    brush = Brushes.White;
                    break;
                default:
                    break;
            }

            return brush;
        }
    }
}
