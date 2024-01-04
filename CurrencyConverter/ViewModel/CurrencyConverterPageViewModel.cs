using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CurrencyConverter.Keys;
using CurrencyConverter.Services;

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
            CurrencyList = CurrencyBasicList.GetCurrencies();
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
            //CalculateCurrency.ChangeCurrency(SelectedCurrencyTo.Rate, SelectedCurrencyFrom.Rate);
        }


        private Command buttonAPIClickedCommand;
        public ICommand ButtonAPIClickedCommand => buttonAPIClickedCommand ??= new Command(ButtonAPIClicked);

        private async void ButtonAPIClicked(object obj)
        {
            var httpClient = new HttpClient();
            try
            {
                if (SelectedCurrencyFrom != null && SelectedCurrencyTo != null)
                {
                    httpClient.DefaultRequestHeaders.Add("apikey", "UmIMzIdnI0Sls0dp3wSMWwEXFiBc7z0E");
                    var response = await httpClient.GetStringAsync($"https://api.apilayer.com/exchangerates_data/convert?to={SelectedCurrencyTo.Code}&from={SelectedCurrencyFrom.Code}&amount={EntryAmount}");
                    var currencyResult = JsonConvert.DeserializeObject<Root>(response);
                    LabelResult = Math.Round(currencyResult.Result, 2) + " " + SelectedCurrencyTo.Code;
                }
                else
                {
                    LabelResult = "You have to use correct values!";
                }
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                httpClient.Dispose();
            }
        }

    }

}

