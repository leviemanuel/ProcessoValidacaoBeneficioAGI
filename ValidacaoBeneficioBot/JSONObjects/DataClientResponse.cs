using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public class DataClientResponse
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("storeId")]
        public long StoreId { get; set; }

        [JsonProperty("costCenter")]
        public long CostCenter { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("attachments")]
        public object[] Attachments { get; set; }

        [JsonProperty("step")]
        public string Step { get; set; }

        [JsonProperty("consultant")]
        public Consultant Consultant { get; set; }

        [JsonProperty("enrichments")]
        public Enrichment[] Enrichments { get; set; }

        [JsonProperty("allowCancellation")]
        public bool AllowCancellation { get; set; }

        [JsonProperty("hasDataprevToken")]
        public bool HasDataprevToken { get; set; }
    }

    public partial class Consultant
    {
        [JsonProperty("taxId")]
        public string TaxId { get; set; }
    }

    public partial class Customer
    {
        [JsonProperty("identificationDocument")]
        public IdentificationDocument IdentificationDocument { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("phones")]
        public object[] Phones { get; set; }
    }

    public partial class IdentificationDocument
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Enrichment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }
    }
}
