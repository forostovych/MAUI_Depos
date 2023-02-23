using Maui_App_Deposites.Pages;

namespace MAUI_Depos.Pages;

public partial class DepositStep2 : ContentPage
{
    public DepositStep2()
    {
        InitializeComponent();
    }

    private async Task ShowButton(object sender)
    {
        var res = (sender as ImageButton).Id;
        await DisplayAlert("Title", res.ToString(), "Ok");
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new DepositStep());
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
}