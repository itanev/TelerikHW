using System;
using System.Linq;
using Library;

class OrderByThenBy
{
    static void Main()
    {
        Student[] listStudents = new Student[5];

        listStudents[0].FirstName = "Pesho";
        listStudents[0].LastName = "Peshev";
        listStudents[0].age = 19;

        listStudents[1].FirstName = "Kiro";
        listStudents[1].LastName = "Qnev";
        listStudents[1].age = 17;

        listStudents[2].FirstName = "Ivan";
        listStudents[2].LastName = "Ivanov";
        listStudents[2].age = 29;

        listStudents[3].FirstName = "Jeko";
        listStudents[3].LastName = "Iordanov";
        listStudents[3].age = 20;

        listStudents[4].FirstName = "Georgi";
        listStudents[4].LastName = "Penev";
        listStudents[4].age = 24;

        //with lambda functions and OrderBy(), ThenBy()
        Console.WriteLine("With lambda");

        var orderedList = listStudents.OrderBy((student) => student.FirstName).
                                        ThenBy((student) => student.LastName);

        foreach (var student in orderedList)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }

        Console.WriteLine("\nWith LINQ");

        //with LINQ
        var sortedList =
            from student in listStudents
            orderby student.FirstName, student.LastName
            select student;

        foreach (var student in sortedList)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }
}
