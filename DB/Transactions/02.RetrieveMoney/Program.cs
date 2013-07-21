using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using System.Transactions;

namespace _02.RetrieveMoney
{
    class Program
    {
        static string pinInput = "5352";
        static string cardNumberInput = "4537497261";
        static decimal moneyInput = 200m;

        static void Main()
        {
            AtmEntities db = new AtmEntities();
            
            using (db)
            {
                TransactionScope transaction = new TransactionScope();
                bool cardFound = false;

                using (transaction)
                {
                    foreach (var acc in db.CardAccounts)
                    {
                        if (Valid(acc.cardNumber, acc.cardPin, acc.cardCash))
                        {
                            acc.cardCash -= moneyInput;
                            TransactionsHistory log = new TransactionsHistory
                            {
                                ammoount = moneyInput,
                                cardNumber = acc.cardNumber,
                                transactionDate = DateTime.Now
                            };

                            db.TransactionsHistories.Add(log);
                            db.SaveChanges();
                            cardFound = true;
                            break;
                        }
                    }

                    if (!cardFound)
                    {
                        throw new ArgumentException("Invalid data.");
                    }
                    else
                    {
                        transaction.Complete();
                    }
                }
            }
        }

        private static bool Valid(string cardNumber, string cardPin, decimal? amount)
        {
            if (cardNumber == cardNumberInput &&
                cardPin == pinInput &&
                amount >= moneyInput)
            {
                return true;
            }

            return false;
        }
    }
}
