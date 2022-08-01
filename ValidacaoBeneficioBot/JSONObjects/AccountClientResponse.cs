using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    internal class AccountClientResponse
    {
        [JsonProperty("Account")]
        public Account Account { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("isPrimary")]
        public bool IsPrimary { get; set; }

        [JsonProperty("record")]
        public Record Record { get; set; }
    }

    public partial class Record
    {
        [JsonProperty("apiName")]
        public string ApiName { get; set; }

        [JsonProperty("childRelationships")]
        public ChildRelationships ChildRelationships { get; set; }

        [JsonProperty("eTag")]
        public string ETag { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lastModifiedById")]
        public string LastModifiedById { get; set; }

        [JsonProperty("lastModifiedDate")]
        public DateTimeOffset LastModifiedDate { get; set; }

        [JsonProperty("recordTypeId")]
        public string RecordTypeId { get; set; }

        [JsonProperty("recordTypeInfo")]
        public RecordTypeInfo RecordTypeInfo { get; set; }

        [JsonProperty("systemModstamp")]
        public DateTimeOffset SystemModstamp { get; set; }

        [JsonProperty("weakEtag")]
        public long WeakEtag { get; set; }
    }

    public partial class ChildRelationships
    {
    }

    public partial class Fields
    {
        [JsonProperty("Name")]
        public Name Name { get; set; }

        [JsonProperty("RecordTypeId")]
        public Name RecordTypeId { get; set; }

        [JsonProperty("SystemModstamp")]
        public Name SystemModstamp { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("displayValue")]
        public string DisplayValue { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class RecordTypeInfo
    {
        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("defaultRecordTypeMapping")]
        public bool DefaultRecordTypeMapping { get; set; }

        [JsonProperty("master")]
        public bool Master { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recordTypeId")]
        public string RecordTypeId { get; set; }
    }
}