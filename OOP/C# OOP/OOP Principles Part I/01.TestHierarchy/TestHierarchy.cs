using System;
using Library;

class TestHierarchy
{
    static void Main()
    {
        StudentsClasses JustClass = new StudentsClasses();

        Student student = new Student();
        student.name = "Pesho Peshev";
        student.comment = "Just a student";

        Teacher teacher = new Teacher();
        teacher.name = "Kiro Peshev";
        teacher.comment = "Just a teacher";

        teacher.listDisciplines.Add(new Disciplines("Math"));
        teacher.listDisciplines.Add(new Disciplines("Phisics"));

        JustClass.students.Add(student);
        JustClass.teachers.Add(teacher);
    }
}
