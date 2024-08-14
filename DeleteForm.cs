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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creating object of Student and DataHandler classes
            Student student = new Student();
            DataHandler handler = new DataHandler();

            student.StudentID = int.Parse(textBox1.Text);
            handler.Delete(student.StudentID);  //Invoking delete method
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);  //closes the form  
        }
    }
}
