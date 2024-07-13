using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HampterWombat.Common;
using HampterWombat.Domain;

namespace HampterWombat.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        DovbocoinData dovboData;
        public MainViewModel()
        {
            DovboData = JsonManipulator.TryRetrieveDovbocoinData();
        }

        [RelayCommand]
        void IncrementBalance()
        {
            DovboData.Balance += DovboData.ClickValue;
        }
    }
}
