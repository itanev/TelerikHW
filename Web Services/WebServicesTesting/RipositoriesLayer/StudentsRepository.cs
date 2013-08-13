using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RipositoriesLayer
{
    public class StudentsRepository : IRepsitory<Student>
    {
        private DbContext dbContext;
        private DbSet<Student> studentsSet;

        public StudentsRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.studentsSet = this.dbContext.Set<Student>();
        }

        public IQueryable<Student> Find(Expression<Func<Student, int, bool>> predicate)
        {
            return this.studentsSet.Where(predicate);
        }

        public Student Add(Student entity)
        {
            this.studentsSet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Student Update(int id, Student entity)
        {
            var originalEntity = this.studentsSet.Find(id);

            originalEntity.age = entity.age;
            originalEntity.firstName = entity.firstName;
            originalEntity.lastName = entity.lastName;
            originalEntity.grade = entity.grade;
            originalEntity.Marks = entity.Marks;
            originalEntity.School = entity.School;

            this.dbContext.SaveChanges();

            return originalEntity;
        }

        public void Delete(int id)
        {
            var entity = this.studentsSet.Find(id);
            if (entity != null)
            {
                this.studentsSet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public Student Get(int id)
        {
            return this.studentsSet.Find(id);
        }

        public IQueryable<Student> All()
        {
            return this.studentsSet;
        }
    }
}
