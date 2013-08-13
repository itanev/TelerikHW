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
    public class MarksController : ApiController
    {
        private MarksRepository repository;
        private StudentsEntities dbContext;

        public MarksController()
        {
            dbContext = new StudentsEntities();
            this.repository = new MarksRepository(dbContext);
        }

        // GET api/students
        public IEnumerable<Mark> Get()
        {
            return repository.All().ToList();
        }

        // GET api/students/5
        public Mark Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/students
        public void Post([FromBody]Mark value)
        {
            repository.Add(value);
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]Mark value)
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