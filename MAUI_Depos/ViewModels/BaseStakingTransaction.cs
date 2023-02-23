namespace MAUI_Depos.ViewModels
{
    public class BaseStakingTransaction
    {
        public int Id { get; set; }

        public int StakingDepositEntityId { get; set; }

        public string TransactionId { get; set; }

        public DateTime TransactionTime { get; set; }

        public string Account { get; set; }

        public decimal Amount { get; set; }
    }
}
