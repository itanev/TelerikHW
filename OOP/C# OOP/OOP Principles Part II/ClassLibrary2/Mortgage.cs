using System;

namespace Bank
{
    public class Mortgage : Account
    {
        public Mortgage(decimal balance, float interestRate, Customer customer)
            : base(balance, interestRate, customer)
        {
        }

        //override withdraw
        public override void WithDraw(decimal amount)
        {
            Console.WriteLine("Action can not be completed.");
        }

        public override decimal CalculateInterestAmount(byte months)
        {
            if (this.customer is Company && months >= 12)
                return (decimal)(months * this.interestRate - 12 * (this.interestRate / 2));
            else if (this.customer is Individual && months >= 6)
                return (decimal)(months * this.interestRate - 6 * this.interestRate);
            else
                return (decimal)(months * this.interestRate - months * this.interestRate);
        }
    }
}
