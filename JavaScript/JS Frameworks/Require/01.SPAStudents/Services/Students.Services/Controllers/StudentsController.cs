using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Require.Services.Controllers
{
    public class StudentsController : ApiController
    {
        public List<Student> Students { get; set; }

        public StudentsController()
        {
            this.Students = GenerateStudents(10);
        }

        [ActionName("students")]
        public IQueryable<Student> GetStudents()
        {
            return this.Students.AsQueryable();
        }

        public IQueryable<Mark> GetMarks(int studentId)
        {
            return this.Students[studentId].Marks.AsQueryable();
        }

        private List<Student> GenerateStudents(int num)
        {
            List<Student> students = new List<Student>();
            Random rand = new Random();
            for (int i = 0; i < num; i++)
            {
                Student currStudent = new Student();
                currStudent.Id = i + 1;
                currStudent.Grade = rand.Next(1, 13);
                currStudent.Name = "Student#" + i;

                for (int k = 0; k < i; k++)
                {
                    Mark currMark = new Mark();
                    currMark.Subject = "Subject#" + k;
                    currMark.Score = rand.Next(2, 7);
                    currStudent.Marks.Add(currMark);
                }

                students.Add(currStudent);
            }

            return students;
        }

        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
