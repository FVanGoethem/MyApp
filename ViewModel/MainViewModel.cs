using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel;

public partial class MainViewModel: BaseViewModel
{
    [ObservableProperty]
    private string myVar = "Blabla";

    public ObservableCollection<StrangeAnimal> MyObservableList { get; } = new();
    public MainViewModel()
    {
        StrangeAnimal Mygale = new StrangeAnimal()
        {
            Id="0",
            Name="Miguel", 
            Description="Belle",
            Picture="myg.jpg" 
        };

        StrangeAnimal boa = new StrangeAnimal()
        {
            Id = "1",
            Name = "aaa",
            Description = "brun",
            Picture = "boa.jpg"
        };

        StrangeAnimal cobra = new StrangeAnimal()
        {
            Id = "2",
            Name = "Cob",
            Description = "Venimeux",
            Picture = "cobra.jpg"
        };

        StrangeAnimal scorpion = new StrangeAnimal()
        {
            Id = "3",
            Name = "Pandinus",
            Description = "noir",
            Picture = "scorpion.jpg"
        };

        Globals.MyStrangeAnimals.Add(Mygale);
        Globals.MyStrangeAnimals.Add(boa);
        Globals.MyStrangeAnimals.Add(cobra);
        Globals.MyStrangeAnimals.Add(scorpion);

        foreach (var item in Globals.MyStrangeAnimals)
        {
            MyObservableList.Add(item);
        }       
    }

    [RelayCommand]
    internal void ChangeBindedLabel()
    {
        IsBusy = true;

        int id = 0;

        foreach(var item in Globals.MyStrangeAnimals)
        {
            int buffer = Convert.ToInt32(item.Id);
            if (buffer >= id) id = ++buffer; 
        }

        MyVar += "blabla";

        StrangeAnimal scorpion = new StrangeAnimal()
        {
            Id = id.ToString(),
            Name = "Pandinus",
            Description = "noir",
            Picture = "scorpion.jpg"
        };

        Globals.MyStrangeAnimals.Add(scorpion);

        MyObservableList.Clear();

        foreach (var item in Globals.MyStrangeAnimals)
        {
            MyObservableList.Add(item);
        }

        IsBusy = false;
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

    internal void RefreshPage()
    {
        MyObservableList.Clear ();

        foreach (var item in Globals.MyStrangeAnimals)
        {
            MyObservableList.Add(item);
        }
    }
}
