using MAUI_Depos.Pages;
using MAUI_Depos.ViewModels;
using PrivateAsset.Shared.Models.Staking;

namespace Maui_App_Deposites.Pages;

public partial class NewDepositAmountPage : ContentPage
{
    private readonly ChooseOptionViewModel viewModel;
    private readonly UserStakingOption option;
    private readonly bool isUnstaked;
    private readonly bool isUserTogled;

    public NewDepositAmountPage(UserStakingOption option, bool isUnstaked)
    {
        InitializeComponent();
        this.option = option;
        this.isUnstaked = isUnstaked;

        SetValuesUI();
    }

    public NewDepositAmountPage(ChooseOptionViewModel viewModel, UserStakingOption userStakingOption, bool isToggled)
    {
        InitializeComponent();
        this.option = userStakingOption;
        this.isUnstaked = isUnstaked;
        this.isUserTogled = isUserTogled;
        this.viewModel = viewModel;

        SetValuesUI();

    }

    private void SetValuesUI()
    {
        DepositPeriod.Text = option.StakeDurationInDays.ToString() + " days ";
        InterestRate.Text = option.APM.ToString() + "% ";
    }


    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NewDepositPage(viewModel), true);
    }

    private async void numberEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        //TempControl.Text = numberEntry.Text;
        await CheckButton();
    }

    private async Task CheckButton()
    {
        double res = Convert.ToDouble(numberEntry.Text);
        if (res >= 1000)
        {
            btnMakeDeposit.BackgroundColor = Colors.Red;
            btnMakeDeposit.IsEnabled = true;
        }
        else
        {
            btnMakeDeposit.BackgroundColor = Color.FromArgb("#272727");
            btnMakeDeposit.IsEnabled = false;
        }
    }

    private async void btnMakeDeposit_Clicked(object sender, EventArgs e)
    {
        decimal userEntryAmount = Convert.ToDecimal(numberEntry.Text);

        double res = Convert.ToDouble(numberEntry.Text);
        if (res >= 1000)
        {
            await Navigation.PushModalAsync(new DepositInfoPage(viewModel, option, userEntryAmount, isUserTogled, isUnstaked));
        }
       
    }
}
