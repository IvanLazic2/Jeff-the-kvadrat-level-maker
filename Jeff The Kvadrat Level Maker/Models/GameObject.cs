using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    /*public enum GameObjectType
    {
        Background,
        SimpleGroundPlatform,
        SimplePlatform,
        Player,
        SmallSpikes,
        MediumSpikes,
        WeirdSpikes,
        LargeSpikes,
        SpikedArea,
        Unknown
    }*/

    public enum GameObjectType
    {
        Background,
        Platform,
        Character,
        Enemy,
        Obstacle,
        Unknown
    }

    public class GameObject : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GameObjectType Type { get; set; }
        public int Size { get; set; }
        public int Height { get; set; }
        public bool Continuous { get; set; }
        

        public GameObject(int x, int y, GameObjectType type, int size = 0, int height = 0)
        {
            X = x;
            Y = y;
            Type = type;
            Size = size;
            Height = height;
        }

        public GameObject()
        {
        }

        public static Type GetTypeOfObjectType(GameObjectType type)
        {
            Type result = null;

            if (type == GameObjectType.Platform)
                result =  typeof(PlatformType);
            else if (type == GameObjectType.Obstacle)
                result =  typeof(ObstacleType);

            return result;
        }

        /*public static IGameObject CreateGameObject(int x, int y, GameObjectType type, int size = 0, int height = 0)
        {
            IGameObject result = new GameObject();

            if (type == GameObjectType.SimpleGroundPlatform ||
                type == GameObjectType.SimplePlatform)

                result = new Platform(x, y, size, Platform.GetPlatformType(type));

            else if (type == GameObjectType.SmallSpikes ||
                     type == GameObjectType.MediumSpikes ||
                     type == GameObjectType.WeirdSpikes ||
                     type == GameObjectType.LargeSpikes ||
                     type == GameObjectType.SpikedArea)

                result = new Obstacle(x, y, Obstacle.GetObstacleType(type), size);

            return result;
        }*/

        public static GameObjectType GetGameObjectType(Color c)
        {
            GameObjectType result = GameObjectType.Unknown;

            if (c.R == 255 && c.G == 255 && c.B == 255) // white
                result = GameObjectType.Background;

            else if (c.R == 0 && c.G == 0 && c.B == 255) // blue
                result = GameObjectType.Character;

            else if (Platform.GetPlatformTypeByColor(c) != PlatformType.Unknown)
                result = GameObjectType.Platform;

            else if (Obstacle.GetObstacleTypeByColor(c) != ObstacleType.Unknown)
                result = GameObjectType.Obstacle;

            return result;
        }
    }
}
