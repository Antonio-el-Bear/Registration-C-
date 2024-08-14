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
            //Creating Student and DataHandler objects
            Student student = new Student();
            DataHandler handler = new DataHandler();

            student.StudentID = int.Parse(textBox1.Text);   //Get StudentID from textbox
           
            //Bindng searched row of data to DataGridView    
            dataGridView1.DataSource = handler.Search(student.StudentID);

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
