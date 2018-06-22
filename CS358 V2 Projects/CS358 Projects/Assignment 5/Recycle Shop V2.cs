using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace CS358_Projects.Assignment_5
{
    public partial class Recycle_Shop_V2 : Form
    {
        Transactions transactions = new Transactions();
        Products products = new Products();

        public Recycle_Shop_V2()
        {
            InitializeComponent();

        }

        private void Recycle_Shop_Load(object sender, EventArgs e)
        {
            
            transactions.LoadTransactions(); // loads the transactions 
            UpdateComboboxes(); // updates the comboboxes to contain the items.

            WriteReciept(); // writes the reciept template (header and footer)
            transactions.rl.reCalculate();
            currentPaymentYear = DateTime.Now.Year;
            currentPaymentQuorter = (int)Math.Ceiling(DateTime.Now.Month / 3.0);
            currentPaymentMonth = DateTime.Now.Month;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Reciept", 270, 500);

        }

        private void UpdateComboboxes()
        {
            //reload the list
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            products.LoadDatabase();
            foreach (Products.product p in products.pl.product_list)
            {
                comboBox1.Items.Add(p.name);
                comboBox2.Items.Add(p.name);
                comboBox3.Items.Add(p.name);
            }
            comboBox4.Items.Clear();
            foreach (Transactions.Reciept transaction in transactions.rl.TransactionReciepts)
            {
                comboBox4.Items.Add(transaction.InvoiceNumber);
            }
        }
        #region " transaction handling into the list of transactions and reciept printing"


        Transactions.Reciept currentReciept = new Transactions.Reciept();

        private void AddTransactionToList(object sender, EventArgs e)//adds the reciept into the lists
        {
            transactions.rl.TransactionReciepts.Add(currentReciept);
            transactions.SaveTransations();
            UpdateComboboxes();

        }
        public void View(double invoiceNumber)
        {
            //sets the current reciept to the one of the invoice number
            currentReciept = transactions.rl.find(invoiceNumber);

            //rewrites the current reciept
            WriteReciept();
        }

        private void NewTransaction(object sender, EventArgs e)
        {
            currentReciept = new Transactions.Reciept();
            currentReciept.datetime = DateTime.Now;
            WriteReciept(); //rewrites the current reciept
            button3.Enabled = true;
            groupBox4.Enabled = true;
        }

        public void AppendItem(Products.product p, double quantity)
        {

            currentReciept.Items.Add(new Transactions.Reciept.LineItem() { price = p.price, name = p.name, quantity = quantity });
            WriteReciept(); //rewrites the current reciept
            
        }

        public void WriteReciept()
        {
            
            printPreviewControl1.Document = printDocument1;
        }




        #endregion

        private void addtolistbutton(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                return;
            //get the product with the name that matches
            Products.product p = products.pl.find(comboBox1.SelectedItem.ToString());
            //
            double price = p.price * Convert.ToDouble(numericUpDown1.Value);
            label1.Text = "Price " + (price).ToString("C2");

            AppendItem(p, Convert.ToDouble(numericUpDown1.Value));

        }
        
        private void Calculate(object sender, EventArgs e)
        {
            //get the product with the name that matches
            Products.product p = products.pl.find(comboBox1.SelectedItem.ToString());
            //
            label1.Text = ("Price " + (p.price * Convert.ToDouble(numericUpDown1.Value)).ToString("C2"));

        }

        #region "Database management"
        private void AddItemToDatabaseButton(object sender, EventArgs e)
        {
            Products.product p = new Products.product();
            p.name = textBox1.Text;
            p.price = double.Parse(textBox2.Text);
            products.pl.add(p);
            // save the database
            products.SaveDatabase();
            UpdateComboboxes();
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = products.pl.product_list[comboBox2.SelectedIndex].price.ToString();

        }

        private void EditItemInDatabaseButton(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
                return;
            //update the price in the product list
            products.pl.product_list[comboBox2.SelectedIndex].price = Convert.ToDouble(textBox3.Text);
            //save the contents of product list to the database
            products.SaveDatabase();
            UpdateComboboxes();
        }

        private void DeleteItemInDatabaseButton(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
                return;
            products.pl.product_list.RemoveAt(comboBox3.SelectedIndex);
            products.SaveDatabase();
            UpdateComboboxes();
        }

        #endregion

        private void button9_Click(object sender, EventArgs e)
        {
            View(Convert.ToDouble(comboBox4.SelectedItem.ToString()));
            button3.Enabled = false;
            groupBox4.Enabled = false;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            button9.Enabled = true;
        }

        private void RecieptBody_TextChanged(object sender, EventArgs e)
        {

        }

        #region "Monthly | Quorterly | Yearly Payment display section"

        #region "Monthly payments display section"

        private int cpm;
        int currentPaymentMonth
        {
            get { return cpm; }
            set
            {
                //other processing code... with the setting of this
                cpm = value;
                switch (value)
                {
                    case 1:
                        buttonMonthPaymentBack.Enabled = false;
                        break;
                    case 2:
                        buttonMonthPaymentBack.Enabled = true;
                        break;
                    case 11:
                        buttonMonthPaymentForward.Enabled = true;
                        break;
                    case 12:
                        buttonMonthPaymentForward.Enabled = false;
                        break;
                }
                labelMonthPayments.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(cpm) + "'s payments: " + transactions.rl.YearAmounts(cpy).Monthly(cpm).ToString("C2");
            }
        }
        string[] Months = DateTimeFormatInfo.CurrentInfo.MonthNames;
        private void buttonMonthPaymentBack_Click(object sender, EventArgs e)
        {
            currentPaymentMonth -= 1;
        }

        private void buttonMonthPaymentForward_Click(object sender, EventArgs e)
        {
            currentPaymentMonth += 1;
        }
        #endregion

        #region "Quorterly payments display section"

        private int cpq;
        int currentPaymentQuorter
        {
            get { return cpq; }
            set
            {
                //other processing code... with the setting of this
                
                switch (value)
                {
                    case 1:
                        buttonQuorterPaymentBack.Enabled = false;
                        break;
                    case 2:
                        buttonQuorterPaymentBack.Enabled = true;
                        break;
                    case 3:
                        buttonQuorterPaymentForward.Enabled = true;
                        break;
                    case 4:
                        buttonQuorterPaymentForward.Enabled = false;
                        break;
                }
                labelQuorterPayments.Text = "Quorter " + value + " payments: " + transactions.rl.YearAmounts(cpy).Quarterly(value).ToString("C2");
                cpq = value;
            }
        } 
        
        private void buttonQuorterPaymentBack_Click(object sender, EventArgs e)
        {
            currentPaymentQuorter -= 1;
        }

        private void buttonQuorterPaymentForward_Click(object sender, EventArgs e)
        {
            currentPaymentQuorter += 1;
        }

        #endregion
        #region "Yearly payments display section"

        private int cpy;
        int currentPaymentYear
        {
            get { return cpy; }
            set
            {
                //other processing code...with the setting of this
                buttonYearlyPaymentBack.Enabled = false;
                buttonYearlyPaymentForward.Enabled = false; //will be enabled later only if years exist...
                foreach (Transactions.RecieptList.YearPayment yp in transactions.rl.yearPayments)
                {
                    if (yp.year > value)
                        buttonYearlyPaymentForward.Enabled = true;
                    if (yp.year < value)
                        buttonYearlyPaymentBack.Enabled = true;

                }

                labelYearPayment.Text =  value + "'s payments: " + transactions.rl.YearAmounts(value).Yearly().ToString("C2");
                cpy = value;
            }
        }
        private void buttonYearlyPaymentBack_Click(object sender, EventArgs e)
        {
            currentPaymentYear -= 1;
        }
        private void buttonYearlyPaymentForward_Click(object sender, EventArgs e)
        {
            currentPaymentYear += 1;
        }
        #endregion

        #endregion
        private void ButtonEditTemplate_Click(object sender, EventArgs e)
        {
            TemplateEditor.TemplateDialog td = new TemplateEditor.TemplateDialog();
            if (td.ShowDialog() == DialogResult.OK)
            {
                transactions.Template = TemplateEditor.TemplateDialog.Template;
                transactions.SaveTemplate();
                WriteReciept();
            }
        }

        
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Graphics g = e.Graphics;
            string DocumentString =
                addWhiteSpaceToCenterText(transactions.Template.welcomeMessage) +
                Environment.NewLine + addWhiteSpaceToCenterText(transactions.Template.storeName) +
                Environment.NewLine + addWhiteSpaceToCenterText(transactions.Template.location) +
                Environment.NewLine + addWhiteSpaceToCenterText(transactions.Template.phonenumber);
            DateTime t = currentReciept.datetime;
            DocumentString += Environment.NewLine + "\n\t" + t.ToString("MM\\/dd\\/yyyy") + "\t\t" + t.ToString("HH:mm");
            DocumentString += "\n\tInvoice: " + currentReciept.InvoiceNumber;
            DocumentString += "\n\tItem \t Price x Qty \t total";
            foreach(Transactions.Reciept.LineItem i in currentReciept.Items)
            {
                DocumentString += Environment.NewLine + "\t" + i.name + "\t @" + i.price + "x" + i.quantity + "\t " + (Convert.ToDecimal(i.price * i.quantity)).ToString("C2");
            }

            DocumentString += Environment.NewLine + Environment.NewLine + addWhiteSpaceToCenterText(transactions.Template.website) +
                Environment.NewLine + addWhiteSpaceToCenterText(transactions.Template.thankYouMessage);

            StringFormat sf = new StringFormat();
            sf.SetTabStops(0,new float[] { 5, 130, 70 });

            e.Graphics.DrawString(DocumentString,new Font("Consolas", 8,FontStyle.Regular),Brushes.Black, new RectangleF(10, 10, printDocument1.DefaultPageSettings.PrintableArea.Width, printDocument1.DefaultPageSettings.PrintableArea.Height),sf);
        }
       
        private string addWhiteSpaceToCenterText(String text)
        {
            
            int start = 25 - (text.Length/2);
            StringBuilder result = new StringBuilder("                                  ");
            result.Insert(start, text);
            return result.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
    }
}