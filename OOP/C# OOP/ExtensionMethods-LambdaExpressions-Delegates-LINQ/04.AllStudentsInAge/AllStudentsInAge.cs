using System;
using Library;
using System.Linq;

class AllStudentsInAge
{
    static void Main()
    {
        Student[] students = new Student[5];

        students[0].FirstName = "Pesho";
        students[0].LastName = "Peshev";
        students[0].age = 19;

        students[1].FirstName = "Kiro";
        students[1].LastName = "Qnev";
        students[1].age = 17;

        students[2].FirstName = "Ivan";
        students[2].LastName = "Ivanov";
        students[2].age = 29;

        students[3].FirstName = "Jeko";
        students[3].LastName = "Iordanov";
        students[3].age = 20;

        students[4].FirstName = "Georgi";
        students[4].LastName = "Penev";
        students[4].age = 24;

        FindStudentsInAge(students);
    }

    static void FindStudentsInAge(Student[] listStudents)
    {
        var studentsInAge =
            from student in listStudents
            where InAge(student)    //using method to do the comparisons
            select student;

        foreach (var student in studentsInAge)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }

    static bool InAge(Student student)
    {
        if (student.age >= 18 && student.age <= 24)
        {
            return true;
        }

        return false;
    }
}
