using MAUI_Depos.Pages;
using MAUI_Depos.Resources;
using MAUI_Depos.ViewModels;
using Newtonsoft.Json;

namespace MAUI_Depos;

public partial class App : Application
{

    public App()
    {
        InitializeComponent();

        string Json = VirtualTestData.Json;

        ChooseOptionViewModel viewModel = JsonConvert.DeserializeObject<ChooseOptionViewModel>(Json);



        MainPage = new DepositPage();

    }
}
