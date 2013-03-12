using System;

namespace Bank
{
    public abstract class Account
    {
        internal Customer customer;
        internal decimal balance { get; set; }
        internal float interestRate { get; set; }

        //base constructor
        public Account(decimal balance, float interestRate, Customer customer)
        {
            this.balance = balance;
            this.interestRate = interestRate;
            this.customer = customer;
        }

        //withdraw money
        public virtual void WithDraw(decimal amount)
        {
            if(!IsValid((int)amount))
                throw new ArgumentException("Amount must be positive number");
            this.balance -= amount;
        }

        //deposit money
        public virtual void Deposit(decimal amount)
        {
            if(!IsValid((int)amount))
                throw new ArgumentException("Months must be positive number");
            this.balance += amount;
        }

        //view balance
        public virtual decimal GetBalance()
        {
            return this.balance;
        }

        //view interestRate
        public virtual float GetInterestRate()
        {
            return this.interestRate;
        }

        public virtual decimal CalculateInterestAmount(byte months)
        {
            if(!IsValid(months))
                throw new ArgumentException("Months must be positive number");
            return (decimal)(months * this.interestRate);
        }

        internal bool IsValid(int number)
        {
            if (number < 0)
                return false;

            return true;
        }
    }
}
