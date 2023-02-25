using Maui_App_Deposites.Pages;
using MAUI_Depos.ViewModels;

namespace MAUI_Depos.Pages;

public partial class DepositPage : ContentPage
{
    private ChooseOptionViewModel viewModel;
    private List<UserStakingOption> options;
    private List<OpportunitiesUI> oportunitiesUI;

    public DepositPage()
    {

    }

    public DepositPage(ChooseOptionViewModel _viewModel)
    {
        viewModel = _viewModel;
        BindingContext = viewModel;
        InitializeComponent();
        LoadValues(_viewModel);
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
            lblUnstake.TextColor = Colors.Grey;
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
        // Создание новой страницы
        DepositStep step = new DepositStep(lblDepositPeriod.Text, lblPercent.Text, swIsActive.IsToggled);

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
            imgLogoUnstak.Opacity = 1;
        }
        else
        {
            switchConrol.IsToggled = false;
            switchConrol.IsEnabled = isActiv;
            switchConrol.OnColor = Colors.Grey;
            switchConrol.ThumbColor = Colors.Grey;
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


}

public class OpportunitiesUI
{
    public static int CurrentId { get; set; }   //      The current ID of the selected opportunity
    public int Id { get; }                      // 0.   Id
    public decimal PercentAPM { get; }          // 5.   Percentage per month {blblPercent.Text}
    public int UnstakeDurationInDays { get; }   // 6.   The waiting period before withdrawing money
    public decimal DepositPeriod { get; }       // 7.   Deposit time {lblDepositPeriod.Text}
    public bool CanUnstakeBeforeEnd { get; }    // 8.   Is it possible to cancel the deposit early?

    public OpportunitiesUI(UserStakingOption res, int id)
    {
        PercentAPM = res.APM;                                   // 5.   Percentage per month
        UnstakeDurationInDays = res.UnstakeDurationInDays;      // 6.   The waiting period before withdrawing money                           // 
        DepositPeriod = res.StakeDurationInDays;                // 7.   Deposit time
        CanUnstakeBeforeEnd = res.CanUnstakeBeforeEnd;          // 8.   Is it possible to cancel the deposit early
        Id = id;
        CurrentId = Id;                                         // 10.  The current ID of the selected opportunity
    }

}