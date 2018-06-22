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
    public partial class Customers : Form
    {
        MySQLConnector DB = new MySQLConnector();
        public Customers()
        {
            InitializeComponent();
        }

        private void refreshList()
        {
            listView1.Items.Clear();
            List<MySQLConnector.Customer> customers = DB.CustomerGetAll;
            foreach (MySQLConnector.Customer c in customers)
            {
                ListViewItem item2 = new ListViewItem(c.B_ID.ToString());
                item2.SubItems.Add(c.B_Company);
                item2.SubItems.Add(c.B_Name);
                item2.SubItems.Add(c.B_Address);
                item2.SubItems.Add(c.B_Phone.ToString());
                item2.SubItems.Add(c.B_Email);
                listView1.Items.Add(item2);
            }
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            refreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Shop_Customer SC = new Shop_Customer();
            MySQLConnector.Customer C = DB.CustomerGetByID(int.Parse(listView1.SelectedItems[0].Text));
            SC.Cus_Address = C.B_Address;
            SC.Cus_Comp = C.B_Company;
            SC.Cus_Email = C.B_Email;
            SC.Cus_Name = C.B_Name;
            SC.Cus_Phone = C.B_Phone;

            if (SC.ShowDialog() == DialogResult.OK)
            {
                C.B_Name = SC.Cus_Name;
                C.B_Company = SC.Cus_Comp;
                C.B_Address = SC.Cus_Address;
                C.B_Email = SC.Cus_Email;
                C.B_Phone = SC.Cus_Phone;

                if (DB.CustomerUpdate(C) == MySQLConnector.Result.Success)
                {
                    refreshList();
                }
            }
                
        }
    }
}
