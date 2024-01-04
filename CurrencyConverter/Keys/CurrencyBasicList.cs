using System;
using System.Collections.Generic;

namespace CurrencyConverter.Keys
{
    public static class CurrencyBasicList
    {
        public static List<Currency> GetCurrencies()
        {
            return new List<Currency>()
            {
                new Currency() { Name = "US Dollar", Code = "USD"},
                new Currency { Name = "Euro", Code = "EUR"},
                new Currency { Name = "British Pound", Code = "GBP"},
                new Currency { Name = "Polish Zloty", Code = "PLN" },
                new Currency { Name = "Canadian Dollar", Code = "CAD" },
                new Currency { Name = "Australian Dollar", Code = "AUD" },
                new Currency { Name = "New Zealand Dollar", Code = "NZD" },
                new Currency { Name = "Chinese Yuan", Code = "CNY" },
                new Currency { Name = "South Korean Won", Code = "KRW" },
                new Currency { Name = "Indian Rupee", Code = "INR" },
                new Currency { Name = "Russian Ruble", Code = "RUB" },
            };
        }
    }
}