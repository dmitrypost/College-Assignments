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
    public partial class Sale : Form
    {
        MySQLConnector DB = new MySQLConnector();
        public Sale()
        {
            InitializeComponent();
            
            refreshList();
        }

        private int CID = 0;
        public int customerID
        {
            get
            {
                return CID;
            }
            set
            {
                MySQLConnector.Customer C = DB.CustomerGetByID(value);
                comboBox1.Text = C.B_Name;
                CID = value;
            }
        }

        private int PID = 0;
        public int productID
        {
            get
            {
                return CID;
            }
            set
            {
                MySQLConnector.Product P = DB.ProductGetByID(value);
                comboBox2.Text = P.P_Code;
                PID = value;
            }
        }

        public double quantity
        {
            get
            {
                return (double)numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value = (decimal)value;
            }
        }

        public string note
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        private DateTime datetime = DateTime.Now;
        public DateTime date
        {
            get
            {
                return datetime;
            }
            set
            {
                datetime = value;
                label4.Text = "Date: " + datetime;
            }
        }

        private struct ListItem
        {
            public int index;
            public string name;
        }
        private List<ListItem> customers_ = new List<ListItem>();
        private List<ListItem> products_ = new List<ListItem>();

        private void refreshList()
        {
            //customers list...
            comboBox1.Items.Clear(); customers_.Clear();
            List<MySQLConnector.Customer> customers = DB.CustomerGetAll;
            int i = 0;
            foreach (MySQLConnector.Customer c in customers)
            {
                customers_.Add(new ListItem() { index = i, name = c.B_Name });
                i++; comboBox1.Items.Add(c.B_Name);
            }
            i = 0;
            //products list
            comboBox2.Items.Clear(); products_.Clear();
            List<MySQLConnector.Product> products = DB.ProductGetAll;
            foreach (MySQLConnector.Product P in products)
            {
                products_.Add(new ListItem() { index = i, name = P.P_Code });
                i++; comboBox2.Items.Add(P.P_Code);
            }

            label4.Text = "Date: " + datetime;
        }

        private void button1_Click(object sender, EventArgs e)
        { // add button
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {// add new customer button
            Shop_Customer SC = new Shop_Customer();
            if (SC.ShowDialog() == DialogResult.OK)
            {
                MySQLConnector.Customer C = new MySQLConnector.Customer();
                C.B_Name = SC.Cus_Name;
                C.B_Company = SC.Cus_Comp;
                C.B_Address = SC.Cus_Address;
                C.B_Email = SC.Cus_Email;
                C.B_Phone = SC.Cus_Phone;

                if (DB.CustomerAdd(C) == MySQLConnector.Result.Success)
                {
                    refreshList();
                }

            }
            else { MessageBox.Show(SC.DialogResult.ToString()); }
        }

        private void button3_Click(object sender, EventArgs e)
        {// add new product button
            Product PD = new Product();
            if (PD.ShowDialog() == DialogResult.OK)
            {
                MySQLConnector.Product P = new MySQLConnector.Product();
                P.P_Code = PD.P_Code;
                P.P_Discription = PD.P_Discription;
                P.P_Price = PD.P_Price;


                if (DB.ProductAdd(P) == MySQLConnector.Result.Success)
                {
                    refreshList();
                }

            }
            else { MessageBox.Show(PD.DialogResult.ToString()); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CID = comboBox1.SelectedIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PID = comboBox2.SelectedIndex;
        }
    }
}
