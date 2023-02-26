using MAUI_Depos.ViewModels;

namespace MAUI_Depos.Pages
{
    public class OpportunitiesUI
    {

        public static int CurrentId { get; set; }   //      The current ID of the selected opportunity
        public int Id { get; }                      // 0.   Id
        public decimal PercentAPM { get; }          // 5.   Percentage per month {blblPercent.Text}
        public int UnstakeDurationInDays { get; }   // 6.   The waiting period before withdrawing money
        public decimal DepositPeriod { get; }       // 7.   Deposit time {lblDepositPeriod.Text}
        public bool CanUnstakeBeforeEnd { get; }    // 8.   Is it possible to cancel the deposit early?

        public OpportunitiesUI(UserStakingOption res, int id)
        {
            PercentAPM = res.APM;                                   // 5.   Percentage per month
            UnstakeDurationInDays = res.UnstakeDurationInDays;      // 6.   The waiting period before withdrawing money                           // 
            DepositPeriod = res.StakeDurationInDays;                // 7.   Deposit time
            CanUnstakeBeforeEnd = res.CanUnstakeBeforeEnd;          // 8.   Is it possible to cancel the deposit early
            Id = id;
            CurrentId = Id;                                         // 10.  The current ID of the selected opportunity
        }

    }
}
