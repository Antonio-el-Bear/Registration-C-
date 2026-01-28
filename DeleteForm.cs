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

            // Ask for confirmation before deletion
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete the student with ID: {studentID}?\nThis action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                //Creating object of Student and DataHandler classes
                Student student = new Student();
                DataHandler handler = new DataHandler();

                student.StudentID = studentID;
                handler.Delete(student.StudentID);  //Invoking delete method
                
                //Clear the textbox
                txtStudentID.Clear();
                txtStudentID.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
