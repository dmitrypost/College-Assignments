using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignments.Assignment_11
{
    public partial class Bank : Form
    {
        public BankAccount BankAcc;

        public Bank()
        {
            InitializeComponent();
            BankAcc = new BankAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Balance: " + BankAcc.deposit(Convert.ToDouble(textBox1.Text)).ToString("C2");
                label2.Text = "successfully added " + textBox1.Text;
            }
            catch (NegativeBalanceException ex)
            {
                label2.Text = "error " + ex.Message;
            }
            catch (NegativeDepositException ex )
            {
                label2.Text = "error " + ex.Message;
            }
            catch (NegativeWithdrawalException ex)
            {
                label2.Text = "error " + ex.Message;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Balance: " + BankAcc.withdraw(Convert.ToDouble(textBox1.Text)).ToString("C2");
                label2.Text = "successfully withdrew " + textBox1.Text;
            }
            catch (NegativeBalanceException ex)
            {

                label2.Text = "error " + ex.Message; 
            }
            catch (NegativeDepositException ex)
            {
                label2.Text = "error " + ex.Message;
            }
            catch (NegativeWithdrawalException ex)
            {
                label2.Text = "error " + ex.Message;
            }
            
        }

    }
}
