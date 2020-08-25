using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 1000;

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit < 0)
            {
                throw new ImproperTransactionException();
            }
            _balance += amountToDeposit;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            if(amountToWithdraw < 0)
            {
                throw new ImproperTransactionException();
            }
            _balance -= amountToWithdraw;
        }
    }
}