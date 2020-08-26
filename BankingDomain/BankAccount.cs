using System;

namespace BankingDomain
{
    public enum AccountType {  Standard, Gold}
    public class BankAccount
    {
        private decimal _balance = 1000;
        public AccountType Type { get; set; } = AccountType.Standard;
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
            switch(Type)
            {
                case AccountType.Standard:
                    {
                        _balance += amountToDeposit;
                        break;
                    }
                case AccountType.Gold:
                    {
                        _balance += amountToDeposit * 1.10M;
                        break;
                    }
            }
            
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