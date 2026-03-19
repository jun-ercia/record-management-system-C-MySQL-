# Student Record Management System (C# + MySQL)

## Overview

This project is a **Console-Based Student Record Management System** developed using **C# and MySQL (ADO.NET)**.
It demonstrates fundamental database operations (CRUD) using an Object-Oriented Programming (OOP) approach.

The system allows users to:

* Add new student records
* View all students
* Search student by ID
* Update student information
* Delete student records

## Features

* Object-Oriented Design (OOP)
* Menu-driven console interface
* MySQL database integration using `MySql.Data`
* Full CRUD operations:

  * Create (Insert)
  * Read (Select)
  * Update
  * Delete
* Input validation
* Duplicate ID checking
* Search functionality
* Safe SQL queries using parameters (prevents SQL injection)

## Technologies Used

* C#
* .NET (Console Application)
* MySQL
* ADO.NET (MySqlClient)
* Visual Studio

## Project Structure

```
MConsole_Based_Data_Entry_Using_C__and_MySQL
│
├── Program.cs
├── Student.cs
├── StudentRepository.cs
└── StudentManagementApp.cs
```

### Description of Files

* `Program.cs`
  Entry point of the application

* `Student.cs`
  Represents the student entity (data model)

* `StudentRepository.cs`
  Handles all database operations (CRUD)

* `StudentManagementApp.cs`
  Contains menu system and user interaction

## Database Setup

### Step 1: Create Database and Table

```sql
CREATE DATABASE IF NOT EXISTS student_db;
USE student_db;

CREATE TABLE IF NOT EXISTS students (
    idno VARCHAR(20) PRIMARY KEY,
    lastname VARCHAR(50) NOT NULL,
    firstname VARCHAR(50) NOT NULL,
    course_code VARCHAR(20) NOT NULL
);
```

### Step 2: Insert Sample Data

```sql
INSERT INTO students (idno, lastname, firstname, course_code) VALUES
('1001', 'Santos', 'Maria', 'BSCS'),
('1002', 'Cruz', 'Juan', 'BSCPE'),
('1003', 'Reyes', 'Angela', 'BSIT'),
('1004', 'Garcia', 'Mark', 'BSCS'),
('1005', 'Torres', 'Nicole', 'BSCPE'),
('1006', 'Flores', 'Daniel', 'BSIT'),
('1007', 'Ramos', 'Sophia', 'BSCS'),
('1008', 'Gomez', 'Ethan', 'BSCPE'),
('1009', 'Mendoza', 'Isabella', 'BSIT'),
('1010', 'Navarro', 'James', 'BSCS');
```

## Configuration

Update your connection string in `Program.cs`:

```csharp
string connectionString = "server=localhost;user id=root;password=admin;database=student_db;";
```

Make sure:

* MySQL server is running
* Port is correct
* Username and password are correct


## How to Run

1. Open the project in Visual Studio
2. Install MySQL NuGet package:

   ```
   MySql.Data
   ```
3. Build the project
4. Run the application
5. Use the menu to interact with the system

## Sample Menu

```
STUDENT RECORD MANAGEMENT SYSTEM

1. View All Students
2. Add Student
3. Search Student by ID
4. Update Student
5. Delete Student
6. Exit
```

## Sample Output

```
STUDENT RECORD FOUND

ID No       : 1001
Last Name   : Santos
First Name  : Maria
Course Code : BSCS
```

## Key Concepts Demonstrated

* OOP (Classes, Objects, Encapsulation)
* Layered Architecture (UI + Repository)
* ADO.NET Data Access
* Parameterized Queries
* Exception Handling
* Input Validation


## Future Improvements

* Search by Last Name
* Update all fields at once
* Pagination for large datasets
* GUI version (Windows Forms / WPF)
* Logging system
* Unit testing


## Author

**Jun Y. Ercia**

## License

This project is for **educational purposes only**.
