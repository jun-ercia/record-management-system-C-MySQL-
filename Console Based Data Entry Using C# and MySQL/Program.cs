using Console_Based_Data_Entry_Using_C__and_MySQL;
using MySql.Data.MySqlClient;
using System;

namespace MConsole_Based_Data_Entry_Using_C__and_MySQL
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Database connection string
            string connectionString = "server=localhost;user id=root;password=admin;database=student_db;";

            // Create repository and application objects
            StudentRepository studentRepository = new StudentRepository(connectionString);
            StudentManagementApp app = new StudentManagementApp(studentRepository);

            // Run the application
            app.Run();
        }
    }
}
