using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Student : ICloneable, IComparable<Student>
    {
        //first name
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        //middle name
        private string middleName;

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }
        
        //last name
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        
        //SSN
        private int ssn;

        public int SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        //permanent address
        private string permanentAddress;

        public string PermanentAddress
        {
            get { return permanentAddress; }
            set { permanentAddress = value; }
        }

        //mobile phone
        private string mobilePhone;

        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }

        //email
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        //course
        private string course;

        public string Course
        {
            get { return course; }
            set { course = value; }
        }
        
        //specialty
        private Specialty specialty;

        public Specialty Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }
        
        //university
        private University university;

        public University University
        {
            get { return university; }
            set { university = value; }
        }
        

        //faculty
        private Faculty faculty;

        public Faculty Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        //override Equals()
        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (student == null)
                return false;

            if (!Object.Equals(this.SSN, student.SSN))
                return false;

            return true;
        }

        //constructor with no parametars
        public Student()
        {
        }

        //constructor to initialize Student
        public Student( string firstName, string middleName, string lastName, int ssn,
                        string permanentAddress, string mobilePhone, string email,
                        string course, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        //helper function for getting university name from enum
        private string GetUniversityName(University university)
        {
            switch(university)
            {
                case University.MIT :
                    return "MIT";
                    break;
                case University.Harvard : 
                    return "Harvard";
                    break;
                case University.Stanfort :
                    return "Stanfort";
                    break;
                default:
                    return "Unknown university";
                    break;
            }
        }

        //helper function for getting specialty name from enum
        private string GetSpecialtyName(Specialty specialty)
        {
            switch (specialty)
            {
                case Specialty.Chemestry:
                    return "Chemestry";
                    break;
                case Specialty.Ikonomics:
                    return "Ikonomics";
                    break;
                case Specialty.IT:
                    return "IT";
                    break;
                case Specialty.Math:
                    return "Math";
                    break;
                case Specialty.Phisics:
                    return "Phisics";
                    break;
                default:
                    return "Unknown specialty";
                    break;
            }
        }

        //helper function for getting faculty name from enum
        private string GetFacultyName(Faculty faculty)
        {
            switch (faculty)
            {
                case Faculty.Buisnes:
                    return "Buisnes";
                    break;
                case Faculty.Chemestry:
                    return "Chemestry";
                    break;
                case Faculty.Phisics:
                    return "Phisics";
                    break;
                case Faculty.Math:
                    return "Math";
                    break;
                default:
                    return "Unknown faculty";
                    break;
            }
        }

        //override ToString()
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0} {1} {2}\n", this.FirstName, this.MiddleName, this.LastName);
            result.AppendFormat("Address: {0}\n", this.PermanentAddress);
            result.AppendFormat("Mobile Phone Number: {0}\n", this.MobilePhone);
            result.AppendFormat("Email: {0}\n", this.Email);
            result.AppendFormat("SSN: {0}\n", this.SSN);
            result.AppendFormat("University: {0}\n", GetUniversityName( this.University ) );
            result.AppendFormat("Specialty: {0}\n", GetSpecialtyName( this.Specialty ) );
            result.AppendFormat("Course: {0}\n", this.Course);
            result.AppendFormat("Faculty: {0}\n", GetFacultyName( this.Faculty ) );

            return result.ToString();
        }

        //override GetHashCode()
        public override int GetHashCode()
        {
            //get the default
            return base.GetHashCode();
        }

        //override == operator
        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Student.Equals(firstStudent, secondStudent);
        }

        //override != operator
        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(Student.Equals(firstStudent, secondStudent));
        }

        //implement Clone method
        public object Clone()
        {
            Student clonedStudent = new Student();

            clonedStudent.Course = this.Course;
            clonedStudent.Email = this.Email;
            clonedStudent.Faculty = this.Faculty;
            clonedStudent.FirstName = this.FirstName;
            clonedStudent.MiddleName = this.MiddleName;
            clonedStudent.LastName = this.LastName;
            clonedStudent.PermanentAddress = this.PermanentAddress;
            clonedStudent.Specialty = this.Specialty;
            clonedStudent.SSN = this.SSN;
            clonedStudent.University = this.University;

            return clonedStudent;
        }

        public int CompareTo(Student other)
        {
            StringBuilder currStudentName = new StringBuilder();

            currStudentName.Append(this.FirstName);
            currStudentName.Append(this.MiddleName);
            currStudentName.Append(this.LastName);

            StringBuilder otherStudentName = new StringBuilder();

            otherStudentName.Append(other.FirstName);
            otherStudentName.Append(other.MiddleName);
            otherStudentName.Append(other.LastName);

            if (currStudentName.ToString().Equals(otherStudentName.ToString()) ||
                this.SSN == other.SSN)
            {
                return 1;
            }

            return 0;
        }
    }
}
