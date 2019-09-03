using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    /// <summary>
    /// Magnus Marthinsen
    /// 822116289
    /// 11/30/2017
    /// </summary>
    public partial class WelcomeScreen : Form
    {
        /// <summary>
        /// The game controller
        /// </summary>
        Controller GameController { get; }

        /// <summary>
        /// Initializes the welcome screen
        /// </summary>
        /// <param name="gc"></param>
        public WelcomeScreen(Controller gc)
        {
            InitializeComponent();
            GameController = gc;
            ErrorMessage.Hide();
        }

        /// <summary>
        /// Loads the welcome screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WelcomeScreen_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the logic with starting a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            GameController.StartNewGame();
            this.Hide();
        }

        /// <summary>
        /// Handles logic for loading a game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGame_Click(object sender, EventArgs e)
        {
            ShowLoadDialog();
        }

        /// <summary>
        /// Displays the load dialox
        /// </summary>
        public void ShowLoadDialog()
        {
            DialogResult result;
            string filename;

            using (var fileChooser = new OpenFileDialog())
            {
                fileChooser.Filter = "Text|*.txt";
                result = fileChooser.ShowDialog();
                filename = fileChooser.FileName;
            }

            if (result == DialogResult.OK)
            {
                this.Hide();
                GameController.LoadGame(filename);
            }
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message"></param>
        public void DisplayErrorMessage(string message)
        {
            ErrorMessage.Text = message;
            ErrorMessage.Show();
        }

        /// <summary>
        /// Hides the error message.
        /// </summary>
        public void HideErrorMessage()
        {
            ErrorMessage.Hide();
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.StartNewGame();
            this.Hide();
        }

        /// <summary>
        /// Shows the load game interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoadDialog(); 
        }

        /// <summary>
        /// Displays the controls-window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls c = new Controls();
            c.Show();
        }

        /// <summary>
        /// Displays the about-box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        /// <summary>
        /// Quits the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.ExitApplication();
            Application.Exit();
        }
    }
}
