using System;
using Lib;

namespace testProgram
{
    public static class TestProgram
    {
        public static void Main()
        {
            #region Test Student Class
            //test Student class
            Student pesho = new Student("Pesho", "Goshev", "Kirov", 8876, "Bulgaria, Sofia, 84681 st", "986571342",
                                        "pesho@gmail.com", "second", Specialty.Ikonomics, University.Harvard, Faculty.Buisnes);

            Student pesho2 = new Student("Pesho", "Goshev", "Kirov", 8659, "Bulgaria, Sofia, 84681 st", "986571342",
                                        "pesho@gmail.com", "second", Specialty.Ikonomics, University.Harvard, Faculty.Buisnes);

            //test == operator and != operator
            Console.WriteLine(pesho == pesho2);

            //test ToString() method
            Console.WriteLine(pesho.ToString());

            //test Equals() method
            Console.WriteLine(pesho.Equals(pesho2));

            //test Clone() method
            object PeshoClone = pesho.Clone();
            Console.WriteLine(PeshoClone);

            //comparison
            if (pesho.CompareTo(pesho2) > 0)
            {
                Console.WriteLine("The two students are the same.");
            }
            #endregion

            #region Test Person Class

            //test functionality of Person
            Person human = new Person("Pesho"); //without age
            Console.WriteLine(human);

            #endregion

            #region Test BitArray64
            BitArray64 num = new BitArray64(7);

            //test Equals()
            Console.WriteLine(num.Equals(7));

            //test enumerator
            //foreach (var bit in num)
            //{
            //    Console.Write(bit);
            //}
            #endregion
        }
    }
}
