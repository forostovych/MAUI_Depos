using MAUI_Depos.Pages;


namespace Maui_App_Deposites.Pages;

public partial class DepositStep : ContentPage
{

    private string lblDepositPeriod;
    private string lblPercent;
    private bool swIsActive;

    public DepositStep()
    {
        InitializeComponent();
        btnMakeDeposit.IsEnabled = false;

    }


    public DepositStep(string _DepositPeriod, string _InterestRate, bool swIsActive)
    {

        InitializeComponent();
        DepositPeriod.Text = _DepositPeriod;
        InterestRate.Text = _InterestRate;
        this.swIsActive = swIsActive;
    }

    private async void btnBack_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new DepositPage(), true);
    }

    private async void numberEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
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

        double res = Convert.ToDouble(numberEntry.Text);
        if (res >= 1000)
        {
            await Navigation.PushModalAsync(new DepositStep2());
        }
       
    }
}
