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
        List<Platform1> Platform1s;
        List<Section> Sections;
        List<Obstacle> Obstacles;


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

            Character = new Character();
            Platform1s = new List<Platform1>();
            Sections = new List<Section>();
            Obstacles = new List<Obstacle>();
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

        private void Character_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Blue;
            pen = Pens.Blue;
        }

        private void Enemy1_MouseClick(object sender, MouseEventArgs e)
        {
            brush = Brushes.Red;
            pen = Pens.Red;
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

        // done
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Character = new Character();
            Platform1s = new List<Platform1>();
            Obstacles = new List<Obstacle>();

            Bitmap finishedImage = new Bitmap(pictureBox1.Image);

            bool platStart = false;
            int platSize = 0;
            int platXCoord = 0;

            bool spikedAreaStart = false;
            int spikedAreaSize = 0;
            int spikedAreaXCoord = 0;

            for (int j = 0; j < finishedImage.Height; j += 16)
            {
                platStart = false;
                platSize = 0;

                spikedAreaStart = false;
                spikedAreaSize = 0;

                for (int i = 0; i < finishedImage.Width; i += 16)
                {
                    Color c = finishedImage.GetPixel(i, j);

                    if (c.R == 255 && c.G == 255 && c.B == 255) //white
                    {
                        if (platStart)
                            platStart = false;

                        if (spikedAreaStart)
                            spikedAreaStart = false;
                    }
                    else if (c.R == 0 && c.G == 0 && c.B == 0) //black
                    {
                        if (spikedAreaStart)
                            spikedAreaStart = false;

                        if (!platStart)
                            platXCoord = i;

                        platStart = true;
                    }
                    else if (c.R == 0 && c.G == 0 && c.B == 255) //blue
                    {
                        if (platStart)
                            platStart = false;

                        if (spikedAreaStart)
                            spikedAreaStart = false;

                        Character.X = i / 16;
                        Character.Y = j;
                    }
                    else if (c.R == 255 && c.G == 0 && c.B == 0) //red
                    {
                        Console.WriteLine("Red");
                    }
                    else if (c.R == 255 && c.G == 255 && c.B == 0) //yellow
                    {
                        if (platStart)
                            platStart = false;

                        if (spikedAreaStart)
                            spikedAreaStart = false;

                        Obstacles.Add(new Obstacle(i / 16, j, ObstacleType.SmallSpikes));
                    }
                    else if (c.R == 255 && c.G == 165 && c.B == 0) //orange
                    {
                        if (platStart)
                            platStart = false;

                        if (spikedAreaStart)
                            spikedAreaStart = false;

                        Obstacles.Add(new Obstacle(i / 16, j, ObstacleType.MediumSpikes));
                    }
                    else if (c.R == 210 && c.G == 105 && c.B == 30) //chocolate
                    {
                        if (platStart)
                            platStart = false;

                        if (spikedAreaStart)
                            spikedAreaStart = false;

                        Obstacles.Add(new Obstacle(i / 16, j, ObstacleType.WeirdSpikes));
                    }
                    else if (c.R == 139 && c.G == 69 && c.B == 19) //saddle brown
                    {
                        if (platStart)
                            platStart = false;

                        if (spikedAreaStart)
                            spikedAreaStart = false;

                        Obstacles.Add(new Obstacle(i / 16, j, ObstacleType.LargeSpikes));
                    }
                    else if (c.R == 210 && c.G == 180 && c.B == 140) // tan
                    {
                        if (platStart)
                            platStart = false;

                        if (!spikedAreaStart)
                            spikedAreaXCoord = i;

                        spikedAreaStart = true;
                    }

                    if (platStart)
                        platSize++;

                    if (spikedAreaStart)
                        spikedAreaSize++;

                    if ((!platStart || i == finishedImage.Width - 16) && platSize != 0)
                        Platform1s.Add(new Platform1(platXCoord / 16, j, platSize));

                    if ((!spikedAreaStart || i == finishedImage.Width - 16) && spikedAreaSize != 0)
                        Obstacles.Add(new Obstacle(spikedAreaXCoord / 16, j, ObstacleType.SpikedArea, spikedAreaSize));

                    if (!platStart)
                        platSize = 0;

                    if (!spikedAreaStart)
                        spikedAreaSize = 0;
                }
            }


            generateSections();
            writeToFile();
        }

        private void generateSections()
        {
            //int sectionsNum = levelWidth / Platform1s.Count / 2;
            Sections = new List<Section>();

            Platform1s.Sort((p1, p2) => p1.Y.CompareTo(p2.Y)); //X
            Obstacles.Sort((o1, o2) => o2.Y.CompareTo(o2.Y));

            //List<Platform1> current = new List<Platform1>();
            Section currentSection = new Section();
            //List<Platform1> next = new List<Platform1>();

            int screensNum = levelWidth / sectionWidth;

            for (int k = 1; k <= screensNum; k++)
            {
                for (int i = 0; i < Platform1s.Count; i++)
                {
                    if ((Platform1s[i].X >= (k - 1) * sectionWidth && Platform1s[i].X < k * sectionWidth) ||
                        (Platform1s[i].X < k * sectionWidth && Platform1s[i].X + Platform1s[i].Size > (k-1) * sectionWidth))

                        currentSection.Platforms1.Add(Platform1s[i]);
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
                    foreach (var platform in Sections[i + 1].Platforms1)
                    {
                        if (platform.X == Sections[i + 1].LeftBorder || platform.X == Sections[i + 1].LeftBorder + 1)
                        {
                            Sections[i].Platforms1.Add(platform);
                        }
                    }

                    Sections[i].Platforms1 = new HashSet<Platform1>(Sections[i].Platforms1).ToList();

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
                    foreach (var platform in Sections[i - 1].Platforms1)
                    {
                        if (platform.X + platform.Size == Sections[i - 1].RightBorder || platform.X + platform.Size == Sections[i - 1].RightBorder - 1)
                        {
                            Sections[i].Platforms1.Add(platform);
                        }
                    }

                    Sections[i].Platforms1 = new HashSet<Platform1>(Sections[i].Platforms1).ToList();

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





        // MOZDA?!?!
        // PROBLEM: svaki puta se kreira nova platforma, a u vise sekcija se moze nalazit ista platforma
        // RJESENJE: kreiraj ih sve prije i onda ih razvrstavaj po sekcijama
        // IDEJA: identificirati platforme po x, y i size propertiju, npr. Platform platform_0_0_64 = Platform.new(0, 0, 64);

        // PROBLEM: kada je sekcija prazna (nema platformi) dogodi se section = Array.new(0) sto se ne bi smjelo dogodit

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

                writer.WriteLine("\tfield int platforms_num;");
                writer.WriteLine("\tfield int obstacles_num;");
                writer.WriteLine("\tfield int sections_num;");

                writer.WriteLine("\tfield int level_width;");
                writer.WriteLine("\tfield int section_width;");

                //writer.WriteLine("\tfield Array section_sizes;");

                writer.WriteLine($"\tfield Array platforms;");
                foreach (var platform in Platform1s)
                {
                    writer.WriteLine($"\tfield Platform platform_{platform.X}_{platform.Y}_{platform.Size};");
                }

                writer.WriteLine($"\tfield Array obstacles;");
                foreach (var obstacle in Obstacles)
                {
                    writer.WriteLine($"\tfield Obstacle obstacle_{obstacle.X}_{obstacle.Y}_{(int)obstacle.Type}_{obstacle.Size};");
                }

                writer.WriteLine($"\tfield Array sections;");
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
                }

                writer.WriteLine($"\tconstructor {levelName} new()");
                writer.WriteLine("\t{");
                writer.WriteLine($"\t\tlet character = Character.new({Character.X}, {Character.Y - 24});");
                writer.WriteLine($"\t\tlet platforms_num = {Platform1s.Count};");
                writer.WriteLine($"\t\tlet obstacles_num = {Obstacles.Count};");
                writer.WriteLine($"\t\tlet sections_num = {Sections.Count};");
                writer.WriteLine($"\t\tlet level_width = {levelWidth};");
                writer.WriteLine($"\t\tlet section_width = {sectionWidth};");
                writer.WriteLine($"\t\tlet sections = Array.new(sections_num);");
                //writer.WriteLine($"\t\tlet platform_section_sizes = Array.new(platform_sections_num);");
                //for (int i = 0; i < Sectionsizes.Count; i++)
                //{
                //    writer.WriteLine($"\t\tlet platform_section_sizes[{i}] = {Sectionsizes[i]};");
                //}

                writer.WriteLine($"\t\tlet platforms = Array.new({Platform1s.Count});");

                foreach (var platform in Platform1s)
                {
                    writer.WriteLine($"\t\tlet platform_{platform.X}_{platform.Y}_{platform.Size} = Platform.new({platform.X}, {platform.Y}, {platform.Size});");
                }

                for (int i = 0; i < Platform1s.Count; i++)
                {
                    writer.WriteLine($"\t\tlet platforms[{i}] = platform_{Platform1s[i].X}_{Platform1s[i].Y}_{Platform1s[i].Size};");
                }


                writer.WriteLine($"\t\tlet obstacles = Array.new({Obstacles.Count});");

                foreach (var obstacle in Obstacles)
                {
                    writer.WriteLine($"\t\tlet obstacle_{obstacle.X}_{obstacle.Y}_{(int)obstacle.Type}_{obstacle.Size} = Obstacle.new({obstacle.X}, {obstacle.Y}, {(int)obstacle.Type}, {obstacle.Height}, {obstacle.Size});");
                }

                for (int i = 0; i < Obstacles.Count; i++)
                {
                    writer.WriteLine($"\t\tlet obstacles[{i}] = obstacle_{Obstacles[i].X}_{Obstacles[i].Y}_{(int)Obstacles[i].Type}_{Obstacles[i].Size};");
                }


                for (int i = 0; i < Sections.Count; i++)
                {
                    //writer.WriteLine($"\t\tlet platform_section{i} = Array.new(platform_section_sizes[{i}]);");

                    writer.WriteLine($"\t\tlet section{i} = Section.new({Sections[i].LeftBorder}, {Sections[i].RightBorder}, {Sections[i].Platforms1.Count}, {Sections[i].Obstacles.Count});");

                    if (Sections[i].Platforms1.Count != 0)
                    {
                        writer.WriteLine($"\t\tlet section{i}platforms = Array.new({Sections[i].Platforms1.Count});");

                        for (int j = 0; j < Sections[i].Platforms1.Count; j++)
                        {
                            writer.WriteLine($"\t\tlet section{i}platforms[{j}] = platform_{Sections[i].Platforms1[j].X}_{Sections[i].Platforms1[j].Y}_{Sections[i].Platforms1[j].Size};");
                        }

                        writer.WriteLine($"\t\tdo section{i}.set_platforms(section{i}platforms);");
                    }

                    if (Sections[i].Obstacles.Count != 0)
                    {
                        writer.WriteLine($"\t\tlet section{i}obstacles = Array.new({Sections[i].Obstacles.Count});");

                        for (int j = 0; j < Sections[i].Obstacles.Count; j++)
                        {
                            writer.WriteLine($"\t\tlet section{i}obstacles[{j}] = obstacle_{Sections[i].Obstacles[j].X}_{Sections[i].Obstacles[j].Y}_{(int)Sections[i].Obstacles[j].Type}_{Sections[i].Obstacles[j].Size};");
                        }

                        writer.WriteLine($"\t\tdo section{i}.set_obstacles(section{i}obstacles);");
                    }
                    
                    writer.WriteLine($"\t\tlet sections[{i}] = section{i};");

                }

                



                writer.WriteLine("\t\treturn this;");
                writer.WriteLine("\t}");
                writer.WriteLine("\tmethod int get_platforms_num() { return platforms_num; }");
                writer.WriteLine("\tmethod int get_obstacles_num() { return obstacles_num; }");
                writer.WriteLine("\tmethod int get_sections_num() { return sections_num; }");
                writer.WriteLine("\tmethod int get_level_width() { return level_width; }");
                writer.WriteLine("\tmethod int get_section_width() { return section_width; }");
                writer.WriteLine("\tmethod Array get_platforms() { return platforms; }");
                writer.WriteLine("\tmethod Array get_obstacles() { return obstacles; }");
                writer.WriteLine("\tmethod Array get_sections() { return sections; }");
                writer.WriteLine("\tmethod Array get_section(int index) { return sections[index]; }");
                writer.WriteLine("\tmethod Character get_character() { return character; }");
                writer.WriteLine("}");
            }
        }

        
    }
}
