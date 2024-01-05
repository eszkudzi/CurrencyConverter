using System;
namespace CurrencyConverter.Model.DTO
{
    public class ExchangeRate
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double Rate { get; set; }
    }
}

