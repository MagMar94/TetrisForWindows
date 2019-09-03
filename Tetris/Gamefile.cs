using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tetris
{
    /// <summary>
    /// Magnus Marthinsen
    /// 822116289
    /// 12/1/2017
    /// 
    /// This gamefile is for storing the variables that should be stored from a game.
    /// </summary>
    class Gamefile
    {
        /// <summary>
        /// Gets or sets the board that gets saved
        /// </summary>
        public Grid Board { get; set; }

        /// <summary>
        /// Gets or sets the score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the total lines removed.
        /// </summary>
        public int RowsRemovedInTotal { get;  set; }

        /// <summary>
        /// Gets or sets the number of rows removed at current level.
        /// </summary>
        /// <value>The rows removed at current level.</value>
        public int RowsRemovedAtCurrentLevel { get;  set; }

        /// <summary>
        /// Creates an instance of the gamefile
        /// </summary>
        /// <param name="board"></param>
        public Gamefile(Grid board, int score, int level, int totalRowsRemoved, int rowsRemovedAtCurrentLevel)
        {
            Board = board;
            Score = score;
            Level = level;
            RowsRemovedInTotal = totalRowsRemoved;
            RowsRemovedAtCurrentLevel = rowsRemovedAtCurrentLevel;
        }

        /// <summary>
        /// Serializes the game with Json
        /// </summary>
        /// <returns></returns>
        public string SerializeGame()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Checks that the gamefiles are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Gamefile other)
            {
                return Board.Equals(other.Board) && Score == other.Score && Level == other.Level && RowsRemovedInTotal == other.RowsRemovedInTotal && RowsRemovedAtCurrentLevel == other.RowsRemovedAtCurrentLevel;
            }
            return false;
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the gamefile as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SerializeGame();
        }
    }
}
