using CommunityToolkit.Maui.Core.Extensions;
using PrivateAsset.Shared.Models.Staking;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PrivateAsset.ViewModels
{
    public class DepositListViewEntity
    {
        public string APY { get; set; }

        public string DepositAmount { get; set; }

        public string TotalPercents { get; set; }

        public List<BaseStakingTransaction> Percents { get; set; }

        public string TimeLeftInDays { get; set; }

        public bool IsActive { get; set; }

        public double ProgresState { get; set; }
    }

    public class DepositListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DepositListViewEntity> deposits { get; set; }

        public DepositListViewModel(List<BaseStakingOption> options, List<BaseStakingDepositEntity> deposits, List<BaseStakingTransaction> interests)
        {
            this.deposits = deposits.Select(x =>
            {
                var percents = interests.Where(f => f.StakingDepositEntityId.Equals(x.Id)).ToList();
                decimal aPM = options.Where(f => f.Id.Equals(x.StakingOptionEntityId)).FirstOrDefault().APM;
                decimal percent = aPM * 12;

                return new DepositListViewEntity()
                {
                    DepositAmount = x.Amount.ToString(),
                    IsActive = x.UnStakeTransactionId == null && !x.IsUnstaked,
                    Percents = percents,
                    APY = ((int)percent).ToString(),
                    TotalPercents = percents.Sum(f => f.Amount).ToString(),
                    TimeLeftInDays = $"{(x.FinishDate - DateTime.Now.Date).TotalDays} days",
                    ProgresState = GetLeftDaysPercent(x),
                };
            }).ToObservableCollection();
        }

        private double GetLeftDaysPercent(BaseStakingDepositEntity x)
        {
            System.DateTime finishDate = x.FinishDate;
            System.DateTime startDate = x.StartDate;
            var dayPass = DateTime.UtcNow.Subtract(startDate).TotalDays;
            var dayRemaining = finishDate.Subtract(DateTime.UtcNow);

            var totalDays = finishDate.Subtract(startDate).TotalDays;

            return dayPass / (totalDays / 100) / 100;
        }

        private double GetRandomPersent() => new Random().NextDouble() * 100;
    }
}
