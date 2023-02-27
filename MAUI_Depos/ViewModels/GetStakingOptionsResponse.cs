using PrivateAsset.Shared.Models.Staking;
using PrivateAsset.Shared.Responses.Exchange;

namespace MAUI_Depos.ViewModels
{
    public class GetStakingOptionsResponse
    {
        public UserExchangeCheckStatus ExchangeCheckStatus { get; set; }

        public UserStakingOption[] AvailableOptions { get; set; }
    }

    public enum UserExchangeCheckStatus
    {
        Success,
        PamAccountNotFound,
        IncorrectNetwork,
        SessionisInActive,
        UserNotRegistered,
        UserNotActivated,
        UserNotFound,
        UnexpectedError
    }

    public class UserExchangeCheckResponse
    {
        public UserExchangeCheckStatus Status { get; set; }

        public static UserExchangeCheckResponse FromStatus(UserExchangeCheckStatus status)
        {
            return new UserExchangeCheckResponse()
            {
                Status = status,
            };
        }
    }
}