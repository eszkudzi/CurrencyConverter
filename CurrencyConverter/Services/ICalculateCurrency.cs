using System;
namespace CurrencyConverter.Services
{
	public interface ICalculateCurrency
	{
		public double ChangeCurrency(double fromCurrency, double toCurrency);
	}
}

