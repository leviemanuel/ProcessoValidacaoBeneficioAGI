using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public partial class AccountHighlightContainerApp
    {
        [JsonProperty("clientLibraries", NullValueHandling = NullValueHandling.Ignore)]
        public List<Uri> ClientLibraries { get; set; }

        [JsonProperty("delegateVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string DelegateVersion { get; set; }

        [JsonProperty("auraConfig", NullValueHandling = NullValueHandling.Ignore)]
        public AuraConfig AuraConfig { get; set; }

        [JsonProperty("isSidTokenEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSidTokenEnabled { get; set; }

        [JsonProperty("absoluteURL", NullValueHandling = NullValueHandling.Ignore)]
        public Uri AbsoluteUrl { get; set; }

        [JsonProperty("styles", NullValueHandling = NullValueHandling.Ignore)]
        public List<Uri> Styles { get; set; }

        [JsonProperty("scripts", NullValueHandling = NullValueHandling.Ignore)]
        public List<Uri> Scripts { get; set; }
    }

    public partial class AuraConfig
    {
        [JsonProperty("deftype", NullValueHandling = NullValueHandling.Ignore)]
        public string Deftype { get; set; }

        [JsonProperty("staticResourceDomain", NullValueHandling = NullValueHandling.Ignore)]
        public string StaticResourceDomain { get; set; }

        [JsonProperty("ns", NullValueHandling = NullValueHandling.Ignore)]
        public Ns Ns { get; set; }

        [JsonProperty("initializers", NullValueHandling = NullValueHandling.Ignore)]
        public Initializers Initializers { get; set; }

        [JsonProperty("host", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Host { get; set; }

        [JsonProperty("context", NullValueHandling = NullValueHandling.Ignore)]
        public Context Context { get; set; }

        [JsonProperty("auraCmpDefBaseURI", NullValueHandling = NullValueHandling.Ignore)]
        public string AuraCmpDefBaseUri { get; set; }

        [JsonProperty("descriptor", NullValueHandling = NullValueHandling.Ignore)]
        public string Descriptor { get; set; }

        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        [JsonProperty("applyCssVarPolyfill", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ApplyCssVarPolyfill { get; set; }
    }

    public partial class Context
    {
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }

        [JsonProperty("app", NullValueHandling = NullValueHandling.Ignore)]
        public string App { get; set; }

        [JsonProperty("pathPrefix", NullValueHandling = NullValueHandling.Ignore)]
        public string PathPrefix { get; set; }

        [JsonProperty("fwuid", NullValueHandling = NullValueHandling.Ignore)]
        public string Fwuid { get; set; }

        [JsonProperty("mlr", NullValueHandling = NullValueHandling.Ignore)]
        public long? Mlr { get; set; }

        [JsonProperty("uad", NullValueHandling = NullValueHandling.Ignore)]
        public long? Uad { get; set; }

        [JsonProperty("loaded", NullValueHandling = NullValueHandling.Ignore)]
        public Loaded Loaded { get; set; }

        [JsonProperty("globalValueProviders", NullValueHandling = NullValueHandling.Ignore)]
        public List<GlobalValueProvider> GlobalValueProviders { get; set; }

        [JsonProperty("enableAccessChecks", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableAccessChecks { get; set; }

        [JsonProperty("dns", NullValueHandling = NullValueHandling.Ignore)]
        public string Dns { get; set; }

        [JsonProperty("ls", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ls { get; set; }

        [JsonProperty("lairn", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Lairn { get; set; }

        [JsonProperty("laerc", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Laerc { get; set; }

        [JsonProperty("lav", NullValueHandling = NullValueHandling.Ignore)]
        public string Lav { get; set; }

        [JsonProperty("csp", NullValueHandling = NullValueHandling.Ignore)]
        public long? Csp { get; set; }

        [JsonProperty("mna", NullValueHandling = NullValueHandling.Ignore)]
        public Mna Mna { get; set; }

        [JsonProperty("lff", NullValueHandling = NullValueHandling.Ignore)]
        public Lff Lff { get; set; }

        [JsonProperty("arse", NullValueHandling = NullValueHandling.Ignore)]
        public long? Arse { get; set; }

        [JsonProperty("acaf", NullValueHandling = NullValueHandling.Ignore)]
        public long? Acaf { get; set; }

        [JsonProperty("services", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Services { get; set; }
    }

    public partial class GlobalValueProvider
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public Values Values { get; set; }
    }

    public partial class Values
    {
        [JsonProperty("CurrentUser", NullValueHandling = NullValueHandling.Ignore)]
        public CurrentUser CurrentUser { get; set; }

        [JsonProperty("userLocaleLang", NullValueHandling = NullValueHandling.Ignore)]
        public string UserLocaleLang { get; set; }

        [JsonProperty("userLocaleCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string UserLocaleCountry { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("variant", NullValueHandling = NullValueHandling.Ignore)]
        public string Variant { get; set; }

        [JsonProperty("langLocale", NullValueHandling = NullValueHandling.Ignore)]
        public string LangLocale { get; set; }

        [JsonProperty("datetimeLocale", NullValueHandling = NullValueHandling.Ignore)]
        public string DatetimeLocale { get; set; }

        [JsonProperty("nameOfMonths", NullValueHandling = NullValueHandling.Ignore)]
        public List<NameOf> NameOfMonths { get; set; }

        [JsonProperty("nameOfWeekdays", NullValueHandling = NullValueHandling.Ignore)]
        public List<NameOf> NameOfWeekdays { get; set; }

        [JsonProperty("labelForToday", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelForToday { get; set; }

        [JsonProperty("firstDayOfWeek", NullValueHandling = NullValueHandling.Ignore)]
        public long? FirstDayOfWeek { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }

        [JsonProperty("dateFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string DateFormat { get; set; }

        [JsonProperty("shortDateFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortDateFormat { get; set; }

        [JsonProperty("longDateFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string LongDateFormat { get; set; }

        [JsonProperty("datetimeFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string DatetimeFormat { get; set; }

        [JsonProperty("shortDatetimeFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortDatetimeFormat { get; set; }

        [JsonProperty("timeFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeFormat { get; set; }

        [JsonProperty("shortTimeFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortTimeFormat { get; set; }

        [JsonProperty("numberFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberFormat { get; set; }

        [JsonProperty("decimal", NullValueHandling = NullValueHandling.Ignore)]
        public string Decimal { get; set; }

        [JsonProperty("grouping", NullValueHandling = NullValueHandling.Ignore)]
        public string Grouping { get; set; }

        [JsonProperty("zero", NullValueHandling = NullValueHandling.Ignore)]
        public string Zero { get; set; }

        [JsonProperty("percentFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string PercentFormat { get; set; }

        [JsonProperty("currencyFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyFormat { get; set; }

        [JsonProperty("currencyCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("dir", NullValueHandling = NullValueHandling.Ignore)]
        public string Dir { get; set; }

        [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
        public string Lang { get; set; }

        [JsonProperty("isEasternNameStyle", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEasternNameStyle { get; set; }

        [JsonProperty("showJapaneseImperialYear", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowJapaneseImperialYear { get; set; }

        [JsonProperty("containerVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string ContainerVersion { get; set; }

        [JsonProperty("isWEBKIT", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsWebkit { get; set; }

        [JsonProperty("isIE11", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIe11 { get; set; }

        [JsonProperty("formFactor", NullValueHandling = NullValueHandling.Ignore)]
        public string FormFactor { get; set; }

        [JsonProperty("isIE10", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIe10 { get; set; }

        [JsonProperty("isContainer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsContainer { get; set; }

        [JsonProperty("isBlackBerry", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsBlackBerry { get; set; }

        [JsonProperty("isIE7", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIe7 { get; set; }

        [JsonProperty("isIE6", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIe6 { get; set; }

        [JsonProperty("isIE9", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIe9 { get; set; }

        [JsonProperty("isIE8", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIe8 { get; set; }

        [JsonProperty("isDesktop", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDesktop { get; set; }

        [JsonProperty("isTablet", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTablet { get; set; }

        [JsonProperty("isIPad", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIPad { get; set; }

        [JsonProperty("isSameSiteNoneIncompatible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSameSiteNoneIncompatible { get; set; }

        [JsonProperty("isWindowsTablet", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsWindowsTablet { get; set; }

        [JsonProperty("isPhone", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPhone { get; set; }

        [JsonProperty("S1Features", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, bool> S1Features { get; set; }

        [JsonProperty("isFIREFOX", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsFirefox { get; set; }

        [JsonProperty("isWindowsPhone", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsWindowsPhone { get; set; }

        [JsonProperty("isOSX", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOsx { get; set; }

        [JsonProperty("containerVersionMajor", NullValueHandling = NullValueHandling.Ignore)]
        public long? ContainerVersionMajor { get; set; }

        [JsonProperty("isAndroid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAndroid { get; set; }

        [JsonProperty("isIPhone", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIPhone { get; set; }

        [JsonProperty("isIOS", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIos { get; set; }

        [JsonProperty("containedContentHost", NullValueHandling = NullValueHandling.Ignore)]
        public string ContainedContentHost { get; set; }

        [JsonProperty("communityPrefix", NullValueHandling = NullValueHandling.Ignore)]
        public string CommunityPrefix { get; set; }

        [JsonProperty("eswConfigDeveloperName", NullValueHandling = NullValueHandling.Ignore)]
        public AppContextId EswConfigDeveloperName { get; set; }

        [JsonProperty("isVoiceOver", NullValueHandling = NullValueHandling.Ignore)]
        public IsVoiceOver IsVoiceOver { get; set; }

        [JsonProperty("setupAppContextId", NullValueHandling = NullValueHandling.Ignore)]
        public AppContextId SetupAppContextId { get; set; }

        [JsonProperty("density", NullValueHandling = NullValueHandling.Ignore)]
        public AppContextId Density { get; set; }

        [JsonProperty("srcdoc", NullValueHandling = NullValueHandling.Ignore)]
        public IsVoiceOver Srcdoc { get; set; }

        [JsonProperty("appContextId", NullValueHandling = NullValueHandling.Ignore)]
        public AppContextId AppContextId { get; set; }

        [JsonProperty("dynamicTypeSize", NullValueHandling = NullValueHandling.Ignore)]
        public AppContextId DynamicTypeSize { get; set; }

        [JsonProperty("security", NullValueHandling = NullValueHandling.Ignore)]
        public Security Security { get; set; }

        [JsonProperty("SaveDraftErrors", NullValueHandling = NullValueHandling.Ignore)]
        public SaveDraftErrors SaveDraftErrors { get; set; }

        [JsonProperty("Errors", NullValueHandling = NullValueHandling.Ignore)]
        public Errors Errors { get; set; }

        [JsonProperty("ForceRecord", NullValueHandling = NullValueHandling.Ignore)]
        public ForceRecord ForceRecord { get; set; }

        [JsonProperty("Offline", NullValueHandling = NullValueHandling.Ignore)]
        public Offline Offline { get; set; }

        [JsonProperty("Duration", NullValueHandling = NullValueHandling.Ignore)]
        public Duration Duration { get; set; }

        [JsonProperty("Exception", NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionClass Exception { get; set; }
    }

    public partial class AppContextId
    {
        [JsonProperty("writable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Writable { get; set; }

        [JsonProperty("defaultValue", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultValue { get; set; }
    }

    public partial class CurrentUser
    {
        [JsonProperty("isChatterEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsChatterEnabled { get; set; }

        [JsonProperty("Email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public partial class Duration
    {
        [JsonProperty("secondsLater", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondsLater { get; set; }

        [JsonProperty("secondsAgo", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondsAgo { get; set; }
    }

    public partial class Errors
    {
        [JsonProperty("NoRecordDataFound", NullValueHandling = NullValueHandling.Ignore)]
        public string NoRecordDataFound { get; set; }
    }

    public partial class ExceptionClass
    {
        [JsonProperty("NoAccessException_desc", NullValueHandling = NullValueHandling.Ignore)]
        public string NoAccessExceptionDesc { get; set; }
    }

    public partial class ForceRecord
    {
        [JsonProperty("RecordDataCannotUseEntity", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordDataCannotUseEntity { get; set; }

        [JsonProperty("invalidRecordLibraryUse", NullValueHandling = NullValueHandling.Ignore)]
        public string InvalidRecordLibraryUse { get; set; }
    }

    public partial class IsVoiceOver
    {
        [JsonProperty("writable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Writable { get; set; }

        [JsonProperty("defaultValue", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DefaultValue { get; set; }
    }

    public partial class NameOf
    {
        [JsonProperty("fullName", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty("shortName", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortName { get; set; }
    }

    public partial class Offline
    {
        [JsonProperty("NoConnectionCSRFProblemTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string NoConnectionCsrfProblemTitle { get; set; }

        [JsonProperty("NoConnectionTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string NoConnectionTitle { get; set; }
    }

    public partial class SaveDraftErrors
    {
        [JsonProperty("DraftsDisabledDueToIssue", NullValueHandling = NullValueHandling.Ignore)]
        public string DraftsDisabledDueToIssue { get; set; }

        [JsonProperty("Generic", NullValueHandling = NullValueHandling.Ignore)]
        public string Generic { get; set; }

        [JsonProperty("PendingSync", NullValueHandling = NullValueHandling.Ignore)]
        public string PendingSync { get; set; }

        [JsonProperty("DeleteEditDraft", NullValueHandling = NullValueHandling.Ignore)]
        public string DeleteEditDraft { get; set; }

        [JsonProperty("DeleteIrreconcilableDraft", NullValueHandling = NullValueHandling.Ignore)]
        public string DeleteIrreconcilableDraft { get; set; }

        [JsonProperty("NoDraftLookupToDraftId", NullValueHandling = NullValueHandling.Ignore)]
        public string NoDraftLookupToDraftId { get; set; }

        [JsonProperty("DifferentActionThanDraft", NullValueHandling = NullValueHandling.Ignore)]
        public string DifferentActionThanDraft { get; set; }

        [JsonProperty("EditDeleteDraft", NullValueHandling = NullValueHandling.Ignore)]
        public string EditDeleteDraft { get; set; }
    }

    public partial class Security
    {
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }
    }

    public partial class Lff
    {
        [JsonProperty("ENABLE_MIXED_SHADOW_MODE", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableMixedShadowMode { get; set; }
    }

    public partial class Loaded
    {

    }

    public partial class Mna
    {
        [JsonProperty("lightning", NullValueHandling = NullValueHandling.Ignore)]
        public string Lightning { get; set; }
    }

    public partial class Initializers
    {
        [JsonProperty("gates", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, List<long>> Gates { get; set; }

        [JsonProperty("accessChecks", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, bool> AccessChecks { get; set; }
    }

    public partial class Ns
    {
        [JsonProperty("internal", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Internal { get; set; }

        [JsonProperty("privileged", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Privileged { get; set; }
    }
}
