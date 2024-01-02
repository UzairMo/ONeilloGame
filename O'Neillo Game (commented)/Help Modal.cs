using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONeilloGame
{
    /// <summary>
    /// Represents a modal dialog providing information.
    /// </summary>
    public partial class HelpModal : Form
    {
        public HelpModal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the Help Modal.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the Help Modal.
        }
    }
}
