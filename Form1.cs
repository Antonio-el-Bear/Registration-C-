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
            //Fetch data from textboxes to fields
            student.StudentID = int.Parse(textBox1.Text);
            student.Name = textBox2.Text;
            student.Lastname = textBox3.Text;
            student.CourseID = textBox4.Text;

            //Invoking the Regiser method and pass data to it
            handler.Register(student.StudentID, student.Name, student.Lastname, student.CourseID);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Fetch data from textboxes to fields
            student.StudentID = int.Parse(textBox1.Text);
            student.Name = textBox2.Text;
            student.Lastname = textBox3.Text;
            student.CourseID = textBox4.Text;

            //Invoking the Update method
            handler.Update(student.StudentID, student.Name, student.Lastname, student.CourseID);

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
    }
}
