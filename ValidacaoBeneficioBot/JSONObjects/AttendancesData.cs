using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class AttendancesData
    {
        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public string Document { get; set; }

        [JsonProperty("fullName", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty("consultant", NullValueHandling = NullValueHandling.Ignore)]
        public Consultant Consultant { get; set; }

        [JsonProperty("externalId", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; set; }

        [JsonProperty("allowDataprev", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowDataprev { get; set; }

        [JsonProperty("allowDataprevRemotely", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowDataprevRemotely { get; set; }

        [JsonProperty("storeId", NullValueHandling = NullValueHandling.Ignore)]
        public string StoreId { get; set; }

        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("actualStoreId", NullValueHandling = NullValueHandling.Ignore)]
        public string ActualStoreId { get; set; }

        [JsonProperty("benefit", NullValueHandling = NullValueHandling.Ignore)]
        public Benefit Benefit { get; set; }

        [JsonProperty("additionalDocuments", NullValueHandling = NullValueHandling.Ignore)]
        public List<AdditionalDocumentsType> AdditionalDocuments { get; set; }

        [JsonProperty("attachments", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Attachments { get; set; }

        [JsonProperty("creationDate", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTimeOffset? CreationDate { get; set; }
        public string CreationDate { get; set; }

        [JsonProperty("hasValidToken", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasValidToken { get; set; }

        [JsonProperty("asyncTokenReceived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AsyncTokenReceived { get; set; }

        [JsonProperty("dataprevAllowanceTypes", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> DataprevAllowanceTypes { get; set; }

        [JsonProperty("lastUpdateDate", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTimeOffset? LastUpdateDate { get; set; }
        public string LastUpdateDate { get; set; }

        [JsonProperty("durationSeconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationSeconds { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public object Phone { get; set; }

        [JsonProperty("income", NullValueHandling = NullValueHandling.Ignore)]
        public Income Income { get; set; }

        [JsonProperty("attendanceType", NullValueHandling = NullValueHandling.Ignore)]
        public object AttendanceType { get; set; }

        [JsonProperty("originalAttendanceType", NullValueHandling = NullValueHandling.Ignore)]
        public object OriginalAttendanceType { get; set; }

        [JsonProperty("dataprevAllowanceType", NullValueHandling = NullValueHandling.Ignore)]
        public object DataprevAllowanceType { get; set; }

        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public object Birthday { get; set; }

        [JsonProperty("postCode", NullValueHandling = NullValueHandling.Ignore)]
        public object PostCode { get; set; }
    }

    public partial class Benefit
    {
        [JsonProperty("benefitKind", NullValueHandling = NullValueHandling.Ignore)]
        public BenefitKind BenefitKind { get; set; }

        [JsonProperty("benefitNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string BenefitNumber { get; set; }

        [JsonProperty("dispatchYear", NullValueHandling = NullValueHandling.Ignore)]
        public string DispatchYear { get; set; }

        [JsonProperty("availableMargin", NullValueHandling = NullValueHandling.Ignore)]
        public object AvaliableMargin { get; set; }

        [JsonProperty("availableCardMargin", NullValueHandling = NullValueHandling.Ignore)]
        public object AvailableCardMargin { get; set; }

        [JsonProperty("ownsLawfulAgent", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OwnsLawfulAgent { get; set; }

        [JsonProperty("cbcIfPayer", NullValueHandling = NullValueHandling.Ignore)]
        public string CBCIfPayer { get; set; }
    }

    public partial class BenefitKind
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public object Code { get; set; }
    }

    public partial class Consultant
    {
        //[JsonProperty("taxId", NullValueHandling = NullValueHandling.Ignore)]
        //public string TaxId { get; set; }
    }
    public partial class Income
    {
        [JsonProperty("calculatedPayday")]
        public object CalculatedPayday { get; set; }

        [JsonProperty("calculatedIncome")]
        public object CalculatedIncome { get; set; }

        [JsonProperty("discount")]
        public object Discount { get; set; }

        [JsonProperty("estimatedIncome")]
        public object EstimatedIncome { get; set; }

        [JsonProperty("estimatedNetIncome")]
        public object EstimatedNetIncome { get; set; }

        [JsonProperty("grossIncome")]
        public object GrossIncome { get; set; }

        [JsonProperty("netIncome")]
        public object NetIncome { get; set; }

        [JsonProperty("paySource")]
        public object PaySource { get; set; }

        [JsonProperty("payday")]
        public object Payday { get; set; }

        [JsonProperty("payDayOrigin")]
        public object PayDayOrigin { get; set; }
    }
}
