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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Please enter a Student ID", "Validation Error");
                return;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentID))
            {
                MessageBox.Show("Student ID must be a number", "Validation Error");
                return;
            }

            //Creating Student and DataHandler objects
            Student student = new Student();
            DataHandler handler = new DataHandler();

            student.StudentID = studentID;   //Get StudentID from textbox
           
            //Binding searched row of data to DataGridView    
            dgvResults.DataSource = handler.Search(student.StudentID);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
