using Students.Models;
using Students.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Students.Services.Controllers
{
    [EnableCors(origins: "http://localhost:17714/api/students", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        public HttpResponseMessage PostStudent(Student student)
        {
            var context = new Context();

            context.Students.Add(student);
            context.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.Created);
        }

        public HttpResponseMessage GetStudents()
        {
            var context = new Context();
            return this.Request.CreateResponse(HttpStatusCode.OK, context.Students.AsQueryable());
        }
    }
}
