using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Czołgi_v0_5
{
    class GameEngine
    {

        static public bool WallColission(byte where, Tank tank = null, Bullet bullet = null)
        {
            bool colission = false;
            int X, Y, width, height;
            int col = 0;
            int row = 0;
            int iteracja = -1;
            int temp;

            if (bullet == null)
            {
                X = tank.picTank.Location.X;
                Y = tank.picTank.Location.Y;
                width = tank.picTank.Width;
                height = tank.picTank.Height;
            }
            else
            {
                X = bullet.picBullet.Location.X;
                Y = bullet.picBullet.Location.Y;
                width = bullet.picBullet.Width;
                height = bullet.picBullet.Height;
            }

            temp = X - X % 50;
            do
            {
                temp = temp - 50;
                iteracja++;
            } while (temp >= 0);
            col = iteracja;
            iteracja = -1;
            temp = Y - Y % 50;
            do
            {
                temp = temp - 50;
                iteracja++;
            } while (temp >= 0);
            row = iteracja;
            switch (where)
            {
                case 0:
                    if ((Y % 50 == 0)||(bullet!=null && (Y%50 == 0|| Y % 50 == 1|| Y % 50 == 2)))
                    {
                        if (Form1.map1[row - 1 + 1, col + 1] == 1)
                        {
                            colission = true;
                        }
                        else if (Form1.map1[row - 1 + 1, col + 1 + 1] == 1 && X % 50 > (50 - width))
                        {
                            colission = true;
                        }
                    }
                    break;
                case 1:
                    if ((X % 50 == 50 - width)|| (bullet != null && (X % 50 == 50 - width|| X % 50 == 49 - width|| X % 50 == 48 - width)))
                    {
                        if (Form1.map1[row + 1, col + 1 + 1] == 1)
                        {
                            colission = true;
                        }
                        else if (Form1.map1[row + 1 + 1, col + 1 + 1] == 1 && Y % 50 > (50 - height))
                        {
                            colission = true;
                        }
                    }
                    break;
                case 2:
                    if ((Y % 50 == 50 - height)|| (bullet != null && (Y % 50 == 50 - height|| Y % 50 == 49 - height|| Y % 50 == 48 - height)))
                    {
                        if (Form1.map1[row + 1 + 1, col + 1] == 1)
                        {
                            colission = true;
                        }
                        else if (Form1.map1[row + 1 + 1, col + 1 + 1] == 1 && X % 50 > (50 - width))
                        {
                            colission = true;
                        }
                    }
                    break;
                case 3:
                    if ((X % 50 == 0)|| (bullet != null && (X % 50 == 0 || X % 50 == 1 || X % 50 == 2)))
                    {
                        if (Form1.map1[row + 1, col - 1 + 1] == 1)
                        {
                            colission = true;
                        }
                        else if (Form1.map1[row + 1 + 1, col - 1 + 1] == 1 && Y % 50 > (50 - height))
                        {
                            colission = true;
                        }
                    }
                    break;
            }

            return colission;
        }

        static public bool TankColission(byte where, Tank tank)
        {
            bool onSwamp = false;
            for(int i =0;i < Form1.listSwamp.Count; i++)
            {
                if (tank.picTank.Bounds.IntersectsWith(Form1.listSwamp[i].Bounds))
                {
                    onSwamp = true;
                }
            }
            if (onSwamp)
            {
                tank.OnSwamp();
            }
            else
            {
                tank.OffSwamp();
            }
            
            if (Form1.tank1.picTank.Bounds.IntersectsWith(Form1.tank2.picTank.Bounds))
            {
                tank.keyTank[where] = false;
                tank.ChangeDirection((byte)((where + 2) % 4));
                tank.TankMove((byte)((where + 2) % 4));
                tank.TankMove((byte)((where + 2) % 4));
                tank.ChangeDirection(where);
                return true;
            }
            else
            {
                
                if (WallColission(where, tank) == true)
                {
                    return true;
                }
            }
            

            return false;
        }

        static public bool BulletColission(byte where, Bullet bullet)
        {
            if (WallColission(bullet.pointDirection, null, bullet) == true)
            {
                Form1.panel1.Controls.Remove(bullet.picBullet);
                if (bullet.which == 1)
                {
                    Form1.shoot1 = false;
                }
                else
                {
                    Form1.shoot2 = false;
                }
                return true;
            }
            else
            {
                if (bullet.picBullet.Bounds.IntersectsWith(Form1.tank1Pic.Bounds) && bullet.which == 2)
                {
                    bullet.Explode();
                    Form1.shoot2 = false;
                    Form1.panel1.Controls.Remove(bullet.picBullet);
                    Form1.tank1.life -= 10;
                    Form1.lifeT1.Refresh();
                    if (Form1.tank1.Destroy() == false)
                        Form1.lifeT1.Value = Form1.tank1.life;
                    return true;
                }

                if (bullet.picBullet.Bounds.IntersectsWith(Form1.tank2Pic.Bounds) && bullet.which == 1)
                {
                    bullet.picBullet.Location = new Point(bullet.picBullet.Location.X - 3, bullet.picBullet.Location.Y - 3);
                    bullet.picBullet.BackColor = Color.Red;
                    bullet.picBullet.Size = new Size(10, 10);
                    Form1.shoot1 = false;
                    Form1.panel1.Controls.Remove(bullet.picBullet);
                    Form1.tank2.life -= 10;
                    Form1.lifeT2.Refresh();
                    if (Form1.tank2.Destroy() == false)
                        Form1.lifeT2.Value = Form1.tank2.life;
                    return true;
                }
            }

            return false;
        }

        public static void TankMove(Tank tank, byte where)
        {
            if (tank.pointDirection == where)
            {
                if (TankColission(where, tank) == false)
                {
                    tank.TankMove(where);
                }
                else
                {
                    tank.picTank.Refresh();
                }
            }
            else
            {
                tank.ChangeDirection(where);
            }

        }

    }
}
