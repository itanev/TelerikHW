using System;
using System.Linq;
using Library;

class FirstBeforeLastLINQ
{
    static void Main()
    {
        //creating array of students
        Student[] students = new Student[5];

        students[0].FirstName = "Pesho";
        students[0].LastName = "Peshev";

        students[1].FirstName = "Kiro";
        students[1].LastName = "Qnev";

        students[2].FirstName = "Ivan";
        students[2].LastName = "Ivanov";

        students[3].FirstName = "Jeko";
        students[3].LastName = "Iordanov";

        students[4].FirstName = "Georgi";
        students[4].LastName = "Penev";

        FirstNameBeforeLastNameStudents(students);
    }

    //finding the students
    static void FirstNameBeforeLastNameStudents(Student[] listStudents)
    {
        var match =
            from student in listStudents
            where AlphabeticllyCompareNames(student)    //using method to do the comparisons
            select student;

        //printing the students who match the condition
        foreach (var studentMatch in match)
        {
            Console.WriteLine("{0} {1}", studentMatch.FirstName, studentMatch.LastName);
        }
    }

    //comparison method
    static bool AlphabeticllyCompareNames(Student currStudent)
    {
        int numCompares = Math.Min(currStudent.FirstName.Length, currStudent.LastName.Length);

        for (int i = 0; i < numCompares; i++)
        {
            if (currStudent.FirstName[i] < currStudent.LastName[i])
            {
                return true;
            }
            else if (currStudent.FirstName[i] > currStudent.LastName[i])
            {
                return false;
            }
        }

        return false;
    }
}
