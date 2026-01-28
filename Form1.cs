using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelgiumCampusRegistrationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Set class objects
        DataHandler handler = new DataHandler();
        Student student = new Student();

        private void button1_Click(object sender, EventArgs e)
        {
            //Validate input
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) || 
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtCourseID.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error");
                return;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentID))
            {
                MessageBox.Show("Student ID must be a number", "Validation Error");
                return;
            }

            //Fetch data from textboxes to fields
            student.StudentID = studentID;
            student.Name = txtFirstName.Text;
            student.Lastname = txtLastName.Text;
            student.CourseID = txtCourseID.Text;

            //Invoking the Register method and pass data to it
            handler.Register(student.StudentID, student.Name, student.Lastname, student.CourseID);
            
            //Clear fields after registration
            ClearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Validate input
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) || 
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtCourseID.Text))
            {
                MessageBox.Show("Please fill in all fields", "Validation Error");
                return;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentID))
            {
                MessageBox.Show("Student ID must be a number", "Validation Error");
                return;
            }

            //Fetch data from textboxes to fields
            student.StudentID = studentID;
            student.Name = txtFirstName.Text;
            student.Lastname = txtLastName.Text;
            student.CourseID = txtCourseID.Text;

            //Invoking the Update method
            handler.Update(student.StudentID, student.Name, student.Lastname, student.CourseID);
            
            //Clear fields after update
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Create an object of the delete form
            DeleteForm d = new DeleteForm();
            d.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Create an object of the search form
            SearchForm s = new SearchForm();
            s.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ClearFields()
        {
            txtStudentID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCourseID.Clear();
            txtStudentID.Focus();
        }
    }
}
