using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tetris
{
    /// <summary>
    /// Graphical user interfase to represent the tetris game.
    /// </summary>
    public partial class TetrisGUI : Form
    {
        /// <summary>
        /// The controller that manages the interaction between the user interface and the model.
        /// </summary>
        public Controller GameController { get; set; }

        /// <summary>
        /// The colors used to represent the grid.
        /// </summary>
        Brush[] Colors { get; set; }
        /// <summary>
        /// The game grid
        /// </summary>
        public Grid Grid { private get; set; }

        /// <summary>
        /// The active tetromino¨since last time screen was refreshed.
        /// </summary>
        public Tetromino ActiveTetromino { private get; set; }

        /// <summary>
        /// The length of each square of the tetrominos.
        /// </summary>
        private int squareSideLength;
        /// <summary>
        /// The margin to the top
        /// </summary>
        private int topMargin;
        /// <summary>
        /// The margin to the left
        /// </summary>
        private int leftMargin;

        /// <summary>
        /// Creates a graphical user interface for the tetris game.
        /// </summary>
        /// <param name="grid"></param>
        public TetrisGUI()
        {
            InitializeComponent();
            PauseMenu.BackColor = Color.FromArgb(80, Color.White);
            GameOverPanel.BackColor = Color.FromArgb(80, Color.White);
            HidePauseMenu();
            HideGameOverScreen();

            playToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = true;

            KeyDown += new KeyEventHandler(Tetris_KeyDown);
            
            Colors = new Brush[]{ Brushes.Black, Brushes.Aqua, Brushes.Orange, Brushes.Blue, Brushes.Yellow, Brushes.Green, Brushes.Purple, Brushes.Red};

            squareSideLength = 30;
            topMargin = 30;
            leftMargin = 10;

            Score.Text = "-";
            Level.Text = "-";
            highScore.Text = "-";
        }

        /// <summary>
        /// Updates the score that is displayed to the user.
        /// </summary>
        /// <param name="points"></param>
        public void UpdateDisplayedScore(string points)
        {
            Score.Text = points;
            highScore.Text = GameController.AllTimeHighScore.ToString();
        }

        /// <summary>
        /// Updates the level that is displayed to the user.
        /// </summary>
        /// <param name="level"></param>
        public void UpdateDisplayedLevel(string level)
        {
            Level.Text = level;
        }

        /// <summary>
        /// Updates the line count that is displayed to the user.
        /// </summary>
        /// <param name="level"></param>
        public void UpdateDisplayedLineCount(string lineCount)
        {
            Lines.Text = lineCount;
        }

        /// <summary>
        /// Listens for event where key is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tetris_KeyDown(Object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    GameController.MoveTetrominoRight();
                    e.Handled = true;
                    break;
                case Keys.Left:
                    GameController.MoveTetrominoLeft();
                    e.Handled = true;
                    break;
                case Keys.Up:
                    GameController.RotatTetrominoClockwise();
                    e.Handled = true;
                    break;
                case Keys.Down:
                    GameController.RotateTetrominoAnticlockwise();
                    e.Handled = true;
                    break;
                case Keys.Space:
                    GameController.DropTetrominoAllTheWay();
                    e.Handled = true;
                    break;
                case Keys.Home:
                    GameController.IncreaseLevel();
                    break;
            }
        }

        /// <summary>
        /// Handles logic for when the pause button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseBtn_Click(object sender, EventArgs e)
        {
            if (GameController.GameIsPaused())
            {
                PauseBtn.Text = "Pause";
                GameController.ResumeGame();
            }
            else
            {
                PauseBtn.Text = "Resume";
                GameController.PauseGame();
            }
        }

        /// <summary>
        /// Raises the Paint Event. Calls paint grid.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            PaintGrid(e);
        }

        /// <summary>
        /// Handles things that must happen when the form closes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            GameController.ExitApplication();
            base.OnClosing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Paints the grid.
        /// </summary>
        /// <param name="e"></param>
        private void PaintGrid(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Pen somePen = new Pen(Color.Black))
            {
                for (int row = 0; row < Grid.GRIDHEIGHT; ++row)
                {
                    for (int column = 0; column < Grid.GRIDWIDTH; ++column)
                    {
                        int colorIndex = Grid.GetValueFromPosition(new GridPosition(row, column));
                        g.FillRectangle(Colors[colorIndex],leftMargin+column*squareSideLength, topMargin+row*squareSideLength, squareSideLength, squareSideLength);
                    }
                }
                for (int row = 0; row < Grid.GRIDHEIGHT; ++row)
                {
                    for (int column = 0; column < Grid.GRIDWIDTH; ++column)
                    {
                        int colorIndex = Grid.GetValueFromPosition(new GridPosition(row, column));
                        if (colorIndex != 0)
                        {
                            DrawEdges(topMargin + row * squareSideLength, leftMargin + column * squareSideLength, g);
                        }
                    }
                }
                if(ActiveTetromino != null)
                {
                    for (int row = 0; row < ActiveTetromino.GetRowCount(); ++row)
                    {
                        for (int column = 0; column < ActiveTetromino.GetColumnCount(); ++column)
                        {
                            if (ActiveTetromino.Shape[ActiveTetromino.Rotation, row, column] != 0)
                            {
                                g.FillRectangle(Colors[ActiveTetromino.Color], leftMargin + (ActiveTetromino.AnchorPosition.Column + column) * squareSideLength, topMargin + (ActiveTetromino.AnchorPosition.Row + row) * squareSideLength, squareSideLength, squareSideLength);
                                DrawEdges(topMargin + (ActiveTetromino.AnchorPosition.Row + row) * squareSideLength, leftMargin + (ActiveTetromino.AnchorPosition.Column + column) * squareSideLength, g);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the next tetromino.
        /// </summary>
        public void SetNextTetromino(Tetromino nextTetromino)
        {
            if(nextTetromino is I)
            {
                NextBlock.Image = Image.FromFile("../../Tetrominos/I.png");
            } else if (nextTetromino is J)
            {
                NextBlock.Image = Image.FromFile("../../Tetrominos/J.png");
            } else if (nextTetromino is L)
            {
                NextBlock.Image = Image.FromFile("../../Tetrominos/L.png");
            } else if (nextTetromino is O)
            {
                NextBlock.Image = Image.FromFile("../../Tetrominos/O.png");
            } else if (nextTetromino is S)
            {
                NextBlock.Image = Image.FromFile("../../Tetrominos/S.png");
            } else if (nextTetromino is T)
            {
                NextBlock.Image = Image.FromFile("../../Tetrominos/T.png");
            } else if (nextTetromino is Z)
            {
                NextBlock.Image = Image.FromFile("../../Tetrominos/Z.png");
            }
        }

        /// <summary>
        /// Draws edges around each square
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="g"></param>
        private void DrawEdges(int row, int column, Graphics g)
        {
            g.DrawLine(Pens.White, new Point(column, row), new Point(column + squareSideLength, row));
            g.DrawLine(Pens.White, new Point(column, row), new Point(column, row + squareSideLength));
            g.DrawLine(Pens.White, new Point(column, row + squareSideLength), new Point(column + squareSideLength, row + squareSideLength));
            g.DrawLine(Pens.White, new Point(column + squareSideLength, row), new Point(column + squareSideLength, row + squareSideLength));
        }

        /// <summary>
        /// Displays the pause menu.
        /// </summary>
        public void DisplayPauseMenu()
        {
            PauseMenu.Show();
            PauseMenu.Enabled = true;
            PauseBtn.Text = "Resume";
            playToolStripMenuItem.Enabled = true;
            pauseToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Hides the pause panel
        /// </summary>
        public void HidePauseMenu()
        {
            PauseMenu.Hide();
            PauseMenu.Enabled = false;
            PauseBtn.Text = "Pause";
            playToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Displays the game over screen
        /// </summary>
        public void DisplayGameOverScreen()
        {
            PauseBtn.Enabled = false;
            GameOverPanel.Show();
            GameOverPanel.Enabled = true;
            saveGameToolStripMenuItem.Enabled = false;
            playToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Hides the game over screen.
        /// </summary>
        public void HideGameOverScreen()
        {
            PauseBtn.Enabled = true;
            GameOverPanel.Hide();
            GameOverPanel.Enabled = false;
            saveGameToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Handles logic for when the save button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            ShowSaveDialog();
        }

        /// <summary>
        /// Handles logic for when the save button is clicked from menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.PauseGame();
            ShowSaveDialog();
        }

        /// <summary>
        /// displays the save dialog
        /// </summary>
        public void ShowSaveDialog()
        {
            DialogResult result;
            string filename;

            using (var fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;
                fileChooser.Filter = "Text|*.txt";
                fileChooser.Title = "Save a game.";
                result = fileChooser.ShowDialog();
                filename = fileChooser.FileName;
            }

            if(result == DialogResult.OK)
            {
                GameController.SaveCurrentGame(filename);
            }
        }

        /// <summary>
        /// Handles logic for when new game button is clicked from the game over menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            GameController.StartNewGame();
            this.Dispose();
        }

        /// <summary>
        /// Handles logic for when new game button is clicked from the pause menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameFromPauseBtn_Click(object sender, EventArgs e)
        {
            GameController.StartNewGame();
            this.Dispose();
        }

        /// <summary>
        /// Handles logic for when new game button is clicked from the menu strip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.StartNewGame();
            this.Dispose();
        }

        /// <summary>
        /// Handles logic for when load game button is clicked from the game over menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            ShowLoadDialog();
        }

        /// <summary>
        /// Handles logic for when load game button is clicked from the pause menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadgameFromPauseBtn_Click(object sender, EventArgs e)
        {
            ShowLoadDialog();
        }

        /// <summary>
        /// Handles logic for when load game button is clicked from the menu strip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameController.PauseGame();
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
                GameController.LoadGame(filename);
                this.Dispose();
            }
        }

        /// <summary>
        /// Handles logic from when the controls button is clicked from the menu strip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!GameController.GameIsOver())
                GameController.PauseGame();
            Controls controlWindow = new Controls();
            controlWindow.Show();
        }

        /// <summary>
        /// The about button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GameController.GameIsOver())
                GameController.PauseGame();
            About infoBox = new About();
            infoBox.Show();
        }

        /// <summary>
        /// Play the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GameController.GameIsPaused() && !GameController.GameIsOver())
            {
                GameController.ResumeGame();
            }
        }

        /// <summary>
        /// Pauses the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GameController.GameIsPaused() && !GameController.GameIsOver())
            {
                GameController.PauseGame();
            }
        }

        /// <summary>
        /// Quits the application
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
