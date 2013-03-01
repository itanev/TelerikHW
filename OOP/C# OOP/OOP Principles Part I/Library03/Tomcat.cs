using System;

namespace Library03
{
    public class Tomcat : Cat
    {
        //tomcat constructor inherits the base - cats constructor
        public Tomcat(double age, string name)
            : base(age, name, "male")
        {
        }
    }
}
