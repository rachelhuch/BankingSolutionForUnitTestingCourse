using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingTests.Fakes
{
    public class StubbedBonusCalculator : ICalculateBankAccountBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
           if(balance == 1000 && amountToDeposit == 100)
            {
                return 42;
            } else
            {
                return 0;
            }
        }
    }
}
