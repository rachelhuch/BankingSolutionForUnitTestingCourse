using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalculatorShould
    {

        [Fact]
        public void DepositsAtOrOverLimitReceiveBonus()
        {
            ICalculateBankAccountBonuses bonusCalculator = new StandardBonusCalculator();
            
            
            var bonus = bonusCalculator.GetDepositBonusFor(5000, 100);

            Assert.Equal(10, bonus);
        }

        [Fact]
        public void DepositsUnderLimitGetNoBonus()
        {
            ICalculateBankAccountBonuses bonusCalculator = new StandardBonusCalculator();

            var bonus = bonusCalculator.GetDepositBonusFor(4999.99M, 100);

            Assert.Equal(0, bonus);
        }
    }
}
