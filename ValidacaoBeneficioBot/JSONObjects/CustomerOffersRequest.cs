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

        [JsonProperty("unavailableProducts", NullValueHandling = NullValueHandling.Ignore)]
        public List<UnavailableProduct> UnavailableProducts { get; set; }
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
        public List<Simulation> Simulations { get; set; }

        [JsonProperty("paymentInformation")]
        public List<object> PaymentInformation { get; set; }

        [JsonProperty("checked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Checked { get; set; }

        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public Account Account { get; set; }

        [JsonProperty("dependencies", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dependencies { get; set; }

        [JsonProperty("packages", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Packages { get; set; }

        [JsonProperty("dueDates", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DueDates { get; set; }

        [JsonProperty("debts", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Debts { get; set; }
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



    public partial class UnavailableProduct
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtitle { get; set; }

        [JsonProperty("productOfferId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductOfferId { get; set; }

        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public Person Account { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public Limit Limit { get; set; }

        [JsonProperty("dependencies", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dependencies { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; set; }

        [JsonProperty("packages", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Packages { get; set; }

        [JsonProperty("income", NullValueHandling = NullValueHandling.Ignore)]
        public UnavailableProductIncome Income { get; set; }

        [JsonProperty("autoSelected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoSelected { get; set; }

        [JsonProperty("hidden", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Hidden { get; set; }

        [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
        public List<Rule> Rules { get; set; }

        [JsonProperty("warnings", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Warnings { get; set; }

        [JsonProperty("simulations", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Simulations { get; set; }

        [JsonProperty("dueDates", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DueDates { get; set; }

        [JsonProperty("paymentInformation", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> PaymentInformation { get; set; }

        [JsonProperty("notAllow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotAllow { get; set; }

        [JsonProperty("debts", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Debts { get; set; }
    }

    public partial class UnavailableProductIncome
    {
        [JsonProperty("benefit", NullValueHandling = NullValueHandling.Ignore)]
        public Benefit Benefit { get; set; }
    }

    public partial class Benefit
    {
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }
    }

    public partial class Limit
    {
        [JsonProperty("minFinalAvailableLimit", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinFinalAvailableLimit { get; set; }

        [JsonProperty("finalAvailableLimit", NullValueHandling = NullValueHandling.Ignore)]
        public long? FinalAvailableLimit { get; set; }

        [JsonProperty("installmentsData", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> InstallmentsData { get; set; }
    }
}

