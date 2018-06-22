using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Assignment_4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public string StudentID ;

        protected void Page_Load(object sender, EventArgs e)
        {
            StudentID = Request.QueryString["id"];
            StudentName.Text = Request.QueryString["name"];
            SqlDataSourceGetStudentCoursesTaken.SelectCommand = "SELECT CoursesTaken.Grade, Courses.Discipline + Courses.CourseNo AS Course, Courses.CourseTitle AS Title FROM ((Courses INNER JOIN CoursesTaken ON Courses.CourseID = CoursesTaken.CourseID) INNER JOIN Students ON CoursesTaken.StudentID = Students.Email) WHERE (Students.Email = '" +
                StudentID + "') ORDER BY Courses.CourseTitle";

            
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
           
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlDataSourceMis.InsertCommand = "INSERT INTO CoursesTaken (Grade, CourseID, StudentID) VALUES ('" + TextBox1.Text + "', '" + DropDownList2.SelectedValue + "' , '" + StudentID +"')";
            
            SqlDataSourceMis.Insert();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataSourceMis.SelectCommand = "SELECT [Grade] FROM [CoursesTaken] WHERE [StudentID] = '" + StudentID + "' AND CourseID = '" + DropDownList1.SelectedValue + "'";
            DataView dv = (DataView)SqlDataSourceMis.Select(DataSourceSelectArguments.Empty);
            TextBox2.Text = (String)dv.Table.Rows[0].ItemArray[0];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataSourceMis.UpdateCommand = "UPDATE CoursesTaken SET Grade = '" + TextBox2.Text + "' WHERE CourseID = '" + DropDownList1.SelectedValue + "' AND StudentID = '" + StudentID +"'";
            SqlDataSourceMis.Update();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlDataSourceMis.DeleteCommand = "DELETE FROM CoursesTaken WHERE CourseID = '" + DropDownList1.SelectedValue + "' AND StudentID = '" + StudentID + "'";
            SqlDataSourceMis.Delete();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}