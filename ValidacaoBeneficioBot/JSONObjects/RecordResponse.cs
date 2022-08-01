using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class RecordResponse
    {
        [JsonProperty("Account", NullValueHandling = NullValueHandling.Ignore)]
        public Account Account { get; set; }
    }

    public partial class Account
    {
        //[JsonProperty("isPrimary", NullValueHandling = NullValueHandling.Ignore)]
        //public bool? IsPrimary { get; set; }

        //[JsonProperty("record", NullValueHandling = NullValueHandling.Ignore)]
        //public Record Record { get; set; }
    }

    public partial class Record
    {
        //[JsonProperty("apiName", NullValueHandling = NullValueHandling.Ignore)]
        //public string ApiName { get; set; }

        //[JsonProperty("childRelationships", NullValueHandling = NullValueHandling.Ignore)]
        //public ChildRelationships ChildRelationships { get; set; }

        //[JsonProperty("eTag", NullValueHandling = NullValueHandling.Ignore)]
        //public string ETag { get; set; }

        //[JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        //public Fields Fields { get; set; }

        //[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        //public string Id { get; set; }

        //[JsonProperty("lastModifiedById", NullValueHandling = NullValueHandling.Ignore)]
        //public string LastModifiedById { get; set; }

        //[JsonProperty("lastModifiedDate", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTimeOffset? LastModifiedDate { get; set; }

        //[JsonProperty("recordTypeId", NullValueHandling = NullValueHandling.Ignore)]
        //public string RecordTypeId { get; set; }

        //[JsonProperty("recordTypeInfo", NullValueHandling = NullValueHandling.Ignore)]
        //public RecordTypeInfo RecordTypeInfo { get; set; }

        //[JsonProperty("systemModstamp", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTimeOffset? SystemModstamp { get; set; }

        //[JsonProperty("weakEtag", NullValueHandling = NullValueHandling.Ignore)]
        //public long? WeakEtag { get; set; }
    }

    public partial class ChildRelationships
    {
    }

    public partial class Fields
    {
        //[JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        //public Name Name { get; set; }

        //[JsonProperty("RecordTypeId", NullValueHandling = NullValueHandling.Ignore)]
        //public Name RecordTypeId { get; set; }

        //[JsonProperty("SystemModstamp", NullValueHandling = NullValueHandling.Ignore)]
        //public Name SystemModstamp { get; set; }
    }

    public partial class Name
    {
        //[JsonProperty("displayValue")]
        //public string DisplayValue { get; set; }

        //[JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        //public string Value { get; set; }
    }

    public partial class RecordTypeInfo
    {
        //[JsonProperty("available", NullValueHandling = NullValueHandling.Ignore)]
        //public bool? Available { get; set; }

        //[JsonProperty("defaultRecordTypeMapping", NullValueHandling = NullValueHandling.Ignore)]
        //public bool? DefaultRecordTypeMapping { get; set; }

        //[JsonProperty("master", NullValueHandling = NullValueHandling.Ignore)]
        //public bool? Master { get; set; }

        //[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        //public string Name { get; set; }

        //[JsonProperty("recordTypeId", NullValueHandling = NullValueHandling.Ignore)]
        //public string RecordTypeId { get; set; }
    }
}
