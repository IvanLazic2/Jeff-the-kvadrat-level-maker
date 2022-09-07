using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public enum EnemyType
    {
        Spider,
        EvilJeffMelee,
        EvilJeffRanged,
        Bat,
        Shooter,
        Unknown
    }


    public class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        //public int Width { get; set; }
        //public int Height { get; set; }
        public EnemyType Type { get; set; }


        public Enemy(int x, int y, EnemyType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public static EnemyType GetOEnemyTypeByColor(Color c)
        {
            EnemyType result = EnemyType.Unknown;

            if (c.R == 255 && c.G == 0 && c.B == 0) // red
                result = EnemyType.Spider;
            else if (c.R == 205 && c.G == 92 && c.B == 92) // indian red
                result = EnemyType.EvilJeffMelee;
            else if (c.R == 128 && c.G == 0 && c.B == 0) // maroon
                result = EnemyType.EvilJeffRanged;
            else if (c.R == 250 && c.G == 128 && c.B == 114) // salmon
                result = EnemyType.Bat;
            else if (c.R == 139 && c.G == 0 && c.B == 0) // dark red
                result = EnemyType.Shooter;


            return result;
        }

        public static Pen GetPenByType(EnemyType type)
        {
            Pen pen = Pens.White;

            switch (type)
            {
                case EnemyType.Spider:
                    pen = Pens.Red;
                    break;
                case EnemyType.EvilJeffMelee:
                    pen = Pens.IndianRed;
                    break;
                case EnemyType.EvilJeffRanged:
                    pen = Pens.Maroon;
                    break;
                case EnemyType.Bat:
                    pen = Pens.Salmon;
                    break;
                case EnemyType.Shooter:
                    pen = Pens.DarkRed;
                    break;
                case EnemyType.Unknown:
                    pen = Pens.White;
                    break;
                default:
                    break;
            }

            return pen;
        }

        public static Brush GetBrushByType(EnemyType type)
        {
            Brush brush = Brushes.White;

            switch (type)
            {
                case EnemyType.Spider:
                    brush = Brushes.Red;
                    break;
                case EnemyType.EvilJeffMelee:
                    brush = Brushes.IndianRed;
                    break;
                case EnemyType.EvilJeffRanged:
                    brush = Brushes.Maroon;
                    break;
                case EnemyType.Bat:
                    brush = Brushes.Salmon;
                    break;
                case EnemyType.Shooter:
                    brush = Brushes.DarkRed;
                    break;
                case EnemyType.Unknown:
                    brush = Brushes.White;
                    break;
                default:
                    break;
            }

            return brush;
        }
    }
}
