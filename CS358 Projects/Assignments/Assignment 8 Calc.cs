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
    public partial class Assignment_8_Calc : Form
    {
        public double firstNumber;
        public double secondNumber;
        public double result;
        public Operand OpCode;

        public enum Operand
        {
            add = 0,
            subtract = 1,
            multiply = 2,
            divide = 3
        }

        public Assignment_8_Calc()
        {
            InitializeComponent();
        }

        private void ButtonDecimal(object sender, EventArgs e)
        {
            if (!TextBox1.Text.Contains("."))
            {
                TextBox1.Text = TextBox1.Text + ".";
            }

        }
        private void ButtonEquals(object sender, EventArgs e)
        {
            if (firstNumber == 0)
            {
                //first number is 0 code...
            }
            secondNumber = Convert.ToDouble(TextBox1.Text);
            switch (OpCode)
            {
                case Operand.add:
                    result = firstNumber + secondNumber;
                    break;
                case Operand.subtract:
                    result = firstNumber - secondNumber;
                    break;
                case Operand.divide:
                    result = firstNumber / secondNumber;
                    break;
                case Operand.multiply:
                    result = firstNumber * secondNumber;
                    break;
            }
            TextBox1.Text = Convert.ToString(result);
            if (TextBox1.Text == "Infinity")
            {
                TextBox1.Text = "Error: / by 0";
            }
            
        }

#region "buttons 0-9"
        private void Button0(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "0";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "1";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "2";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "3";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "4";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "5";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "6";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "7";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "8";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            getRidOfOperand();
            TextBox1.Text = TextBox1.Text + "9";
        }
#endregion

        private void getRidOfOperand()
        {

            if (TextBox1.Text == "0")
            {
                TextBox1.Text = "";
            }
            if (TextBox1.Text.Contains("+") || TextBox1.Text.Contains("-") || TextBox1.Text.Contains("*") || TextBox1.Text.Contains("/"))
            {
                switch (TextBox1.Text)
                {
                    case "/":
                        OpCode = Operand.divide;
                        break;
                    case "*":
                        OpCode = Operand.multiply;
                        break;
                    case "+":
                        OpCode = Operand.add;
                        break;
                    case "-":
                        OpCode = Operand.subtract;
                        break;
                }
                TextBox1.Text = "";
            }
            
        }

#region "operators"
        private void ButtonDivide(object sender, EventArgs e)
        {
            saveFirstNumber();
            TextBox1.Text = "/";
            OpCode = Operand.divide;

        }
        private void ButtonMultiply(object sender, EventArgs e)
        {
            saveFirstNumber();
            TextBox1.Text = "*";
            OpCode = Operand.multiply;
        }

        private void ButtonAdd(object sender, EventArgs e)
        {
            saveFirstNumber();
            TextBox1.Text = "+";
            OpCode = Operand.add;
        }
        
        private void ButtonSubtract(object sender, EventArgs e)
        {
            if (firstNumber == 0)
            {
                TextBox1.Text = "‒";
                return;
            }
            saveFirstNumber();
            TextBox1.Text = "-";
            OpCode = Operand.subtract;
        }

        private void saveFirstNumber()
        {
            if (TextBox1.Text.Contains("‒"))
            {
                string temp = TextBox1.Text;
                temp = temp.Substring(1);
                temp = "-" + temp;
                firstNumber = Convert.ToDouble(temp);
                return;
            }
            firstNumber = Convert.ToDouble(TextBox1.Text);
        }
#endregion

        private void ButtonClear(object sender, EventArgs e)
        {
            TextBox1.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            result = 0;

        }

    }
}
