using System;

namespace Console_Based_Data_Entry_Using_C__and_MySQL
{
    internal class StudentManagementApp
    {
        private readonly StudentRepository repository;

        // Constructor that receives the repository object
        public StudentManagementApp(StudentRepository repository)
        {
            this.repository = repository;
        }

        // Main application loop
        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                DisplayMenu();
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        repository.DisplayAllStudents();
                        break;

                    case "2":
                        AddStudentMenu();
                        break;

                    case "3":
                        SearchStudentMenu();
                        break;

                    case "4":
                        UpdateStudentMenu();
                        break;

                    case "5":
                        DeleteStudentMenu();
                        break;

                    case "6":
                        Console.WriteLine("\nExiting program...");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid menu choice. Please try again.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // Displays the main menu
        private void DisplayMenu()
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("         STUDENT RECORD MANAGEMENT SYSTEM");
            Console.WriteLine("=================================================");
            Console.WriteLine("1. View All Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.WriteLine("=================================================");
        }

        // Handles adding a new student
        private void AddStudentMenu()
        {
            Console.WriteLine("\nADD STUDENT");
            Console.WriteLine("-------------------------------------------------");

            string idNo = ReadRequiredInput("Enter ID No: ");

            // Check if ID already exists before inserting
            if (repository.StudentExists(idNo))
            {
                Console.WriteLine("\nA student with this ID already exists.");
                return;
            }

            string lastName = ReadRequiredInput("Enter Last Name: ");
            string firstName = ReadRequiredInput("Enter First Name: ");
            string course = ReadRequiredInput("Enter Course: ");

            Student student = new Student(idNo, lastName, firstName, course);
            repository.AddStudent(student);
        }

        // Handles searching for a student
        private void SearchStudentMenu()
        {
            Console.WriteLine("\nSEARCH STUDENT");
            Console.WriteLine("-------------------------------------------------");

            string idNo = ReadRequiredInput("Enter ID No to search: ");
            repository.SearchStudentById(idNo);
        }

        // Handles updating student information
        private void UpdateStudentMenu()
        {
            Console.WriteLine("\nUPDATE STUDENT");
            Console.WriteLine("-------------------------------------------------");

            string idNo = ReadRequiredInput("Enter ID No to update: ");

            if (!repository.StudentExists(idNo))
            {
                Console.WriteLine("\nStudent ID not found.");
                return;
            }

            Console.WriteLine("\nSelect field to update:");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Course");

            int fieldChoice = ReadMenuChoice("Enter your choice: ", 1, 3);
            string newValue = ReadRequiredInput("Enter new value: ");

            repository.UpdateStudentField(idNo, fieldChoice, newValue);
        }

        // Handles deleting a student
        private void DeleteStudentMenu()
        {
            Console.WriteLine("\nDELETE STUDENT");
            Console.WriteLine("-------------------------------------------------");

            string idNo = ReadRequiredInput("Enter ID No to delete: ");

            if (!repository.StudentExists(idNo))
            {
                Console.WriteLine("\nStudent ID not found.");
                return;
            }

            Console.Write("Are you sure you want to delete this record? (Y/N): ");
            string confirmation = Console.ReadLine();

            if (confirmation != null && confirmation.Trim().ToUpper() == "Y")
            {
                repository.DeleteStudent(idNo);
            }
            else
            {
                Console.WriteLine("\nDelete operation cancelled.");
            }
        }

        // Reads required input and prevents empty values
        private string ReadRequiredInput(string prompt)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input.Trim();
        }

        // Reads and validates a numeric menu choice within a range
        private int ReadMenuChoice(string prompt, int min, int max)
        {
            int choice;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out choice);

                if (!isValid || choice < min || choice > max)
                {
                    Console.WriteLine($"Please enter a number from {min} to {max}.");
                    isValid = false;
                }

            } while (!isValid);

            return choice;
        }
    }
}
