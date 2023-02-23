using System.Text.Json.Serialization;

namespace Maui_App_Deposites
{
    public class BaseStakingOption
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        /// revenue per month
        public decimal APM { get; set; }

        /// Unstake time (15/60 days)
        public int UnstakeDurationInDays { get; set; }

        public int StakeDurationInDays { get; set; }

        public bool CanUnstakeBeforeEnd { get; set; }

        /// revenur per year
        [JsonIgnore]
        public decimal APY
        {
            get
            {
                return APM * 12;
            }
        }
    }
}
