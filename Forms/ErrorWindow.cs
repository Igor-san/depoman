using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DepoMan.Forms
{
    public partial class ErrorWindow : Form
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        public ErrorWindow(string errorMessage, string buttonText)
            : this()
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                tbErrorMessage.Text = errorMessage;
            }
            if (!string.IsNullOrEmpty(buttonText))
            {
                buttonAppClose.Text = buttonText;
            }
        }

    }
}
