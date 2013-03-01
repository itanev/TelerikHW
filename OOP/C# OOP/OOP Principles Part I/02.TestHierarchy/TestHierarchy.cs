using System;
using Library02;
using System.Collections.Generic;
using System.Linq;

class TestHierarchy
{
    static void Main()
    {
        //students
        List<Student> listStudents = new List<Student>();

        listStudents.Add(new Student("Kiro", "Peshev", 3));
        listStudents.Add(new Student("Pesho", "Peshev", 5));
        listStudents.Add(new Student("Gosho", "Peshev", 2));
        listStudents.Add(new Student("Ivan", "Peshev", 3.4f));
        listStudents.Add(new Student("Mincho", "Peshev", 6));
        listStudents.Add(new Student("Zario", "Peshev", 2));
        listStudents.Add(new Student("Nqkoi", "Peshev", 2.5f));
        listStudents.Add(new Student("Nikoi", "Peshev", 5));
        listStudents.Add(new Student("Vsichki", "Peshev", 4));
        listStudents.Add(new Student("Kiro", "Peshev", 5.4f));

        var sortedStudents =
            from student in listStudents
            orderby student.Grade
            select student;

        Console.WriteLine("Students");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine("{0} {1} - {2}", student.FirstName, student.LastName, student.Grade);
        }

        //workers
        List<Worker> listWorkers = new List<Worker>();

        listWorkers.Add(new Worker(100, 8));
        listWorkers.Add(new Worker(150, 8));
        listWorkers.Add(new Worker(50, 2));
        listWorkers.Add(new Worker(500, 12));
        listWorkers.Add(new Worker(80, 6));
        listWorkers.Add(new Worker(120, 9));
        listWorkers.Add(new Worker(90, 8));
        listWorkers.Add(new Worker(35, 3));
        listWorkers.Add(new Worker(200, 10));
        listWorkers.Add(new Worker(180, 9));

        var sortedWorkers =
            from worker in listWorkers
            orderby worker.MoneyPerHour() descending
            select worker;

        Console.WriteLine("\nWorkers");
        foreach (var worker in sortedWorkers)
        {
            Console.WriteLine("{0:F2}", worker.MoneyPerHour());
        }
    }
}
