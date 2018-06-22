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
    public partial class Shop_Management : Form
    {
        MySQLConnector DB = new MySQLConnector();
        public Shop_Management()
        {
            InitializeComponent();
        }

        private void Shop_Management_Load(object sender, EventArgs e)
        {
            
        }

        private void buyersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form targetForm = null;

            foreach (Form frm in MdiChildren)
            {

                if (frm.Text == "Customers")
                {
                    targetForm = frm;
                    break;
                }

            }

            if (targetForm != null)
            {
                targetForm.Activate();
            }
            else
            {
                // create new form and show it
                Customers p = new Customers();
                p.Show();
                p.MdiParent = this;
            }
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form targetForm = null;

            foreach (Form frm in MdiChildren)
            {
                
                    if (frm .Text == "Products")
                    {
                        targetForm = frm;
                        break;
                    }
                
            }

            if (targetForm != null)
            {
                targetForm.Activate();
            }
            else
            {
                // create new form and show it
                Products p = new Products();
                p.Show();
                p.MdiParent = this;
            }
            
            
        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form targetForm = null;

            foreach (Form frm in MdiChildren)
            {

                if (frm.Text == "Vendors")
                {
                    targetForm = frm;
                    break;
                }

            }

            if (targetForm != null)
            {
                targetForm.Activate();
            }
            else
            {
                // create new form and show it
                Vendors p = new Vendors();
                p.Show();
                p.MdiParent = this;
            }
        }

        private void purchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form targetForm = null;

            foreach (Form frm in MdiChildren)
            {

                if (frm.Text == "Purchases")
                {
                    targetForm = frm;
                    break;
                }

            }

            if (targetForm != null)
            {
                targetForm.Activate();
            }
            else
            {
                // create new form and show it
                Purchases p = new Purchases();
                p.Show();
                p.MdiParent = this;
            }

        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form targetForm = null;

            foreach (Form frm in MdiChildren)
            {

                if (frm.Text == "Sales")
                {
                    targetForm = frm;
                    break;
                }

            }

            if (targetForm != null)
            {
                targetForm.Activate();
            }
            else
            {
                // create new form and show it
                Sales p = new Sales();
                p.Show();
                p.MdiParent = this;
            }

        }
    }
}
