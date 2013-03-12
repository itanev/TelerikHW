using System;

namespace Bank
{
    public class Loan : Account
    {
        public Loan(decimal balance, float interestRate, Customer customer)
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
            if (!IsValid(months))
                throw new ArgumentException("Months must be positive number");

            if (this.customer is Customer && months >= 3)
                return (decimal)(months * this.interestRate) - (decimal)(3 * this.interestRate);
            else if (this.customer is Company && months >= 2)
                return (decimal)(months * this.interestRate) - (decimal)(2 * this.interestRate);
            else
                return (decimal)(months * this.interestRate - months * this.interestRate);
        }
    }
}
