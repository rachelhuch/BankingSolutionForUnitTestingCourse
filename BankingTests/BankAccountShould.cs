using BankingDomain;
using BankingTests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountShould
    {
        [Fact]
        public void UseTheBonusCalculatorOnDeposits()
        {
            var stubbedBonusCalculator = new Mock<ICalculateBankAccountBonuses>();
            stubbedBonusCalculator.Setup(b => b.GetDepositBonusFor(1000, 100)).Returns(107);
            var account = new BankAccount(stubbedBonusCalculator.Object, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;

            account.Deposit(amountToDeposit);

            Assert.Equal(amountToDeposit + openingBalance + 107, account.GetBalance());
           
        }
    }
}
