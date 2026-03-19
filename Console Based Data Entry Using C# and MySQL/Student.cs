using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Based_Data_Entry_Using_C__and_MySQL
{
    internal class Student
    {
        // Properties of the Student class
        public string IdNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Course_Code { get; set; }

        // Constructor to initialize student data
        public Student(string idNo, string lastName, string firstName, string course)
        {
            IdNo = idNo;
            LastName = lastName;
            FirstName = firstName;
            Course_Code = course;
        }
    }
}
