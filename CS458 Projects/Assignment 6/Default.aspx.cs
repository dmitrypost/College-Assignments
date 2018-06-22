using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_6.Resources
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetStudents()
        {
            List<Student> students = new List<Student>();
            string strConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\University.accdb";
            using (OleDbConnection connDBConnection = new OleDbConnection(strConnection))
            {
                string strQuery = "SELECT * FROM STUDENTS";
                OleDbCommand Cmd = new OleDbCommand(strQuery, connDBConnection);
                connDBConnection.Open();
                OleDbDataReader ObjReader = Cmd.ExecuteReader();
                if (ObjReader != null)
                {
                    while (ObjReader.Read())
                    {
                        Student s = new Student();

                        s.LastName = ObjReader.GetValue(0).ToString();
                        s.FirstName = ObjReader.GetValue(1).ToString();
                        s.MiddleInitail = ObjReader.GetValue(2).ToString();
                        s.Phone = ObjReader.GetValue(3).ToString();
                        s.Email = ObjReader.GetValue(4).ToString();
                        s.GPA = Convert.ToDouble(ObjReader.GetValue(5));
                        students.Add(s);
                    }
                }
                ObjReader.Close();
            }
            // return students.ToArray();
            var serializer = new JavaScriptSerializer();
            var result = serializer.Serialize(students);
            Console.WriteLine(result);
            return result;
        }

        [WebMethod]
        public static string GetCoursesTaken(string studentID)
        {
            if (studentID == "" || studentID == String.Empty) return "";
            List<CoursesTaken> courses = new List<CoursesTaken>();
            string strConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\University.accdb";
            using (OleDbConnection connDBConnection = new OleDbConnection(strConnection))
            {
                string strQuery = string.Format("SELECT CourseID, Grade FROM CoursesTaken WHERE StudentID = '{0}'",studentID);
                OleDbCommand Cmd = new OleDbCommand(strQuery, connDBConnection);
                connDBConnection.Open();
                OleDbDataReader ObjReader = Cmd.ExecuteReader();
                if (ObjReader != null)
                {
                    while (ObjReader.Read())
                    {
                        CoursesTaken ct = new CoursesTaken();
                        ct.CourseID = ObjReader.GetValue(0).ToString();
                        ct.Grade = ObjReader.GetValue(1).ToString();
                        courses.Add(ct);
                    }
                }
                ObjReader.Close();
            }
            // return students.ToArray();
            var serializer = new JavaScriptSerializer();
            var result = serializer.Serialize(courses);
            Console.WriteLine(result);
            return result;
        }
    }
}