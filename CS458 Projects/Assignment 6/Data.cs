using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Assignment_6
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string MiddleInitail { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public double GPA { get; set; }
    }
    [DataContract]
    public class Courses
    {
        [DataMember]
        public string CourseID { get; set; }
        [DataMember]
        public string Discipline { get; set; }
        [DataMember]
        public string CourseNo { get; set; }
        [DataMember]
        public string CourseTitle { get; set; }
    }
    [DataContract]
    public class CoursesTaken
    {
        //[DataMember] //Not needed since we won't be returning this
        //public string StudentID { get; set; }
        [DataMember]
        public string CourseID { get; set; }
        [DataMember]
        public string Grade { get; set; }
    }
    
}