using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller gameController = new Controller();

            WelcomeScreen ws = new WelcomeScreen(gameController);
            gameController.BaseUserInterface = ws;
            Application.Run(ws);

        }
    }
}
