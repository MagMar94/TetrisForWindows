using System;
namespace Tetris
{
    /// <summary>
    /// O.
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 10/30/2017
    /// </summary>
    public class O : Tetromino
    {
        /// <summary>
        /// The shape.
        /// </summary>
        private readonly int[,,] shape;

       /// <summary>
       /// Initializes a new instance of the <see cref="T:Tetris.O"/> class.
       /// </summary>
       /// <param name="color">Color.</param>
        public O(int color) : base(color)
        {
            shape = new int[4, 4, 4];

            for (int orientation = 0; orientation < 4; ++orientation)
            {
                for (int row = 1; row < 3; ++row)
                {
                    for (int column = 1; column < 3; ++column)
                    {
                        shape[orientation,row, column] = color;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.O"/> class.
        /// </summary>
        /// <param name="tetromino">Tetromino.</param>
        public O(O tetromino) : base(tetromino.Color)
        {
            shape = tetromino.Shape;
        }

        /// <summary>
        /// Gets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public override int[,,] Shape => shape;

        /// <summary>
        /// Checks if two tetrominos are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
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
        /// Returns the tetromino as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
