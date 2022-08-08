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

        Bitmap bmp;
        Pen pen;
        Brush brush;
        Rectangle drawingRectangle;

        bool isMouseDown;

        Character Character;
        List<Section> Sections;

        List<Platform> Platforms;
        List<Obstacle> Obstacles;
        List<Enemy> Enemies;
        List<Collectable> Collectables;

        int[,] Matrix;



        public Form1()
        {
            levelWidth = 128; // 32
            levelHeight = 16; // 16
            gameScreenWidth = 32;
            sectionWidth = 4;

            InitializeComponent();

            pictureBox1.Width = levelWidth * 16;
            pictureBox1.Height = levelHeight * 16;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

            pen = new Pen(Color.Black, 0);
            brush = Brushes.Black;

            drawingRectangle = new Rectangle();

            clear();

            Character = new Character(0, 0);
            //Platforms = new List<Platform>();
            Sections = new List<Section>();
            //Obstacles = new List<Obstacle>();
            Enemies = new List<Enemy>();
            Collectables = new List<Collectable>();
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

        private void draw(MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
            }

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                drawingRectangle.X = 16 * (e.Location.X / 16);
                drawingRectangle.Y = 16 * (e.Location.Y / 16);
                drawingRectangle.Width = 15;
                drawingRectangle.Height = 15;

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




        private void SetSingleObjectsFromImage(Bitmap finishedImage)
        {
            Enemies = new List<Enemy>();
            Collectables = new List<Collectable>();

            for (int j = 0; j < finishedImage.Height; j += 16)
            {
                for (int i = 0; i < finishedImage.Width; i += 16)
                {
                    Color c = finishedImage.GetPixel(i, j);

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
                        default:
                            break;
                    }

                    /*if (GameObject.GetGameObjectType(c) == GameObjectType.Character)
                    {
                        Character = new Character(i / 16, j);
                    }*/
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

            //generateSections();
            writeToFile();
        }

        private void generateSections()
        {
            //int sectionsNum = levelWidth / Platform1s.Count / 2;
            Sections = new List<Section>();

            Platforms.Sort((p1, p2) => p1.Y.CompareTo(p2.Y)); //X
            Obstacles.Sort((o1, o2) => o2.Y.CompareTo(o2.Y));

            //List<Platform1> current = new List<Platform1>();
            Section currentSection = new Section();
            //List<Platform1> next = new List<Platform1>();

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
                //currentSection.PlatformsNum = currentSection.Platforms1.Count;
                Sections.Add(currentSection);
                currentSection = new Section();
            }

            /*foreach (var obstacle in Obstacles)
            {
                int index = obstacle.X / sectionWidth;
                Sections[index].Obstacles.Add(obstacle);
            }*/

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

                //Sections[i].PlatformsNum = Sections[i].Platforms1.Count;
            }


        }

        private void generateMapMatrix()
        {
            Matrix = new int[levelWidth, levelHeight];

            int numOfPlatformTypes = 11;
            foreach (var platform in Platforms)
            {
                for (int i = 0; i < platform.Size; i++)
                {
                    Matrix[platform.X + i, (int)(platform.Y / 16)] = (int)platform.Type + 1;
                }
            }

            foreach (var obstacle in Obstacles)
            {
                for (int i = 0; i < obstacle.Size; i++)
                {
                    for (int j = 0; j < (int)((obstacle.Height + 16) / 16); j++)
                    {
                        Matrix[obstacle.X + i, (int)(obstacle.Y / 16) - j] = numOfPlatformTypes + (int)obstacle.Type;
                    }
                }
            }

            // TODO: dodat collectables u matricu
        }



        private void writeToFile()
        {
            string levelName = fileNameTextBox.Text;
            string folder = @"D:\User\Fakse\Moderni racunalni sustavi\Projekt\Jeff the kvadrat\";
            string fileName = levelName + ".jack";
            string fullPath = folder + fileName;

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine($"class {levelName}");
                writer.WriteLine("{");
                writer.WriteLine("\tfield Character character;");

                writer.WriteLine("\tfield int PlatformsCount;");
                writer.WriteLine("\tfield int ObstaclesCount;");
                writer.WriteLine("\tfield int EnemiesCount;");
                writer.WriteLine("\tfield int CollectablesCount;");
                //writer.WriteLine("\tfield int sections_num;");

                //writer.WriteLine("\tfield int LevelWidth;");
                //writer.WriteLine("\tfield int section_width;");

                //writer.WriteLine("\tfield Array section_sizes;");

                writer.WriteLine($"\tfield Array Platforms;");
                /*for (int i = 0; i < Platforms.Count; i++)
                {
                    //writer.WriteLine($"\tfield Platform platform_{platform.X}_{platform.Y}_{(int)platform.Type}_{platform.Size};");
                    writer.WriteLine($"\tfield Platform platform{i};");
                }*/

                writer.WriteLine($"\tfield Array Obstacles;");
                /*for (int i = 0; i < Obstacles.Count; i++)
                {
                    //writer.WriteLine($"\tfield Obstacle obstacle_{obstacle.X}_{obstacle.Y}_{(int)obstacle.Type}_{obstacle.Size};");
                    writer.WriteLine($"\tfield Obstacle obstacle{i};");
                }*/

                writer.WriteLine($"\tfield Array Enemies;");
                /*for (int i = 0; i < Enemies.Count; i++)
                {
                    //writer.WriteLine($"\tfield Obstacle obstacle_{obstacle.X}_{obstacle.Y}_{(int)obstacle.Type}_{obstacle.Size};");
                    writer.WriteLine($"\tfield Enemy enemy{i};");
                }*/

                writer.WriteLine($"\tfield Array Collectables;");
                /*for (int i = 0; i < Collectables.Count; i++)
                {
                    //writer.WriteLine($"\tfield Obstacle obstacle_{obstacle.X}_{obstacle.Y}_{(int)obstacle.Type}_{obstacle.Size};");
                    writer.WriteLine($"\tfield Collectable collectable{i};");
                }*/

                /*writer.WriteLine($"\tfield Array sections;");
                for (int i = 0; i < Sections.Count; i++)
                {
                    writer.WriteLine($"\tfield Section section{i};");
                }
                // PROVJERIT JEL PLATFORM COUNT > 0
                for (int i = 0; i < Sections.Count; i++)
                {
                    writer.WriteLine($"\tfield Array section{i}platforms;");
                }
                // PROVJERIT JEL OBSTACLE COUNT > 0
                for (int i = 0; i < Sections.Count; i++)
                {
                    writer.WriteLine($"\tfield Array section{i}obstacles;");
                }*/

                writer.WriteLine($"\tfield Array Map;");
                for (int i = 0; i < levelWidth; i++)
                {
                    writer.WriteLine($"\tfield Array map{i};");
                }
                writer.WriteLine($"\tfield int MapWidth;");
                writer.WriteLine($"\tfield int MapHeight;");

                writer.WriteLine($"\tconstructor {levelName} new()");
                writer.WriteLine("\t{");
                writer.WriteLine($"\t\tlet character = Character.new({Character.X}, {Character.Y - 24});");
                writer.WriteLine($"\t\tlet PlatformsCount = {Platforms.Count};");
                writer.WriteLine($"\t\tlet ObstaclesCount = {Obstacles.Count};");
                writer.WriteLine($"\t\tlet EnemiesCount = {Enemies.Count};");
                writer.WriteLine($"\t\tlet CollectablesCount = {Collectables.Count};");
                //writer.WriteLine($"\t\tlet sections_num = {Sections.Count};");
                //writer.WriteLine($"\t\tlet level_width = {levelWidth};");
                //writer.WriteLine($"\t\tlet section_width = {sectionWidth};");
                //writer.WriteLine($"\t\tlet sections = Array.new(sections_num);");
                //writer.WriteLine($"\t\tlet platform_section_sizes = Array.new(platform_sections_num);");
                //for (int i = 0; i < Sectionsizes.Count; i++)
                //{
                //    writer.WriteLine($"\t\tlet platform_section_sizes[{i}] = {Sectionsizes[i]};");
                //}

                if (Platforms.Count != 0)
                    writer.WriteLine($"\t\tlet Platforms = Array.new({Platforms.Count});");

                for (int i = 0; i < Platforms.Count; i++)
                {
                    writer.WriteLine($"\t\tlet Platforms[{i}] = Platform.new({Platforms[i].X}, {Platforms[i].Y}, {(int)Platforms[i].Type}, {Platforms[i].Size});");
                }


                if (Obstacles.Count != 0)
                    writer.WriteLine($"\t\tlet Obstacles = Array.new({Obstacles.Count});");

                for (int i = 0; i < Obstacles.Count; i++)
                {
                    writer.WriteLine($"\t\tlet Obstacles[{i}] = Obstacle.new({Obstacles[i].X}, {Obstacles[i].Y}, {(int)Obstacles[i].Type}, {Obstacles[i].Height}, {Obstacles[i].Size});");
                }


                if (Enemies.Count != 0)
                    writer.WriteLine($"\t\tlet Enemies = Array.new({Enemies.Count});");

                for (int i = 0; i < Enemies.Count; i++)
                {
                    writer.WriteLine($"\t\tlet Enemies[{i}] = Enemy.new({Enemies[i].X}, {Enemies[i].Y}, {(int)Enemies[i].Type});");
                }


                if (Collectables.Count != 0)
                    writer.WriteLine($"\t\tlet Collectables = Array.new({Collectables.Count});");

                for (int i = 0; i < Collectables.Count; i++)
                {
                    writer.WriteLine($"\t\tlet Collectables[{i}] = Collectable.new({Collectables[i].X}, {Collectables[i].Y}, {(int)Collectables[i].Type});");
                }




                writer.WriteLine($"\t\tlet Map = Array.new({levelWidth});");
                for (int i = 0; i < levelWidth; i++)
                {
                    writer.WriteLine($"\t\tlet map{i} = Array.new({levelHeight});");
                    for (int j = 0; j < levelHeight; j++)
                    {
                        writer.WriteLine($"\t\tlet map{i}[{j}] = {Matrix[i, j]};");
                    }
                    writer.WriteLine($"\t\tlet Map[{i}] = map{i};");
                }
                writer.WriteLine($"\t\tlet MapWidth = {levelWidth};");
                writer.WriteLine($"\t\tlet MapHeight = {levelWidth};");



                writer.WriteLine("\t\treturn this;");
                writer.WriteLine("\t}");
                writer.WriteLine("\tmethod int getPlatformsCount() { return PlatformsCount; }");
                writer.WriteLine("\tmethod int getObstaclesCount() { return ObstaclesCount; }");
                writer.WriteLine("\tmethod int getEnemiesCount() { return EnemiesCount; }");
                writer.WriteLine("\tmethod int getCollectablesCount() { return CollectablesCount; }");
                //writer.WriteLine("\tmethod int get_sections_num() { return sections_num; }");
                //writer.WriteLine("\tmethod int getLevelWidth() { return LevelWidth; }");
                //writer.WriteLine("\tmethod int get_section_width() { return section_width; }");
                writer.WriteLine("\tmethod Array getPlatforms() { return Platforms; }");
                writer.WriteLine("\tmethod Array getObstacles() { return Obstacles; }");
                writer.WriteLine("\tmethod Array getEnemies() { return Enemies; }");
                writer.WriteLine("\tmethod Array getCollectables() { return Collectables; }");
                //writer.WriteLine("\tmethod Array get_sections() { return sections; }");
                //writer.WriteLine("\tmethod Array get_section(int index) { return sections[index]; }");
                writer.WriteLine("\tmethod Character getCharacter() { return character; }");
                writer.WriteLine("\tmethod Array getMap() { return Map; }");
                writer.WriteLine("\tmethod int getMapWidth() { return MapWidth; }");
                writer.WriteLine("\tmethod int getMapHeight() { return MapHeight; }");
                writer.WriteLine("}");
            }
        }

        
    }
}
