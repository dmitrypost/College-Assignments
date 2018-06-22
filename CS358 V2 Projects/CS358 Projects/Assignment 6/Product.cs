using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS358_Projects.Assignment_6
{
    public partial class Product : Form
    {
        public string P_Code
        {
            get
            {
                return textBoxEx1.Text;
            }
            set
            {
                textBoxEx1.Text = value;
            }
        }

        public string P_Discription
        {
            get
            {
                return textBoxEx2.Text;
            }
            set
            {
                textBoxEx2.Text = value;
            }
        }

        public double P_Price
        {
            get
            {
                try
                {
                    return double.Parse(textBoxEx3.Text);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            set
            {
                textBoxEx3.Text = value.ToString();
            }
        }

        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
