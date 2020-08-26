using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class DepositsOnAccountsShould
    {
        [Fact]
        public void NotifyTheFed()
        {
            // Given
            // - I create a "spy"
            var mockedFedNotifier = new Mock<INotifyTheFeds>();
            var account = new BankAccount(
                new Mock<ICalculateBankAccountBonuses>().Object,
                mockedFedNotifier.Object);
            // When I make a deposit
            account.Deposit(123.45M);
            // Then I ask the spy *(mock) if it got called with the right arguments.
            mockedFedNotifier.Verify(f => f.NotifyOfDeposit(123.45M));
        }
    }
}
