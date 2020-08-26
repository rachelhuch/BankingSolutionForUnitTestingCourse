namespace BankingDomain
{
    public interface INotifyTheFeds
    {
        void NotifyOfDeposit(decimal amountToDeposit);
    }
}