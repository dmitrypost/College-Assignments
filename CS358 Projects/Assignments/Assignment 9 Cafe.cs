using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignments
{
    public partial class Assignment_9_Cafe : Form
    {
        public Assignment_9_Cafe()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
            {
                case "Coffee":
                    listBox1.Items.Add(tabControl1.SelectedTab.Text + "\t\t$1.80");
                    break;
                case "Tea":
                    listBox1.Items.Add(tabControl1.SelectedTab.Text + "\t\t$1.75");
                    break;
                case "Pastries":
                    listBox1.Items.Add(tabControl1.SelectedTab.Text + "\t\t$2.00");
                    break;
            }
            
            foreach (Control ctrl in tabControl1.SelectedTab.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox ckbox = (CheckBox)ctrl;
                   
                    if (ckbox.Checked)
                    {
                        if(ckbox.Text.Contains("$")){
                            listBox1.Items.Add("    " + ckbox.Text.Substring(0,ckbox.Text.IndexOf("$")) + "\t" + ckbox.Text.Substring(ckbox.Text.IndexOf("$")));}
                        else{
                        listBox1.Items.Add("    " + ckbox.Text);}
                    }   }   }   ReclaculateTotal();
        }

        private void RemoveSelected(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            ReclaculateTotal();
        }

        private void ClearAll(object sender, EventArgs e)
        {
            do
            {
                if (listBox1.Items.Count == 0)
                    break;
                listBox1.Items.RemoveAt(0);
            } while (listBox1.Items.Count > 0);
            label1.Text = "Total: $0.00";
        }

        private void ReclaculateTotal()
        {
            double total = 0;
            foreach (var ctrl in listBox1.Items)
            {
                    if (ctrl.ToString().Contains("$"))
                    {
                        total += Convert.ToDouble(ctrl.ToString().Substring(ctrl.ToString().IndexOf("$")+1));
                    }
            }
            label1.Text = "Total: " + total.ToString("C2");
        }
    }
    
}
