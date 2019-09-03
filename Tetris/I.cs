using System;
namespace Tetris
{
    /// <summary>
    /// The I-shape. 
    /// 
    /// Magnus Marthinsen
    /// 822116289
    /// 10/30/2017
    /// </summary>
    public class I : Tetromino
    {
        /// <summary>
        /// The shape.
        /// </summary>
        private readonly int[,,] shape;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.I"/> class.
        /// </summary>
        /// <param name="color">Color.</param>
        public I(int color) : base(color)
        {
            shape = new int[4, 4, 4];

            //The first rotation
            for (int column = 0; column < 4; ++column){
                shape[0, 1, column] = color;
            }

            //The second rotation
            for (int row = 0; row < 4; ++row)
            {
                shape[1, row, 1] = color;
            }

            //The third rotation
            for (int column = 0; column < 4; ++column)
            {
                shape[2, 2, column] = color;
            }

            //The fourth rotation
            for (int row = 0; row < 4; ++row)
            {
                shape[3, row, 2] = color;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tetris.I"/> class.
        /// </summary>
        /// <param name="tetromino">Tetromino.</param>
        public I(I tetromino) : base(tetromino.Color)
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
