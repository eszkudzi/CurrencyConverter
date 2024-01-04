using CurrencyConverter.ViewModel;

namespace CurrencyConverter.View;

public partial class CurrencyConverterPage : ContentPage
{
    public CurrencyConverterPage()
    {
        InitializeComponent();
        BindingContext = new CurrencyConverterPageViewModel();
    }
}
