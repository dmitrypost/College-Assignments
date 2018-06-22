using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS358_Projects.Assignment_6
{
    public partial class TextBoxEx : MaskedTextBox
    {

        private string iniText;
        [Browsable(true)]
        [Category("Appearance")]
        public string InitialText { get {return iniText; } set { iniText = value; Text = value; } }
        public TextBoxEx()
        {
            InitializeComponent();

        }

        private void TextBoxEx_TextChanged(object sender, EventArgs e)
        {
            
            if (Text == InitialText)
            {
                ForeColor = Color.Gray;
            }
            else
            {
                ForeColor = Color.Black;
            }
        }

        private void TextBoxEx_Enter(object sender, EventArgs e)
        {
            if (Text == InitialText)
            {
                Text = "";
            }
            
        }

        private void TextBoxEx_Leave(object sender, EventArgs e)
        {
            if (Text == "")
            {
                Text = InitialText;
            }
        }
        
    }
}
