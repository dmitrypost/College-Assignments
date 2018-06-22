using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Assignment_4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                var f = GridView1.SelectedRow.Cells[1].Text + " " + GridView1.SelectedRow.Cells[2].Text;
                Response.Redirect("Student Details.aspx?StudentID=" + GridView1.SelectedValue );


            
        }
    }
}