using System;
using Newtonsoft.Json;

namespace CurrencyConverter
{
    public class Info
    {
        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
    }

    public class Query
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }
    }

    public class Root
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }

        [JsonProperty("result")]
        public double Result { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }


}

