using Maui_App_Deposites.Pages;
using MAUI_Depos.ViewModels;
using PrivateAsset.Shared.Models.Staking;
using PrivateAsset.ViewModels;
using PrivateAsset.Views;
using WalletConnectSharp.Desktop;

namespace MAUI_Depos.Pages;

public partial class NewDepositPage : ContentPage
{
    private ChooseOptionViewModel viewModel;
    private List<UserStakingOption> options;
    private List<OpportunitiesUI> oportunitiesUI;

    public NewDepositPage()
    {
        InitializeComponent();
    }

    public NewDepositPage(ChooseOptionViewModel _viewModel)
    {
        InitializeComponent();
        viewModel = _viewModel;
        BindingContext = viewModel;
        LoadValues(_viewModel);
    }
    private List<BaseStakingTransaction> GetDepositInterests(BaseStakingDepositEntity depositEntity)
    {
        List<BaseStakingTransaction> interests = viewModel.UserInformation.Interests.Where(x => x.StakingDepositEntityId == depositEntity.Id).ToList();

        return interests;
    }
    private void LoadValues(ChooseOptionViewModel _viewModel)
    {
        options = InitializeActiveStakingOptions(_viewModel);       // Initialize all active options
        oportunitiesUI = InitializeOpportunitiesUI(options);        // Initialize all OpportunitiesUI
        SetPeriodValuesNew();
    }
    private async Task SetPeriodValuesNew()
    {
        int selectedId = OpportunitiesUI.CurrentId;
        OpportunitiesUI currentUI = oportunitiesUI[selectedId];

        if (selectedId == 0)
        {
            lblMaintPercent.Text = $"{currentUI.PercentAPM} %";
            lblDepositPeriod.Text = $"{currentUI.DepositPeriod} days";
            lblPercent.Text = $"{currentUI.PercentAPM} % per month";
            lblUnstakeDurationInDays.Text = SetUnstakeDurationInDays(currentUI);

            SwitchConrol(swIsActive, currentUI.CanUnstakeBeforeEnd);
            ButtonConrol(btnMinus, false);
            ButtonConrol(btnPlus, true);
        }

        else if (selectedId != 0 && selectedId != oportunitiesUI.Count-1)
        {
            lblMaintPercent.Text = $"{currentUI.PercentAPM} %";
            lblDepositPeriod.Text = $"{currentUI.DepositPeriod} days";
            lblPercent.Text = $"{currentUI.PercentAPM} % per month";
            lblUnstakeDurationInDays.Text = SetUnstakeDurationInDays(currentUI);

            SwitchConrol(swIsActive, currentUI.CanUnstakeBeforeEnd);
            ButtonConrol(btnMinus, true);
            ButtonConrol(btnPlus, true);
        }

        else if (selectedId == oportunitiesUI.Count-1)
        {
            lblMaintPercent.Text = $"{currentUI.PercentAPM} %";
            lblDepositPeriod.Text = $"{currentUI.DepositPeriod} days";
            lblPercent.Text = $"{currentUI.PercentAPM} % per month";
            lblUnstakeDurationInDays.Text = SetUnstakeDurationInDays(currentUI);

            SwitchConrol(swIsActive, currentUI.CanUnstakeBeforeEnd);
            ButtonConrol(btnMinus, true);
            ButtonConrol(btnPlus, false);
        }
    }
    private string SetUnstakeDurationInDays(OpportunitiesUI currentUI)
    {
        if (currentUI.CanUnstakeBeforeEnd == false)
        {
            return "0";
        }
        else
        {
            return $"Days unstake period {currentUI.UnstakeDurationInDays} days";
        }
    }
    private List<UserStakingOption> InitializeActiveStakingOptions(ChooseOptionViewModel viewModel)
    {
        options = new List<UserStakingOption>();

        foreach (var res in viewModel.options)
        {
            if (res.IsActive)
            {
                options.Add(res);
            }
        }

        return options;
    }
    private List<OpportunitiesUI> InitializeOpportunitiesUI(List<UserStakingOption> options)
    {
        oportunitiesUI = new List<OpportunitiesUI>();
        for (int i = 0; i < options.Count; i++)
        {
            oportunitiesUI.Add(new OpportunitiesUI(options[i], i));
        }

        return oportunitiesUI;
    }
    private async void btnMakeDeposit_Clicked(object sender, EventArgs e)
    {
        bool isUserTogled = swIsActive.IsToggled;
        // Создание новой страницы
        NewDepositAmountPage step = new NewDepositAmountPage(viewModel, options[OpportunitiesUI.CurrentId], isUserTogled);

        // Анимированный переход на следующую страницу
        await Navigation.PushModalAsync(step, true);

    }
    private async void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (OpportunitiesUI.CurrentId == 0)
            return;

        OpportunitiesUI.CurrentId = OpportunitiesUI.CurrentId - 1;
        await SetPeriodValuesNew();
    }
    private async void btnPlus_Clicked(object sender, EventArgs e)
    {
        if (OpportunitiesUI.CurrentId == oportunitiesUI.Count - 1)
            return;

        OpportunitiesUI.CurrentId = OpportunitiesUI.CurrentId + 1;
        await SetPeriodValuesNew();
    }
    private async void swIsActive_Toggled(object sender, ToggledEventArgs e)
    {
        if (swIsActive.IsToggled == true)
        {
            swIsActive.OnColor = Color.FromArgb("#22551F");
            swIsActive.ThumbColor = Color.FromArgb("#00B200");
        }
        else
        {
            swIsActive.OnColor = Colors.Grey;
            swIsActive.ThumbColor = Colors.White;

        }
    }
    private void SwitchConrol(Switch switchConrol, bool isActiv)
    {
        if (isActiv == true)
        {
            switchConrol.IsToggled = false;
            switchConrol.IsEnabled = isActiv;
            switchConrol.OnColor = Colors.Grey;
            switchConrol.ThumbColor = Colors.White;
            lblUnstake.TextColor = Colors.White;

            imgLogoUnstak.Opacity = 1;
        }
        else
        {
            switchConrol.IsToggled = false;
            switchConrol.IsEnabled = isActiv;
            switchConrol.OnColor = Colors.Grey;
            switchConrol.ThumbColor = Colors.Grey;
            lblUnstake.TextColor = Colors.Grey;

            imgLogoUnstak.Opacity = 0.3d;
        }
    }
    private void ButtonConrol(Microsoft.Maui.Controls.Button button, bool isActiv)
    {
        if (isActiv == true)
        {
            button.IsEnabled = isActiv;
            button.TextColor = Colors.White;
        }
        else
        {
            button.IsEnabled = isActiv;
            button.TextColor = Colors.Grey;
        }
    }

    private void btnGoTest_Clicked(object sender, EventArgs e)
    {
        List<BaseStakingOption> options = viewModel.UserInformation.StakingOptionsResponse.AvailableOptions.Select(x => (BaseStakingOption)x).ToList();
        List<BaseStakingDepositEntity> deposits = viewModel.UserInformation.Deposits.ToList();
        List<BaseStakingTransaction> interests = viewModel.UserInformation.Interests.ToList();
        DepositListViewModel depositviewModel = new DepositListViewModel(options, deposits, interests);
        WalletConnect walletConnect = null;

        Navigation.PushModalAsync( new DepositListPage(depositviewModel, walletConnect));
    }
}

