using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Automation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<StrangeAnimal> MyObservableList { get; } = [];
    JSONServices MyJSONService;
    public MainViewModel(JSONServices MyJSONService)
    {
        this.MyJSONService = MyJSONService;
    }
 
    [RelayCommand]
    internal async Task GoToDetails(string id)
    {
        IsBusy = true;

        await Shell.Current.GoToAsync("DetailsView", true, new Dictionary<string,object>
        {
            {"selectedAnimal",id}
        });

        IsBusy = false;
    }
    internal async Task RefreshPage()
    {
        MyObservableList.Clear ();

        if(Globals.MyStrangeAnimals.Count == 0) Globals.MyStrangeAnimals = await MyJSONService.GetStrangeAnimals();

        foreach (var item in Globals.MyStrangeAnimals)
        {
            MyObservableList.Add(item);
        }
    }
}
