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

        using var stream = FileSystem.OpenAppPackageFileAsync("ChooseOptionViewModel.json").GetAwaiter().GetResult();
        using var reader = new StreamReader(stream);

        var contents = reader.ReadToEnd();
        string Json = VirtualTestData.Json;
        ChooseOptionViewModel viewModel;


        viewModel = JsonConvert.DeserializeObject<ChooseOptionViewModel>(contents);
        MainPage = new DepositPage(viewModel);

        
        //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "file.txt");
        //string fileContents = string.Empty;

        //if (File.Exists(filePath))
        //{
        //    fileContents = File.ReadAllText(filePath);
        //}
        

    }
}
