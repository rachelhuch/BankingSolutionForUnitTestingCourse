namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateBankAccountBonuses
    {
       

        decimal ICalculateBankAccountBonuses.GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            if(balance >= 5000)
            {
                return amountToDeposit * .10M;
            } else
            {
                return 0;
            }
        }
    }
}