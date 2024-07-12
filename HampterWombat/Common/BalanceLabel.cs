namespace HampterWombat.Common
{
    public class BalanceLabel : Label
    {
        private string? _previousText;

        public event EventHandler<TextChangedEventArgs>? TextChanged;
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == TextProperty.PropertyName)
            {
                string newText = Text;
                string oldText = _previousText ?? string.Empty;
                _previousText = newText;

                TextChanged?.Invoke(this, new TextChangedEventArgs(newText, oldText));
            }
        }
    }

}
