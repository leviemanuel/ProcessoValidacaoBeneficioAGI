using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class CustomerOffersRequest
    {
        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<Product> Products { get; set; }
    }

    public partial class Person
    {
    }

    public partial class Product
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtitle { get; set; }

        [JsonProperty("productOfferId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductOfferId { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; set; }

        [JsonProperty("income", NullValueHandling = NullValueHandling.Ignore)]
        public Income Income { get; set; }

        [JsonProperty("autoSelected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoSelected { get; set; }

        [JsonProperty("hidden", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
        public List<Rule> Rules { get; set; }

        [JsonProperty("warnings")]
        public List<object> Warnings { get; set; }

        [JsonProperty("simulations")]
        public List<object> Simulations { get; set; }

        [JsonProperty("paymentInformation")]
        public List<object> PaymentInformation { get; set; }

        [JsonProperty("checked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Checked { get; set; }
    }

    public partial class Income
    {
        [JsonProperty("benefit", NullValueHandling = NullValueHandling.Ignore)]
        public Person Benefit { get; set; }
    }

    public partial class Rule
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}

