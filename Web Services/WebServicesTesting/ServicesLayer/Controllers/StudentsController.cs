using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RipositoriesLayer;
using DataLayer;

namespace ServicesLayer.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentsRepository repository;
        private StudentsEntities dbContext;

        public StudentsController()
        {
            dbContext = new StudentsEntities();
            this.repository = new StudentsRepository(dbContext);
        }

        // GET api/students
        public IEnumerable<Student> Get()
        {
            return repository.All().ToList();
        }

        // GET api/students/5
        public Student Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/students
        public void Post([FromBody]Student value)
        {
            repository.Add(value);
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]Student value)
        {
            repository.Update(id, value);
        }

        // DELETE api/students/5
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}