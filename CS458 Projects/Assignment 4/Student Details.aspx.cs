using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DataView rdrAccess = (DataView)SqlDataSourceStudentData.Select(DataSourceSelectArguments.Empty))
                {

                    TextBox1.Text = rdrAccess[0].Row["LastName"].ToString();
                    TextBox2.Text = rdrAccess[0].Row["MiddleInitial"].ToString();
                    TextBox3.Text = rdrAccess[0].Row["FirstName"].ToString();

                    TextBox4.Text = rdrAccess[0].Row["Phone"].ToString();
                    TextBox6.Text = rdrAccess[0].Row["Email"].ToString();
                    TextBox5.Text = rdrAccess[0].Row["GPA"].ToString();

                }
            }
        }

        protected void SqlDataSourceStudentData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoursesTaken.aspx?ID=" + TextBox6.Text + "&name=" +TextBox1.Text + " " + TextBox3.Text);

        }
    }
}