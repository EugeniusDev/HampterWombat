using HampterWombat.Common;
using HampterWombat.ViewModels;

namespace HampterWombat
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnDisappearing()
        {
            if (BindingContext is MainViewModel viewModel)
            {
                JsonManipulator.SaveDovbocoinData(viewModel.DovboData);
            }
            
            base.OnDisappearing();
        }

        private async void BalanceLabel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(e.NewTextValue, out int value))
            {
                return;
            }

            await DisplayMessageDependingOnValue(value);
        }

        private async Task DisplayMessageDependingOnValue(int value)
        {
            if (value >= 1000)
            {
                await DisplayAlert("How?", "Wow! You are real DOVBOYOB!",
                    "Thanks");
            }
            else if (value >= 100 && value <= 105)
            {
                await DisplayAlert("What the hell?", "Why are you still doing that? Get a job!",
                    "No, I will tap forever!");
            }
            else if (value >= 50 && value <= 53)
            {
                await DisplayAlert("That's enough",
                    "Криптодебіл - горе в сім'ї...", "No!");
            }
            else if (value == 10)
            {
                await DisplayAlert("Come on", "Stop doing that", "Bruh no");
            }
        }

        private void BoosterBtn_Clicked(object sender, EventArgs e)
        {
            ToggleShop();
            UpdateProposition();
        }

        private void UpdateProposition()
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;
            int clickValue = viewModel.DovboData.ClickValue;
            PropositionLabel.Text = $"+{CalculateNewClickValue(clickValue)} to tap price " +
                $"just for {CalculatePrice(clickValue)} DVB!";
        }

        private static int CalculateNewClickValue(int oldClickValue)
        {
            return (int)(oldClickValue * 1.1);
        }

        private static int CalculatePrice(int clickValue)
        {
            return clickValue * 2 + 10;
        }

        private void ToggleShop()
        {
            if (BoosterBtn.Text.Equals("Buy boosters"))
            {
                ShopFrame.IsEnabled = true;
                ShopFrame.IsVisible = true;
                BoosterBtn.Text = "Continue on tapping the wombat";
            }
            else
            {
                ShopFrame.IsEnabled = false;
                ShopFrame.IsVisible = false;
                BoosterBtn.Text = "Buy boosters";
            }
        }

        private async void BuyBtn_Clicked(object sender, EventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)BindingContext;
            int price = CalculatePrice(viewModel.DovboData.ClickValue);
            if (viewModel.DovboData.Balance >= price)
            {
                viewModel.DovboData.Balance -= price;
                viewModel.DovboData.ClickValue += CalculateNewClickValue(viewModel.DovboData.ClickValue);
                UpdateProposition();
                await DisplayAlert("Purchase confirmed",
                    "You successfully upgraded tap price", "Great!");
            }
            else
            {
                await DisplayAlert("Could not buy the improvement",
                    $"Not enough coins, tap " +
                    $"{price - viewModel.DovboData.Balance} DVB more!", "Ok");
            }
        }
    }
}
