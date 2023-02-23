using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Extensions;

namespace MAUI_Depos.ViewModels
{
    public class ChooseOptionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<UserStakingOption> options { get; set; }

        public GetStakingUserInformationResponse UserInformation { get; set; }

        public string UserPamBalance { get; set; }

        public decimal userPamBalance { get; set; }



        public ChooseOptionViewModel(GetStakingUserInformationResponse userInformation, string walletAddress, string walletNetwork, decimal userPamBalance)
        {
            this.UserInformation = userInformation;
            this.options = userInformation.StakingOptionsResponse.AvailableOptions.ToObservableCollection();

            this.WalletAddress = walletAddress;
            this.WalletNetwork = walletNetwork;
            this.userPamBalance = userPamBalance;
            UserPamBalance = userPamBalance.ToString("0.00");
        }

        public string WalletAddress { get; set; } = "undefined";

        public string WalletNetwork { get; set; } = "undefined network";
    }
}
