using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Czołgi_v0_5
{ 
    public class Bullet
    {
        public byte pointDirection;
        Point shootPoint;
        Point movePoint;
        public byte which;
        public PictureBox picBullet;
        public int bulletSize = 4;
        int speed = 3;
        int x, y;
        public Bullet(Tank tank, byte where, ref PictureBox picture)
        {

            picBullet = picture;
            which = tank.GetWhich();
            //shootPoint <<<
            switch (where)
            {
                case 0:
                    y = -speed;
                    shootPoint = new Point(tank.picTank.Location.X + 20 - (bulletSize / 2), tank.picTank.Location.Y - (bulletSize / 2));
                    break;
                case 1:
                    x = speed;
                    shootPoint = new Point(tank.picTank.Location.X + 40 - (bulletSize / 2), tank.picTank.Location.Y + 20 - (bulletSize / 2));
                    break;
                case 2:
                    y = speed;
                    shootPoint = new Point(tank.picTank.Location.X + 20 - (bulletSize / 2), tank.picTank.Location.Y + 40 - (bulletSize / 2));
                    break;
                case 3:
                    x = -speed;
                    shootPoint = new Point(tank.picTank.Location.X - (bulletSize / 2), tank.picTank.Location.Y + 20 - (bulletSize / 2));
                    break;
            }
            movePoint = shootPoint;
            pointDirection = where;

            picBullet.BackColor = Color.Orange;
            picBullet.Size = new Size(4, 4);
            picBullet.Location = movePoint;
            picBullet.Enabled = true;

        }


        public Point BulletMove()
        {
            movePoint.X += x;
            movePoint.Y += y;
            picBullet.Location = movePoint;
            return movePoint;
        }
        public void Explode()
        {
            PictureBox explosion = new PictureBox();
            explosion.Location = new Point(this.picBullet.Location.X - 3, this.picBullet.Location.Y - 3);
            explosion.BackColor = Color.Red;
            explosion.Size = new Size(10, 10);
            Form1.panel1.Controls.Add(explosion);
            explosion.BringToFront();
            explosion.visible = false;
        } 

        ~Bullet(){
        }
        

    }
}
