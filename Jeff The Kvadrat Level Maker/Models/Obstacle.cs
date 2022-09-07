using System;
using System.Collections.Generic;
using System.Drawing;
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
        LargeSpikes,
        SpikedArea,
        Unknown
    }

    public class Obstacle : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ObstacleType Type { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }

        GameObjectType IGameObject.Type { get; set; }
        public bool Continuous { get; set; }

        public Obstacle(int x, int y, ObstacleType type, int size)
        {
            X = x;
            Y = y;
            Type = type;
            Size = size;

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
                case ObstacleType.SpikedArea:
                    Height = 0;
                    break;
                default:
                    break;
            }

            Continuous = true;
        }

        public static List<Obstacle> GetAllObstaclesFromImage(Bitmap finishedImage)
        {
            List<Obstacle> obstacles = new List<Obstacle>();

            foreach (var type in Enum.GetValues(typeof(ObstacleType)))
            {
                if ((ObstacleType)type != ObstacleType.Unknown)
                {
                    var result = GetObstacleFromImage(finishedImage, (ObstacleType)type);
                    obstacles.AddRange(result);
                }
                
            }

            return obstacles;
        }

        public static List<Obstacle> GetObstacleFromImage(Bitmap finishedImage, ObstacleType type)
        {
            List<Obstacle> gameObjects = new List<Obstacle>();

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

                    if (GetObstacleTypeByColor(c) == type)
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
                        gameObjects.Add(new Obstacle(objectXCoord / 16, j, type, objectSize));

                    if (!objectStart)
                        objectSize = 0;
                }
            }

            return gameObjects;
        }


        public static ObstacleType GetObstacleTypeByColor(Color c)
        {
            ObstacleType result = ObstacleType.Unknown;

            if (c.R == 255 && c.G == 255 && c.B == 0) // yellow
                result = ObstacleType.SmallSpikes;
            else if (c.R == 255 && c.G == 165 && c.B == 0) // orange
                result = ObstacleType.MediumSpikes;
            else if (c.R == 210 && c.G == 105 && c.B == 30) // chocolate
                result = ObstacleType.WeirdSpikes;
            else if (c.R == 139 && c.G == 69 && c.B == 19) // saddle brown
                result = ObstacleType.LargeSpikes;
            else if (c.R == 210 && c.G == 180 && c.B == 140) // tan
                result = ObstacleType.SpikedArea;

            return result;
        }

        public static Pen GetPenByType(ObstacleType type)
        {
            Pen pen = Pens.White;

            switch (type)
            {
                case ObstacleType.SmallSpikes:
                    pen = Pens.Yellow;
                    break;
                case ObstacleType.MediumSpikes:
                    pen = Pens.Orange;
                    break;
                case ObstacleType.WeirdSpikes:
                    pen = Pens.Chocolate;
                    break;
                case ObstacleType.LargeSpikes:
                    pen = Pens.SaddleBrown;
                    break;
                case ObstacleType.SpikedArea:
                    pen = Pens.Tan;
                    break;
                case ObstacleType.Unknown:
                    pen = Pens.White;
                    break;
                default:
                    break;
            }

            return pen;
        }

        public static Brush GetBrushByType(ObstacleType type)
        {
            Brush brush = Brushes.White;

            switch (type)
            {
                case ObstacleType.SmallSpikes:
                    brush = Brushes.Yellow;
                    break;
                case ObstacleType.MediumSpikes:
                    brush = Brushes.Orange;
                    break;
                case ObstacleType.WeirdSpikes:
                    brush = Brushes.Chocolate;
                    break;
                case ObstacleType.LargeSpikes:
                    brush = Brushes.SaddleBrown;
                    break;
                case ObstacleType.SpikedArea:
                    brush = Brushes.Tan;
                    break;
                case ObstacleType.Unknown:
                    brush = Brushes.White;
                    break;
                default:
                    break;
            }

            return brush;
        }
    }
}
