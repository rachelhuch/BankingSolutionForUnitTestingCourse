using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountDepositsShould
    {
        [Fact]
        public void GetBonus()
        {
            var account = new GoldAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit + 10M,
                account.GetBalance());
        }
    }
}
