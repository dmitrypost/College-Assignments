using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Assignmnet_2
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        HttpCookie myCookie = new HttpCookie("Results");
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            myCookie = Request.Cookies["Results"];
            

            if (!Session.IsCookieless && myCookie != null && !IsPostBack)
            {
                
                // Read the cookie information and display it.
              
                //Response.Write("<p>" + myCookie.Name + "<p>" + myCookie.Value);
                
                string[] ss = myCookie.Value.Split('&');
                foreach (string s in ss)
                {
                    string[] value = s.Split('=');
                    SetControl(value[0], value[1]);
                }
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

            myCookie = new HttpCookie("Results");
            foreach (Control c in Page.Controls)
            { CheckControls(c.Controls); }


            myCookie.Expires = DateTime.MaxValue;
            Response.Cookies.Add(myCookie);
        }

        private void CheckControls(ControlCollection CC)
        {
            foreach (Control c in CC)
            {
                
                if (c is TextBox)
                {
                    TextBox myTextbox = (TextBox)c;
                    myCookie[myTextbox.ClientID.ToString()] = myTextbox.Text;

                    
                }
                if (c is DropDownList)
                {
                    DropDownList myDDL = (DropDownList)c;
                    myCookie[myDDL.ClientID.ToString()] = myDDL.SelectedIndex.ToString();
                }
                
                if (c is CheckBoxList)
                {
                    CheckBoxList myCBL = (CheckBoxList)c;
                    List<int> SelectedIndicies = new List<int>();
                    foreach (ListItem i in myCBL.Items)
                    {
                        if (i.Selected)
                        {

                            SelectedIndicies.Add(myCBL.Items.IndexOf(i));

                        }
                    }
                    myCookie[myCBL.ID.ToString()] = IntListToString(SelectedIndicies);
                }
                CheckControls(c.Controls);
            
            }

        }
        
        private bool SetControl(string ctrl, string Value)// returns true if found and set
        {
            if (Page.FindControl(ctrl) != null)
            {
                Control c = Page.FindControl(ctrl);
                if (c is TextBox)
                {
                    TextBox myTextbox = (TextBox)c;
                    myTextbox.Text = Value;
                }
                if (c is DropDownList)
                {
                    DropDownList myDDL = (DropDownList)c;
                    myDDL.SelectedIndex = Convert.ToInt32(Value);
                }
                if (c is CheckBoxList)
                {
                    CheckBoxList myCBL = (CheckBoxList)c;
                    List<int> SelectedIndicies = StringToIntList(Value);

                    foreach (int i in SelectedIndicies)
                    {
                        myCBL.Items[i].Selected = true;
                    }
                }
            }
            return false;
        }

        private string IntListToString (List<int> list)
        {
            return string.Join(",", list);
        }

        private List<int> StringToIntList (string str)
        {
            string[] ss = str.Split(',');
            List<int> list = new List<int>();
            foreach (string s in ss)
            {
                list.Add(Convert.ToInt32(s));
            }
            return list;
        }
    }
}