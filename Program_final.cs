using System;
using System.Data.Entity;

namespace StudentDatabase
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolDB") { }
        public DbSet<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                FirstName = "Ahmet",
                LastName = "Yýlmaz",
                DateOfBirth = new DateTime(2000, 1, 1)
            };

            AddStudent(student);
            Console.ReadKey();
        }

        static void AddStudent(Student student)
        {
            using (var context = new SchoolContext())
            {
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student added!");
                Console.WriteLine($"ID: {student.StudentID}");
            }
        }
    }
}
