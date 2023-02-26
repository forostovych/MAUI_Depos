using Maui_App_Deposites.Pages;
using MAUI_Depos.ViewModels;

namespace MAUI_Depos.Pages;

public partial class DepositInfoPage : ContentPage
{
    private readonly UserStakingOption options;
    private readonly bool isUnstaked;
    private readonly decimal userEntryAmount;

    private GetStakingUserInformationResponse responses;

    public DepositInfoPage()
    {
        InitializeComponent();
    }

    public DepositInfoPage(UserStakingOption options, decimal userEntryAmount, bool isUnstaked)
    {
        InitializeComponent();
        this.options = options;
        this.userEntryAmount = userEntryAmount;
        this.isUnstaked = isUnstaked;
        SetValuesUI();
    }

    private void SetValuesUI()
    {
        DepositPeriod.Text = options.StakeDurationInDays.ToString() + " days, ";
        InterestRate.Text = options.APM.ToString() + "%";

        lblAmount.Text = userEntryAmount.ToString() + " $";
        lblAmountSmall.Text = userEntryAmount.ToString() + " $";
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