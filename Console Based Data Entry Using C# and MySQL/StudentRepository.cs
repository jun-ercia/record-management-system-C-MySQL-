using System;
using MySql.Data.MySqlClient;

namespace Console_Based_Data_Entry_Using_C__and_MySQL
{
    internal class StudentRepository
    {
        private readonly string connectionString;

        // Constructor that accepts the database connection string
        public StudentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Displays all student records from the database
        public void DisplayAllStudents()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT idno, lastname, firstname, course_code FROM students ORDER BY lastname, firstname";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("\nNo student records found.");
                            return;
                        }

                        Console.WriteLine("\n==============================================");
                        Console.WriteLine("              STUDENT RECORDS");
                        Console.WriteLine("==============================================");

                        while (reader.Read())
                        {
                            Console.WriteLine($"ID No     : {reader["idno"]}");
                            Console.WriteLine($"Last Name : {reader["lastname"]}");
                            Console.WriteLine($"First Name: {reader["firstname"]}");
                            Console.WriteLine($"Course    : {reader["course_code"]}");
                            Console.WriteLine("----------------------------------------------");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFailed to retrieve student records.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Inserts a new student record into the database
        public void AddStudent(Student student)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO students (idno, lastname, firstname, course_code) 
                                     VALUES (@idno, @lastname, @firstname, @course)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idno", student.IdNo);
                        command.Parameters.AddWithValue("@lastname", student.LastName);
                        command.Parameters.AddWithValue("@firstname", student.FirstName);
                        command.Parameters.AddWithValue("@course", student.Course_Code);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nStudent record added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to add student record.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("\nDatabase error while adding student.");
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nUnexpected error while adding student.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Checks if a student ID already exists in the database
        public bool StudentExists(string idNo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM students WHERE idno = @idno";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idno", idNo);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFailed to check student record.");
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Searches for a student record by ID number
        public void SearchStudentById(string idNo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT idno, lastname, firstname, course_code FROM students WHERE idno = @idno";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idno", idNo);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("\n==============================================");
                                Console.WriteLine("            STUDENT RECORD FOUND");
                                Console.WriteLine("==============================================");
                                Console.WriteLine($"ID No     : {reader["idno"]}");
                                Console.WriteLine($"Last Name : {reader["lastname"]}");
                                Console.WriteLine($"First Name: {reader["firstname"]}");
                                Console.WriteLine($"Course    : {reader["course_code"]}");
                                Console.WriteLine("==============================================");
                            }
                            else
                            {
                                Console.WriteLine("\nNo student found with the given ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFailed to search student record.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Updates a selected student field based on the user's choice
        public void UpdateStudentField(string idNo, int fieldChoice, string newValue)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "";

                    // Determine which field will be updated
                    switch (fieldChoice)
                    {
                        case 1:
                            query = "UPDATE students SET firstname = @newValue WHERE idno = @idno";
                            break;

                        case 2:
                            query = "UPDATE students SET lastname = @newValue WHERE idno = @idno";
                            break;

                        case 3:
                            query = "UPDATE students SET course_code = @newValue WHERE idno = @idno";
                            break;

                        default:
                            Console.WriteLine("\nInvalid update option.");
                            return;
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newValue", newValue);
                        command.Parameters.AddWithValue("@idno", idNo);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nStudent record updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nNo matching student record found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFailed to update student record.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Deletes a student record using the given ID number
        public void DeleteStudent(string idNo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM students WHERE idno = @idno";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idno", idNo);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\nStudent record deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nNo matching student record found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nFailed to delete student record.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
