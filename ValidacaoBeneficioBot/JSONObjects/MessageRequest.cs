using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoBeneficioBot.JSONObjects
{
    public class MessageRequest
    {
        public MessageRequest()
        {
            Actions = new List<Action>();
        }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Action> Actions { get; set; }
    }

    public partial class Action
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        //[JsonProperty("state", NullValueHandling=NullValueHandling.Ignore)]
        //public string State { get; set; }

        //[JsonProperty("returnValue", NullValueHandling=NullValueHandling.Ignore)]
        //public ReturnValue ReturnValue { get; set; }

        //[JsonProperty("error", NullValueHandling=NullValueHandling.Ignore)]
        //public Error Error { get; set; }

        //[JsonProperty("components", NullValueHandling=NullValueHandling.Ignore)]
        //public Component[] Components { get; set; }


        [JsonProperty("descriptor", NullValueHandling = NullValueHandling.Ignore)]
        public string Descriptor { get; set; }

        [JsonProperty("callingDescriptor", NullValueHandling = NullValueHandling.Ignore)]
        public string CallingDescriptor { get; set; }

        [JsonProperty("params", NullValueHandling = NullValueHandling.Ignore)]
        public ActionParams Params { get; set; }

        [JsonProperty("storable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Storable { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

    }

    public partial class ActionParams
    {
        [JsonProperty("params", NullValueHandling = NullValueHandling.Ignore)]
        public ActionParams Params { get; set; }

        [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
        public Attributes Attributes { get; set; }

        [JsonProperty("publishedChangelistNum", NullValueHandling = NullValueHandling.Ignore)]
        public long? PublishedChangelistNum { get; set; }

        [JsonProperty("brandingSetId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? BrandingSetId { get; set; }

        [JsonProperty("viewOrThemeLayoutId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ViewOrThemeLayoutId { get; set; }

        [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
        public string Action { get; set; }

        [JsonProperty("interview", NullValueHandling = NullValueHandling.Ignore)]
        public string Interview { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<Field> Fields { get; set; }

        [JsonProperty("uiElementVisited", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UIElementVisited { get; set; }

        [JsonProperty("enableTrace", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableTrace { get; set; }

        [JsonProperty("lcErrors", NullValueHandling = NullValueHandling.Ignore)]
        public object LCErrors { get; set; }

        [JsonProperty("flowDevName", NullValueHandling = NullValueHandling.Ignore)]
        public string FlowDevName { get; set; }

        [JsonProperty("flowName", NullValueHandling = NullValueHandling.Ignore)]
        public string FlowName { get; set; }

        [JsonProperty("groupId", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupId { get; set; }

        [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
        public string Arguments { get; set; }

        [JsonProperty("enableRollbackMode", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EnableRollbackMode { get; set; }

        [JsonProperty("debugAsUserId", NullValueHandling = NullValueHandling.Ignore)]
        public string DebugAsUserId { get; set; }

        [JsonProperty("audienceKey", NullValueHandling = NullValueHandling.Ignore)]
        public string AudienceKey { get; set; }

        [JsonProperty("html", NullValueHandling = NullValueHandling.Ignore)]
        public string HTML { get; set; }

        [JsonProperty("dashboardId", NullValueHandling = NullValueHandling.Ignore)]
        public string DashboardId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("namespace", NullValueHandling = NullValueHandling.Ignore)]
        public string Namespace { get; set; }

        [JsonProperty("navigationLinkSetIdOrName", NullValueHandling = NullValueHandling.Ignore)]
        public string NavigationLinkSetIdOrName { get; set; }

        [JsonProperty("includeImageUrl", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeImageUrl { get; set; }

        [JsonProperty("addHomeMenuItem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AddHomeMenuItem { get; set; }

        [JsonProperty("menuItemTypesToSkip", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MenuItemTypesToSkip { get; set; }

        [JsonProperty("masterLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string MasterLabel { get; set; }

        [JsonProperty("recordDescriptor", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordDescriptor { get; set; }

        [JsonProperty("networkId", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkId { get; set; }

        [JsonProperty("requestOrigin", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestOrigin { get; set; }

        [JsonProperty("classname", NullValueHandling = NullValueHandling.Ignore)]
        public string Classname { get; set; }

        [JsonProperty("objectApiName", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectApiName { get; set; }

        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        [JsonProperty("accountId", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountId { get; set; }

        [JsonProperty("recordId", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordId { get; set; }

        [JsonProperty("cacheable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Cacheable { get; set; }

        [JsonProperty("isContinuation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsContinuation { get; set; }

        [JsonProperty("command", NullValueHandling = NullValueHandling.Ignore)]
        public Command Command { get; set; }

        [JsonProperty("hasAttrVaringCmps", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasAttrVaringCmps { get; set; }

        [JsonProperty("headerLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderLabel { get; set; }

        [JsonProperty("optionalFields", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> OptionalFields { get; set; }

        [JsonProperty("taskId", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskId { get; set; }


        [JsonProperty("failedAction", NullValueHandling = NullValueHandling.Ignore)]
        public string FailedAction { get; set; }

        [JsonProperty("failedId", NullValueHandling = NullValueHandling.Ignore)]
        public int? FailedId { get; set; }

        [JsonProperty("clientError", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientError { get; set; }

        [JsonProperty("additionalData", NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalData { get; set; }

        [JsonProperty("clientStack", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientStack { get; set; }

        [JsonProperty("componentStack", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentStack { get; set; }

        [JsonProperty("stacktraceIdGen", NullValueHandling = NullValueHandling.Ignore)]
        public string StackTraceIdGen { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public string Level { get; set; }
    }

    public partial class Command
    {

        [JsonProperty("AccountId", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountId { get; set; }

        [JsonProperty("AttendanceType", NullValueHandling = NullValueHandling.Ignore)]
        public string AttendanceType { get; set; }

        [JsonProperty("PaymentSourceType", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentSourceType { get; set; }
    }

    public partial class NewAccountSimulationFlow : ActionParams
    {

        [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Arguments { get; set; }

    }

    public partial class Attributes
    {
        [JsonProperty("itemId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ItemId { get; set; }

        [JsonProperty("viewId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ViewId { get; set; }

        [JsonProperty("routeType", NullValueHandling = NullValueHandling.Ignore)]
        public string RouteType { get; set; }

        [JsonProperty("themeLayoutType", NullValueHandling = NullValueHandling.Ignore)]
        public string ThemeLayoutType { get; set; }

        [JsonProperty("params", NullValueHandling = NullValueHandling.Ignore)]
        public AttributesParams Params { get; set; }

        [JsonProperty("hasAttrVaringCmps", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasAttrVaringCmps { get; set; }

        [JsonProperty("pageLoadType", NullValueHandling = NullValueHandling.Ignore)]
        public string PageLoadType { get; set; }

        [JsonProperty("includeLayout", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeLayout { get; set; }

        [JsonProperty("NavigationMenuEditorRefresh", NullValueHandling = NullValueHandling.Ignore)]
        public string NavigationMenuEditorRefresh { get; set; }

        [JsonProperty("hideHomeText", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideHomeText { get; set; }

        [JsonProperty("hideAppLauncher", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideAppLauncher { get; set; }

        [JsonProperty("recordId", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordId { get; set; }

        [JsonProperty("headerLabel", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderLabel { get; set; }

        [JsonProperty("richTextValue", NullValueHandling = NullValueHandling.Ignore)]
        public string RichTextValue { get; set; }
    }

    public partial class Field
    {
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string FieldSon { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("isVisible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsVisible { get; set; }
    }

    public partial class AttributesParams
    {
        [JsonProperty("viewid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Viewid { get; set; }

        [JsonProperty("view_uddid", NullValueHandling = NullValueHandling.Ignore)]
        public string ViewUddid { get; set; }

        [JsonProperty("entity_name", NullValueHandling = NullValueHandling.Ignore)]
        public string EntityName { get; set; }

        [JsonProperty("audience_name", NullValueHandling = NullValueHandling.Ignore)]
        public string AudienceName { get; set; }

        [JsonProperty("picasso_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PicassoId { get; set; }

        [JsonProperty("routeId", NullValueHandling = NullValueHandling.Ignore)]
        public string RouteId { get; set; }

        [JsonProperty("recordId", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordId { get; set; }

        [JsonProperty("recordName", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordName { get; set; }
    }

    public class AuraContextRequest
    {
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }

        [JsonProperty("fwuid", NullValueHandling = NullValueHandling.Ignore)]
        public string Fwuid { get; set; }

        [JsonProperty("app", NullValueHandling = NullValueHandling.Ignore)]
        public string App { get; set; }

        [JsonProperty("loaded", NullValueHandling = NullValueHandling.Ignore)]
        public Loaded Loaded { get; set; }

        [JsonProperty("dn", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Globals> Dn { get; set; }

        [JsonProperty("globals", NullValueHandling = NullValueHandling.Ignore)]
        public Globals Globals { get; set; }

        [JsonProperty("uad", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Uad { get; set; }
    }

    public partial class Globals
    {
    }

    public partial class Loaded
    {
        [JsonProperty("APPLICATION@markup://siteforce:communityApp", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationMarkupSiteforceCommunityApp { get; set; }

        [JsonProperty("COMPONENT@markup://flowruntime:flowRuntimeForFlexiPage", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage { get; set; }

        [JsonProperty("COMPONENT@markup://force:outputField", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupForceOutputField { get; set; }

        [JsonProperty("COMPONENT@markup://forceCommunity:dashboard", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupForceCommunityDashboard { get; set; }

        [JsonProperty("COMPONENT@markup://forceCommunity:flowCommunity", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupForceCommunityFlowCommunity { get; set; }

        [JsonProperty("COMPONENT@markup://forceCommunity:globalNavigation", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupForceCommunityGlobalNavigation { get; set; }

        [JsonProperty("COMPONENT@markup://forceCommunity:recordDetail", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupForceCommunityRecordDetail { get; set; }

        [JsonProperty("COMPONENT@markup://forceCommunity:groupAnnouncement", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupForceCommunityGroupAnnouncement { get; set; }

        [JsonProperty("COMPONENT@markup://forceCommunity:richTextInline", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupForceCommunityRichTextInline { get; set; }

        [JsonProperty("COMPONENT@markup://instrumentation:o11yCoreCollector", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupInstrumentationO11YCoreCollector { get; set; }

        [JsonProperty("COMPONENT@markup://siteforce:regionLoaderWrapper", NullValueHandling = NullValueHandling.Ignore)]
        public string ComponentMarkupSiteforceRegionLoaderWrapper { get; set; }

        [JsonProperty("APPLICATION@markup://c:accountHighlightContainerApp", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationMarkupCAccountHighlightContainerApp { get; set; }
    }

}
