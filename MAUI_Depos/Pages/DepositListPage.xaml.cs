using PrivateAsset.Shared.Models.Staking;
using PrivateAsset.ViewModels;
using WalletConnectSharp.Desktop;

namespace PrivateAsset.Views;
public partial class DepositListPage : ContentPage
{
    private DepositListViewModel viewModel;
    private UserStakingOption choosedOption;
    private WalletConnect walletConnect;

    public DepositListPage(DepositListViewModel viewModel, WalletConnect walletConnect)
    {
        this.walletConnect = walletConnect;

        this.viewModel = viewModel;
        BindingContext = viewModel;
        InitializeComponent();

        GetDepositAmount();
    }

    private void GetDepositAmount()
    {
        double totalAmouint = 0;
        for (int i = 0; i < viewModel.deposits.Count; i++)
        {
            totalAmouint += Convert.ToDouble(viewModel.deposits[i].DepositAmount);
        }

        lblMainInfoAmount.Text = totalAmouint.ToString() + " $";
    }
}