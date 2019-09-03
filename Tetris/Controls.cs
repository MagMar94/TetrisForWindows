using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    /// <summary>
    /// Magnus Marhtinsen
    /// 822116289
    /// 12/01/2017
    /// </summary>
    public partial class Controls : Form
    {
        /// <summary>
        /// Initializes the Controls window.
        /// </summary>
        public Controls()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles logic for the OK button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
