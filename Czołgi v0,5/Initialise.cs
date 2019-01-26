using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Czołgi_v0_5
{
    static class Initialise
    {
        static public Random random = new Random();
        static Panel panel1;
        public static List<PictureBox> listWall = new List<PictureBox>();
        public static List<PictureBox> listSwamp = new List<PictureBox>();
        static public void GenerateMap(ref Panel panel, ref List<PictureBox> listWall1, ref List<PictureBox> listSwamp1)
        {
            panel1 = panel;
            listWall = listWall1;
            listSwamp = listSwamp1;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (Form1.map1[i, j] == 1)
                        CreateWall(j, i);
                    if (Form1.map1[i, j] == 0)
                        CreateFloor(j, i);
                    if (Form1.map1[i, j] == 2)
                        CreateSwamp(j, i);
                }
            }
        }

        static public void CreateTanks(ref Tank tank1, ref Tank tank2, ref PictureBox tank1Pic, ref PictureBox tank2Pic, ref Timer tank1timer, ref Timer tank2timer)
        {
            tank1 = new Tank(1, ref tank1Pic, ref tank1timer);
            tank2 = new Tank(2, ref tank2Pic, ref tank2timer);
            tank1.picTank.Size = new Size(40, 40);
            tank2.picTank.Size = new Size(40, 40);
            tank1.picTank.BackColor = Color.Transparent;
            tank2.picTank.BackColor = Color.Transparent;
            tank1.picTank.Tag = "Tank";
            tank2.picTank.Tag = "Tank";
            panel1.Controls.Add(tank1Pic);
            panel1.Controls.Add(tank2.picTank);
            tank1.picTank.BringToFront();
            tank2.picTank.BringToFront();
            Form1.lifeT1.Location = new Point(505, 40);
            Form1.lifeT2.Location = new Point(505, 60);
            Form1.lifeT1.Size = new Size(100, 10);
            Form1.lifeT2.Size = new Size(100, 10);
            Form1.lifeT1.Enabled = true;
            Form1.lifeT2.Enabled = true;
            Form1.lifeT1.Style = ProgressBarStyle.Continuous;
            Form1.lifeT2.Style = ProgressBarStyle.Continuous;
            Form1.lifeT1.ForeColor = Color.FromArgb(58, 127, 2);
            Form1.lifeT2.ForeColor = Color.FromArgb(90, 63, 1);
            Form1.lifeT1.Value = tank1.life;
            Form1.lifeT2.Value = tank2.life;
        }

        static public void CreateWall(int column, int row)
        {
            PictureBox wall = new PictureBox();
            wall.Tag = "Wall";
            wall.Location = new Point(-50 + column * 50, -50 + row * 50);
            wall.Size = new Size(50, 50);
            wall.Image = Image.FromFile(@"res\walle.png");
            listWall.Add(wall);
            panel1.Controls.Add(wall);
        }

        static public void CreateFloor(int column, int row)
        {
            PictureBox floor = new PictureBox();
            floor.Tag = "floor";
            floor.Location = new Point(-50 + column * 50, -50 + row * 50);
            floor.Size = new Size(50, 50);
            floor.Image = Image.FromFile(@"res\floor.png");
            floor.Image.RotateFlip((RotateFlipType)random.Next(0, 7));
            panel1.Controls.Add(floor);
        }
        public static void CreateSwamp(int column, int row)
        {
            PictureBox swamp = new PictureBox();
            swamp.Tag = "swamp";
            swamp.Location = new Point(-50 + column * 50, -50 + row * 50);
            swamp.Size = new Size(50, 50);
            swamp.Image = Image.FromFile(@"res\swamp.png");
            swamp.Image.RotateFlip((RotateFlipType)random.Next(0, 7));
            listSwamp.Add(swamp);
            panel1.Controls.Add(swamp);
        }
        public static void SetVisibilityEnable(ref Button button, bool tf)
        {
            button.Visible = tf;
            button.Enabled = tf;
        }
    }
}
