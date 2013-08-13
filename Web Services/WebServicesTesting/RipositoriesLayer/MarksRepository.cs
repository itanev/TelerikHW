using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RipositoriesLayer
{
    public class MarksRepository : IRepsitory<Mark>
    {
        private DbContext dbContext;
        private DbSet<Mark> MarksSet;

        public MarksRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.MarksSet = this.dbContext.Set<Mark>();
        }

        public IQueryable<Mark> Find(Expression<Func<Mark, int, bool>> predicate)
        {
            return this.MarksSet.Where(predicate);
        }

        public Mark Add(Mark entity)
        {
            this.MarksSet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Mark Update(int id, Mark entity)
        {
            var originalEntity = this.MarksSet.Find(id);

            originalEntity.Students = entity.Students;
            originalEntity.subject = entity.subject;
            originalEntity.value = entity.value;

            this.dbContext.SaveChanges();

            return originalEntity;
        }

        public void Delete(int id)
        {
            var entity = this.MarksSet.Find(id);
            if (entity != null)
            {
                this.MarksSet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public Mark Get(int id)
        {
            return this.MarksSet.Find(id);
        }

        public IQueryable<Mark> All()
        {
            return this.MarksSet;
        }
    }
}
