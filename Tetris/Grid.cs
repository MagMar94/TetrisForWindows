using System;
using System.Collections;
using Newtonsoft.Json;

namespace Tetris
{
    /// <summary>
    /// Grid. Row 0 is the row at the bottom, Column 0 is the column on the left side of the screen.
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 10/30/2017
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// The width of the grid.
        /// </summary>
        public const int GRIDWIDTH = 10;
        /// <summary>
        /// The height og the grid.
        /// </summary>
        public const int GRIDHEIGHT = 16;

        /// <summary>
        /// Gets or sets the playing field.
        /// </summary>
        /// <value>The field.</value>
        private int[,] field;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.Grid"/> class.
        /// </summary>
        public Grid()
        {
            Field = new int[GRIDHEIGHT, GRIDWIDTH];
        }

        /// <summary>
        ///Gets or Sets the field
        /// </summary>
        public int[,] Field
        {
            get
            {
                return field;
            }
            set
            {
                if (value.GetLength(0) == GRIDHEIGHT && value.GetLength(1) == GRIDWIDTH)
                {
                    bool allValuesAreValid = true;
                    for(int row = 0; row < GRIDHEIGHT && allValuesAreValid; ++row)
                    {
                        for(int column = 0; column < GRIDWIDTH && allValuesAreValid; ++column)
                        {
                            if(value[row,column] < 0 || value[row,column] > 7)
                            {
                                allValuesAreValid = false;
                            }
                        }
                    }
                    if (allValuesAreValid)
                    {
                        field = value;
                    }
                }    
            }
        }

        /// <summary>
        /// Generates a random startposition.
        /// </summary>
        /// <returns></returns>
        public static GridPosition GetRandomStartPosition()
        {
            int column = Tetris.RandomGenerator.Next(GRIDWIDTH - 3);
            return new GridPosition(0, column);
        }

        /// <summary>
        /// Places the tetromino on the grid if it is not placed allready.
        /// </summary>
        /// <param name="tetromino">Tetromino.</param>
        public void PlaceOnGrid(Tetromino tetromino)
        {
            if (!tetromino.IsLockedInPlace)
            {
                GridPosition position = tetromino.AnchorPosition;
                for (int row = 0; row < tetromino.GetRowCount(); ++row)
                {
                    for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                    {
                        if (tetromino.Shape[tetromino.Rotation, row, column] != 0)
                        {
                            Field[position.Row + row, position.Column + column] = tetromino.Color;
                        }
                    }
                }
                tetromino.IsLockedInPlace = true;
            }
        }

        /// <summary>
        /// Gets the value from the position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int GetValueFromPosition(GridPosition pos)
        {
            return Field[pos.Row, pos.Column];
        }

        /// <summary>
        /// Removes the full rows.
        /// </summary>
        /// <returns>The numbers of rows that got removed.</returns>
        public int RemoveFullRows(){
            int[] fullRows = FindFullRows();
            for (int row = 0; row < fullRows.Length; ++row){
                RemoveRowWithRowsAboveFalling(fullRows[row]);
            }
            return fullRows.Length;
        }

        /// <summary>
        /// Finds the full rows.
        /// </summary>
        /// <returns>The full rows.</returns>
        private int[] FindFullRows(){
            int[] fullRows = new int[GRIDWIDTH];
            int index = 0;

            for (int row = 0; row < GRIDHEIGHT; ++row)
            {
                int column = 0;
                while (column < GRIDWIDTH && Field[row, column] != 0)
                {
                    ++column;
                }
                if(column == GRIDWIDTH)
                {
                    fullRows[index] = row;
                    ++index;
                }
            }
            return RemoveElementsAfterIndex(fullRows, index);
        }

        /// <summary>
        /// Removes the index of the elements after.
        /// </summary>
        /// <returns>The elements after index.</returns>
        /// <param name="array">Array.</param>
        /// <param name="index">Index.</param>
        private int[] RemoveElementsAfterIndex(int[] array, int index){
            int[] newArray = new int[index];
            for (int i = 0; i < index; ++i){
                newArray[i] = array[i];
            }
            return newArray;
        }

        /// <summary>
        /// Removes the row. All lines above fall one row down as a result.
        /// </summary>
        /// <param name="row">Row.</param>
        private void RemoveRowWithRowsAboveFalling(int row){
            if (0 <= row && row < Grid.GRIDHEIGHT){
                while(row > 0){
                    CopyRowAbove(row);
                    --row;
                }
                DeleteTopRow();
            } else {
                throw new ArgumentOutOfRangeException(nameof(row), row, $"{nameof(row)} must be greater or equal to zero, and smaller than the height of the grid.");
            }
        }

        /// <summary>
        /// Copies the row above.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the row is he first row or if it is not a part of the grid.</exception>
        private void CopyRowAbove(int row){
            if(row == 0 || GRIDHEIGHT <= row){
                throw new ArgumentOutOfRangeException(nameof(row), row, "The row has to be on the grid, and can not be the first row.");
            }
            for (int column = 0; column < GRIDWIDTH; ++column)
            {
                Field[row, column] = Field[row -1, column];
            }
        }

        /// <summary>
        /// Deletes the top row.
        /// </summary>
        private void DeleteTopRow(){
            for (int column = 0; column < GRIDWIDTH; ++column)
            {
                Field[0, column] = 0;
            }
        }

        /// <summary>
        /// Checks that the position is legal.
        /// </summary>
        /// <returns><c>true</c>, if legal position was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsLegalPosition(Tetromino tetromino){
            return IsWithingGrid(tetromino) && !IsPlacedInOccupiedPosition(tetromino);
        }

        /// <summary>
        /// Checks if tetromino is outside of the grid.
        /// </summary>
        /// <returns><c>true</c>, if withing grid, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        private bool IsWithingGrid(Tetromino tetromino){
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && (tetromino.AnchorPosition.Column+column < 0 || GRIDWIDTH <= tetromino.AnchorPosition.Column + column || tetromino.AnchorPosition.Row + row < 0 || GRIDHEIGHT <= tetromino.AnchorPosition.Row + row))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Detects if the tetromino is placed in an allready occupied position.
        /// </summary>
        /// <returns><c>true</c>, if placed in occupied position, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        private bool IsPlacedInOccupiedPosition(Tetromino tetromino){
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && 0 <= tetromino.AnchorPosition.Column + column && tetromino.AnchorPosition.Column + column < GRIDWIDTH && 0 <= tetromino.AnchorPosition.Row + row && tetromino.AnchorPosition.Row + row < GRIDHEIGHT && Field[tetromino.AnchorPosition.Row+row, tetromino.AnchorPosition.Column + column] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if there is some sort of collision to the right. That includes the edge and other tetrominos.
        /// </summary>
        /// <returns><c>true</c>, if collision to the right was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsCollisionToTheRight(Tetromino tetromino){
            return IsAtRightEdge(tetromino) || IsInterferingTetrominoToTheRight(tetromino);
        }

        /// <summary>
        /// Checks if the tetromino will go outside the grid to the right if it gets moved by one.
        /// </summary>
        /// <returns><c>true</c>, if collision at the right edge was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsAtRightEdge(Tetromino tetromino){
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row){
                for (int column = 0; column < tetromino.GetColumnCount(); ++column){
                    if(tetromino.Shape[tetromino.Rotation,row,column] != 0 && GRIDWIDTH <= column + position.Column + 1){
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if is is a tetromino to the right that makes it impossible to move that way.
        /// </summary>
        /// <returns><c>true</c>, if interfering tetromino to the rgiht was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino that wants to move to the right.</param>
        private bool IsInterferingTetrominoToTheRight(Tetromino tetromino){
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && 0 <= (position.Column + column + 1) && (position.Column + column + 1) < GRIDWIDTH && 0 <= position.Row + row && position.Row + row < GRIDHEIGHT && Field[position.Row + row, position.Column + column + 1] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if there is some sort of collision to the left. That includes the edge and other tetrominos.
        /// </summary>
        /// <returns><c>true</c>, if collision at the left edge was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsCollisionToTheLeft(Tetromino tetromino){
            return IsAtLeftEdge(tetromino) || IsInterferingTetrominoToTheLeft(tetromino);
        }

        /// <summary>
        /// Checks if the tetromino will go outside the grid to the left if it gets moved by one.
        /// </summary>
        /// <returns><c>true</c>, if at left edte was ised, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsAtLeftEdge(Tetromino tetromino){
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && column + position.Column - 1 < 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if is is a tetromino to the left that makes it impossible to move that way.
        /// </summary>
        /// <returns><c>true</c>, if interfering tetromino to the left was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        private bool IsInterferingTetrominoToTheLeft(Tetromino tetromino){
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && 0 <= position.Row + row && position.Row + row < GRIDHEIGHT && 0 <= (position.Column + column - 1) && (position.Column + column - 1) < GRIDWIDTH && Field[position.Row + row, position.Column + column -1] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if there is some sort of collision below. That includes the edge of the field and other tetrominos.
        /// </summary>
        /// <returns><c>true</c>, if collision below was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsCollisionBelow(Tetromino tetromino){
            return IsAtBottomRow(tetromino) || IsInterferingTetrominoBelow(tetromino);
        }

        /// <summary>
        /// Checks if the tetromino will go outside the grid below if it gets moved by one.
        /// </summary>
        /// <returns><c>true</c>, if the tetromino is at the bottom, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsAtBottomRow(Tetromino tetromino){
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && GRIDHEIGHT <= row + position.Row + 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if is is a tetromino below makes it impossible to move that way.
        /// </summary>
        /// <returns><c>true</c>, if interfering tetromino below was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        private bool IsInterferingTetrominoBelow(Tetromino tetromino){
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && (position.Row + row + 1) < GRIDHEIGHT && 0 <= position.Column + column && position.Column + column < GRIDWIDTH && Field[position.Row + row + 1, position.Column + column] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if it is a collision one row above the tetromino.
        /// </summary>
        /// <returns><c>true</c>, if collision above was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsCollisionAbove(Tetromino tetromino){
            return IsAtTopRow(tetromino) || IsInterferingTetrominoAbove(tetromino);
        }

        /// <summary>
        /// Checks if the tetromino is at top row.
        /// </summary>
        /// <returns><c>true</c>, if collision at top row was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        public bool IsAtTopRow(Tetromino tetromino)
        {
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && row + position.Row - 1 < 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if it is an interfering tetromino above.
        /// </summary>
        /// <returns><c>true</c>, if interfering tetromino above was detected, <c>false</c> otherwise.</returns>
        /// <param name="tetromino">Tetromino.</param>
        private bool IsInterferingTetrominoAbove(Tetromino tetromino)
        {
            GridPosition position = tetromino.AnchorPosition;
            for (int row = 0; row < tetromino.GetRowCount(); ++row)
            {
                for (int column = 0; column < tetromino.GetColumnCount(); ++column)
                {
                    if (tetromino.Shape[tetromino.Rotation, row, column] != 0 && row + position.Row - 1 < 0 && Field[position.Row + row - 1, position.Column + column] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if two grids are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Grid other)
            {
                return other.ToString().Equals(this.ToString());
            }
            return false;
        }

        /// <summary>
        /// Returns the grid as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string grid = "";
            for (int row = 0; row < GRIDHEIGHT; ++row)
            {
                grid = $"[{grid}";
                for (int column = 0; column < GRIDWIDTH; ++column)
                {
                    grid = $"{grid}, {Field[row, column]}";
                }
                grid = $"{grid}]\n";
            }
            return grid;
        }

        /// <summary>
        /// gets the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
