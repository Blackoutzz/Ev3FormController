using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace EV3Controller
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static Form1 Controller;
        static Brick EV3;
        static Task Work;
        static bool Connected;
        [STAThread]
        static void Main()
        {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                   // Controller = new Form1();
                    //Controller.ShowDialog();

        }
        

    }

}
