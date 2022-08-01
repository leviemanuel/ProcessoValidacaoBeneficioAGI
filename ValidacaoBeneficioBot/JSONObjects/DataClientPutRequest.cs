using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public class DataClientPutRequest
    {

        [JsonProperty("phone")]
        public object Phone { get; set; }

        [JsonProperty("additionalDocuments")]
        public List<AdditionalDocumentsType> AdditionalDocuments { get; set; }

        [JsonProperty("benefit")]
        public BenefitType Benefit { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get { return (DateBirthday.HasValue ? DateBirthday.Value.ToString("yyyy-MM-dd") : null); } }

        [JsonIgnore]
        public DateTime? DateBirthday { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("income")]
        public IncomeType Income { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("hasValidToken")]
        public bool? HasValidToken { get; set; }

        [JsonProperty("attendanceType")]
        public string AttendanceType { get; set; }

        [JsonProperty("consultant")]
        public ConsultantType Consultant { get; set; }

        [JsonProperty("originalAttendanceType")]
        public string OriginalAttendanceType { get; set; }

        [JsonProperty("dataprevAllowanceType")]
        public object DataprevAllowanceType { get; set; }

        [JsonProperty("allowDataprev")]
        public bool AllowDataprev { get; set; }

        [JsonProperty("allowDataprevRemotely")]
        public bool AllowDataprevRemotely { get; set; }

        [JsonProperty("storeId")]
        public string StoreId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; }

        [JsonProperty("creationDate")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty("asyncTokenReceived")]
        public bool AsyncTokenReceived { get; set; }

        [JsonProperty("lastUpdateDate")]
        public DateTime? LastUpdateDate { get; set; }

        [JsonProperty("durationSeconds")]
        public int? DurationSeconds { get; set; }

        [JsonProperty("actualStoreId")]
        public string ActualStoreId { get; set; }

        [JsonProperty("dataprevAllowanceTypes")]
        public List<object> DataprevAllowanceTypes { get; set; }
    }

    public class AdditionalDocumentsType
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }

    public class BenefitType
    {
        [JsonProperty("benefitKind")]
        public BenefitKindType BenefitKind { get; set; }

        [JsonProperty("cbcIfPayer")]
        public string CBCIfPayer { get; set; }

        [JsonProperty("dispatchYear")]
        public int? DispatchYear { get; set; }

        [JsonProperty("benefitNumber")]
        public string BenefitNumber { get; set; }

        [JsonProperty("ownsLawfulAgent")]
        public bool? OwnsLawfulAgent { get; set; }

        [JsonProperty("availableMargin")]
        public object AvailableMargin { get; set; }

        [JsonProperty("availableCardMargin")]
        public object AvailableCardMargin { get; set; }
    }

    public class BenefitKindType
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

    }

    public class IncomeType
    {
        [JsonProperty("grossIncome")]
        public int? GrossIncome { get; set; }

        [JsonProperty("netIncome")]
        public int? NetIncome { get; set; }

        [JsonProperty("payday")]
        public string Payday { get { return (DatePayday.HasValue ? DatePayday.Value.ToString("yyyy-MM-dd") : null); } }

        [JsonIgnore]
        public DateTime? DatePayday { get; set; }

        [JsonProperty("calculatedPayday")]
        public bool? CalculatedPayday { get; set; }

        [JsonProperty("discount")]
        public string Discount { get; set; }

    }

    public class ConsultantType
    {
        [JsonProperty("taxId")]
        public string TaxId { get; set; }

    }
}
