using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using StudentsSystem;
using StudentSystemContext;
using System.Data.Entity;

namespace StudentSystemClient
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
            var db = new Context();

            using (db)
            {
                Student pesho = new Student
                {
                    Id = 1,
                    Name = "Pesho",
                    Number = 44242
                };

                Course math = new Course
                {
                    Id = 1,
                    Name = "Math",
                    Description = "Bulshit",
                    Materials = "Some materials"
                };

                Homework homework = new Homework
                {
                    Id = 1,
                    Content = "some tasks",
                    TimeSent = DateTime.Now,
                    Courses = new HashSet<Course>(),
                    Students = new HashSet<Student>()
                };

                StudentsInCourse relationship = new StudentsInCourse
                {
                    Courses = new HashSet<Course>(),
                    Students = new HashSet<Student>()
                };

                relationship.Courses.Add(math);
                relationship.Students.Add(pesho);

                homework.Courses.Add(math);
                homework.Students.Add(pesho);

                db.Students.Add(pesho);

                db.SaveChanges();

                // Test the data.
                foreach (var student in db.Students)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
    }
}
