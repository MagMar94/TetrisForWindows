using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tetris
{
    /// <summary>
    /// The controller manages the interaction between the user interface and the model.
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 10/30/2017
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// The welcome screen
        /// </summary>
        public WelcomeScreen BaseUserInterface { get; set; }

        /// <summary>
        /// The game user interface
        /// </summary>
        private TetrisGUI GameUserIterface { get; set; }

        /// <summary>
        /// The model
        /// </summary>
        private Tetris Model { get; set; }

        /// <summary>
        /// The all time high score
        /// </summary>
        public int AllTimeHighScore { get; private set; }

        /// <summary>
        /// The next tetromino
        /// </summary>
        public Tetromino NextTetromino { get; private set; }

        /// <summary>
        /// The thread that runs the model.
        /// </summary>
        private Thread game;

        /// <summary>
        /// A delegate that refreshes the screen
        /// </summary>
        delegate void RefreshScreen();

        /// <summary>
        /// A delegate the displays the game over screen
        /// </summary>
        delegate void ShowGameOverScreen();

        /// <summary>
        /// Constructor that initializes the user interface and the model.
        /// </summary>
        /// <param name="tetris"></param>
        /// <param name="UI"></param>
        public Controller()
        {
            AllTimeHighScore = FileManager.LoadHighScore();
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        public void StartNewGame()
        {
            KillGame();
            GameUserIterface = new TetrisGUI();
            Model = new Tetris();
            GameUserIterface.GameController = this;
            Model.GameController = this;

            game = new Thread(Model.PlayGame);
            GameUserIterface.Grid = Model.Fieldgrid;
            game.Start();
            
            GameUserIterface.ActiveTetromino = Model.ActiveTetromino;


            UpdateScore();
            UpdateLevel();
            UpdateLineCount();

            GameUserIterface.Show();
        }

        /// <summary>
        /// Loads a game and starts it.
        /// </summary>
        /// <param name="filename"></param>
        public void LoadGame(string filename)
        {
            GameUserIterface = new TetrisGUI();
            Model = FileManager.LoadGameFromFile(filename);
            if(Model != null)
            {
                KillGame();
                GameUserIterface.GameController = this;
                Model.GameController = this;

                game = new Thread(Model.PlayGame);
                GameUserIterface.Grid = Model.Fieldgrid;
                game.Start();
                GameUserIterface.ActiveTetromino = Model.ActiveTetromino;

                UpdateScore();
                UpdateLevel();
                UpdateLineCount();

                GameUserIterface.Show();
            } else
            {
                BaseUserInterface.Show();
                BaseUserInterface.DisplayErrorMessage("Game could not be loaded");
            }
        }

        /// <summary>
        /// Aborts the thread that runs the logic.
        /// </summary>
        public void KillGame()
        {
            if (game != null && game.IsAlive)
            {
                game.Abort();
            }
        }

        /// <summary>
        /// Rereshes the user interface.
        /// </summary>
        public void RefreshUserInterface()
        {
            GameUserIterface.ActiveTetromino = Model.ActiveTetromino;
            if (GameUserIterface.InvokeRequired)
            {
                RefreshScreen rs = new RefreshScreen(RefreshUserInterface);
                try
                {
                    GameUserIterface.Invoke(rs);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (ObjectDisposedException e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    //The program has exited, no point in updating the screen
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (System.ComponentModel.InvalidAsynchronousStateException e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    //The program has exited, no point in updating the screen
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    //General catch to catch other thread related errors that rarely happens and are hard to force.
                }
            }
            else
            {
                GameUserIterface.Refresh();
            }
        }

        /// <summary>
        /// Handles logic for right arrow key pressed.
        /// </summary>
        public void MoveTetrominoRight()
        {
            Model.MoveActiveTetrminoToTheRightIfPossible();
            GameUserIterface.ActiveTetromino = Model.ActiveTetromino;
            GameUserIterface.Refresh();
        }

        /// <summary>
        /// Handles logic for left arrow key pressed.
        /// </summary>
        public void MoveTetrominoLeft()
        {
            Model.MoveActiveTetrominoToTheLeftIsPossible();
            GameUserIterface.ActiveTetromino = Model.ActiveTetromino;
            GameUserIterface.Refresh();
        }

        /// <summary>
        /// Handle logic for up arrow key pressed.
        /// </summary>
        public void RotatTetrominoClockwise()
        {
            Model.RotatActiveTetrominoToTheRightIfPossible();
            GameUserIterface.ActiveTetromino = Model.ActiveTetromino;
            GameUserIterface.Refresh();
        }

        /// <summary>
        /// Handles logic for the down arrow key pressed.
        /// </summary>
        public void RotateTetrominoAnticlockwise()
        {
            Model.RotatActiveTetrominoToTheLeftIfPossible();
            GameUserIterface.ActiveTetromino = Model.ActiveTetromino;
            GameUserIterface.Refresh();
        }

        /// <summary>
        /// Handles logic for when the space bar is pressed.
        /// </summary>
        public void DropTetrominoAllTheWay()
        {
            Model.DropActiveTetromino();
            GameUserIterface.ActiveTetromino = Model.ActiveTetromino;
            GameUserIterface.Refresh();
        }

        /// <summary>
        /// Updates the displayed score
        /// </summary>
        /// <param name="points"></param>
        public void UpdateScore()
        {
            if(AllTimeHighScore < Model.Score)
            {
                AllTimeHighScore = Model.Score;
            }
            GameUserIterface.UpdateDisplayedScore(Model.Score.ToString());
        }

        /// <summary>
        /// Updates the displayed level.
        /// </summary>
        public void UpdateLevel()
        {
            GameUserIterface.UpdateDisplayedLevel(Model.Level.ToString());
        }

        /// <summary>
        /// Updates the displayed line count
        /// </summary>
        public void UpdateLineCount()
        {
            GameUserIterface.UpdateDisplayedLineCount(Model.RowsRemovedInTotal.ToString());
        }

        /// <summary>
        /// Pauses the game
        /// </summary>
        public void PauseGame()
        {
            Model.PauseGame();
            GameUserIterface.DisplayPauseMenu();
        }

        /// <summary>
        /// Resumes the game.
        /// </summary>
        public void ResumeGame()
        {
            Model.ResumeGame();
            GameUserIterface.HidePauseMenu();
        }

        /// <summary>
        /// Increases the level.
        /// </summary>
        public void IncreaseLevel()
        {
            Model.IncreaseLevel();
            GameUserIterface.UpdateDisplayedLevel(Model.Level.ToString());
        }

        /// <summary>
        /// Displays the next tetromino to the user.
        /// </summary>
        public void DisplayNexTetromino()
        {
            GameUserIterface.SetNextTetromino(Model.NextTetromino);
        }

        /// <summary>
        /// Returns if the game is paused (true) or not (false).
        /// </summary>
        /// <returns></returns>
        public bool GameIsPaused()
        {
            return Model.Paused;
        }

        /// <summary>
        /// Indicates if the game is over (true) or not (false).
        /// </summary>
        /// <returns></returns>
        public bool GameIsOver()
        {
            return Model.GameIsOver;
        }

        /// <summary>
        /// Saving the current game to file.
        /// </summary>
        /// <param name="filePathAndName"></param>
        public void SaveCurrentGame(string filePathAndName)
        {
            FileManager.SaveGameToFile(filePathAndName, Model);
        }

        /// <summary>
        /// Handles logic when Game Over occures.
        /// </summary>
        public void GameOver()
        {
            if (GameUserIterface.InvokeRequired)
            {
                ShowGameOverScreen go = new ShowGameOverScreen(GameUserIterface.DisplayGameOverScreen);
                try
                {
                    GameUserIterface.Invoke(go);
                }
                catch (ObjectDisposedException)
                {
                    //The program has exited
                }
            }
            else
            {
                GameUserIterface.DisplayGameOverScreen();
            }
        }

        /// <summary>
        /// Handles the logic that closes the application.
        /// </summary>
        public void ExitApplication()
        {
            FileManager.SaveHighscore(AllTimeHighScore);
            if(BaseUserInterface != null)
                BaseUserInterface.Close();
            if(game != null)
                game.Abort();
        }
    }
}
