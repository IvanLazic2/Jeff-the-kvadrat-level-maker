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
    }
}
