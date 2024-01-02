using CurrencyConverter.ViewModel;

namespace CurrencyConverter.View;

public partial class CurrencyConverterPage : ContentPage
{
    public CurrencyConverterPage()
    {
        InitializeComponent();
        BindingContext = new CurrencyConverterPageViewModel();

    }

    private void PickerFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        var viewModel = BindingContext as CurrencyConverterPageViewModel;
        viewModel.PickerFrom_SelectedIndexChanged(PickerFrom.SelectedItem as Currency);
    }

    private void PickerTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        var viewModel = BindingContext as CurrencyConverterPageViewModel;
        viewModel.PickerTo_SelectedIndexChanged(PickerTo.SelectedItem as Currency);
    }
}
