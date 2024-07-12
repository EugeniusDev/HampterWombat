using CommunityToolkit.Mvvm.ComponentModel;

namespace HampterWombat.Domain
{
    public partial class DovbocoinData : ObservableObject
    {
        [ObservableProperty]
        int balance;
        [ObservableProperty]
        int clickValue;

        public DovbocoinData()
        {
            Balance = 0;
            ClickValue = 1;
        }
        public DovbocoinData(int balance, int stepOfIncreasing)
        {
            Balance = balance;
            ClickValue = stepOfIncreasing;
        }
    }
}
