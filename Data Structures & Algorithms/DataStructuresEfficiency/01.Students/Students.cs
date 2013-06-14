using System;
using System.Collections.Generic;
using System.IO;

namespace _01.Students
{
    public class Students
    {
        public static void Main()
        {
             SortedDictionary<string, List<Tuple<string, string>>> studentsAndCourses = 
                 new SortedDictionary<string,List<Tuple<string,string>>>();

            FillDictionary(studentsAndCourses);
            Print(studentsAndCourses);
        }
  
        private static void Print(SortedDictionary<string, List<Tuple<string, string>>> studentsAndCourses)
        {
            foreach (var item in studentsAndCourses)
            {
                var sortedNames = item.Value;
                sortedNames.Sort();
                Console.Write("{0}: ", item.Key);

                foreach (var name in sortedNames)
                {
                    Console.Write("{0} {1}, ", name.Item1, name.Item2);
                }

                Console.WriteLine();
            }
        }
  
        private static void FillDictionary(SortedDictionary<string, List<Tuple<string, string>>> studentsAndCourses)
        {
            StreamReader reader = new StreamReader("students.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    var parts = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var firstName = parts[0].Trim();
                    var lastName = parts[1].Trim();
                    var course = parts[2].Trim();
                    if (studentsAndCourses.ContainsKey(course))
                    {
                        studentsAndCourses[course].Add(new Tuple<string, string>(firstName, lastName));
                    }
                    else
                    {
                        var studentsInCourse = new List<Tuple<string, string>>();
                        studentsInCourse.Add(new Tuple<string, string>(firstName, lastName));

                        studentsAndCourses.Add(course, studentsInCourse);
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
