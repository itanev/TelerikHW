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
    public class SchoolsController : ApiController
    {
        private SchoolsRepository repository;
        private StudentsEntities dbContext;

        public SchoolsController()
        {
            dbContext = new StudentsEntities();
            this.repository = new SchoolsRepository(dbContext);
        }

        // GET api/students
        public IEnumerable<School> Get()
        {
            return repository.All().ToList();
        }

        // GET api/students/5
        public School Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/students
        public void Post([FromBody]School value)
        {
            repository.Add(value);
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]School value)
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