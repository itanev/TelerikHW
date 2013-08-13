using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RipositoriesLayer
{
    public class SchoolsRepository : IRepsitory<School>
    {
        private DbContext dbContext;
        private DbSet<School> SchoolsSet;

        public SchoolsRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.SchoolsSet = this.dbContext.Set<School>();
        }

        public IQueryable<School> Find(Expression<Func<School, int, bool>> predicate)
        {
            return this.SchoolsSet.Where(predicate);
        }

        public School Add(School entity)
        {
            this.SchoolsSet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public School Update(int id, School entity)
        {
            var originalEntity = this.SchoolsSet.Find(id);

            originalEntity.Students = entity.Students;
            originalEntity.location = entity.location;
            originalEntity.name = entity.name;

            this.dbContext.SaveChanges();

            return originalEntity;
        }

        public void Delete(int id)
        {
            var entity = this.SchoolsSet.Find(id);
            if (entity != null)
            {
                this.SchoolsSet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public School Get(int id)
        {
            return this.SchoolsSet.Find(id);
        }

        public IQueryable<School> All()
        {
            return this.SchoolsSet;
        }
    }
}
