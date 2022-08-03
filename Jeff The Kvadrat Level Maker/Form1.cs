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
        //List<int> Sectionsizes;


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
            //Sectionsizes = new List<int>();
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

        // done
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Character = new Character();
            Platform1s = new List<Platform1>();

            Bitmap finishedImage = new Bitmap(pictureBox1.Image);

            bool platStart = false;
            int platSize = 0;
            int xCoord = 0;

            for (int j = 0; j < finishedImage.Height; j += 16)
            {
                platStart = false;
                platSize = 0;

                for (int i = 0; i < finishedImage.Width; i += 16)
                {
                    Color c = finishedImage.GetPixel(i, j);

                    if (c.R == 255 && c.G == 255 && c.B == 255)
                    {
                        if (platStart)
                            platStart = false;
                    }
                    else if (c.R == 0 && c.G == 0 && c.B == 0)
                    {
                        if (!platStart)
                            xCoord = i;

                        platStart = true;
                    }
                    else if (c.R == 0 && c.G == 0 && c.B == 255)
                    {
                        Character.X = i / 16;
                        Character.Y = j;
                    }
                    else if (c.R == 255 && c.G == 0 && c.B == 0)
                    {
                        Console.WriteLine("Red");
                    }

                    if (platStart)
                        platSize++;

                    if ((!platStart || i == finishedImage.Width - 16) && platSize != 0)
                        Platform1s.Add(new Platform1(xCoord / 16, j, platSize));

                    
                    if (!platStart)
                        platSize = 0;
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

                currentSection.LeftBorder = (k - 1) * sectionWidth;
                currentSection.RightBorder = k * sectionWidth;
                //currentSection.PlatformsNum = currentSection.Platforms1.Count;
                Sections.Add(currentSection);
                currentSection = new Section();
            }

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
                }

                Sections[i].PlatformsNum = Sections[i].Platforms1.Count;
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
                writer.WriteLine("\tfield int sections_num;");
                writer.WriteLine("\tfield int level_width;");
                writer.WriteLine("\tfield int section_width;");

                //writer.WriteLine("\tfield Array section_sizes;");

                writer.WriteLine($"\tfield Array platforms;");
                foreach (var platform in Platform1s)
                {
                    writer.WriteLine($"\tfield Platform platform_{platform.X}_{platform.Y}_{platform.Size};");
                }

                writer.WriteLine($"\tfield Array sections;");
                for (int i = 0; i < Sections.Count; i++)
                {
                    writer.WriteLine($"\tfield Section section{i};");
                }
                for (int i = 0; i < Sections.Count; i++)
                {
                    writer.WriteLine($"\tfield Array section{i}platforms;");
                }

                writer.WriteLine($"\tconstructor {levelName} new()");
                writer.WriteLine("\t{");
                writer.WriteLine($"\t\tlet character = Character.new({Character.X}, {Character.Y - 24});");
                writer.WriteLine($"\t\tlet platforms_num = {Platform1s.Count};");
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
              




                for (int i = 0; i < Sections.Count; i++)
                {
                    //writer.WriteLine($"\t\tlet platform_section{i} = Array.new(platform_section_sizes[{i}]);");
                    writer.WriteLine($"\t\tlet section{i}platforms = Array.new({Sections[i].PlatformsNum});");

                    for (int j = 0; j < Sections[i].Platforms1.Count; j++)
                    {
                        writer.WriteLine($"\t\tlet section{i}platforms[{j}] = platform_{Sections[i].Platforms1[j].X}_{Sections[i].Platforms1[j].Y}_{Sections[i].Platforms1[j].Size};");
                    }

                    writer.WriteLine($"\t\tlet section{i} = Section.new(section{i}platforms, {Sections[i].LeftBorder}, {Sections[i].RightBorder}, {Sections[i].PlatformsNum});");

                    writer.WriteLine($"\t\tlet sections[{i}] = section{i};");
                }

                



                writer.WriteLine("\t\treturn this;");
                writer.WriteLine("\t}");
                writer.WriteLine("\tmethod int get_platforms_num() { return platforms_num; }");
                writer.WriteLine("\tmethod int get_sections_num() { return sections_num; }");
                writer.WriteLine("\tmethod int get_level_width() { return level_width; }");
                writer.WriteLine("\tmethod int get_section_width() { return section_width; }");
                writer.WriteLine("\tmethod Array get_platforms() { return platforms; }");
                writer.WriteLine("\tmethod Array get_sections() { return sections; }");
                writer.WriteLine("\tmethod Array get_section(int index) { return sections[index]; }");
                writer.WriteLine("\tmethod Character get_character() { return character; }");
                writer.WriteLine("}");
            }
        }
    }
}
