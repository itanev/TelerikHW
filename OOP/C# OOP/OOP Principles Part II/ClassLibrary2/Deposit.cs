using System;

namespace Bank
{
    public class Deposit : Account
    {
        public Deposit(decimal balance, float interestRate, Customer customer)
            : base(balance, interestRate, customer)
        {
        }

        public override decimal CalculateInterestAmount(byte months)
        {
            if (!IsValid(months))
                throw new ArgumentException("Monts must be positive number");

            if (this.balance > 0 && this.balance < 1000)
                this.interestRate = 0;
            return (decimal)(months * this.interestRate);
        }
    }
}
