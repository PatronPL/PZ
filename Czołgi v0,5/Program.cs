using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Czołgi_v0_5
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GameEngine gameEngine = new GameEngine();
            Form1 formaGra = new Form1();
            Application.EnableVisualStyles();
            Application.Run(formaGra);
        }
    }
}
