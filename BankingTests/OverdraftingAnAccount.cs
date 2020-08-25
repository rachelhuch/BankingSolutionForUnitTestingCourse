using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class OverdraftingAnAccount
    {
        /*
          Our bank does not allow you to overdraft. You can't take out more than 
        you have. You CAN get to zero, though (it's your money).
        If you try to overdraft
            - the balance stays the same
                -e.g. if you have 500 in your account, and you take out 1000,
                      you still have 500 in your account (not zero).
                      And an OverdraftException is thrown.

         */

        [Fact]
        public void YouCanTakeAllYourMoney()
        {
            var account = new BankAccount();

            account.Withdraw(account.GetBalance());

            Assert.Equal(0, account.GetBalance());
            // this passed immediately. No red. Be sceptical, but it might be good.
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {
            var account = new BankAccount();
            var originalBalance = account.GetBalance();

            Assert.Throws<OverdraftException>(() => 
            account.Withdraw(originalBalance + .01M));

        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount();
            var originalBalance = account.GetBalance();

            try
            {
                account.Withdraw(originalBalance + .01M);
            }
            catch (OverdraftException)
            {

                // Gulp!
            }

            Assert.Equal(originalBalance, account.GetBalance());
        }

    }
}
