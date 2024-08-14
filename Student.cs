using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgiumCampusRegistrationApp
{
    internal class Student
    {
        //Properties
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string CourseID { get; set; }

        //Parameterized Constructor
        public Student(int sid, string n, string s, string cid) 
        {
            this.StudentID = sid;
            this.CourseID = cid;
            this.Name = n;
            this.Lastname = s;
        }

        //Default Constructor
        public Student() { }
    }
}
