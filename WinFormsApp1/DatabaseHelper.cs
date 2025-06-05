using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WinFormsApp1
{
    public class DatabaseHelper
    {
        //Step 1 Create the connection string
        private string connectionString;
        public string mesg = "";
        public DatabaseHelper() 
        {
            connectionString = "Server=localhost;Database=SchoolDB; Uid=root; Pwd=''";
            //connectionString = "Server=127.0.0.1;Port=3306;Database=SchoolDB; Uid=root; Pwd=''";
          
        }

        //Step 2 Create the method that opens the connection
        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                mesg = "Connection to MySQL opened successfully";
                MessageBox.Show(mesg);
                return connection;
            }
            catch (MySqlException ex)
            {
                mesg = $"Error opening connection: {ex.Message}";
                MessageBox.Show(mesg);
                return null;
            }
        }


        //Step 3 Create the method that closes the connection 
        public void ClosedConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                    mesg = "Connection to MySQL closed successfully";
                    MessageBox.Show(mesg);
                }
                catch (MySqlException ex)
                {
                    mesg = $"Error closing connection: {ex.Message}";
                    MessageBox.Show(mesg);
                }
            }
        }
    }
}
