using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Czołgi_v0_5
{
    static class SocketConnect
    {
        
        public static string serverIp = Dns.GetHostName();
        public static IPAddress iphost = Dns.GetHostEntry(serverIp).AddressList[0];
        public static string dnsClient;
        public static int port;
        public static TcpListener server = new TcpListener(iphost, 8080);
        public static TcpClient client = default(TcpClient);
        public static ManualResetEvent connectDone =new ManualResetEvent(false);


        public static void HostTimer()
        {
            client = server.AcceptTcpClient();
            byte[] receivedBuff = new byte[6];
            NetworkStream stream = client.GetStream();

                stream.Read(receivedBuff, 0, 6);


            for (int i = 0; i < 4; i++)
            {
                if (receivedBuff[i] == 1)
                {
                    if (Form1.onlinehost)
                        Form1.tank2.keyTank[i] = true;
                    if (!Form1.onlinehost)
                        Form1.tank1.keyTank[i] = true;
                }
                if (receivedBuff[i] == 0)
                {
                    if (Form1.onlinehost)
                        Form1.tank2.keyTank[i] = false;
                    if (!Form1.onlinehost)
                        Form1.tank1.keyTank[i] = false;
                }
            }
            if (receivedBuff[4] == 1)
            {
                if (!Form1.onlinehost && Form1.shoot1 == false && Form1.tank1.isDestroyed == false)
                {
                    PictureBox picbullet1 = new PictureBox();
                    Form1.bullet1 = new Bullet(Form1.tank1, Form1.tank1.pointDirection, ref picbullet1);
                    Form1.panel1.Controls.Add(picbullet1);
                    picbullet1.BringToFront();
                    Form1.shoot1 = true;
                }
                if (Form1.onlinehost && Form1.shoot2 == false && Form1.tank2.isDestroyed == false)
                {
                    PictureBox picbullet2 = new PictureBox();
                    Form1.bullet2 = new Bullet(Form1.tank2, Form1.tank2.pointDirection, ref picbullet2);
                    Form1.panel1.Controls.Add(picbullet2);
                    picbullet2.BringToFront();
                    Form1.shoot2 = true;
                }
            }
            if (receivedBuff[5] == 1)
            {
                Form1.Timers_off();
                MessageBox.Show("Partner się rozłączył. Restartuje gre.", "OJOJ!");
                Application.Restart();
            }
        }
        static public void SendTimer()
        {
            try
            {
                try
                {
                    client = new TcpClient(dnsClient, port);
                }catch(SocketException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                

                byte[] sendData = new byte[6];
                sendData[Form1.KUp] = 0;
                sendData[Form1.KRight] = 0;
                sendData[Form1.KDown] = 0;
                sendData[Form1.KLeft] = 0;
                sendData[4] = 0;
                sendData[5] = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (Form1.tank1.keyTank[i] == true && Form1.onlinehost)
                        sendData[i] = 1;
                    if (Form1.tank2.keyTank[i] == true && !Form1.onlinehost)
                        sendData[i] = 1;
                }
                if (Form1.shoot2 == true && Form1.tank2.isDestroyed == false && !Form1.onlinehost)
                {
                    sendData[4] = 1;
                }
                if (Form1.shoot1 == true && Form1.tank1.isDestroyed == false && Form1.onlinehost)
                {
                    sendData[4] = 1;
                }
                if (Form1.disconect == true)
                {
                    sendData[5] = 1;
                }


                NetworkStream stream = SocketConnect.client.GetStream();


                stream.Write(sendData, 0, 6);
                stream.Close();
                client.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static public void HostClientStart(int port1, int port2, bool isHost)
        {
            dnsClient = Form1.secondIP.Text;
            Console.WriteLine(dnsClient);
            Form1.secondIP.Enabled = false;
            Form1.secondIP.Visible = false;
            Form1.ipLabel.Enabled = false;
            Form1.ipLabel.Visible = false;
            server = new TcpListener(SocketConnect.iphost, port2);
            port = port1;
            Form1.onlinehost = isHost;
            try
            {
                SocketConnect.server.Start();
                Console.WriteLine("Server started");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
