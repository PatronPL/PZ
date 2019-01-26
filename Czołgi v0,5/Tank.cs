using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Czołgi_v0_5
{
    public class Tank
    {
        public byte pointDirection;
        private Point punkt;
        public int life;
        private byte which;
        public PictureBox picTank;
        int speed = 1;
        public bool isDestroyed = false;
        public bool[] keyTank = new bool[4] { false, false, false, false };
        Timer tick;
        

        public Tank(byte which,ref PictureBox picTank, ref Timer timer)
        {
            if(which == 1)
            {
                this.which = 1;
                pointDirection = 0;
                punkt.X = picTank.Location.X;
                punkt.Y = picTank.Location.Y;
                picTank.Image = Image.FromFile(@"res\czołgV1.png");
            }
            if (which == 2)
            {
                this.which = 2;
                pointDirection = 2;
                punkt.X = picTank.Location.X;
                punkt.Y = picTank.Location.Y;
                picTank.Image = Image.FromFile(@"res\czołgV2.png");
                picTank.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            life = 100;
            tick = timer;
            this.picTank = picTank;
        }

        public Point TankMove(byte where)
        {
            if(pointDirection==where)
            switch (where)
            {
                    case 0:
                        punkt.Y -= speed;
                        break;
                    case 1:
                        punkt.X += speed;
                        break;
                    case 2:
                        punkt.Y += speed;
                        break;
                    case 3:
                        punkt.X -= speed;
                        break;
                }
            picTank.Location = punkt;
            picTank.Refresh();
            return punkt;
        }

        public void ChangeDirection(byte where)
        {
            switch (where)
            {
                case 0:
                    pointDirection = where;
                    if (which == 1)
                        picTank.Image = Image.FromFile(@"res\czołgV1.png");
                    if (which == 2)
                        picTank.Image = Image.FromFile(@"res\czołgV2.png");
                    picTank.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
                case 1:
                    pointDirection = where;
                    if (which == 1)
                        picTank.Image = Image.FromFile(@"res\czołgV1.png");
                    if (which == 2)
                        picTank.Image = Image.FromFile(@"res\czołgV2.png");
                    picTank.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 2:
                    pointDirection = where;
                    if (which == 1)
                        picTank.Image = Image.FromFile(@"res\czołgV1.png");
                    if (which == 2)
                        picTank.Image = Image.FromFile(@"res\czołgV2.png");
                    picTank.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 3:
                    pointDirection = where;
                    if (which == 1)
                        picTank.Image = Image.FromFile(@"res\czołgV1.png");
                    if (which == 2)
                        picTank.Image = Image.FromFile(@"res\czołgV2.png");
                    picTank.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

            }
        }

        public bool Destroy()
        {
            if (life < 0)
            {
                picTank.Enabled = false;
                picTank.Visible = false;
                picTank.Location = new Point(-50, -50);
                picTank.Refresh();
                isDestroyed = true;
                return true;
            }
            return false;
        }

        public void OnSwamp()
        {
            tick.Interval = 40;
        }
        public void OffSwamp()
        {
            tick.Interval = 16;
        }

        
        public byte GetWhich()
        {
            return which;
        }


    }
}
