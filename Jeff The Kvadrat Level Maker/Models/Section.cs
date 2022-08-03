using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public class Section
    {
        public List<Platform1> Platforms1 { get; set; }
        public int LeftBorder { get; set; }
        public int RightBorder { get; set; }
        public int PlatformsNum { get; set; }

        public Section()
        {
            Platforms1 = new List<Platform1>();
        }
    }
}
