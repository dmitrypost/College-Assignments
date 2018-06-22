using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CS358_Projects.Assignment_6
{

    public partial class Products : Form
    {
        MySQLConnector DB = new MySQLConnector();
        public Products()
        {
            InitializeComponent();
            refreshList();  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit the selected product

        }
        private void refreshList()
        {
            listView1.Items.Clear();
            List<MySQLConnector.Product> products = DB.ProductGetAll;
            foreach (MySQLConnector.Product P in products)
            {
                ListViewItem item2 = new ListViewItem(P.P_ID.ToString());
                
                item2.SubItems.Add(P.P_Code);
                item2.SubItems.Add(P.P_Discription);
                item2.SubItems.Add(P.P_Price.ToString());
               
                listView1.Items.Add(item2);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Add a new product
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Product PD = new Product();
            MySQLConnector.Product P = DB.ProductGetByID(int.Parse(listView1.SelectedItems[0].Text));
            PD.P_Code = P.P_Code;
            PD.P_Discription = P.P_Discription;
            PD.P_Price = P.P_Price;
           

            if (PD.ShowDialog() == DialogResult.OK)
            {
                P.P_Code = PD.P_Code;
                P.P_Discription = PD.P_Discription;
                P.P_Price = PD.P_Price;
               
                if (DB.ProductUpdate(P) == MySQLConnector.Result.Success)
                {
                    refreshList();
                }
            }
        }
    }
}
