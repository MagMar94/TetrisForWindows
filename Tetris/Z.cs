using System;
namespace Tetris
{
    /// <summary>
    /// Z.
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 10/30/2017
    /// </summary>
    public class Z : Tetromino
    {
        /// <summary>
        /// The shape.
        /// </summary>
        private readonly int[,,] shape;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.Z"/> class.
        /// </summary>
        public Z(int color) : base(color)
        {
            shape = new int[4,4,4];

            //The first rotation
            shape[0, 1, 0] = color;
            shape[0, 1, 1] = color;
            shape[0, 2, 1] = color;
            shape[0, 2, 2] = color;

            //The second rotation
            shape[1, 1, 2] = color;
            shape[1, 2, 1] = color;
            shape[1, 2, 2] = color;
            shape[1, 3, 1] = color;

            //The third rotation
            shape[2, 1, 1] = color;
            shape[2, 1, 2] = color;
            shape[2, 2, 2] = color;
            shape[2, 2, 3] = color;

            //The fourth rotation
            shape[3, 1, 3] = color;
            shape[3, 2, 2] = color;
            shape[3, 2, 3] = color;
            shape[3, 3, 2] = color;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.Z"/> class.
        /// </summary>
        /// <param name="tetromino">Tetromino.</param>
        public Z(Z tetromino) : base(tetromino.Color)
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
