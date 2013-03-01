using System;

namespace Library03
{
    public class Kitten : Cat
    {
        //kitten constructor inherits the base - cats constructor
        public Kitten(double age, string name) : base(age, name, "female")
        {
        }
    }
}
