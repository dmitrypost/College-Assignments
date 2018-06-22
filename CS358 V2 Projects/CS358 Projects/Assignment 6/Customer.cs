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
    public partial class Shop_Customer : Form
    {
        MySQLConnector DB = new MySQLConnector();
        public Shop_Customer()
        {
            InitializeComponent();
            
        }

        public string Cus_Comp
        { get { return textBoxEx1.Text; } set { textBoxEx1.Text = value; } }
        public string Cus_Name
        { get { return textBoxEx2.Text; } set { textBoxEx2.Text = value; } }

        public string Cus_Phone
        { get { return textBoxEx3.Text; } set { textBoxEx3.Text = value; } }

        public string Cus_Email
        { get { return textBoxEx4.Text; } set { textBoxEx4.Text = value; } }

        public string Cus_Address
        { get { return textBoxEx8.Text; } set { textBoxEx8.Text = value; } }

        private void Shop_Customer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

        }
    }
}
