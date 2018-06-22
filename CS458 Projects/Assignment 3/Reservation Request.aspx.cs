using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assfdlsanmfewkr3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                Calendar1.Visible = false;
                for (int i = 0; i < 10; i ++)
                {
                    DropDownList1.Items.Add(i.ToString());
                    DropDownList2.Items.Add(i.ToString());
                }
               
            }
           
        }



        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString().Substring(0, Calendar1.SelectedDate.ToString().IndexOf(" "));
            Calendar1.Visible = false;
            TextBox1.CssClass = "valid";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DateTime date = new DateTime();
            //Flip the visibility attribute
            Calendar1.Visible = !(Calendar1.Visible);
            //If the calendar is visible try assigning the date from the textbox
            if (Calendar1.Visible)
            {
                //If the Conversion was successfull assign the textbox's date
                if (DateTime.TryParse(TextBox1.Text, out date))
                {
                    Calendar1.SelectedDate = date;
                    TextBox1.CssClass = "valid";
                }
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            //CheckControls(Page.Controls);

            CheckControls(Form.Controls);
            

        }

        private void CheckControls(ControlCollection cc)
        {
            foreach (Control c in cc)
            {
                try
                {
                    if (c is TextBox)
                    {
                        TextBox t = (TextBox)c;
                        t.Text = string.Empty;
                        t.CssClass = "required";
                    }

                }
                catch (Exception)
                {
                    
                }
                CheckControls(c.Controls);
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            //email validated
            RegularExpressionValidator1.Validate();
            bool v = false;
            try
            {
                System.Net.Mail.MailAddress address = new System.Net.Mail.MailAddress(TextBox4.Text);
                v = address.Address == TextBox4.Text;
            }
            catch (Exception)
            {
                
            }
            if (RegularExpressionValidator1.IsValid && (v))
            {
                
                TextBox4.CssClass = "valid";
               
            }
            else
            {
                
                TextBox4.CssClass = "invalid";
                
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            // if the date entered is a valid date then can proceed            
            if (!DateTime.TryParse(TextBox1.Text, out date))
            {
                TextBox1.CssClass = "invalid";
                Page.SetFocus(TextBox1);
                TextBox1.Text = String.Empty;
            }
            else
            {
                TextBox1.CssClass = "valid";
            }
               
        }

        protected void UpdateTotal(object sender, EventArgs e)
        {
            //calculates the total amount and outputs it as a currency format.
            Label1.Text = ((Convert.ToInt32(DropDownList1.SelectedValue) * 125) + (Convert.ToInt32(DropDownList2.SelectedValue) * 75)).ToString("C2");
        }
    }
}