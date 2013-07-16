using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsSystem
{
    public class StudentsInCourse
    {
        private ICollection<Student> students;
        private ICollection<Course> courses;

        public StudentsInCourse()
        {
            this.students = new HashSet<Student>();
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }
    }
}
