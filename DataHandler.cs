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
            //Set up query
            string query = $"INSERT INTO StudentDetails VALUES('{sid}', '{n}', '{s}', '{cid}')";

            //Use SqlConnection object to connect using connection string
            con = new SqlConnection(connect);       
            con.Open();     //Open connection
            command = new SqlCommand(query, con);       //Setup the query to the connection

            try
            {
                command.ExecuteNonQuery();  //Execute the query
                MessageBox.Show("Student Successfully registered");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details not saved." + ex.Message);
            }
            finally 
            {
                con.Close();
            }
        }

        public void Update(int sid, string n, string s, string cid) 
        {
            //Set up query
            string query = $"UPDATE StudentDetails SET [LastName] = '{s}', [Surname] = '{n}', [CourseID] = '{cid}' WHERE [StudentID] = '{sid}'";

            //Use SqlConnection object to connect using connection string
            con = new SqlConnection(connect);
            con.Open();     //Open connection
            command = new SqlCommand(query, con);       //Setup the query to the connection

            try
            {
                command.ExecuteNonQuery();  //Execute the query
                MessageBox.Show("Details for Student Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details not updated." + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //Method for Deleting data from table
        public void Delete(int sid) 
        {
            //Query
            string query = $"DELETE FROM StudentDetails WHERE StudentID = '{sid}'";

            //Use SqlConnection object to connect using connection string
            con = new SqlConnection(connect);
            con.Open();     //Open connection
            command = new SqlCommand(query, con);       //Setup the query to the connection

            try
            {
                command.ExecuteNonQuery();  //Execute the query
                MessageBox.Show($"Details for Student with ID: {sid} has been deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Details not deleted." + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        //Search method
        public DataTable Search(int sid) 
        {
            //Set the query
            string query = $"SELECT * FROM StudentDetails WHERE [StudentID] = '{sid}'";

            con = new SqlConnection(connect);
            adapter = new SqlDataAdapter(query, con);

            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }
    }
}
