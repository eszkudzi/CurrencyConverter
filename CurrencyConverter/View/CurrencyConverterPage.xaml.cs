using Newtonsoft.Json;
using CurrencyConverter.ViewModel;

namespace CurrencyConverter.View;

public partial class CurrencyConverterPage : ContentPage
{
   private string currencyFrom;
    private string currencyTo;
    List<Currency> CurrencyList = new List<Currency>()
    {
        new Currency(){Name = "US Dollar", Code = "USD"},
        new Currency { Name = "Euro", Code = "EUR" },
        new Currency { Name = "British Pound", Code = "GBP" },
        new Currency { Name = "Polish Zloty", Code = "PLN" },
        new Currency { Name = "Canadian Dollar", Code = "CAD" },
        new Currency { Name = "Australian Dollar", Code = "AUD" },
        new Currency { Name = "New Zealand Dollar", Code = "NZD" },
        new Currency { Name = "Chinese Yuan", Code = "CNY" },
        new Currency { Name = "South Korean Won", Code = "KRW" },
        new Currency { Name = "Indian Rupee", Code = "INR" },
        new Currency { Name = "Russian Ruble", Code = "RUB" },

    };
    public CurrencyConverterPage()
    {
        InitializeComponent();
        BindingContext = new CurrencyConverterPageViewModel();
        PickerFrom.ItemsSource = CurrencyList;
        PickerTo.ItemsSource = CurrencyList;
    }

    /*private async void Button_Clicked(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("apikey", "UmIMzIdnI0Sls0dp3wSMWwEXFiBc7z0E");
        var response = await httpClient.GetStringAsync($"https://api.apilayer.com/exchangerates_data/convert?to={currencyTo}&from={currencyFrom}&amount={EntryAmount.Text}");
        var currencyresult = JsonConvert.DeserializeObject<Root>(response);
        LabelResult.Text = Math.Round(currencyresult.Result, 2) + currencyTo;
    }*/

    private void PickerFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = PickerFrom.SelectedItem as Currency;
        currencyFrom = selectedItem.Code;
    }

    private void PickerTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = PickerTo.SelectedItem as Currency;
        currencyTo = selectedItem.Code;
    }
}
