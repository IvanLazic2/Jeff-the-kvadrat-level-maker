using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public class Section
    {
        public List<Platform> Platforms { get; set; }
        public List<Obstacle> Obstacles { get; set; }
        public int LeftBorder { get; set; }
        public int RightBorder { get; set; }

        public Section()
        {
            Platforms = new List<Platform>();
            Obstacles = new List<Obstacle>();
        }
    }
}
