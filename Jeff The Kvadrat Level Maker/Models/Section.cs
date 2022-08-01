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
        public int X { get; set; }
        public int Size { get; set; }
        public int FirstPlatformX { get; set; }
        public int LastPlatformX { get; set; }
    }
}
