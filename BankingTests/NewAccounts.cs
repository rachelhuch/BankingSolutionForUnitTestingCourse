using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace BankingTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectOpeningBalance()
        {
            // WTCYWYH (Write the code you wish you had)
            // Given I have a brand new account.
            var account = new BankAccount();

            // When I get the balance
            decimal balance = account.GetBalance();

            // Then I should have $1000.00
            Assert.Equal(1000M, balance);
        }
    }
}
