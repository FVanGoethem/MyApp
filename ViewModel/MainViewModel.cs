using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel;

public partial class MainViewModel: ObservableObject
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
        MyVar += "blabla";
    }
    [RelayCommand]
    internal async Task GoToDetails(string id)
    {
        await Shell.Current.GoToAsync("DetailsView", true);
    }
}
