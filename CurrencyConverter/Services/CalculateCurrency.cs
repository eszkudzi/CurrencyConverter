using System;
namespace CurrencyConverter.Services
{
	public class CalculateCurrency : ICalculateCurrency
	{
		public CalculateCurrency()
		{
		}

        public double ChangeCurrency(double fromCurrency, double toCurrency, double rate)
        {
			toCurrency = fromCurrency * rate;
			return toCurrency;
        }
    }
}

