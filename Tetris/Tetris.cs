using System;
using System.Threading;

namespace Tetris
{
    /// <summary>
    /// Tetris.
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 11/06/2017
    /// </summary>
    public class Tetris
    {
        /// <summary>
        /// The controller that mangages the interaction between the model and the user interface.
        /// </summary>
        public Controller GameController { get; set; } 

        /// <summary>
        /// Gets the score.
        /// </summary>
        /// <value>The score.</value>
        public int Score { get; private set; }

        /// <summary>
        /// The grid.
        /// </summary>
        public Grid Fieldgrid { get; private set; }

        /// <summary>
        /// The active tetromino.
        /// </summary>
        public Tetromino ActiveTetromino { get; private set; }

        /// <summary>
        /// The next tetromino the user will get.
        /// </summary>
        public Tetromino NextTetromino { get; private set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public int Level { get; private set; }

        /// <summary>
        /// Indicates if it is game over (true) or not (false).
        /// </summary>
        public bool GameIsOver { get; private set; }

        /// <summary>
        /// Gets or sets the total lines removed.
        /// </summary>
        public int RowsRemovedInTotal { get; private set; }

        /// <summary>
        /// Gets or sets the number of rows removed at current level.
        /// </summary>
        /// <value>The rows removed at current level.</value>
        public int RowsRemovedAtCurrentLevel { get; private set; }

        /// <summary>
        /// Tells if the game is paused (true) or not (false).
        /// </summary>
        public bool Paused { get; private set; }

        /// <summary>
        /// Gets the random generator.
        /// </summary>
        /// <value>The random generator.</value>
        public static Random RandomGenerator { get; private set; }

        /// <summary>
        /// Gets the moving tetromino.
        /// </summary>
        /// <remarks>
        /// Source:
        /// https://msdn.microsoft.com/en-us/library/system.threading.mutex(v=vs.110).aspx
        /// </remarks>
        /// <value>The moving tetromino.</value>
        private Mutex MovingTetrominoMutex { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.Tetris"/> class.
        /// </summary>
        public Tetris()
        {
            Level = 1;
            Fieldgrid = new Grid();
            RandomGenerator = new Random();
            MovingTetrominoMutex = new Mutex();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.Tetris"/> class.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="level"></param>
        /// <param name="rowsRemovedInTotal"></param>
        /// <param name="rowsRemovedAtLevel"></param>
        public Tetris(Grid grid, int level, int score, int rowsRemovedInTotal, int rowsRemovedAtLevel)
        {
            Fieldgrid = grid;
            Level = level;
            RowsRemovedInTotal = rowsRemovedInTotal;
            RowsRemovedAtCurrentLevel = rowsRemovedAtLevel;
            Score = score;

            RandomGenerator = new Random();
            MovingTetrominoMutex = new Mutex();
        }

        /// <summary>
        /// Plays the game.
        /// </summary>
        public void PlayGame(){
            NextTetromino = GenerateNewRandomTetromino();
            do
            {
                ActiveTetromino = NextTetromino;
                NextTetromino = GenerateNewRandomTetromino();
                GameController.RefreshUserInterface();
                GameController.DisplayNexTetromino();
                if (Fieldgrid.IsLegalPosition(ActiveTetromino)){
                    Thread tetrominoDownMover = new Thread(MoveTetrominoDown);
                    tetrominoDownMover.IsBackground = true; //makes sure the thread gets killed on application exit
                    tetrominoDownMover.Start();
                    while (!ActiveTetromino.IsLockedInPlace)
                    {
                        //wait until active tetromino is locked in place
                    }
                    int rowsRemoved = Fieldgrid.RemoveFullRows();
                    CalculateScore(rowsRemoved);
                    RowsRemovedAtCurrentLevel += rowsRemoved;
                    RowsRemovedInTotal += rowsRemoved;
                    GameController.UpdateLineCount();
                    ManageLevel();
                } else {
                    GameIsOver = true;
                    ActiveTetromino = null;
                }
            } while (!GameIsOver);
            GameController.GameOver();
        }

        /// <summary>
        /// Moves the active tetromino to the right if it is possible.
        /// </summary>
        public void MoveActiveTetrminoToTheRightIfPossible()
        {
            if (!Paused)
            {
                MovingTetrominoMutex.WaitOne();
                if (ActiveTetromino != null)
                    ActiveTetromino.MoveToTheRightIfPossible(Fieldgrid);
                MovingTetrominoMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Moves the active tetromino to the left if it is possible.
        /// </summary>
        public void MoveActiveTetrominoToTheLeftIsPossible()
        {
            if (!Paused)
            {
                MovingTetrominoMutex.WaitOne();
                if (ActiveTetromino != null)
                    ActiveTetromino.MoveToTheLeftIfPossible(Fieldgrid);
                MovingTetrominoMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Rotates the active tetromino to the right if it is possible.
        /// </summary>
        public void RotatActiveTetrominoToTheRightIfPossible()
        {
            if (!Paused)
            {
                MovingTetrominoMutex.WaitOne();
                if (ActiveTetromino != null)
                    ActiveTetromino.RotateRightIfPossible(Fieldgrid);
                MovingTetrominoMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Rotates the active tetromino to the left if it is possible.
        /// </summary>
        public void RotatActiveTetrominoToTheLeftIfPossible()
        {
            if (!Paused)
            {
                MovingTetrominoMutex.WaitOne();
                if (ActiveTetromino != null)
                    ActiveTetromino.RotateLeftIfPossible(Fieldgrid);
                MovingTetrominoMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Moves the active tetromino one down if it is possible.
        /// </summary>
        public void MoveActiveTetrominoOneDownIfPossible()
        {
            if (!Paused)
            {
                MovingTetrominoMutex.WaitOne();
                if (ActiveTetromino != null)
                    ActiveTetromino.MoveDownIfPossible(Fieldgrid);
                MovingTetrominoMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Drops the active tetromino all the way down and locks it in place.
        /// </summary>
        public void DropActiveTetromino()
        {
            if (!Paused)
            {
                MovingTetrominoMutex.WaitOne();
                if (ActiveTetromino != null)
                    ActiveTetromino.DropDown(Fieldgrid);
                MovingTetrominoMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void PauseGame()
        {
            MovingTetrominoMutex.WaitOne();
            Paused = true;
        }

        /// <summary>
        /// Contineus the game.
        /// </summary>
        public void ResumeGame()
        {
            Paused = false;
            MovingTetrominoMutex.ReleaseMutex();
        }

        /// <summary>
        /// Increases the level
        /// </summary>
        public void IncreaseLevel()
        {
            Level = ++Level;
        }

        /// <summary>
        /// Generates a new random tetromino.
        /// </summary>
        /// <returns>The new random tetromino.</returns>
        private Tetromino GenerateNewRandomTetromino()
        {
            int nextRandomTetromino = RandomGenerator.Next(7);
            switch (nextRandomTetromino)
            {
                case 0:
                    return new I(1);
                case 1:
                    return new J(2);
                case 2:
                    return new L(3);
                case 3:
                    return new O(4);
                case 4:
                    return new S(5);
                case 5:
                    return new T(6);
                case 6:
                    return new Z(7);
                default:
                    throw new IndexOutOfRangeException("The random value gave something unexpected.");
            }
        }

        /// <summary>
        /// Calculates the score.
        /// </summary>
        /// <param name="numberOfRowsRemoved">Number of rows removed.</param>
        private void CalculateScore(int numberOfRowsRemoved){
            if(0 < numberOfRowsRemoved){
                Score += (numberOfRowsRemoved * 100 + (numberOfRowsRemoved-1)*50) * Level;
                GameController.UpdateScore();
            }
        }

        /// <summary>
        /// Manages the level.
        /// </summary>
        private void ManageLevel(){
            if (10 <= RowsRemovedAtCurrentLevel)
            {
                Level = ++Level;
                RowsRemovedAtCurrentLevel = 0;
                GameController.UpdateLevel();
            }
        }

        /// <summary>
        /// Moves the tetromino down.
        /// </summary>
        /// <remarks>
        /// This method is used by a thread. It needs its own copy of the reference to the
        /// tetromino, because the only time this thread stops is when the 
        /// tetromino cant move any further. If the tetromino is dropped all 
        /// the way at once (space bar), it will generate a new active tetromino. 
        /// This will get its own thread, and now two threads are working on the 
        /// same tetromino. 
        /// </remarks>
        private void MoveTetrominoDown(){
            Tetromino tet = ActiveTetromino;
            Thread.Sleep((int)(500 * Math.Pow(0.75, Level-1)));
            MovingTetrominoMutex.WaitOne();
            while (tet != null && !Fieldgrid.IsCollisionBelow(tet))
            {
                tet.MoveDownIfPossible(Fieldgrid);
                MovingTetrominoMutex.ReleaseMutex();
                GameController.RefreshUserInterface();
                Thread.Sleep((int)(500 * Math.Pow(0.75, Level-1)));
                MovingTetrominoMutex.WaitOne();
            }
            if(tet != null && !tet.IsLockedInPlace)
                Fieldgrid.PlaceOnGrid(tet);
            MovingTetrominoMutex.ReleaseMutex();
            GameController.RefreshUserInterface();
        }

        /// <summary>
        /// Compares two tetris games
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Tetris other)
            {
                Gamefile game1 = new Gamefile(Fieldgrid, Score, Level, RowsRemovedInTotal, RowsRemovedAtCurrentLevel);
                Gamefile game2 = new Gamefile(other.Fieldgrid, other.Score, other.Level, other.RowsRemovedInTotal, other.RowsRemovedAtCurrentLevel);
                return game1.Equals(game2);
            }
            return false;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the game on a string form.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Gamefile game = new Gamefile(Fieldgrid, Score, Level, RowsRemovedInTotal, RowsRemovedAtCurrentLevel);
            return game.ToString();
        }
    }
}
