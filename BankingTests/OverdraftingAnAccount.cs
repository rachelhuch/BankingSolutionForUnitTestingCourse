using BankingDomain;
using BankingTests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class OverdraftingAnAccount
    {


        BankAccount _account;
        public OverdraftingAnAccount()
        {
            _account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
        }

        [Fact]
        public void YouCanTakeAllYourMoney()
        {
           

            _account.Withdraw(_account.GetBalance());

            Assert.Equal(0, _account.GetBalance());
            // this passed immediately. No red. Be sceptical, but it might be good.
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {
            
            var originalBalance = _account.GetBalance();

            Assert.Throws<OverdraftException>(() => 
            _account.Withdraw(originalBalance + .01M));

        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
           
            var originalBalance = _account.GetBalance();

            try
            {
                _account.Withdraw(originalBalance + .01M);
            }
            catch (OverdraftException)
            {

                // Gulp!
            }

            Assert.Equal(originalBalance, _account.GetBalance());
        }

    }
}
