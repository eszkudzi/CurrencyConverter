using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CurrencyConverter.ViewModel

{
    public class CurrencyConverterPageViewModel : INotifyPropertyChanged

    {
        private List<Currency> currencyList;

        private Currency selectedCurrencyFrom;
        private Currency selectedCurrencyTo;

        private string entryAmount;

        private string labelResult;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Currency> CurrencyList
        {
            get => currencyList;
            set => SetProperty(ref currencyList, value);
        }

        public Currency SelectedCurrencyFrom
        {
            get => selectedCurrencyFrom;
            set => SetProperty(ref selectedCurrencyFrom, value);
        }

        public Currency SelectedCurrencyTo
        {
            get => selectedCurrencyTo;
            set => SetProperty(ref selectedCurrencyTo, value);
        }

        public string EntryAmount
        {
            get => entryAmount;
            set => SetProperty(ref entryAmount, value);

        }

        public string LabelResult
        {
            get => labelResult;
            set => SetProperty(ref labelResult, value);
        }

        public CurrencyConverterPageViewModel()
        {

            CurrencyList = new List<Currency>()
            {
                new Currency(){Name = "US Dollar", Code = "USD", Rate = 1.0},
                new Currency { Name = "Euro", Code = "EUR", Rate = 0.85 },
                new Currency { Name = "British Pound", Code = "GBP", Rate = 0.72 },
                new Currency { Name = "Polish Zloty", Code = "PLN", Rate = 3.9 },
                new Currency { Name = "Canadian Dollar", Code = "CAD", Rate = 1.25 },
                new Currency { Name = "Australian Dollar", Code = "AUD", Rate = 1.3 },
                new Currency { Name = "New Zealand Dollar", Code = "NZD", Rate = 1.4 },
                new Currency { Name = "Chinese Yuan", Code = "CNY", Rate = 6.4 },
                new Currency { Name = "South Korean Won", Code = "KRW", Rate = 1130.0 },
                new Currency { Name = "Indian Rupee", Code = "INR", Rate = 74.0 },
                new Currency { Name = "Russian Ruble", Code = "RUB", Rate = 75.0 },
            };

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

        private Command buttonClickedCommand;

        public ICommand ButtonClickedCommand => buttonClickedCommand ??= new Command(ButtonClicked);

        private void ButtonClicked()
        {
            LabelResult = EntryAmount;
        }


        private Command buttonAPIClickedCommand;
        public ICommand ButtonAPIClickedCommand => buttonAPIClickedCommand ??= new Command(ButtonAPIClicked);

        private async void ButtonAPIClicked(object obj)
        {
          
            if (SelectedCurrencyFrom != null && SelectedCurrencyTo != null)
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("apikey", "UmIMzIdnI0Sls0dp3wSMWwEXFiBc7z0E");
                var response = await httpClient.GetStringAsync($"https://api.apilayer.com/exchangerates_data/convert?to={SelectedCurrencyTo.Code}&from={SelectedCurrencyFrom.Code}&amount={EntryAmount}");
                var currencyResult = JsonConvert.DeserializeObject<Root>(response);
                LabelResult = Math.Round(currencyResult.Result, 2) + SelectedCurrencyTo.Code;
            }
            else
            {
                LabelResult = "Wybierz waluty.";
            }
        }

        public void PickerFrom_SelectedIndexChanged(Currency selectedItem)
        {
            SelectedCurrencyFrom = selectedItem;
        }

        public void PickerTo_SelectedIndexChanged(Currency selectedItem)
        {
            SelectedCurrencyTo = selectedItem;
        }

    }

}

