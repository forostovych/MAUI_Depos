using Maui_App_Deposites;
using Maui_App_Deposites.Pages;

namespace MAUI_Depos.Pages;

public partial class DepositPage : ContentPage
{
    static BaseStakingOption baseStaking;
    static DepositPeriod depositPeriod;

    public DepositPage()
    {

        InitializeComponent();
        LoadValues();

    }

    private void LoadValues()
    {
        TestInitializeValues();
        SetPeriodValues();
    }

    private async void btnMakeDeposit_Clicked(object sender, EventArgs e)
    {
        // Создание новой страницы
        DepositStep step = new DepositStep(lblDepositPeriod.Text, lblPercent.Text, swIsActive.IsToggled);

        // Анимированный переход на следующую страницу
        await Navigation.PushModalAsync(step);

    }

    private void TestInitializeValues()
    {

        baseStaking = new BaseStakingOption()
        {
            Id = 1,
            IsActive = true,
            APM = 10,
            UnstakeDurationInDays = 15,
            StakeDurationInDays = 60,
            CanUnstakeBeforeEnd = false,
        };
        depositPeriod = DepositPeriod.twelve;
        frmCryptoMask.Opacity = 0.01;

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

    private async void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (depositPeriod == DepositPeriod.one)
            return;

        depositPeriod = (depositPeriod) - 1;
        await SetPeriodValues();
    }

    private async void btnPlus_Clicked(object sender, EventArgs e)
    {
        if (depositPeriod == DepositPeriod.twelve)
            return;

        depositPeriod = (DepositPeriod)((depositPeriod) + 1);
        await SetPeriodValues();
    }

    private async Task SetPeriodValues()
    {

        if (depositPeriod == DepositPeriod.one)
        {
            lblDepositPeriod.Text = "1 month";
            lblPercent.Text = "1.5%";
            lblMaintPercent.Text = lblPercent.Text;
            frmCryptoMask.Opacity = 0.5d;
            frmCryptoMask.IsVisible = true;
            ButtonConrol(btnMinus, false);

            return;
        }
        else if (depositPeriod == DepositPeriod.three)
        {

            lblDepositPeriod.Text = "3 month";
            lblPercent.Text = "4.5%";
            lblMaintPercent.Text = lblPercent.Text;
            ButtonConrol(btnMinus, true);
            lblUnstake.TextColor = Colors.Grey;
            frmCryptoMask.Opacity = 0.5d;
            frmCryptoMask.IsVisible = true;
            SwitchConrol(swIsActive, false);

            return;
        }
        else if (depositPeriod == DepositPeriod.six)
        {
            lblDepositPeriod.Text = "6 month";
            lblPercent.Text = "9.5%";
            lblMaintPercent.Text = lblPercent.Text;
            lblUnstake.TextColor = Colors.White;
            frmCryptoMask.Opacity = 0.01;
            frmCryptoMask.IsVisible = false;
            SwitchConrol(swIsActive, true);

            return;
        }
        else if (depositPeriod == DepositPeriod.nine)
        {
            lblDepositPeriod.Text = "9 month";
            lblPercent.Text = "14%";
            lblMaintPercent.Text = lblPercent.Text;
            ButtonConrol(btnPlus, true);
            frmCryptoMask.Opacity = 0.01;
            frmCryptoMask.IsVisible = false;

            return;
        }
        else if (depositPeriod == DepositPeriod.twelve)
        {
            lblDepositPeriod.Text = "12 month";
            lblPercent.Text = "18.6%";
            lblMaintPercent.Text = lblPercent.Text;


            ButtonConrol(btnPlus, false);
            frmCryptoMask.Opacity = 0.01;
            frmCryptoMask.IsVisible = false;

            return;
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
        }
        else
        {
            switchConrol.IsToggled = false;
            switchConrol.IsEnabled = isActiv;
            switchConrol.OnColor = Colors.Grey;
            switchConrol.ThumbColor = Colors.Grey;
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

public enum DepositPeriod
{
    one,
    three,
    six,
    nine,
    twelve,
}