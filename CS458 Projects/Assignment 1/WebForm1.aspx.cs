using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session.IsCookieless)
            {
                HttpCookie myCookie = new HttpCookie("Results");
                myCookie = Request.Cookies["Results"];

                // Read the cookie information and display it.
                if (myCookie != null)
                    Response.Write("<p>" + myCookie.Name + "<p>" + myCookie.Value);
                

            }
        }

        protected void UpdateTotal(object sender, EventArgs e)
        {
            
            int st = DropDownList1.SelectedItem.Text.IndexOf("$") + 1;
            int ed = DropDownList1.SelectedItem.Text.IndexOf(")") - st;
            string amount = DropDownList1.SelectedItem.Text.Substring(st, ed);
            double dropdownAmount = Convert.ToDouble(amount);

            foreach(ListItem c in CheckBoxList1.Items)
            {
                if (c.Selected)
                {
                    st = c.Text.IndexOf("$") + 1;
                    ed = c.Text.IndexOf(")") - st;
                    amount = c.Text.Substring(st, ed);
                    dropdownAmount += Convert.ToDouble(amount);
                }
            }
            TextBoxTotal.Text = dropdownAmount.ToString("C2");

            HttpCookie myCookie = new HttpCookie("Results");
            foreach (Control c in Page.Controls)
            {
                
                if (c is Label)
                {
                    Label myLabel = (Label)c;
                    myLabel.Text += "this works";
                }
            }
            myCookie["DropdownSelectedItem"] = DropDownList1.SelectedItem.Text;
            myCookie["CheckBoxListItem1"] = CheckBoxList1.Items[0].Selected.ToString();
            myCookie["CheckBoxListItem2"] = CheckBoxList1.Items[1].Selected.ToString();
            myCookie["CheckBoxListItem3"] = CheckBoxList1.Items[2].Selected.ToString();
            myCookie["CheckBoxListItem4"] = CheckBoxList1.Items[3].Selected.ToString();
            myCookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(myCookie);
        }
        

    }
}