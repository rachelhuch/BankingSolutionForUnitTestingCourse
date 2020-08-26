using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal _balance = 1000;
        private ICalculateBankAccountBonuses _bonusCalculator;
        private INotifyTheFeds _feds;

        public BankAccount(ICalculateBankAccountBonuses bonusCalculator, INotifyTheFeds feds)
        {
            _bonusCalculator = bonusCalculator;
            _feds = feds;
        }

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
            // Ravi agreed that if we give him our balance and the amount, he'll us a bonus.
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
           _feds.NotifyOfDeposit(amountToDeposit);
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new OverdraftException();
            }
            if (amountToWithdraw < 0)
            {
                throw new ImproperTransactionException();
            }
            _balance -= amountToWithdraw;
        }
    }
}