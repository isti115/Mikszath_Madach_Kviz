using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mikszath_Madach_Kviz_2
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void helpForm_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("help.txt", Encoding.Default);

            helpTextLabel.Text = sr.ReadToEnd();

            sr.Close();
        }
    }
}
