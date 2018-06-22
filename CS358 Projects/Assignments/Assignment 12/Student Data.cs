using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// didn't complete...
namespace Assignments.Assignment_12
{
    public partial class Student_Data : Form
    {
        public Student_Data()
        {
            InitializeComponent();
        }

        public struct Student
        {
            public String FirstName;
            public String LastName;
            public String MiddleInitial;
            public String PhoneNumber;
            public String Email;
            public String GPA;

        }

        List<Student> Students = new List<Student>();

        private void button1_Click(object sender, EventArgs e)
        {
            string[] studentData = System.IO.File.ReadAllLines("Students.txt");
            foreach (String strStudent in studentData)
            {
                Student st = new Student();
                try
                {
                    string emailGpa = strStudent.Substring(strStudent.LastIndexOf("'"));
                    st.Email = emailGpa.Substring(1, emailGpa.IndexOf(" "));

                    string dfsaf = emailGpa.Substring(emailGpa.IndexOf(" ") + 1);
                    dfsaf = dfsaf.Substring(0, dfsaf.IndexOf(" "));
                    st.GPA = (dfsaf);
                    count3point0gpa(dfsaf);


                    string namePhone = strStudent.Substring(strStudent.IndexOf("'"), strStudent.LastIndexOf("'") - strStudent.IndexOf("'"));
                    String pnum = namePhone.Substring(namePhone.LastIndexOf("'"));
                    st.PhoneNumber = (pnum.Substring(0, pnum.IndexOf(" ")));

                    String lname = namePhone.Substring(0, namePhone.IndexOf(" "));
                    st.LastName = lname;

                    String minit = namePhone.Substring(namePhone.LastIndexOf("'") - 4,1);
                    st.MiddleInitial = minit;

                    String fname = namePhone.Substring(namePhone.IndexOf("'")+1);
                    fname = fname.Substring(fname.IndexOf("'")+1);
                    fname = fname.Substring(0, fname.IndexOf(" "));
                    st.FirstName = fname;
                    if (lname.ToLower() == "anderson")
                    {
                        andersons++;
                    }

                    Students.Add(st); //add to list...
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                textBox1.Text = Students.Count.ToString();
            }

        }

        private int threepointzero = 0;
        private double totalgap = 0;
        private int andersons = 0;
        private void count3point0gpa( String gpa)
        {
            try
            {
                int fd = 0;
                fd = Convert.ToInt32(gpa);
                if (fd >= 3)
                {
                    threepointzero++;
                }
                totalgap += fd;
            }
            catch (Exception)
            {
                MessageBox.Show("error 3.0");

            }
            threepointzero++;
        }

        private double averageGPA()
        {
            return totalgap / Students.Count;
        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = averageGPA().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "there are " + andersons + " andersons";
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
