using PrivateAsset.Shared.Models.Staking;

namespace MAUI_Depos.ViewModels
{
    public class GetStakingUserInformationResponse
    {

        public BaseStakingDepositEntity[] Deposits { get; set; }

        public BaseStakingTransaction[] Interests { get; set; }

        public GetStakingOptionsResponse StakingOptionsResponse { get; set; }


    }
}