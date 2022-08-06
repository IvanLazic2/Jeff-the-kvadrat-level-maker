using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public interface IGameObject
    {
        int X { get; set; }
        int Y { get; set; }
        GameObjectType Type { get; set; }
        int Size { get; set; }
        int Height { get; set; }
        bool Continuous { get; set; }
    }
}
