using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Czołgi_v0_5
{
    public partial class Form1 : Form
    {
        static public Label ipLabel = new Label();
        static public TextBox secondIP = new TextBox();
        static public bool onlinehost = false;
        static public bool online = false;
        static bool timersOff = false;
        public static int[,] map1 = new int[12, 12]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,1},
            {1,0,1,0,2,0,0,0,0,1,0,1},
            {1,0,2,1,0,1,1,0,2,1,0,1},
            {1,2,2,0,0,0,0,0,1,0,0,1},
            {1,0,1,1,2,0,0,0,2,2,0,1},
            {1,0,0,0,2,1,0,0,0,2,0,1},
            {1,0,0,1,2,0,0,1,1,0,0,1},
            {1,2,0,0,1,0,2,1,0,0,1,1},
            {1,2,1,0,1,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1,1}
        };

        public static Panel panel1 = new Panel();
        public static List<PictureBox> listWall = new List<PictureBox>();
        public static List<PictureBox> listSwamp = new List<PictureBox>();
        public static PictureBox tank1Pic = new PictureBox();
        public static PictureBox tank2Pic = new PictureBox();
        public static ProgressBar lifeT1 = new ProgressBar();
        public static ProgressBar lifeT2 = new ProgressBar();
        public static Bullet bullet1;
        public static Bullet bullet2;
        public static Tank tank1;
        public static Tank tank2;
        public const byte KUp = 0;
        public const byte KRight = 1;
        public const byte KDown = 2;
        public const byte KLeft = 3;


        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            startButton.Location = new Point(200, 200);
            startButton.Size = new Size(150, 70);
            startButton.Text = "Start Local";
            Initialise.SetVisibilityEnable(ref startButton, true);

            socketButton.Location = new Point(200, 300);
            socketButton.Size = new Size(150, 70);
            socketButton.Text = "Start Online";
            Initialise.SetVisibilityEnable(ref socketButton, true);

            loadButton.Location = new Point(200, 400);
            loadButton.Size = new Size(150, 50);
            loadButton.Text = "Load";
            Initialise.SetVisibilityEnable(ref loadButton, false);
            tank1timer.Enabled = false;
            tank2timer.Enabled = false;

            
            exit.Location = new Point(200, 450);
            exit.Size = new Size(150, 50);
            exit.Text = "Exit";
            Initialise.SetVisibilityEnable(ref exit, true);
            

            tank1Pic.Location = new Point(250, 400);
            tank2Pic.Location = new Point(250, 56);
        }

        private void StartGame()
        {
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(500, 500);
            panel1.BackColor = Color.FromArgb(111, 99, 91);
            this.Controls.Add(panel1);
            
            Initialise.GenerateMap(ref panel1, ref listWall, ref listSwamp);
            Bitmap background = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(background, panel1.DisplayRectangle);
            panel1.BackgroundImage = background;

            Initialise.CreateTanks(ref tank1, ref tank2, ref tank1Pic, ref tank2Pic, ref tank1timer, ref tank2timer);
            Controls.Add(Form1.lifeT1);
            Controls.Add(Form1.lifeT2);
            tank1timer.Enabled = true;
            tank2timer.Enabled = true;
        }


        private void LoadGame(Point tank1p, Point tank2p)
        {
            Button load1 = new Button();
            Initialise.SetVisibilityEnable(ref load1, true);
            load1.Location = new Point(200, 200);
            load1.Size = new Size(100, 100);
            tank1Pic.Location = tank1p;
            tank2Pic.Location = tank2p;
            StartGame();
        }






        private void startButton_Click(object sender, EventArgs e)
        {
            Initialise.SetVisibilityEnable(ref startButton, false);
            Initialise.SetVisibilityEnable(ref loadButton, false);
            Initialise.SetVisibilityEnable(ref socketButton, false);
            Initialise.SetVisibilityEnable(ref exit, false);
            if (online == true)
            {
                timerHost.Enabled = true;
                timerSend.Enabled = true;
            }
            disconect = false;
            StartGame();
        }

        private void socketButton_Click(object sender, EventArgs e)
        {
            Initialise.SetVisibilityEnable(ref startButton, false);
            Initialise.SetVisibilityEnable(ref loadButton, false);
            Initialise.SetVisibilityEnable(ref socketButton, false);
            Initialise.SetVisibilityEnable(ref exit, false);
            buttonClient.Text = "Odpal Client'a";
            buttonHost.Text = "Odpal Host'a";
            Initialise.SetVisibilityEnable(ref buttonHost, true);
            Initialise.SetVisibilityEnable(ref buttonClient, true);
            online = true;

            
            ipLabel.Text = "Twoj DNS: " + SocketConnect.serverIp;
            //iphost.MapToIPv4().ToString() +
            ipLabel.Location = new Point(200, 100);
            ipLabel.Size = new Size(200, 50);
            ipLabel.Enabled = true;
            ipLabel.Visible = true;
            this.Controls.Add(ipLabel);
            
            secondIP.Location = new Point(200, 150);
            ipLabel.Size = new Size(200, 50);
            secondIP.Text = "Wprowadz DNS";
            secondIP.Enabled = true;
            secondIP.Visible = true;
            this.Controls.Add(secondIP);

        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            Initialise.SetVisibilityEnable(ref startButton, false);
            Initialise.SetVisibilityEnable(ref loadButton, false);
            Initialise.SetVisibilityEnable(ref socketButton, false);
            LoadGame(new Point(2, 2), new Point(452, 452));
        }

        private void buttonHost_Click(object sender, EventArgs e)
        {
            SocketConnect.HostClientStart(8080,8181,true);

            Initialise.SetVisibilityEnable(ref buttonHost, false);
            Initialise.SetVisibilityEnable(ref buttonClient, false);

            startButton.Text = "Start gdy gracze gotowi";
            Initialise.SetVisibilityEnable(ref startButton, true);
        }
        private void buttonClient_Click(object sender, EventArgs e)
        {
            SocketConnect.HostClientStart(8181, 8080, false);

            Initialise.SetVisibilityEnable(ref buttonHost, false);
            Initialise.SetVisibilityEnable(ref buttonClient, false);

            startButton.Text = "Start gdy gracze gotowi";
            Initialise.SetVisibilityEnable(ref startButton, true);

        }

        public static void Timers_off()
        {
            timersOff = true;
        }

        private void timerHost_Tick(object sender, EventArgs e)
        {
            if (timersOff == true)
            {
                timersOff = false;
                timerHost.Enabled = false;
                timerSend.Enabled = false;
                tank1timer.Enabled = false;
                tank2timer.Enabled = false;
                bulletTimer.Enabled = false;
            }
            SocketConnect.HostTimer();
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            if (timersOff == true)
            {
                timersOff = false;
                timerHost.Enabled = false;
                timerSend.Enabled = false;
                tank1timer.Enabled = false;
                tank2timer.Enabled = false;
                bulletTimer.Enabled = false;
            }
            SocketConnect.SendTimer();
        }




        static public bool shoot1, shoot2, disconect;
        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (onlinehost == true || online == false) { 
            if (e.KeyCode == Keys.Up)
            {
                tank1.keyTank[KUp] = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                tank1.keyTank[KRight] = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                tank1.keyTank[KDown] = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                tank1.keyTank[KLeft] = false;
            }
            if (e.KeyCode == Keys.Space && shoot1 == false && tank1.isDestroyed == false)
            {
                shoot1 = true;
                PictureBox picbullet1 = new PictureBox();
                bullet1 = new Bullet(tank1, tank1.pointDirection, ref picbullet1);
                panel1.Controls.Add(picbullet1);
                picbullet1.BringToFront();
            }
        }

            if (onlinehost == false || online == false)
            {
                if (e.KeyCode == Keys.W)
                {
                    tank2.keyTank[KUp] = false;
                }
                if (e.KeyCode == Keys.D)
                {
                    tank2.keyTank[KRight] = false;
                }
                if (e.KeyCode == Keys.S)
                {
                    tank2.keyTank[KDown] = false;
                }
                if (e.KeyCode == Keys.A)
                {
                    tank2.keyTank[KLeft] = false;
                }
                if (e.KeyCode == Keys.F && shoot2 == false && tank2.isDestroyed == false)
                {
                    shoot2 = true;
                    PictureBox picbullet2 = new PictureBox();
                    bullet2 = new Bullet(tank2, tank2.pointDirection, ref picbullet2);
                    panel1.Controls.Add(picbullet2);
                    picbullet2.BringToFront();
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (onlinehost == true || online == false) { 
            //Czołg 1
                if (e.KeyCode == Keys.Up)
                {
                    tank1.keyTank[KUp] = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    tank1.keyTank[KRight] = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    tank1.keyTank[KDown] = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    tank1.keyTank[KLeft] = true;
                }
            }
            //Czołg 2
            if (onlinehost == false || online==false)
            {
                if (e.KeyCode == Keys.W)
                {
                    tank2.keyTank[KUp] = true;
                }
                if (e.KeyCode == Keys.D)
                {
                    tank2.keyTank[KRight] = true;
                }
                if (e.KeyCode == Keys.S)
                {
                    tank2.keyTank[KDown] = true;
                }
                if (e.KeyCode == Keys.A)
                {
                    tank2.keyTank[KLeft] = true;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                disconect = true;
                if (online)
                {
                    SocketConnect.SendTimer();
                    online = false;
                }
                Application.Restart();
            }
        }

        private void tank1timer_Tick(object sender, EventArgs e)
        {
            if (tank1.keyTank[KUp] == true)
                GameEngine.TankMove(tank1, KUp);
            if (tank1.keyTank[KRight] == true)
                GameEngine.TankMove(tank1, KRight);
            if (tank1.keyTank[KDown] == true)
                GameEngine.TankMove(tank1, KDown);
            if (tank1.keyTank[KLeft] == true)
                GameEngine.TankMove(tank1, KLeft);
            
            tank1Pic.Refresh();
        }
        private void tank2timer_Tick(object sender, EventArgs e)
        {
            if (tank2.keyTank[KUp] == true)
                GameEngine.TankMove(tank2, KUp);
            if (tank2.keyTank[KRight] == true)
                GameEngine.TankMove(tank2, KRight);
            if (tank2.keyTank[KDown] == true)
                GameEngine.TankMove(tank2, KDown);
            if (tank2.keyTank[KLeft] == true)
                GameEngine.TankMove(tank2, KLeft);

            tank2Pic.Refresh();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gre wykonał Damian TOMASIK", "Dziękuję za gre!");
            Application.Exit();
        }

        private void bulletstimer_Tick(object sender, EventArgs e)
        {
            if (shoot1 == true && GameEngine.BulletColission(bullet1.pointDirection, bullet1) == false)
            {
                bullet1.BulletMove();
            }

            
            
            if(shoot2 == true && GameEngine.BulletColission(bullet2.pointDirection, bullet2) == false)
            {
                bullet2.BulletMove();
            }
        }
    }
}
