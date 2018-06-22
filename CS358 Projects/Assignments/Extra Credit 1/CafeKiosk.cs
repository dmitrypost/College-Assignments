using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CafeKiosk
{
    public partial class CafeKiosk : Form
    {
        public CafeKiosk()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayBill();
        }

        private void displayBill()
        {
//            int[] listArray = listBox1.getSelectedIndices();
//            SelectedIndexCollection listArray = listBox1.SelectedIndices;
            double localTax = 0.01;
            double stateTax = 0.06;
            double tax;
            double subTotal = 0;
            double total;

            //Set the text area to non-edit mode and start
            //with an empty string.
            textBox1.ReadOnly = true;
            textBox1.Text = "";
            textBox1.AppendText("not so crappy anymore KIOSK A LA CARTE\n\n");
            textBox1.AppendText("--------------- Welcome ----------------\n\n");


            //Calculate the cost of the items ordered.
            for (int index = 0; index < listBox1.SelectedIndices.Count; index++)
            {
                subTotal = subTotal + Convert.ToDouble(yourChoicesItems[listBox1.SelectedIndices[index]].Substring(yourChoicesItems[listBox1.SelectedIndices[index]].IndexOf("$") + 1));

            }

                  tax = (localTax * subTotal) + (stateTax * subTotal);
                  total = subTotal + tax;

                      //Display the costs.
                  for (int index = 0; index < listBox1.SelectedIndices.Count; index++)
                  {
                     textBox1.AppendText(yourChoicesItems[listBox1.SelectedIndices[index]] + "\n");
                  }

                textBox1.AppendText("\n");
                textBox1.AppendText("SUB TOTAL\t"+ subTotal.ToString("C2") + "\n");
                textBox1.AppendText("TAX      \t\t"+ tax.ToString("C2") + "\n");
                textBox1.AppendText("TOTAL    \t\t"+ total.ToString("C2") + "\n\n");
                textBox1.AppendText("\n" + System.IO.File.ReadAllText("EndOfRecieptMessage.txt"));
                
                      //Reset list array.
                listBox1.ClearSelected();

                // salesreport stuff... 

                if (System.IO.File.Exists("SalesReport.txt"))
                {
                    string report = System.IO.File.ReadAllText("SalesReport.txt");


                    double pastTax = Convert.ToDouble(report.Substring(0,report.IndexOf(":")));
                    double pastSales = Convert.ToDouble(report.Substring(report.IndexOf(":") + 1));

                    double newReportTax = pastTax + tax;
                    double newPeportSales = pastSales + total;

                    System.IO.File.WriteAllText("SalesReport.txt", newReportTax + ":" + newPeportSales);
                    //MessageBox.Show("Taxes collected: " + newReportTax.ToString("C2") + "\n Sales total: " + newPeportSales.ToString("C2"), "Sales Report");
                }
                else
                {//create it...
                    System.IO.File.WriteAllText("SalesReport.txt", tax + ":" + total);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("SalesReport.txt"))
            {
                string report = System.IO.File.ReadAllText("SalesReport.txt");

                double pastTax = Convert.ToDouble(report.Substring(0, report.IndexOf(":")));
                double pastSales = Convert.ToDouble(report.Substring(report.IndexOf(":") + 1));


                MessageBox.Show("Taxes collected: " + pastTax.ToString("C2") + "\n Sales total: " + pastSales.ToString("C2"), "Sales Report");
            }
        }
    }
}
