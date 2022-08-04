using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public enum ObstacleType
    {
        SmallSpikes,
        MediumSpikes,
        WeirdSpikes,
        LargeSpikes
    }

    public class Obstacle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ObstacleType Type { get; set; }
        public int Height { get; set; }

        public Obstacle(int x, int y, ObstacleType type)
        {
            X = x;
            Y = y;
            Type = type;

            switch (type)
            {
                case ObstacleType.SmallSpikes:
                    Height = 0;
                    break;
                case ObstacleType.MediumSpikes:
                    Height = 16;
                    break;
                case ObstacleType.WeirdSpikes:
                    Height = 48;
                    break;
                case ObstacleType.LargeSpikes:
                    Height = 64;
                    break;
                default:
                    break;
            }
        }
    }
}
