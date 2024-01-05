using System;
namespace CurrencyConverter.Services
{
	public interface ICalculateCurrency
	{
		public double ChangeCurrency(string fromCurrency, string toCurrency);
	}
}

