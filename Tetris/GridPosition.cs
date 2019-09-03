using System;
namespace Tetris
{
    /// <summary>
    /// Grid position.
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 10/30/2017
    /// </summary>
    public class GridPosition
    {
        /// <summary>
        /// The row.
        /// </summary>
        private int row;
        /// <summary>
        /// The column.
        /// </summary>
        private int column;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.GridPosition"/> class.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="column">Column.</param>
        public GridPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.GridPosition"/> class.
        /// </summary>
        /// <param name="position">Position.</param>
        public GridPosition(GridPosition position){
            Row = position.Row;
            Column = position.Column;
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        /// <value>The row.</value>
        public int Row{
            get
            {
                return row;
            }
            private set{
                if (0 <= value && value < Grid.GRIDHEIGHT)
                {
                    row = value;
                } 
                else 
                {
                    row = 0;
                }
            }
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        /// <value>The column.</value>
        public int Column{
            get
            {
                return column;
            }
            private set{
                if (-3 <= value && value < Grid.GRIDWIDTH)
                {
                    column = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(value)} must be greater or equal to zero, and smaller than the width of the grid.");
                } 
            }
        }

        /// <summary>
        /// Checks if two grispositions are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is GridPosition other)
            {
                return row == other.Row && column == other.Column;
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
        /// Returns the position as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}";
        }
    }
}
