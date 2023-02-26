using PrivateAsset.Shared.Models.Staking;

namespace MAUI_Depos.ViewModels
{
    public class UserStakingOption : BaseStakingOption
    {
        public decimal UserStakedAmount { get; set; }
        public List<BaseStakingOptionWallet> Wallets { get; set; }
    }
}