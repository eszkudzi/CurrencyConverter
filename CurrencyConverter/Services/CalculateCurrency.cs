using System;
using CurrencyConverter.Keys;
using System.Linq;

namespace CurrencyConverter.Services
{
    public class CalculateCurrency : ICalculateCurrency
    {
        public CalculateCurrency()
        {
        }

        public double ChangeCurrency(string fromCurrency, string toCurrency, string amount)
        {
            var exchangeRate = ExchangeRateList.GetCurrencies()
                .FirstOrDefault(rate => rate.FromCurrency == fromCurrency && rate.ToCurrency == toCurrency);

            if (!double.TryParse(amount, out double amountValue))
            {
                throw new ArgumentException("Invalid amount value");
            }

            if (fromCurrency == toCurrency)
            {
                return amountValue;
            }

            if (exchangeRate == null)
            {
                throw new ArgumentException("Exchange rate not found");
            }

            double result = amountValue * exchangeRate.Rate;

            return result;
        }
    }
}