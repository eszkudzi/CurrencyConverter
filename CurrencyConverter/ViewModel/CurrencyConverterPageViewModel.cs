using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CurrencyConverter.ViewModel
{
    public class CurrencyConverterPageViewModel : INotifyPropertyChanged
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

        public CurrencyConverterPageViewModel()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private Command buttonAPIClickedCommand;
        public ICommand ButtonAPIClickedCommand => buttonAPIClickedCommand ??= new Command(ButtonAPIClicked);

        private async void ButtonAPIClicked(object obj)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("apikey", "UmIMzIdnI0Sls0dp3wSMWwEXFiBc7z0E");
            var response = await httpClient.GetStringAsync($"https://api.apilayer.com/exchangerates_data/convert?to={currencyTo}&from={currencyFrom}&amount={EntryAmount}");
            var currencyresult = JsonConvert.DeserializeObject<Root>(response);
            LabelResult = Math.Round(currencyresult.Result, 2) + currencyTo;
        }


        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private BindingBase name;

        public BindingBase Name { get => name; set => SetProperty(ref name, value); }

        private string labelResult;

        public string LabelResult { get => labelResult; set => SetProperty(ref labelResult, value); }

        private string entryAmount;

        public string EntryAmount { get => entryAmount; set => SetProperty(ref entryAmount, value); }

        private Command buttonClickedCommand;
        public ICommand ButtonClickedCommand => buttonClickedCommand ??= new Command(ButtonClicked);

        private void ButtonClicked()
        {

        }
    }
}

