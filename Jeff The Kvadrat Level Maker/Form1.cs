using Jeff_The_Kvadrat_Level_Maker.Extensions;
using Jeff_The_Kvadrat_Level_Maker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeff_The_Kvadrat_Level_Maker
{
    public partial class Form1 : Form
    {
        int levelWidth;
        int levelHeight;
        int gameScreenWidth;
        int sectionWidth;

        string directory;

        Bitmap bmp;
        Pen pen;
        Pen gridPen = Pens.Gray;
        Brush brush;
        Rectangle drawingRectangle;

        bool isMouseDown;

        Character Character;
        Finish Finish;
        List<Section> Sections;

        List<Platform> Platforms;
        List<Obstacle> Obstacles;
        List<Enemy> Enemies;
        List<Collectable> Collectables;
        List<SpawnPoint> SpawnPoints;

        int[,] Matrix;

        Form2 Form2;


        public Form1()
        {
            levelWidth = 128; // 32
            levelHeight = 16; // 16
            gameScreenWidth = 32;
            sectionWidth = 4;

            InitializeComponent();

            pictureBox1.Width = levelWidth * 16 + 1;
            pictureBox1.Height = levelHeight * 16 + 1;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

            pen = new Pen(Color.Black, 0);
            brush = Brushes.Black;

            drawingRectangle = new Rectangle();

            clear();
            makeGrid();

            Character = new Character(0, 0);
            //Platforms = new List<Platform>();
            Sections = new List<Section>();
            //Obstacles = new List<Obstacle>();
            Enemies = new List<Enemy>();
            Collectables = new List<Collectable>();
            SpawnPoints = new List<SpawnPoint>();

            Form2 = new Form2(this);

            directory = @"D:\User\Fakse\Moderni racunalni sustavi\Projekt\Jeff the kvadrat";

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = directory;
            openFileDialog1.Filter = "level files (Level*.jack) | Level*.jack";
        }

        private void clear()
        {
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                Rectangle rec = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

                g.FillRectangle(Brushes.White, rec);
                g.DrawRectangle(Pens.White, rec);
            }

            pictureBox1.Invalidate();
        }

        private void makeGrid()
        {
            int numOfCells = pictureBox1.Width * pictureBox1.Height / 16;
            int cellSize = 16;

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                for (int i = 0; i < numOfCells; i++)
                {
                    // Vertical
                    g.DrawLine(gridPen, i * cellSize, 0, i * cellSize, numOfCells * cellSize);
                    // Horizontal
                    g.DrawLine(gridPen, 0, i * cellSize, numOfCells * cellSize, i * cellSize);
                }
            }
        }

        private void draw(MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
            }

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                drawingRectangle.X = 16 * (e.Location.X / 16) + 1;
                drawingRectangle.Y = 16 * (e.Location.Y / 16) + 1;
                drawingRectangle.Width = 15 - 1;
                drawingRectangle.Height = 15 - 1;

                if (e.Button == MouseButtons.Left)
                {
                    g.FillRectangle(brush, drawingRectangle);
                    g.DrawRectangle(pen, drawingRectangle);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    g.FillRectangle(Brushes.White, drawingRectangle);
                    g.DrawRectangle(Pens.White, drawingRectangle);
                }
            }

        }

        private void draw(int x, int y, Pen pen, Brush brush)
        {
            if (pictureBox1.Image == null)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
            }

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                drawingRectangle.X = 16 * (x) + 1;
                drawingRectangle.Y = 16 * (y / 16) + 1;
                drawingRectangle.Width = 15 - 1;
                drawingRectangle.Height = 15 - 1;

                g.FillRectangle(brush, drawingRectangle);
                g.DrawRectangle(pen, drawingRectangle);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;

            draw(e);

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                draw(e);

                pictureBox1.Invalidate();
            }
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        // clear
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)

            {
                //pictureBox1.Image = null;

                clear();

                makeGrid();

                Invalidate();
            }
        }

        private void Platform1_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Black;
            pen = Pens.Black;
        }

        private void SimplePlatformPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.DimGray;
            pen = Pens.DimGray;
        }

        private void Character_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Blue;
            pen = Pens.Blue;
        }

        private void SmallSpikesPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Yellow;
            pen = Pens.Yellow;
        }

        private void MediumSpikesPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Orange;
            pen = Pens.Orange;
        }

        private void WeirdSpikesPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Chocolate;
            pen = Pens.Chocolate;
        }

        private void LargeSpikesPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.SaddleBrown;
            pen = Pens.SaddleBrown;
        }

        private void SpikedAreaPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Tan;
            pen = Pens.Tan;
        }

        private void StonePlatformPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.DarkGray;
            pen = Pens.DarkGray;
        }

        private void Brick1PlatformPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.LightGray;
            pen = Pens.LightGray;
        }

        private void Brick2PlatformPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.RosyBrown;
            pen = Pens.RosyBrown;
        }

        private void RoboticPlatformPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.SlateGray;
            pen = Pens.SlateGray;
        }

        private void StonePlatformSmallPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.DarkOliveGreen;
            pen = Pens.DarkOliveGreen;
        }

        private void BrickPlatform1SmallPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.MediumAquamarine;
            pen = Pens.MediumAquamarine;
        }

        private void BrickPlatform2SmallPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Brown;
            pen = Pens.Brown;
        }

        private void RoboticPanelSmall_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.DarkSlateGray;
            pen = Pens.DarkSlateGray;
        }

        private void Spider_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Red;
            pen = Pens.Red;
        }

        private void EvilJeffMeleePanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.IndianRed;
            pen = Pens.IndianRed;
        }

        private void EvilJeffRangedPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Maroon;
            pen = Pens.Maroon;
        }

        private void BatPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Salmon;
            pen = Pens.Salmon;
        }

        private void CoinPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Gold;
            pen = Pens.Gold;
        }

        private void LifePanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.DeepPink;
            pen = Pens.DeepPink;
        }

        private void AmmoPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Purple;
            pen = Pens.Purple;
        }

        private void FinishPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Green;
            pen = Pens.Green;
        }

        private void ShooterPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.DarkRed;
            pen = Pens.DarkRed;
        }

        private void SpawnPointPanel_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Cyan;
            pen = Pens.Cyan;
        }




        private void SetSingleObjectsFromImage(Bitmap finishedImage)
        {
            Enemies = new List<Enemy>();
            Collectables = new List<Collectable>();
            SpawnPoints = new List<SpawnPoint>();

            for (int j = 0; j < finishedImage.Height - 1; j += 16)
            {
                for (int i = 0; i < finishedImage.Width - 1; i += 16)
                {
                    Color c = finishedImage.GetPixel(i + 1, j + 1);

                    switch (GameObject.GetGameObjectType(c))
                    {
                        case GameObjectType.Character:
                            Character = new Character(i / 16, j);
                            break;
                        case GameObjectType.Enemy:
                            Enemies.Add(new Enemy(i / 16, j, Enemy.GetOEnemyTypeByColor(c)));
                            break;
                        case GameObjectType.Collectable:
                            Collectables.Add(new Collectable(i / 16, j, Collectable.GetCollectableTypeByColor(c)));
                            break;
                        case GameObjectType.Finish:
                            Finish = new Finish(i / 16, j / 16);
                            break;
                        case GameObjectType.SpawnPoint:
                            SpawnPoints.Add(new SpawnPoint(i / 16, j));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // done
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap finishedImage = new Bitmap(pictureBox1.Image);

            Platforms = Platform.GetAllPlatformsFromImage(finishedImage);
            Obstacles = Obstacle.GetAllObstaclesFromImage(finishedImage);

            SetSingleObjectsFromImage(finishedImage);


            generateMapMatrix();

            writeToFile();
        }

        private void generateSections()
        {
            Sections = new List<Section>();

            Platforms.Sort((p1, p2) => p1.Y.CompareTo(p2.Y)); //X
            Obstacles.Sort((o1, o2) => o2.Y.CompareTo(o2.Y));

            Section currentSection = new Section();

            int screensNum = levelWidth / sectionWidth;

            for (int k = 1; k <= screensNum; k++)
            {
                for (int i = 0; i < Platforms.Count; i++)
                {
                    if ((Platforms[i].X >= (k - 1) * sectionWidth && Platforms[i].X < k * sectionWidth) ||
                        (Platforms[i].X < k * sectionWidth && Platforms[i].X + Platforms[i].Size > (k - 1) * sectionWidth))

                        currentSection.Platforms.Add(Platforms[i]);
                }

                for (int i = 0; i < Obstacles.Count; i++)
                {
                    if ((Obstacles[i].X >= (k - 1) * sectionWidth && Obstacles[i].X < k * sectionWidth) ||
                        (Obstacles[i].X < k * sectionWidth && Obstacles[i].X + Obstacles[i].Size > (k - 1) * sectionWidth))

                        currentSection.Obstacles.Add(Obstacles[i]);
                }

                currentSection.LeftBorder = (k - 1) * sectionWidth;
                currentSection.RightBorder = k * sectionWidth;
                Sections.Add(currentSection);
                currentSection = new Section();
            }

            // borders
            for (int i = 0; i < Sections.Count; i++)
            {
                if (i != Sections.Count - 1)
                {
                    foreach (var platform in Sections[i + 1].Platforms)
                    {
                        if (platform.X == Sections[i + 1].LeftBorder || platform.X == Sections[i + 1].LeftBorder + 1)
                        {
                            Sections[i].Platforms.Add(platform);
                        }
                    }

                    Sections[i].Platforms = new HashSet<Platform>(Sections[i].Platforms).ToList();

                    foreach (var obstacle in Sections[i + 1].Obstacles)
                    {
                        if (obstacle.X == Sections[i + 1].LeftBorder || obstacle.X == Sections[i + 1].LeftBorder + 1)
                        {
                            Sections[i].Obstacles.Add(obstacle);
                        }
                    }

                    Sections[i].Obstacles = new HashSet<Obstacle>(Sections[i].Obstacles).ToList();
                }

                if (i != 0)
                {
                    foreach (var platform in Sections[i - 1].Platforms)
                    {
                        if (platform.X + platform.Size == Sections[i - 1].RightBorder || platform.X + platform.Size == Sections[i - 1].RightBorder - 1)
                        {
                            Sections[i].Platforms.Add(platform);
                        }
                    }

                    Sections[i].Platforms = new HashSet<Platform>(Sections[i].Platforms).ToList();

                    foreach (var obstacle in Sections[i - 1].Obstacles)
                    {
                        if (obstacle.X + obstacle.Size == Sections[i - 1].RightBorder || obstacle.X + obstacle.Size == Sections[i - 1].RightBorder - 1)
                        {
                            Sections[i].Obstacles.Add(obstacle);
                        }
                    }

                    Sections[i].Obstacles = new HashSet<Obstacle>(Sections[i].Obstacles).ToList();
                }
            }


        }

        private void generateMapMatrix()
        {
            Matrix = new int[levelWidth, levelHeight];

            int numOfPlatformTypes = 10;
            foreach (var platform in Platforms)
            {
                if (platform.Type != PlatformType.Unknown)
                {
                    for (int i = 0; i < platform.Size; i++)
                    {
                        Matrix[platform.X + i, (int)(platform.Y / 16)] = (int)platform.Type + 1;
                    }
                }
            }

            int numOfObstacleTypes = 5;
            foreach (var obstacle in Obstacles)
            {
                if (obstacle.Type != ObstacleType.Unknown)
                {
                    for (int i = 0; i < obstacle.Size; i++)
                    {
                        for (int j = 0; j < (int)((obstacle.Height + 16) / 16); j++)
                        {
                            Matrix[obstacle.X + i, (int)(obstacle.Y / 16) - j] = numOfPlatformTypes + (int)obstacle.Type + 1;
                        }
                    }
                }

            }

            int numOfCollectableTypes = 3;
            foreach (var collectable in Collectables)
            {
                if (collectable.Type != CollectableType.Unknown)
                {
                    Matrix[collectable.X, (int)(collectable.Y / 16)] = numOfPlatformTypes + numOfObstacleTypes + (int)collectable.Type + 1;
                }
            }
        }



        private void writeToFile()
        {
            string levelName = fileNameTextBox.Text;
            string folder = directory;
            string fileName = levelName + ".jack";
            string fullPath = folder + "\\" + fileName;

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                if (Finish == null)
                    Finish = new Finish(levelWidth - 1, 14);

                writer.WriteLine($"class {levelName}");
                writer.WriteLine("{");
                writer.WriteLine("\tfield Character character;");
                writer.WriteLine("\tfield Finish finish;");

                writer.WriteLine("\tfield int PlatformsCount;");
                writer.WriteLine("\tfield int ObstaclesCount;");
                writer.WriteLine("\tfield int EnemiesCount;");
                writer.WriteLine("\tfield int CollectablesCount;");
                writer.WriteLine("\tfield int SpawnPointsCount;");

                writer.WriteLine($"\tfield Array Platforms;");
                writer.WriteLine($"\tfield Array Obstacles;");
                writer.WriteLine($"\tfield Array Enemies;");
                writer.WriteLine($"\tfield Array Collectables;");
                writer.WriteLine("\tfield Array SpawnPoints;");

                writer.WriteLine($"\tfield Array Map;");

                writer.WriteLine($"\tfield int MapWidth;");
                writer.WriteLine($"\tfield int MapHeight;");

                writer.WriteLine($"\tconstructor {levelName} new()");
                writer.WriteLine("\t{");
                writer.WriteLine("\t\tvar int i;");
                writer.WriteLine($"\t\tlet character = Character.new({Character.X}, {Character.Y - 24}, false);");
                writer.WriteLine($"\t\tlet finish = Finish.new({Finish.X}, {Finish.Y * 16});");
                writer.WriteLine($"\t\tlet PlatformsCount = {Platforms.Count};");
                writer.WriteLine($"\t\tlet ObstaclesCount = {Obstacles.Count};");
                writer.WriteLine($"\t\tlet EnemiesCount = {Enemies.Count};");
                writer.WriteLine($"\t\tlet CollectablesCount = {Collectables.Count};");
                writer.WriteLine($"\t\tlet SpawnPointsCount = {SpawnPoints.Count};");

                if (Platforms.Count != 0)
                    writer.WriteLine($"\t\tlet Platforms = Array.new({Platforms.Count});");

                for (int i = 0; i < Platforms.Count; i++)
                {
                    writer.WriteLine($"\t\tdo MemoryExt.poke(Platforms, {i}, Platform.new({Platforms[i].X}, {Platforms[i].Y}, {(int)Platforms[i].Type}, {Platforms[i].Size}));");
                }


                if (Obstacles.Count != 0)
                    writer.WriteLine($"\t\tlet Obstacles = Array.new({Obstacles.Count});");

                for (int i = 0; i < Obstacles.Count; i++)
                {
                    writer.WriteLine($"\t\tdo MemoryExt.poke(Obstacles, {i}, Obstacle.new({Obstacles[i].X}, {Obstacles[i].Y}, {(int)Obstacles[i].Type}, {Obstacles[i].Height}, {Obstacles[i].Size}));");
                }

                if (Enemies.Count != 0)
                    writer.WriteLine($"\t\tlet Enemies = Array.new({Enemies.Count});");

                for (int i = 0; i < Enemies.Count; i++)
                {
                    writer.WriteLine($"\t\tdo MemoryExt.poke(Enemies, {i}, Enemy.new({Enemies[i].X}, {Enemies[i].Y}, {(int)Enemies[i].Type}));");
                }

                if (Collectables.Count != 0)
                    writer.WriteLine($"\t\tlet Collectables = Array.new({Collectables.Count});");

                for (int i = 0; i < Collectables.Count; i++)
                {
                    writer.WriteLine($"\t\tdo MemoryExt.poke(Collectables, {i}, Collectable.new({Collectables[i].X}, {Collectables[i].Y}, {(int)Collectables[i].Type}));");
                }

                if (SpawnPoints.Count != 0)
                    writer.WriteLine($"\t\tlet SpawnPoints = Array.new({SpawnPoints.Count});");

                for (int i = 0; i < SpawnPoints.Count; i++)
                {
                    writer.WriteLine($"\t\tdo MemoryExt.poke(SpawnPoints, {i}, SpawnPoint.new({SpawnPoints[i].X}, {SpawnPoints[i].Y}));");
                }

                if (SpawnPoints.Count != 0)
                {
                    writer.WriteLine($"\t\tdo character.setSpawnPointsCount(SpawnPointsCount);");
                    writer.WriteLine($"\t\tdo character.setSpawnPoints(SpawnPoints);");
                }


                writer.WriteLine($"\t\tlet MapWidth = {levelWidth};");
                writer.WriteLine($"\t\tlet MapHeight = {levelHeight};");

                writer.WriteLine($"\t\tlet Map = Array.new({levelWidth * levelHeight});");

                writer.WriteLine($"\t\twhile (i < {levelWidth * levelHeight})");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tlet Map[i] = 0;");
                writer.WriteLine("\t\t\tlet i = i + 1;");
                writer.WriteLine("\t\t}");

                var tempMatrix = Matrix.Cast<int>().ToArray();
                for (int i = 0; i < levelWidth * levelHeight; i++)
                {
                    if (tempMatrix[i] != 0)
                    {
                        writer.WriteLine($"\t\tdo MemoryExt.poke(Map, {i}, {tempMatrix[i]});");
                    }
                }

                writer.WriteLine("\t\treturn this;");
                writer.WriteLine("\t}");
                writer.WriteLine("\tmethod int getPlatformsCount() { return PlatformsCount; }");
                writer.WriteLine("\tmethod int getObstaclesCount() { return ObstaclesCount; }");
                writer.WriteLine("\tmethod int getEnemiesCount() { return EnemiesCount; }");
                writer.WriteLine("\tmethod int getCollectablesCount() { return CollectablesCount; }");
                writer.WriteLine("\tmethod Array getPlatforms() { return Platforms; }");
                writer.WriteLine("\tmethod Array getObstacles() { return Obstacles; }");
                writer.WriteLine("\tmethod Array getEnemies() { return Enemies; }");
                writer.WriteLine("\tmethod Array getCollectables() { return Collectables; }");
                writer.WriteLine("\tmethod Character getCharacter() { return character; }");
                writer.WriteLine("\tmethod int getFinish() { return finish; }");
                writer.WriteLine("\tmethod Array getMap() { return Map; }");
                writer.WriteLine("\tmethod int getMapWidth() { return MapWidth; }");
                writer.WriteLine("\tmethod int getMapHeight() { return MapHeight; }");

                writer.WriteLine("\tmethod void dispose()");
                writer.WriteLine("\t{");

                writer.WriteLine("\t\tvar int i;");
                writer.WriteLine("\t\tvar Platform platform;");
                writer.WriteLine("\t\tvar Obstacle obstacle;");
                writer.WriteLine("\t\tvar Enemy enemy;");
                writer.WriteLine("\t\tvar Collectable collectable;");
                writer.WriteLine("\t\tvar SpawnPoint spawnPoint;");

                writer.WriteLine("\t\tdo character.dispose();");
                writer.WriteLine("\t\tlet character = 0;");
                writer.WriteLine("\t\tdo finish.dispose();");
                writer.WriteLine("\t\tlet finish = 0;");

                writer.WriteLine("\t\twhile (i < PlatformsCount)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tlet platform = Platforms[i];");
                writer.WriteLine("\t\t\tdo platform.dispose();");
                writer.WriteLine("\t\t\tlet platform = 0;");
                writer.WriteLine("\t\t\tlet i = i + 1;");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet PlatformsCount = 0;");

                writer.WriteLine("\t\tlet i = 0;");
                writer.WriteLine("\t\twhile (i < ObstaclesCount)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tlet obstacle = Obstacles[i];");
                writer.WriteLine("\t\t\tdo obstacle.dispose();");
                writer.WriteLine("\t\t\tlet obstacle = 0;");
                writer.WriteLine("\t\t\tlet i = i + 1;");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet ObstaclesCount = 0;");

                writer.WriteLine("\t\tlet i = 0;");
                writer.WriteLine("\t\twhile (i < EnemiesCount)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tlet enemy = Enemies[i];");
                writer.WriteLine("\t\t\tdo enemy.dispose();");
                writer.WriteLine("\t\t\tlet enemy = 0;");
                writer.WriteLine("\t\t\tlet i = i + 1;");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet EnemiesCount = 0;");

                writer.WriteLine("\t\tlet i = 0;");
                writer.WriteLine("\t\twhile (i < CollectablesCount)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tlet collectable = Collectables[i];");
                writer.WriteLine("\t\t\tdo collectable.dispose();");
                writer.WriteLine("\t\t\tlet collectable = 0;");
                writer.WriteLine("\t\t\tlet i = i + 1;");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet CollectablesCount = 0;");

                writer.WriteLine("\t\tlet i = 0;");
                writer.WriteLine("\t\twhile (i < SpawnPointsCount)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tlet spawnPoint = SpawnPoints[i];");
                writer.WriteLine("\t\t\tdo spawnPoint.dispose();");
                writer.WriteLine("\t\t\tlet spawnPoint = 0;");
                writer.WriteLine("\t\t\tlet i = i + 1;");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet SpawnPointsCount = 0;");

                writer.WriteLine("\t\tif (PlatformsCount > 0)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tdo Platforms.dispose();");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet Platforms = 0;");

                writer.WriteLine("\t\tif (ObstaclesCount > 0)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tdo Obstacles.dispose();");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet Obstacles = 0;");

                writer.WriteLine("\t\tif (EnemiesCount > 0)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tdo Enemies.dispose();");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet Enemies = 0;");

                writer.WriteLine("\t\tif (CollectablesCount > 0)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tdo Collectables.dispose();");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet Collectables = 0;");

                writer.WriteLine("\t\tif (SpawnPointsCount > 0)");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tdo SpawnPoints.dispose();");
                writer.WriteLine("\t\t}");
                writer.WriteLine("\t\tlet SpawnPoints = 0;");

                writer.WriteLine("\t\tlet i = 0;");
                writer.WriteLine($"\t\twhile (i < {levelWidth * levelHeight})");
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tlet Map[i] = 0;");
                writer.WriteLine("\t\t\tlet i = i + 1;");
                writer.WriteLine("\t\t}");

                writer.WriteLine("\t\tdo Map.dispose();");
                writer.WriteLine("\t\tlet Map = 0;");
                writer.WriteLine("\t\tlet MapWidth = 0;");
                writer.WriteLine("\t\tlet MapHeight = 0;");

                writer.WriteLine("\t\tdo Memory.deAlloc(this);");
                writer.WriteLine("\t\treturn;");
                writer.WriteLine("\t}");



                writer.WriteLine("}");
            }
        }

        private void spriteEditorButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (Form2 == null)
                Form2 = new Form2(this);

            Form2.ShowDialog();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            openFileDialog1.ShowDialog();
            var filePath = openFileDialog1.FileName;

            if (filePath == "")
                return;

            Regex characterRx = new Regex(@"let character = Character.new\((\d+), (\d+), false\);", RegexOptions.Compiled | RegexOptions.Multiline);

            Regex finishRx = new Regex(@"let finish = Finish.new\((\d+), (\d+)\);", RegexOptions.Compiled | RegexOptions.Multiline);

            Regex platformRx = new Regex(@"do MemoryExt.poke\(Platforms, \d+, Platform.new\((\d+), (\d+), (\d+), (\d+)\)\);", RegexOptions.Compiled | RegexOptions.Multiline);

            Regex obstacleRx = new Regex(@"do MemoryExt.poke\(Obstacles, \d+, Obstacle.new\((\d+), (\d+), (\d+), (\d+), (\d+)\)\);", RegexOptions.Compiled | RegexOptions.Multiline);

            Regex enemyRx = new Regex(@"do MemoryExt.poke\(Enemies, \d+, Enemy.new\((\d+), (\d+), (\d+)\)\)", RegexOptions.Compiled | RegexOptions.Multiline);

            Regex collectableRx = new Regex(@"do MemoryExt.poke\(Collectables, \d+, Collectable.new\((\d+), (\d+), (\d+)\)\)", RegexOptions.Compiled | RegexOptions.Multiline);

            Regex spawnPointRx = new Regex(@"do MemoryExt.poke\(SpawnPoints, \d+, SpawnPoint.new\((\d+), (\d+)\)\)", RegexOptions.Compiled | RegexOptions.Multiline);

            clear();
            makeGrid();

            using (StreamReader reader = new StreamReader(filePath))
            {
                Match match = null;
                MatchCollection matches = null;
                GroupCollection groups = null;

                string text = reader.ReadToEnd();

                // CHARACTER
                match = characterRx.Match(text);
                groups = match.Groups;
                draw(int.Parse(groups[1].Value), int.Parse(groups[2].Value) + 24, Pens.Blue, Brushes.Blue);

                // FINISH
                match = finishRx.Match(text);
                groups = match.Groups;
                draw(int.Parse(groups[1].Value), int.Parse(groups[2].Value), Pens.Green, Brushes.Green);

                // PLATFORMS
                matches = platformRx.Matches(text);
                foreach (Match m in matches)
                {
                    groups = m.Groups;

                    for (int i = 0; i < int.Parse(groups[4].Value); i++)
                    {
                        draw(int.Parse(groups[1].Value) + i, 
                            int.Parse(groups[2].Value), 
                            Platform.GetPenByType((PlatformType)int.Parse(groups[3].Value)), 
                            Platform.GetBrushByType((PlatformType)int.Parse(groups[3].Value)));
                    }
                }

                // OBSTACLES
                matches = obstacleRx.Matches(text);
                foreach (Match m in matches)
                {
                    groups = m.Groups;

                    for (int i = 0; i < int.Parse(groups[5].Value); i++)
                    {
                        draw(int.Parse(groups[1].Value) + i, 
                            int.Parse(groups[2].Value), 
                            Obstacle.GetPenByType((ObstacleType)int.Parse(groups[3].Value)), 
                            Obstacle.GetBrushByType((ObstacleType)int.Parse(groups[3].Value)));
                    }
                }

                // ENEMIES
                matches = enemyRx.Matches(text);
                foreach (Match m in matches)
                {
                    groups = m.Groups;

                    draw(int.Parse(groups[1].Value), 
                        int.Parse(groups[2].Value), 
                        Enemy.GetPenByType((EnemyType)int.Parse(groups[3].Value)), 
                        Enemy.GetBrushByType((EnemyType)int.Parse(groups[3].Value)));
                }

                // COLLECTABLES
                matches = collectableRx.Matches(text);
                foreach (Match m in matches)
                {
                    groups = m.Groups;

                    draw(int.Parse(groups[1].Value), 
                        int.Parse(groups[2].Value), 
                        Collectable.GetPenByType((CollectableType)int.Parse(groups[3].Value)), 
                        Collectable.GetBrushByType((CollectableType)int.Parse(groups[3].Value)));
                }

                // SPAWN POINTS
                matches = spawnPointRx.Matches(text);
                foreach (Match m in matches)
                {
                    groups = m.Groups;

                    draw(int.Parse(groups[1].Value), int.Parse(groups[2].Value), Pens.Cyan, Brushes.Cyan);
                }
            }

            fileNameTextBox.Text = Path.GetFileNameWithoutExtension(filePath);
        }

        private void chooseFolderButton_MouseClick(object sender, MouseEventArgs e)
        {
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				directory = folderBrowserDialog1.SelectedPath;
				openFileDialog1.InitialDirectory = directory;
			}
        }
    }
}
