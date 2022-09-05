using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    internal class FonteINSSResponse
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("person", NullValueHandling = NullValueHandling.Ignore)]
        public Person Person { get; set; }

        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<Product> Products { get; set; }

        [JsonProperty("unavailableProducts", NullValueHandling = NullValueHandling.Ignore)]
        public List<UnavailableProduct> UnavailableProducts { get; set; }

        [JsonProperty("pendingAttributes", NullValueHandling = NullValueHandling.Ignore)]
        public List<PendingAttribute> PendingAttributes { get; set; }
    }

    public partial class PendingAttribute
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("enforce", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enforce { get; set; }
    }

    public partial class Person
    {
        [JsonProperty("birthDay", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? BirthDay { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public ProductLimit Limit { get; set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public List<Detail> Details { get; set; }
    }

    public partial class ProductAccount
    {
    }

    public partial class Detail
    {
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }

    public partial class DueDate
    {
        [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
        public long? Day { get; set; }

        [JsonProperty("firstDueDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FirstDueDate { get; set; }
    }

    public partial class ProductLimit
    {
        [JsonProperty("availablePaymentCapacity", NullValueHandling = NullValueHandling.Ignore)]
        public double? AvailablePaymentCapacity { get; set; }

        [JsonProperty("minAvailablePaymentCapacity", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinAvailablePaymentCapacity { get; set; }

        [JsonProperty("minFinalAvailableLimit", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinFinalAvailableLimit { get; set; }

        [JsonProperty("finalAvailableLimit", NullValueHandling = NullValueHandling.Ignore)]
        public double? FinalAvailableLimit { get; set; }

        [JsonProperty("maxInstallments", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxInstallments { get; set; }

        [JsonProperty("minInstallments", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinInstallments { get; set; }

        [JsonProperty("installmentsData", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> InstallmentsData { get; set; }
    }

    public partial class Package
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public partial class PaymentInformation
    {
        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentInformationAccount Account { get; set; }

        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }
    }

    public partial class PaymentInformationAccount
    {
        [JsonProperty("bank", NullValueHandling = NullValueHandling.Ignore)]
        public string Bank { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("cbcInstitutionCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CbcInstitutionCode { get; set; }

        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public long? Priority { get; set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AccountRequired { get; set; }
    }

    public partial class Simulation
    {
        [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? Rate { get; set; }

        [JsonProperty("yearlyRate", NullValueHandling = NullValueHandling.Ignore)]
        public double? YearlyRate { get; set; }

        [JsonProperty("installments", NullValueHandling = NullValueHandling.Ignore)]
        public int? Installments { get; set; }

        [JsonProperty("installmentsData", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> InstallmentsData { get; set; }

        [JsonProperty("firstDueDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FirstDueDate { get; set; }

        [JsonProperty("finalDueDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FinalDueDate { get; set; }

        [JsonProperty("availablePaymentCapacity", NullValueHandling = NullValueHandling.Ignore)]
        public double? AvailablePaymentCapacity { get; set; }

        [JsonProperty("finalAvailableLimit", NullValueHandling = NullValueHandling.Ignore)]
        public double? FinalAvailableLimit { get; set; }

        [JsonProperty("operationGrossValue", NullValueHandling = NullValueHandling.Ignore)]
        public double? OperationGrossValue { get; set; }

        [JsonProperty("financedAmount", NullValueHandling = NullValueHandling.Ignore)]
        public double? FinancedAmount { get; set; }

        [JsonProperty("iof", NullValueHandling = NullValueHandling.Ignore)]
        public double? Iof { get; set; }

        [JsonProperty("iofTotalValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? IofTotalValue { get; set; }

        [JsonProperty("monthlyCet", NullValueHandling = NullValueHandling.Ignore)]
        public double? MonthlyCet { get; set; }

        [JsonProperty("yearlyCet", NullValueHandling = NullValueHandling.Ignore)]
        public double? YearlyCet { get; set; }

        [JsonProperty("includeFare", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeFare { get; set; }

        [JsonProperty("includeIof", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeIof { get; set; }

        [JsonProperty("releasedValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReleasedValue { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("simulationDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? SimulationDate { get; set; }

        [JsonProperty("isDefault", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDefault { get; set; }

        [JsonProperty("rateOption", NullValueHandling = NullValueHandling.Ignore)]
        public RateOption RateOption { get; set; }

        [JsonProperty("fareValue", NullValueHandling = NullValueHandling.Ignore)]
        public long? FareValue { get; set; }
    }

    public partial class RateOption
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
        public string Index { get; set; }
    }

    public partial class UnavailableProductLimit
    {
        [JsonProperty("minFinalAvailableLimit", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinFinalAvailableLimit { get; set; }

        [JsonProperty("finalAvailableLimit", NullValueHandling = NullValueHandling.Ignore)]
        public long? FinalAvailableLimit { get; set; }

        [JsonProperty("installmentsData", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> InstallmentsData { get; set; }
    }
}
