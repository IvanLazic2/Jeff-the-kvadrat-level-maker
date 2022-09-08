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
    public partial class Form2 : Form
    {
        public Form1 Form1 { get; set; }

        List<Frame> Frames = new List<Frame>();

        Bitmap bmp;
        Pen pen;
        Pen gridPen = Pens.Gray;
        Brush brush;

        Rectangle drawingRectangle;
        bool isMouseDown;

        int currFrame;

        int numberOfAnimationFrames;

        public Form2()
        {
            InitializeComponent();
            init();
        }

        public Form2(Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
            init();
        }

        private void init()
        {
            pictureBox1.Width = (int)numericUpDown1.Value * 16 + 1;
            pictureBox1.Height = (int)numericUpDown2.Value * 16 + 1;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

            pen = new Pen(Color.Black, 0);
            brush = Brushes.Black;

            drawingRectangle = new Rectangle();

            listView1.View = View.LargeIcon;
            imageList1.ImageSize = new Size(64, 64);
            listView1.LargeImageList = imageList1;
            listView1.Activation = ItemActivation.Standard;
            listView1.MultiSelect = false;

            clear();
            makeGrid();

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Width = (int)numericUpDown1.Value * 16 + 1;
            pictureBox1.Height = (int)numericUpDown2.Value * 16 + 1;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

            clear();
            makeGrid();
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
                    if (i % 16 == 0)
                        gridPen = Pens.Red;
                    else
                        gridPen = Pens.Gray;

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

        /*private Sprite generateSpriteFromImage2(Bitmap finishedImage)
        {
            //int[,] sprite = new int[(finishedImage.Width - 1) / 256, (finishedImage.Height - 1) / 256];

            Sprite sprite = new Sprite((finishedImage.Width - 1) / 256, (finishedImage.Height - 1) / 256);

            //for (int i = 0; i < finishedImage.Width - 1; i += 256)
            for (int i = finishedImage.Height - 257; i >= 0; i -= 256)
            {

                List<int[,]> spriteRow = new List<int[,]>();

                //for (int j = finishedImage.Height - 257; j >= 0; j -= 256)
                for (int j = 0; j < finishedImage.Width - 1; j += 256)
                {
                    SpritePart spritePart = new SpritePart();

                    for (int k = 0; k < 256; k += 16)
                    {
                        for (int l = 0; l < 256; l += 16)
                        {
                            Color c = finishedImage.GetPixel(j + k + 1, i + l + 1);

                            if (c.R == 0 && c.G == 0 && c.B == 0)
                            {
                                spritePart.Array[l / 16, k / 16] = 1;
                            }
                        }
                    }

                    spritePart.ConvertArray();
                    sprite.Array[((finishedImage.Height - 1) / 256) - (i / 256) - 1, j / 256] = spritePart;
                }
            }

            return sprite;
        }*/

        private int blockRowToInt(int[] blockRow)
        {
            //get grid binary representation
            string binary = "";
            for (int i = 0; i < 16; i++)
            {
                if (blockRow[i] == 1)
                    binary = "1" + binary;
                else
                    binary = "0" + binary;
            }

            bool isNegative = false;
            //if number is negative, get its  one's complement
            if (binary[0] == '1')
            {
                isNegative = true;
                string oneComplement = "";
                for (int k = 0; k < 16; k++)
                {
                    if (binary[k] == '1')
                        oneComplement = oneComplement + "0";
                    else
                        oneComplement = oneComplement + "1";
                }
                binary = oneComplement;
            }

            //calculate one's complement decimal value
            int value = 0;
            for (int k = 0; k < 16; k++)
            {
                value = value * 2;
                if (binary[k] == '1')
                    value = value + 1;
            }

            //two's complement value if it is a negative value
            if (isNegative == true)
                value = -(value + 1);


            return value;
        }

        private List<int> generateSpriteFromImage(Bitmap finishedImage)
        {
            List<int> blockRows = new List<int>();

            for (int i = ((finishedImage.Height - 1) / 16) - 1; i >= 0; i--)
            {
                for (int j = 0; j < (finishedImage.Width - 1) / 256; j++)
                {
                    int[] blockRow = new int[16];

                    for (int k = 0; k < 16; k++)
                    {
                        Color c = finishedImage.GetPixel(((j * 256) + (k * 16)) + 1, (i * 16) + 1);

                        if (c.R == 0 && c.G == 0 && c.B == 0)
                        {
                            blockRow[k] = 1;
                        }
                    }

                    blockRows.Add(blockRowToInt(blockRow));
                }
            }

            return blockRows;
        }

        private void generateFrames(Bitmap finishedImage, List<int> sprite, List<int> spriteMirrored)
        {
            string frameName = frameNameTextBox.Text;
            Frame frame = null;

            if (Frames.Exists(x => x.Name == frameName))
            {
                frame = Frames.Find(x => x.Name == frameName);
                frame.Image = finishedImage;
                frame.Sprite = sprite;
                frame.SpriteMirrored = spriteMirrored;

                int imageIndex = imageList1.Images.Keys.IndexOf(frameName);

                // find the previous image by key
                Image previousImage = imageList1.Images[imageIndex];
                // remove the previous image from the collection
                imageList1.Images.RemoveByKey(frameName);
                // dispose the previous image
                previousImage.Dispose();
                // add a new image
                imageList1.Images.Add(frameName, frame.Image);
                imageList1.Images.SetKeyName(imageIndex, frame.Name);

                listView1.Refresh();

            }
            else
            {
                frame = new Frame((int)numericUpDown1.Value / 16, (int)numericUpDown2.Value / 16, frameName, finishedImage, sprite, spriteMirrored);
                Frames.Add(frame);

                imageList1.Images.Add(frame.Image);
                imageList1.Images.SetKeyName(currFrame, frame.Name);

                ListViewItem item = new ListViewItem();
                item.Tag = frame;
                item.Text = frame.Name;
                //item.ImageIndex = currFrame;
                item.ImageKey = frame.Name;
                listView1.Items.Add(item);
                currFrame++;
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var selectedFrame = listView1.SelectedItems[0].Tag as Frame;

            pictureBox1.Width = selectedFrame.Image.Width;
            pictureBox1.Height = selectedFrame.Image.Height;

            pictureBox1.Image = selectedFrame.Image;

            frameNameTextBox.Text = selectedFrame.Name;
        }


        private void saveButton_MouseClick(object sender, MouseEventArgs e)
        {
            List<int> sprite;
            List<int> spriteMirrored;

            Bitmap finishedImage = new Bitmap(pictureBox1.Image);

            sprite = generateSpriteFromImage(finishedImage);

            Bitmap imageToMirror = new Bitmap(pictureBox1.Image);
            imageToMirror.RotateFlip(RotateFlipType.RotateNoneFlipX);

            spriteMirrored = generateSpriteFromImage(imageToMirror);

            generateFrames(finishedImage, sprite, spriteMirrored);
        }

        private void deleteButton_MouseClick(object sender, MouseEventArgs e)
        {
            var selectedItem = listView1.SelectedItems[0];
            var frame = selectedItem.Tag as Frame;

            int imageIndex = imageList1.Images.Keys.IndexOf(frame.Name);

            // find the previous image by key
            Image previousImage = imageList1.Images[imageIndex];
            // remove the previous image from the collection
            imageList1.Images.RemoveByKey(frame.Name);
            // dispose the previous image
            previousImage.Dispose();

            selectedItem.Remove();

            Frames.Remove(frame);

            currFrame--;
        }

        private void mirrorButton_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            pictureBox1.Image = image;
        }

        private void doneButton_MouseClick(object sender, MouseEventArgs e)
        {
            numberOfAnimationFrames = (int)numericUpDown3.Value;

            writeToFile();
        }

        private void writeToFile()
        {
            string spriteName = spriteNameTextBox.Text;
            string folder = @"D:\User\Fakse\Moderni racunalni sustavi\Projekt\Jeff the kvadrat\";
            string fileName = spriteName + ".jack";
            string fullPath = folder + fileName;

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine($"class {spriteName}");
                writer.WriteLine("{");

                writer.WriteLine("\tstatic int Width;");
                writer.WriteLine("\tstatic int Height;");

                writer.WriteLine("\tstatic int AnimationFramesCount;");
                //writer.WriteLine("\tstatic int SpecialFramesCount;");
                //writer.WriteLine("\tstatic int TotalFramesCount;");

                //writer.WriteLine("\tstatic bool stopAnimation;");

                writer.WriteLine("\tstatic int currFrame;");
                writer.WriteLine("\tstatic int animationTimer;");
                writer.WriteLine("\tstatic int animationDelay;");
                //writer.WriteLine("\tstatic int specialFrameTimer;");

                /*for (int i = numberOfAnimationFrames; i < Frames.Count; i++)
                {
                    writer.WriteLine($"\tstatic int {Frames[i].Name}Duration;");
                }*/

                /*for (int i = numberOfAnimationFrames; i < Frames.Count; i++)
                {
                    writer.WriteLine($"\tstatic int {Frames[i].Name}Index;");
                }*/

                writer.WriteLine("\tstatic Array Frames;");
                writer.WriteLine("\tstatic int FrameSize;");
                if (hasMirroredCheckBox.Checked)
                {
                    writer.WriteLine("\tstatic Array FramesMirrored;");
                }


                for (int i = 0; i < Frames.Count; i++)
                {
                    writer.WriteLine($"\tstatic Array {Frames[i].Name};");
                    if (hasMirroredCheckBox.Checked)
                    {
                        writer.WriteLine($"\tstatic Array {Frames[i].Name}Mirrored;");
                    }

                }


                writer.WriteLine($"\tfunction void init()");
                writer.WriteLine("\t{");

                writer.WriteLine("///////////////// CONFIG /////////////////");

                if (Frames.Count > 1)
                    writer.WriteLine($"\t\tlet animationDelay = 3;");

                /*for (int i = numberOfAnimationFrames; i < Frames.Count; i++)
                {
                    writer.WriteLine($"\t\tlet {Frames[i].Name}Duration = 10;");
                }*/

                writer.WriteLine("//////////////////////////////////////////");

                var width = (int)numericUpDown1.Value / 16;
                var height = (int)numericUpDown2.Value / 16;

                writer.WriteLine($"\t\tlet Width = {width};");
                writer.WriteLine($"\t\tlet Height = {height};");

                writer.WriteLine($"\t\tlet AnimationFramesCount = {numberOfAnimationFrames};");
                //writer.WriteLine($"\t\tlet SpecialFramesCount = {Frames.Count - numberOfAnimationFrames};");
                //writer.WriteLine($"\t\tlet TotalFramesCount = {Frames.Count};");

                writer.WriteLine($"\t\tlet FrameSize = {width * height * 16};");
                writer.WriteLine($"\t\tlet Frames = Array.new(AnimationFramesCount);");
                if (hasMirroredCheckBox.Checked)
                {
                    writer.WriteLine($"\t\tlet FramesMirrored = Array.new(AnimationFramesCount);");
                }


                for (int i = 0; i < Frames.Count; i++)
                {
                    List<int> sprite = Frames[i].Sprite;
                    List<int> spriteMirrored = Frames[i].SpriteMirrored;

                    writer.WriteLine($"\t\tlet {Frames[i].Name} = Array.new({width * height * 16});");
                    if (hasMirroredCheckBox.Checked)
                    {
                        writer.WriteLine($"\t\tlet {Frames[i].Name}Mirrored = Array.new({width * height * 16});");
                    }

                    for (int j = 0; j < sprite.Count; j++)
                    {
                        if (sprite[j] != 0)
                        {
                            if (sprite[j] == -32768)
                                writer.WriteLine($"\t\tdo MemoryExt.poke({Frames[i].Name}, {j}, ~32767);");
                            else
                                writer.WriteLine($"\t\tdo MemoryExt.poke({Frames[i].Name}, {j}, {sprite[j]});");
                        }
                    }
                    if (hasMirroredCheckBox.Checked)
                    {
                        for (int j = 0; j < spriteMirrored.Count; j++)
                        {
                            if (spriteMirrored[j] != 0)
                            {
                                if (spriteMirrored[j] == -32768)
                                    writer.WriteLine($"\t\tdo MemoryExt.poke({Frames[i].Name}Mirrored, {j}, ~32767);");
                                else
                                    writer.WriteLine($"\t\tdo MemoryExt.poke({Frames[i].Name}Mirrored, {j}, {spriteMirrored[j]});");
                            }
                        }
                    }

                    writer.WriteLine($"\t\tdo MemoryExt.poke(Frames, {i}, {Frames[i].Name});");
                    if (hasMirroredCheckBox.Checked)
                    {
                        writer.WriteLine($"\t\tdo MemoryExt.poke(FramesMirrored, {i}, {Frames[i].Name}Mirrored);");
                    }

                }

                writer.WriteLine("\t\treturn;");
                writer.WriteLine("\t}");

                for (int i = numberOfAnimationFrames; i < Frames.Count; i++)
                {
                    writer.WriteLine($"\tfunction void Play{Frames[i].Name}()");
                    writer.WriteLine("\t{");
                    writer.WriteLine($"\t\tlet specialFrameTimer = {Frames[i].Name}Duration;");
                    writer.WriteLine("\t\tlet stopAnimation = true;");
                    writer.WriteLine($"\t\tlet currFrame = {Frames[i].Name}Index;");
                    writer.WriteLine("\t\treturn;");
                    writer.WriteLine("\t}");
                }

                writer.WriteLine("\tfunction int getWidth() { return Width; }");
                writer.WriteLine("\tfunction int getHeight() { return Height; }");

                if (numberOfAnimationFrames != 1)
                {
                    writer.WriteLine("\tfunction void CheckTimers()");
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\tif (animationTimer < 1)");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine($"\t\t\tdo {spriteName}.ChangeFrame();");
                    writer.WriteLine("\t\t\tlet animationTimer = animationDelay;");
                    writer.WriteLine("\t\t}");
                    /*writer.WriteLine("\t\tif (specialFrameTimer < 1)");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tlet stopAnimation = false;");
                    writer.WriteLine("\t\t\tlet specialFrameTimer = 0;");
                    writer.WriteLine("\t\t}");*/
                    writer.WriteLine("\t\treturn;");
                    writer.WriteLine("\t}");

                    writer.WriteLine("\tfunction void DecrementTimers()");
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\tlet animationTimer = animationTimer - 1;");
                    //writer.WriteLine("\t\tlet specialFrameTimer = specialFrameTimer - 1;");
                    writer.WriteLine("\t\treturn;");
                    writer.WriteLine("\t}");

                    writer.WriteLine("\tfunction void ChangeFrame()");
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\tif (currFrame < (AnimationFramesCount - 1))");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tlet currFrame = currFrame + 1;");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine("\t\telse");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tlet currFrame = 0;");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine("\t\treturn;");
                    writer.WriteLine("\t}");
                }

                if (hasMirroredCheckBox.Checked)
                {
                    writer.WriteLine("\tfunction void DrawFrame(int memAddress, bool mirrored, int x, int y)");
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\tif (mirrored)");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tdo Sprite.Draw(memAddress, FramesMirrored[currFrame], FrameSize, Width, Height, x, y);");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine("\t\telse");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tdo Sprite.Draw(memAddress, Frames[currFrame], FrameSize, Width, Height, x, y);");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine("\t\treturn;");
                    writer.WriteLine("\t}");
                }
                else
                {
                    writer.WriteLine("\tfunction void DrawFrame(int memAddress, int x, int y)");
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\tdo Sprite.Draw(memAddress, Frames[currFrame], FrameSize, Width, Height, x, y);");
                    writer.WriteLine("\t\treturn;");
                    writer.WriteLine("\t}");
                }

                writer.WriteLine("}");
            }
        }
    }
}

