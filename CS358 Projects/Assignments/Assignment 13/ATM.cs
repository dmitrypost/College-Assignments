using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLDll;

namespace Assignments.Assignment_13
{
    public partial class ATM : Form
    {
        public ATM()
        {
            InitializeComponent();
        }

        void enableDisableKeypad(bool set)
        {
            button1.Enabled = set;
            button2.Enabled = set;
            button3.Enabled = set;
            button4.Enabled = set;
            button5.Enabled = set;
            button6.Enabled = set;
            button7.Enabled = set;
            button8.Enabled = set;
            button9.Enabled = set;
            button10.Enabled = set;

        }

        private void appendKey(object sender, MouseEventArgs e)
        {
            Button self = (Button)sender;
            textBox2.Text = textBox2.Text + self.Text;
            button11.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            textBox2.Text = "";
            textBox1.Text = "Please enter the pin number";
            enableDisableKeypad(true);
            button14.Enabled = true;
        }




        Connection c;
        Statement s;
        ResultSet r;
        bool valid = false; //
        int bal;
        string name = "";
        

        private void button11_Click(object sender, EventArgs e)
        {
            if (valid) 
            {
                string b = r.getString("balanceAmount");
                int a = Int32.Parse(b);
                if (Int32.Parse(textBox2.Text) > Int32.Parse(r.getString("balanceAmount")))
                {
                    textBox1.Text = "You cannot withdraw more than the balance amount";
                    textBox2.Text = "";
                    button12.Enabled = false; //disable till a new balance is entered... which will reenable this button 
                }
                else
                {
                    
                    bal = Int32.Parse(r.getString("balanceAmount"));
                    int subt = Int32.Parse(textBox2.Text);
                    bal = bal - subt;

                    s.executeUpdate("UPDATE accountInformation SET balanceAmount = " + bal + " WHERE accountNumber = '" + comboBox1.Text + "'");
                    button11.Enabled = false;
                    enableDisableKeypad(false);
                    textBox2.Text = "";

                    button12.Enabled = true; //balance button
                    button13.Enabled = true; //withdraw button
                    textBox1.Text = "Please take your money";
                }
            }
            else
            {
                try
                {
                    
                    pin = textBox2.Text;
                    getInfo();

                    
                    while (r.next())
                    {
                        name = r.getString("firstName");
                        bal = Int32.Parse(r.getString("balanceAmount"));
                    

                    }
                    button11.Enabled = false;
                    enableDisableKeypad(false);

                    textBox1.Text = "Welcome back " + name ;

                    button12.Enabled = true;
                    button13.Enabled = true;
                    valid = true;
                }
                catch (Exception)
                {

                    textBox2.Text = "";
                    textBox1.Text = "Please enter a valid pin number";
                }
                textBox2.Text = "";
            }
            
            
        }

        string pin = "";

        private void getInfo()
        {
            SQL sql = new SQL();
            String url = "http://www.boehnecamp.com/phpMyAdmin/razorsql_mysql_bridge.php";
            c = sql.getConnection(url);
            s = c.createStatement(url);
            r = s.executeQuery("SELECT * FROM accountInformation WHERE accountNumber = '" + comboBox1.Text + "' AND pin = '" + pin + "'");
                    
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "Current balance: " + bal; 
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button12.Enabled = false; //balance button
            button13.Enabled = false; //withdraw button (this button)
            enableDisableKeypad(true);
            textBox1.Text = "Please enter the amount you would like to withdraw";
            button11.Enabled = true; //enter button


            
            //Console.WriteLine("Returned from executeUpdate");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //done button
            c.close();
            s.close();
            r.close();

            enableDisableKeypad(false);
            button11.Enabled = false; //enter button
            button12.Enabled = false; //balance button
            button13.Enabled = false; //withdraw button
            button14.Enabled = false; //done button     (this button)
            comboBox1.Enabled = true;
            valid = false; // 
            textBox1.Text = "Please select account number...";
        }

        

    }
}
