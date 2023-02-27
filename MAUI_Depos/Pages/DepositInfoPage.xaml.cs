using Maui_App_Deposites.Pages;
using MAUI_Depos.ViewModels;
using MAUI_ScanImages.Services;
using PrivateAsset.Shared.Models.Staking;

namespace MAUI_Depos.Pages;

public partial class DepositInfoPage : ContentPage
{
    private readonly GetStakingUserInformationResponse responses;
    private readonly ChooseOptionViewModel viewModel;
    private readonly UserStakingOption option;

    private readonly decimal userEntryAmount;
    private readonly bool isUserTogled;
    private readonly bool isUnstaked;

    public DepositInfoPage(ChooseOptionViewModel viewModel, UserStakingOption option, decimal userEntryAmount, bool isUserTogled, bool isUnstaked)
    {
        InitializeComponent();

        this.viewModel = viewModel;
        this.option = option;
        this.userEntryAmount = userEntryAmount;
        this.isUserTogled = isUserTogled;
        this.isUnstaked = isUnstaked;
        SetValuesUI();
    }

    private void SetValuesUI()
    {
        DepositPeriod.Text = option.StakeDurationInDays.ToString() + " days, ";
        InterestRate.Text = option.APM.ToString() + "%";

        lblAmount.Text = userEntryAmount.ToString() + " $";
        lblAmountSmall.Text = userEntryAmount.ToString() + " $";

        SetInterest(65);      // Set Interest Amount (as integer)65%                                      
    }

    private void SetInterest(int interestAmount)
    {
        ServiceInterest serviceInterest = new ServiceInterest();
        imgInterestDisplay.Source = serviceInterest.GetInterestImage(interestAmount);

        double expectedProfit = (double)userEntryAmount * ((double)option.APM / 100);
        double currentAmount = expectedProfit * ((double)interestAmount / 100);
        lblAmountSmall.Text = currentAmount.ToString();
    }

    private async Task ShowButton(object sender)
    {
        var res = (sender as ImageButton).Id;
        await DisplayAlert("Title", res.ToString(), "Ok");
    }

    private async void btnDividendPayment_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnRenew_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnBankStatement_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnContract_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnName_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnName_Clicked_1(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnStopContract_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnCalculation_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private async void btnStop_Clicked(object sender, EventArgs e)
    {
        await ShowButton(sender);
    }

    private void btnHome_Clicked(object sender, EventArgs e)
    {

    }
}