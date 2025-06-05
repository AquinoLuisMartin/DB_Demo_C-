using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddNewData_Click(object sender, EventArgs e)
        {
            StudentManager sm = new StudentManager();
            //sm.InsertStudent("Jose", "Ramos", Convert.ToDateTime("1970-03-02"), "jramos@gmail.com");
            sm.InsertStudent("Levie", "Panesa", Convert.ToDateTime("1980-03-02"), "lpanesa@gmail.com");
            sm.InsertStudent("Abegail", "Salvador", Convert.ToDateTime("1990-06-05"), "asalvador@gmail.com");

        } //End of procedure btnAddNewData

        private void btnRetrieveAllData_Click(object sender, EventArgs e)
        {
            StudentManager sm = new StudentManager();
            sm.GetAllStudents();


        }

        private void btnRetrieveSelectedData_Click(object sender, EventArgs e)
        {
            StudentManager sm = new StudentManager();
            sm.GetStudentById(5);
        }

        private void btnUpdateSpecificData_Click(object sender, EventArgs e)
        {
            StudentManager sm = new StudentManager();
            sm.UpdateStudentEmail(1, "maryrose@gmail.com");
        }

        private void btnDeleteSpecificData_Click(object sender, EventArgs e)
        {
            StudentManager sm = new StudentManager();
            sm.DeleteStudent(1);
        }
    } //End of class Form1

    public class StudentManager
    {
        private DatabaseHelper dbHelper;
        public string mesg = "";

        public StudentManager()
        {
            dbHelper = new DatabaseHelper();
        }

        public void InsertStudent(string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            if (connection == null) return;

            string query = "INSERT INTO Students (FirstName, LastName, DateOfBirth, Email) VALUES (@FirstName, @LastName, @DateOfBirth, @Email)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@Email", email);
                try
                {
                    int rowsaffected = command.ExecuteNonQuery();
                    mesg = $"{rowsaffected} row(s) inserted successfully";
                    MessageBox.Show(mesg);

                }
                catch (MySqlException ex)
                {
                    mesg = $"Error inserting student: {ex.Message}";
                    MessageBox.Show(mesg);
                }
                finally
                {
                    dbHelper.ClosedConnection(connection);
                }

            }
        } //End of method InsertStudent()

        public void GetAllStudents()
        {
            MySqlConnection connection = dbHelper.GetConnection();
            if (connection == null) return;

            string query = "SELECT StudentID, FirstName, LastName, DateOfBirth, Email FROM Students";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            mesg = "All Students\n\n";
                            while (reader.Read())
                            {
                                int studentId = reader.GetInt32("StudentID");
                                string firstName = reader.GetString("FirstName");
                                string lastName = reader.GetString("LastName");
                                DateTime dateOfBirth = reader.GetDateTime("DateOfBirth");
                                string email = reader.GetString("email");

                                mesg += $"ID: {studentId}\nComplete name: {firstName} {lastName}\nDate of Birth: {dateOfBirth}\nEmail address: {email}\n\n";
                            }
                            MessageBox.Show(mesg);
                        }
                        else
                        {
                            mesg = "No student found";
                            MessageBox.Show(mesg);

                        }
                    }
                }
                catch (MySqlException ex)
                {
                    mesg = $"Error retrieving student: {ex.Message}";
                    MessageBox.Show(mesg);

                }
                finally
                {
                    dbHelper.ClosedConnection(connection);
                }
            }

        } //End of method GetAllStudents()

        public void GetStudentById(int studentId)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            if (connection == null) return;

            string query = "SELECT StudentID, FirstName, LastName, DateOfBirth, Email FROM Students WHERE StudentID = @StudentID";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentId);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        { 
                            string firstName = reader.GetString("FirstName");
                            string lastName = reader.GetString("LastName");
                            DateTime dateOfBirth = reader.GetDateTime("DateOfBirth");
                            string email = reader.GetString("email");

                            mesg += $"ID: {studentId}\nComplete name: {firstName} {lastName}\nDate of Birth: {dateOfBirth}\nEmail address: {email}\n\n";
                           
                            MessageBox.Show(mesg);
                        }
                        else
                        {
                            mesg = "No student found";
                            MessageBox.Show(mesg);

                        }
                    }
                }
                catch (MySqlException ex)
                {
                    mesg = $"Error retrieving student: {ex.Message}";
                    MessageBox.Show(mesg);

                }
                finally
                {
                    dbHelper.ClosedConnection(connection);
                }
            }

        } //End of method GetStudentById()


        public void UpdateStudentEmail(int studentID, string newEmail)
        {
            MySqlConnection connection = dbHelper.GetConnection();

            if (connection == null) return;

            string query = "UPDATE Students SET Email = @NewEmail WHERE StudentID = @StudentID";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@NewEmail", newEmail);
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        mesg = $"{rowsAffected} row(s) updated successfully";
                    }
                    else
                    {
                        mesg = $"Student with ID {studentID} not found!";
                    }
                    MessageBox.Show(mesg);
                }
                catch (MySqlException ex) 
                {
                    mesg = $"Error updating student: {ex.Message}";
                    MessageBox.Show(mesg);
                }
                finally
                {
                    dbHelper.ClosedConnection(connection);
                }
            }

        } //End of method UpdateStudentEmail()

        public void DeleteStudent(int studentID)
        {
            MySqlConnection connection = dbHelper.GetConnection();

            if (connection == null) return;

            string query = "DELETE FROM Students WHERE StudentID = @StudentID";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentID", studentID);
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        mesg = $"{rowsAffected} row(s) deleted successfully";
                    }
                    else
                    {
                        mesg = $"Student with ID {studentID} not found!";
                    }
                    MessageBox.Show(mesg);
                }
                catch (MySqlException ex)
                {
                    mesg = $"Error deleting student: {ex.Message}";
                    MessageBox.Show(mesg);
                }
                finally
                {
                    dbHelper.ClosedConnection(connection);
                }
            }
        }
    } //End of class StudentManager

} //End of namespace WinFormsApp1
