using System;

namespace Tetris
{
    /// <summary>
    /// Tetromino.
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 10/30/2017
    /// </summary>
    public abstract class Tetromino
    {
        /// <summary>
        /// Gets or sets the anchor position. Is in the top left corner.
        /// </summary>
        /// <value>The anchor position.</value>
        public GridPosition AnchorPosition { get; protected set; }

        /// <summary>
        /// Gets the rotation value.
        /// </summary>
        /// <value>The rotation.</value>
        public int Rotation { get; protected set; }

        /// <summary>
        /// Gets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public abstract int[,,] Shape { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Tetris.Tetromino"/> is locked in place.
        /// </summary>
        /// <value><c>true</c> if is locked in place; otherwise, <c>false</c>.</value>
        public bool IsLockedInPlace { get; set; }

        /// <summary>
        /// The color.
        /// </summary>
        private readonly int color;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.Tetromino"/> class.
        /// </summary>
        /// <remarks>
        /// Calculates the default by taking half the gridsize and then two steps
        /// to the left. The reason for the two steps is that the anchor position 
        /// is top left, and every tetromino is 4 wide.
        /// </remarks>
        protected Tetromino(int color)
        {
            AnchorPosition = Grid.GetRandomStartPosition();
            Rotation = Tetris.RandomGenerator.Next(4);
            IsLockedInPlace = false;
            this.color = color;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>The color.</value>
        public int Color => color;

        /// <summary>
        /// Rotates to the right if it is possible. To do so, it does the rotation.
        /// It then cheks if it is coliding on the left side, right side, top or bottom.
        /// Then we try to move the tetromino the oposit direction to see if we get a 
        /// valid position.
        /// </summary>
        /// <param name="grid">The game grid</param>
        public void RotateRightIfPossible(Grid grid){
            Rotation = (Rotation + 1) % 4;
            if(!grid.IsLegalPosition(this)){
                bool collisionFixed = false;
                if (grid.IsCollisionToTheLeft(this))
                {
                    collisionFixed = FixLeftCollisionWhenRotating(grid);
                }
                else if (grid.IsCollisionToTheRight(this))
                {
                    collisionFixed = FixRightCollisionWhenRotating(grid);
                }
                if (!collisionFixed && grid.IsCollisionAbove(this))
                {
                    collisionFixed = FixTopCollisionWhenRotating(grid);
                }
                else if (!collisionFixed && grid.IsCollisionBelow(this))
                {
                    collisionFixed = FixBottomCollisionWhenRotating(grid);
                }
                if (!collisionFixed)
                {
                    RotateLeft();
                }
            }            
        }

        /// <summary>
        /// Rotates to the left if it is possible. To do so, it does the rotation.
        /// It then cheks if it is coliding on the left side, right side, top or bottom.
        /// Then we try to move the tetromino the oposit direction to see if we get a 
        /// valid position.
        /// </summary>
        /// <param name="grid">The game grid</param>
        public void RotateLeftIfPossible(Grid grid)
        {
            RotateLeft();
            if (!grid.IsLegalPosition(this))
            {
                bool collisionFixed = false;
                //if (grid.IsCollisionToTheLeft(this))
                if (grid.IsAtLeftEdge(this))
                {
                    collisionFixed = FixLeftCollisionWhenRotating(grid);
                }
                else if (grid.IsAtRightEdge(this))//(grid.IsCollisionToTheRight(this))
                {
                    collisionFixed = FixRightCollisionWhenRotating(grid);
                }
                if (!collisionFixed && grid.IsAtTopRow(this))//grid.IsCollisionAbove(this))
                {
                    collisionFixed = FixTopCollisionWhenRotating(grid);
                }
                else if (!collisionFixed && grid.IsAtBottomRow(this))//grid.IsCollisionBelow(this))
                {
                    collisionFixed = FixBottomCollisionWhenRotating(grid);
                }
                if (!collisionFixed)
                {
                    Rotation = (Rotation + 1) % 4;
                }
            }
        }

        /// <summary>
        /// Tries to fix collision on the left side by going to the right. If it doesen't work, the rotation is reset.
        /// </summary>
        /// <returns><c>true</c>, if left collision when rotating was fixed, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        private bool FixLeftCollisionWhenRotating(Grid grid){
            int moveCounter = 0;
            GridPosition originalAnchorPosition = new GridPosition(AnchorPosition);
            while(!grid.IsLegalPosition(this) && grid.IsCollisionToTheLeft(this) && !grid.IsCollisionToTheRight(this) && moveCounter < 3){
                AnchorPosition = new GridPosition(AnchorPosition.Row, AnchorPosition.Column + 1);
                ++moveCounter;
            }
            if (!grid.IsLegalPosition(this)) //reset state to before rotation
            {
                AnchorPosition = originalAnchorPosition;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tries to fix collision on the right side by going one to the left. If it doesen't work, the rotation is reset.
        /// </summary>
        /// <param name="grid">Grid.</param>
        private bool FixRightCollisionWhenRotating(Grid grid)
        {
            int moveCounter = 0;
            GridPosition originalAnchorPosition = new GridPosition(AnchorPosition);
            while (!grid.IsLegalPosition(this) && grid.IsCollisionToTheRight(this) && !grid.IsCollisionToTheLeft(this) && moveCounter < 3)
            {
                AnchorPosition = new GridPosition(AnchorPosition.Row, AnchorPosition.Column - 1);
                ++moveCounter;
            }
            if (!grid.IsLegalPosition(this)) //reset state to before rotation
            {
                AnchorPosition = originalAnchorPosition;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Fixes the bottom collision when rotating by moving up. Goes up a maximmum of 2 rows.
        /// </summary>
        /// <param name="grid">Grid.</param>
        private bool FixBottomCollisionWhenRotating(Grid grid){
            int moveCounter = 0;
            GridPosition originalAnchorPosition = new GridPosition(AnchorPosition);
            while (!grid.IsLegalPosition(this) && grid.IsCollisionBelow(this) && !grid.IsCollisionAbove(this) && moveCounter < 3)
            {
                AnchorPosition = new GridPosition(AnchorPosition.Row-1, AnchorPosition.Column);
                ++moveCounter;
            }
            if (!grid.IsLegalPosition(this)) //reset state to before rotation
            {
                AnchorPosition = originalAnchorPosition;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Fixes top collision when rotating by moving down. Goes down a maximmum of 2 rows.
        /// </summary>
        /// <param name="grid">Grid.</param>
        private bool FixTopCollisionWhenRotating(Grid grid){
            int moveCounter = 0;
            GridPosition originalAnchorPosition = new GridPosition(AnchorPosition);
            while (!grid.IsLegalPosition(this) && grid.IsCollisionAbove(this) && !grid.IsCollisionBelow(this)&& moveCounter < 3)
            {
                AnchorPosition = new GridPosition(AnchorPosition.Row + 1, AnchorPosition.Column);
                ++moveCounter;
            }
            if (!grid.IsLegalPosition(this)) //reset state to before rotation
            {
                AnchorPosition = originalAnchorPosition;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Undoes the rotation.
        /// </summary>
        private void RotateLeft()
        {
            if (Rotation == 0)
            {
                Rotation = 3;
            }
            else
            {
                Rotation = --Rotation;
            }
        }

        /// <summary>
        /// Moves to the right if possible.
        /// </summary>
        /// <returns><c>true</c>, if the right move was successfull, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        public bool MoveToTheRightIfPossible(Grid grid){
            if(!grid.IsCollisionToTheRight(this)){
                AnchorPosition = new GridPosition(AnchorPosition.Row, AnchorPosition.Column + 1);
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Moves to the left if possible.
        /// </summary>
        /// <returns><c>true</c>, if the left move was successfull, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        public bool MoveToTheLeftIfPossible(Grid grid){
            if (!grid.IsCollisionToTheLeft(this))
            {
                AnchorPosition = new GridPosition(AnchorPosition.Row, AnchorPosition.Column - 1);
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Drops the tetromino all the way down.
        /// </summary>
        /// <param name="grid">Grid.</param>
        public void DropDown(Grid grid){
            bool successfullMove = true;
            while (successfullMove){
                successfullMove = MoveDownIfPossible(grid);
            }
            grid.PlaceOnGrid(this);
        }

        /// <summary>
        /// Moves down if possible.
        /// </summary>
        /// <returns><c>true</c>, if the down move was successfull, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        public bool MoveDownIfPossible(Grid grid){
            if(!grid.IsCollisionBelow(this)){
                AnchorPosition = new GridPosition(AnchorPosition.Row + 1, AnchorPosition.Column);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the row count.
        /// </summary>
        /// <returns>The row count.</returns>
        public int GetRowCount(){
            return Shape.GetLength(1);
        }

        /// <summary>
        /// Gets the column count.
        /// </summary>
        /// <returns>The column count.</returns>
        public int GetColumnCount(){
            return Shape.GetLength(2);
        }

        /// <summary>
        /// Gets the value from the position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int GetValueFromPosition(GridPosition pos)
        {
            return Shape[Rotation,pos.Row, pos.Column];
        }

        /// <summary>
        /// Checks if two tetrominos are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Tetromino other)
            {
                return other.ToString().Equals(this.ToString());
            }
            return false;
        }

        /// <summary>
        /// Gets the hash code for the object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the tetromino as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tetromino = "";
            for (int row = 0; row < GetRowCount(); ++row)
            {
                tetromino = $"[{tetromino}";
                for (int column = 0; column < GetColumnCount(); ++column)
                {
                    tetromino = $"{tetromino}, {Shape[0, row, column]}";
                }
                tetromino = $"{tetromino}]\n";
            }
            return tetromino;
        }
    }
}
