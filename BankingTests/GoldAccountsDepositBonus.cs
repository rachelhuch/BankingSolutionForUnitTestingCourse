using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountsDepositBonus
    {
        [Fact]
        public void GoldAccountsGetABonusOnDeposits()
        {
            // Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;
            account.Type = AccountType.Gold;

            // When
            account.Deposit(amountToDeposit);


            // Then
            Assert.Equal(openingBalance + amountToDeposit + 10, account.GetBalance());
        }
    }
}
