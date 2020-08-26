using BankingDomain;
using BankingTests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class MakingDeposits
    {
        [Fact]
        public void DepositsIncreaseBalance()
        {
            // Given
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 1M;


            // When
            account.Deposit(amountToDeposit);

            // Then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());

        }
    }
}
