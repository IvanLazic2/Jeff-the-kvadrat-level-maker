using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeff_The_Kvadrat_Level_Maker.Models
{
    public enum PlatformType
    {
        SimpleGroundPlatform,
        SimplePlatform,
        StonePlatform,
        Brick1Platform,
        Brick2Platform,
        RoboticPlatform,
        SmallStonePlatform,
        SmallBrick1Platform,
        SmallBrick2Platform,
        SmallRoboticPlatform,
        Unknown
    }

    public class Platform : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public PlatformType Type { get; set; }

        GameObjectType IGameObject.Type { get; set; }
        public int Height { get; set; }
        public bool Continuous { get; set; }

        public Platform(int x, int y, PlatformType platformType, int size)
        {
            X = x;
            Y = y;
            Size = size;
            Type = platformType;

            Continuous = true;
            Height = 0;
        }

        public static List<Platform> GetAllPlatformsFromImage(Bitmap finishedImage)
        {
            List<Platform> platforms = new List<Platform>();

            foreach (var type in Enum.GetValues(typeof(PlatformType)))
            {
                if ((PlatformType)type != PlatformType.Unknown)
                {
                    var result = GetPlatformFromImage(finishedImage, (PlatformType)type);
                    platforms.AddRange(result);
                }

            }

            return platforms;
        }

        public static List<Platform> GetPlatformFromImage(Bitmap finishedImage, PlatformType type)
        {
            List<Platform> gameObjects = new List<Platform>();

            bool objectStart = false;
            int objectSize = 0;
            int objectXCoord = 0;


            for (int j = 0; j < finishedImage.Height - 1; j += 16)
            {
                objectStart = false;
                objectSize = 0;

                for (int i = 0; i < finishedImage.Width - 1; i += 16)
                {
                    Color c = finishedImage.GetPixel(i + 1, j + 1);

                    if (GetPlatformTypeByColor(c) == type)
                    {

                        if (!objectStart)
                            objectXCoord = i;

                        objectStart = true;
                    }
                    else
                    {
                        if (objectStart)
                            objectStart = false;
                    }

                    if (objectStart)
                        objectSize++;

                    if ((!objectStart || i == finishedImage.Width - 16 - 1) && objectSize != 0)
                        gameObjects.Add(new Platform(objectXCoord / 16, j, type, objectSize));

                    if (!objectStart)
                        objectSize = 0;
                }
            }

            return gameObjects;
        }

        public static PlatformType GetPlatformTypeByColor(Color c)
        {
            PlatformType result = PlatformType.Unknown;

            if (c.R == 0 && c.G == 0 && c.B == 0) // black
                result = PlatformType.SimpleGroundPlatform;
            else if (c.R == 105 && c.G == 105 && c.B == 105) // dim gray
                result = PlatformType.SimplePlatform;
            else if (c.R == 169 && c.G == 169 && c.B == 169) // dark gray
                result = PlatformType.StonePlatform;
            else if (c.R == 211 && c.G == 211 && c.B == 211) // light gray
                result = PlatformType.Brick1Platform;
            else if (c.R == 188 && c.G == 143 && c.B == 143) // rosy brown
                result = PlatformType.Brick2Platform;
            else if (c.R == 112 && c.G == 128 && c.B == 144) // slate gray
                result = PlatformType.RoboticPlatform;
            else if (c.R == 85 && c.G == 107 && c.B == 47) // dark olive green
                result = PlatformType.SmallStonePlatform;
            else if (c.R == 102 && c.G == 205 && c.B == 170) // medium aquamarine
                result = PlatformType.SmallBrick1Platform;
            else if (c.R == 165 && c.G == 42 && c.B == 42) // brown
                result = PlatformType.SmallBrick2Platform;
            else if (c.R == 47 && c.G == 79 && c.B == 79) // dark slate gray
                result = PlatformType.SmallRoboticPlatform;

            return result;
        }

        public static Pen GetPenByType(PlatformType type)
        {
            Pen pen = Pens.White;

            switch (type)
            {
                case PlatformType.SimpleGroundPlatform:
                    pen = Pens.Black;
                    break;
                case PlatformType.SimplePlatform:
                    pen = Pens.DimGray;
                    break;
                case PlatformType.StonePlatform:
                    pen = Pens.DarkGray;
                    break;
                case PlatformType.Brick1Platform:
                    pen = Pens.LightGray;
                    break;
                case PlatformType.Brick2Platform:
                    pen = Pens.RosyBrown;
                    break;
                case PlatformType.RoboticPlatform:
                    pen = Pens.SlateGray;
                    break;
                case PlatformType.SmallStonePlatform:
                    pen = Pens.DarkOliveGreen;
                    break;
                case PlatformType.SmallBrick1Platform:
                    pen = Pens.MediumAquamarine;
                    break;
                case PlatformType.SmallBrick2Platform:
                    pen = Pens.Brown;
                    break;
                case PlatformType.SmallRoboticPlatform:
                    pen = Pens.DarkSlateGray;
                    break;
                case PlatformType.Unknown:
                    pen = Pens.White;
                    break;
                default:
                    break;
            }

            return pen;
        }

        public static Brush GetBrushByType(PlatformType type)
        {
            Brush brush = Brushes.White;

            switch (type)
            {
                case PlatformType.SimpleGroundPlatform:
                    brush = Brushes.Black;
                    break;
                case PlatformType.SimplePlatform:
                    brush = Brushes.DimGray;
                    break;
                case PlatformType.StonePlatform:
                    brush = Brushes.DarkGray;
                    break;
                case PlatformType.Brick1Platform:
                    brush = Brushes.LightGray;
                    break;
                case PlatformType.Brick2Platform:
                    brush = Brushes.RosyBrown;
                    break;
                case PlatformType.RoboticPlatform:
                    brush = Brushes.SlateGray;
                    break;
                case PlatformType.SmallStonePlatform:
                    brush = Brushes.DarkOliveGreen;
                    break;
                case PlatformType.SmallBrick1Platform:
                    brush = Brushes.MediumAquamarine;
                    break;
                case PlatformType.SmallBrick2Platform:
                    brush = Brushes.Brown;
                    break;
                case PlatformType.SmallRoboticPlatform:
                    brush = Brushes.DarkSlateGray;
                    break;
                case PlatformType.Unknown:
                    brush = Brushes.White;
                    break;
                default:
                    break;
            }

            return brush;
        }
    }
}
