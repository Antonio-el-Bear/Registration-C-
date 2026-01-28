using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;      //Add namespace
using System.Data.SqlClient;     //Add namespace
using System.Windows.Forms;  //Add namespace

namespace BelgiumCampusRegistrationApp
{
    internal class DataHandler
    {
        //Constructor
        public DataHandler() { }

        //Set string for connecting to SQL Server
        string connect = "Data Source =.; Initial Catalog = StudentDB; Integrated Security= SSPI";

        //Declare objects we will use in different methods
        SqlDataAdapter adapter;
        SqlConnection con;
        SqlCommand command;

        //Creating method to register students
        public void Register(int sid, string n, string s, string cid) 
        {
            if (string.IsNullOrWhiteSpace(n) || string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(cid))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            //Set up query with parameterized query to prevent SQL injection
            string query = "INSERT INTO StudentDetails (StudentID, FirstName, LastName, CourseID) VALUES (@sid, @name, @lastname, @courseid)";

            //Use SqlConnection object to connect using connection string
            try
            {
                using (con = new SqlConnection(connect))
                {
                    con.Open();     //Open connection
                    command = new SqlCommand(query, con);       //Setup the query to the connection
                    
                    // Add parameters
                    command.Parameters.AddWithValue("@sid", sid);
                    command.Parameters.AddWithValue("@name", n);
                    command.Parameters.AddWithValue("@lastname", s);
                    command.Parameters.AddWithValue("@courseid", cid);

                    command.ExecuteNonQuery();  //Execute the query
                    MessageBox.Show("Student Successfully registered");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details not saved. " + ex.Message);
            }
        }

        public void Update(int sid, string n, string s, string cid) 
        {
            if (string.IsNullOrWhiteSpace(n) || string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(cid))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            //Set up query with parameterized query to prevent SQL injection
            string query = "UPDATE StudentDetails SET FirstName = @name, LastName = @lastname, CourseID = @courseid WHERE StudentID = @sid";

            //Use SqlConnection object to connect using connection string
            try
            {
                using (con = new SqlConnection(connect))
                {
                    con.Open();     //Open connection
                    command = new SqlCommand(query, con);       //Setup the query to the connection
                    
                    // Add parameters
                    command.Parameters.AddWithValue("@sid", sid);
                    command.Parameters.AddWithValue("@name", n);
                    command.Parameters.AddWithValue("@lastname", s);
                    command.Parameters.AddWithValue("@courseid", cid);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Details for Student Successfully Updated");
                    }
                    else
                    {
                        MessageBox.Show("No student found with that ID");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details not updated. " + ex.Message);
            }
        }

        //Method for Deleting data from table
        public void Delete(int sid) 
        {
            //Query with parameterized query
            string query = "DELETE FROM StudentDetails WHERE StudentID = @sid";

            //Use SqlConnection object to connect using connection string
            try
            {
                using (con = new SqlConnection(connect))
                {
                    con.Open();     //Open connection
                    command = new SqlCommand(query, con);       //Setup the query to the connection
                    
                    // Add parameter
                    command.Parameters.AddWithValue("@sid", sid);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Details for Student with ID: {sid} has been deleted");
                    }
                    else
                    {
                        MessageBox.Show("No student found with that ID");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details not deleted. " + ex.Message);
            }
        }

        //Search method
        public DataTable Search(int sid) 
        {
            //Set the query with parameterized query
            string query = "SELECT * FROM StudentDetails WHERE StudentID = @sid";

            try
            {
                using (con = new SqlConnection(connect))
                {
                    adapter = new SqlDataAdapter(query, con);
                    adapter.SelectCommand.Parameters.AddWithValue("@sid", sid);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No student found with that ID");
                    }

                    return table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed. " + ex.Message);
                return new DataTable();
            }
        }
    }
}
