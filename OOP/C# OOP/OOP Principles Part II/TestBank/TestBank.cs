using System;
using Bank;

class TestBank
{
    static void Main()
    {
        Individual someone = new Individual();

        Account someonesAccount = new Loan((decimal)123.54, (float)2.3, someone);

        someonesAccount.Deposit(20);

        Company someCompany = new Company();

        Account someCompanyAccount = new Deposit((decimal)-1434.23, (float)4.5, someCompany);

        Console.WriteLine( someCompanyAccount.CalculateInterestAmount(13) );

        Account someonesMortgageAcc = new Mortgage((decimal)1243.1, (float)45.3, someone);

        Console.WriteLine(someonesMortgageAcc.CalculateInterestAmount(7));
    }
}
