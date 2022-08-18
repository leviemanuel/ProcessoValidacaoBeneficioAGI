using HtmlAgilityPack;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ValidacaoBeneficioBot.JSONObjects;
using ValidacaoBeneficioBot.Objs;

namespace ValidacaoBeneficioBot
{
    public class Bot2
    {
        private string urlSite = "https://agibank.force.com/";
        private string urlAPI = "https://api.agibank.com.br/";
        private int timeout = 10000;

        private RestClient client;
        private Dictionary<string, string> keys = new Dictionary<string, string>();

        private string accept;
        private string userAgent;
        private string referer;
        private int cntURL = -1;
        private RestResponse response;
        AccountClientResponse objCliente;
        VfrmRemotingProviderImplResponse vfrmRemotingProviderImplResponse;
        JSONObjects.SimularRequest SimularRequestContext;

        AccountHighlightContainerApp accountHighlightContainerApp;
        AttendancesData attendancesData;
        ApexRemoteResponseItem apexRemoteRSPItem;
        string urlPadrao;


        public bool BotInicialize(ref string erro)
        {
            try
            {
                client = new RestClient(urlSite);

                var hdrs = new Dictionary<string, string>();

                UpdateKeys("Accept-Encoding", "gzip, deflate, br");
                UpdateKeys("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");

                response = DoGet(urlSite + "s/",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");

                response = DoGet(urlSite + "services/auth/sso/Agibank?startURL=%2Fs%2F",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _referer: "https://agibank.force.com/s/");

                var urlItens = response.ResponseUri.Query.Split('&');

                UpdateKeys("sessionDataKey", urlItens.FirstOrDefault(i => i.Contains("sessionDataKey=")).Split('=')[1]);
                UpdateKeys("scope", urlItens.FirstOrDefault(i => i.Contains("scope=")).Split('=')[1]);
                UpdateKeys("state", urlItens.FirstOrDefault(i => i.Contains("state=")).Split('=')[1]);
                UpdateKeys("tenantDomain", urlItens.FirstOrDefault(i => i.Contains("tenantDomain=")).Split('=')[1]);
                UpdateKeys("client_id", urlItens.FirstOrDefault(i => i.Contains("client_id=")).Split('=')[1]);
                UpdateKeys("relyingParty", urlItens.FirstOrDefault(i => i.Contains("relyingParty=")).Split('=')[1]);
                UpdateKeys("type", urlItens.FirstOrDefault(i => i.Contains("type=")).Split('=')[1]);
                UpdateKeys("sp", urlItens.FirstOrDefault(i => i.Contains("sp=")).Split('=')[1]);
                UpdateKeys("authenticators", urlItens.FirstOrDefault(i => i.Contains("authenticators=")).Split('=')[1]);


                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                response = DoGet(urlAPI + "logincontext?sessionDataKey=" + keys["sessionDataKey"] + "&" +
                                           "relyingParty=" + keys["relyingParty"] + "&" +
                                           "tenantDomain=" + keys["tenantDomain"] + "&" +
                                           "_=1654981842613",
                    headers: hdrs,
                    _accept: "*/*",
                    _referer: response.ResponseUri.OriginalString,
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.39");


                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public bool Login(string user, string pass, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "api.agibank.com.br");
                hdrs.Add("Origin", "https://api.agibank.com.br");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded");

                response = DoPost(urlAPI + "commonauth",
                    @"username=" + user + "&password=" + WebUtility.UrlEncode(pass) + "&sessionDataKey=" + keys["sessionDataKey"],
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.39",
                    _referer: urlAPI + @"authenticationendpoint/login.do?client_id=" + keys["client_id"] + "&" +
                                        "commonAuthCallerPath=%2Foauth2%2Fauthorize&" +
                                        "forceAuth=false&" +
                                        "passiveAuth=false&" +
                                        "redirect_uri=https%3A%2F%2Fagibank.force.com%2Fservices%2Fauthcallback%2FAgibank&" +
                                        "response_type=code&" +
                                        "scope=openid+refresh_token&" +
                                        "state=" + keys["state"] + @"&" +
                                        "tenantDomain=" + keys["tenantDomain"] + @"&" +
                                        "sessionDataKey=" + keys["sessionDataKey"] + @"&" +
                                        "relyingParty=" + keys["relyingParty"] + @"&" +
                                        "type=oidc&" +
                                        "sp=" + keys["sp"] + @"&" +
                                        "isSaaSApp=false&" +
                                        "authenticators=" + keys["authenticators"]
                    );

                var url = "";
                var auxURL = "<meta http-equiv=\"Refresh\" content=\"0; URL=https://agibank.force.com/secur/frontdoor.jsp?sid=";
                auxURL = response.Content.Substring(response.Content.IndexOf(auxURL) + auxURL.Length);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));

                url = "/secur/frontdoor.jsp?sid=" + WebUtility.HtmlDecode(auxURL);

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet(url,
                                 headers: hdrs,
                                 _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.39",
                                 _referer: response.ResponseUri.AbsoluteUri);

                response = DoGet(urlSite + "s/", headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _referer: WebUtility.HtmlDecode(auxURL));

                auxURL = response.Content.Split(new string[] { "var auraConfig = " }, StringSplitOptions.None)[1];

                var fwuid = auxURL.Substring(auxURL.IndexOf("fwuid\":\"") + 8);
                fwuid = fwuid.Substring(0, fwuid.IndexOf(("\"")));
                UpdateKeys("fwuid", fwuid);

                var auraToken = auxURL.Substring(auxURL.IndexOf("\"token\":\"") + 9);
                auraToken = auraToken.Substring(0, auraToken.IndexOf("\",\""));
                UpdateKeys("aura.token", auraToken);

                var ApplicationMarkupSiteforceCommunityApp = auxURL.Substring(auxURL.IndexOf("auraCmpDef?_au=") + 15);
                ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp.Substring(0, ApplicationMarkupSiteforceCommunityApp.IndexOf("&"));
                UpdateKeys("ApplicationMarkupSiteforceCommunityApp", ApplicationMarkupSiteforceCommunityApp);

                var lrmc = auxURL.Substring(auxURL.IndexOf("_lrmc=") + 6);
                lrmc = lrmc.Substring(0, lrmc.IndexOf("&"));
                UpdateKeys("lrmc", lrmc);

                auxURL = WebUtility.UrlDecode(response.Content.Split(new string[] { "var auraConfig = " }, StringSplitOptions.None)[0]);

                var pageId = auxURL.Substring(auxURL.IndexOf("pageId") + 9);
                pageId = pageId.Substring(0, pageId.IndexOf("\""));
                UpdateKeys("pageId", pageId);

                #region POSTS CAPTURADOS NO RESPONSE

                var urls = response.Content.Split(new string[] { "src=\"" }, StringSplitOptions.None);

                foreach (var urlGet in urls.OrderBy(u => u.Length))
                {
                    if (urlGet.Substring(0, 10) == "/s/sfsites")
                        //if (urlGet.Contains(pageId))
                        response = DoGet(urlGet.Substring(0, urlGet.IndexOf("<") - 2),
                            headers: hdrs,
                            _accept: "*/*",
                            _referer: "https://agibank.force.com/s/");
                }
                #endregion

                var userId = response.Content.Substring(response.Content.IndexOf("$SObjectType\",\"values\":") + 23);
                userId = userId.Substring(0, userId.IndexOf("}") + 2);
                dynamic objUsuario = JsonConvert.DeserializeObject(userId);
                userId = objUsuario.CurrentUser.Id;
                UpdateKeys("UserId", userId);

                var attrViewId = response.Content.Substring(response.Content.IndexOf("0I36e000002Vlhx\",\"hasCmpTargets\":true,\"seo_description\":\"\",\"is_public\":\"false\",\"audience_name\":\"Default\",\"id\":\"") + 111);
                attrViewId = attrViewId.Substring(0, attrViewId.IndexOf("\""));

                var paramViewId = response.Content.Substring(response.Content.IndexOf("dev_name\":\"Home\",\"cache_minutes\":\"30\",\"themeLayoutType\":\"Inner\",\"route_uddid\":\"") + 80);
                paramViewId = paramViewId.Substring(paramViewId.IndexOf("view_uuid") + 12);
                paramViewId = paramViewId.Substring(0, paramViewId.IndexOf("\""));
                UpdateKeys("view_uuid", paramViewId);

                var BPOid = response.Content.Substring(response.Content.IndexOf("\"is_public\":\"false\",\"audience_name\":\"BPO\",\"id\":\"") + 48);
                BPOid = BPOid.Substring(0, BPOid.IndexOf("\""));
                UpdateKeys("BPOId", BPOid);

                var brandingSetId = response.Content.Substring(response.Content.IndexOf("brandingSetId") + 16);
                brandingSetId = brandingSetId.Substring(0, brandingSetId.IndexOf("\""));

                MessageRequest objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "2;a",
                    Descriptor = "serviceComponent://ui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableComponentLoaderController/ACTION$getPageComponent",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Attributes = new JSONObjects.Attributes()
                        {
                            ViewId = new Guid(attrViewId),
                            RouteType = "home",
                            ThemeLayoutType = "Inner",
                            Params = new JSONObjects.AttributesParams()
                            {
                                Viewid = new Guid(paramViewId),
                                ViewUddid = "",
                                EntityName = "",
                                AudienceName = "",
                                PicassoId = "",
                                RouteId = ""
                            },
                            HasAttrVaringCmps = false,
                            PageLoadType = "STANDARD_PAGE_CONTENT",
                            IncludeLayout = true
                        },
                        PublishedChangelistNum = 25,
                        BrandingSetId = new Guid(brandingSetId),
                    }
                });

                JSONObjects.AuraContextRequest context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp
                    }
                };

                var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                    "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                    "&aura.pageURI=%2Fs%2F" +
                    "&aura.token=" + WebUtility.UrlEncode(auraToken);

                hdrs["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                #region POST 01

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "2;a",
                    Descriptor = "serviceComponent://ui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableComponentLoaderController/ACTION$getAudienceTargetedPageComponent",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Attributes = new JSONObjects.Attributes()
                        {
                            ViewId = new Guid(attrViewId),
                            RouteType = "home",
                            ThemeLayoutType = "Inner",
                            Params = new JSONObjects.AttributesParams()
                            {
                                Viewid = new Guid(paramViewId),
                                ViewUddid = "",
                                EntityName = "",
                                AudienceName = "",
                                PicassoId = "",
                                RouteId = ""
                            },
                            HasAttrVaringCmps = false,
                            PageLoadType = "AUDIENCE_TARGETED_PAGE_CONTENT"
                        },
                        PublishedChangelistNum = 25,
                        BrandingSetId = new Guid(brandingSetId)
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-comm-runtime-components-aura-components-siteforce-controller.PubliclyCacheableComponentLoader.getAudienceTargetedPageComponent=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 02

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "30;a",
                    Descriptor = "serviceComponent://ui.chatter.components.messages.MessagesController/ACTION$getMessagingPermAndPref",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { },
                    Storable = true
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "41;a",
                    Descriptor = "serviceComponent://ui.self.service.components.profileMenu.ProfileMenuController/ACTION$getProfileMenuResponse",
                    CallingDescriptor = "markup://selfService:profileMenuAPI",
                    Params = new JSONObjects.ActionParams() { },
                    Version = "55.0"
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "85;a",
                    Descriptor = "serviceComponent://ui.force.components.controllers.hostConfig.HostConfigController/ACTION$getConfigData",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { },
                    Storable = true
                });


                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-chatter-components-messages.Messages.getMessagingPermAndPref=1&ui-force-components-controllers-hostConfig.HostConfig.getConfigData=1&ui-self-service-components-profileMenu.ProfileMenu.getProfileMenuResponse=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 03

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "78;a",
                    Descriptor = "serviceComponent://ui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableAttributeLoaderController/ACTION$getComponentAttributes",
                    CallingDescriptor = "markup://siteforce:pageLoader",
                    Params = new JSONObjects.ActionParams()
                    {
                        ViewOrThemeLayoutId = new Guid("4d92a357-2ba2-417f-93ee-8f53cdb55dd5"),
                        PublishedChangelistNum = 25,
                        AudienceKey = "11FxOYiYfpMxmANj4kGJzg"
                    },
                    Version = "55.0",
                    Storable = true
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-comm-runtime-components-aura-components-siteforce-controller.PubliclyCacheableAttributeLoader.getComponentAttributes=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 04

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "143;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.richText.RichTextController/ACTION$getParsedRichTextValue",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        HTML = "<p><img class=\"sfdcCbImage\" src=\"{!contentAsset.buscar_proposta.1}\" /></p>"
                    },
                    Version = "55.0",
                    Storable = true
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "111;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardComponentController/ACTION$isFeedEnabled",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        DashboardId = "01Z6e000001DeZoEAK"
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "112;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardComponentController/ACTION$getAdditionalParameters",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "144;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.richText.RichTextController/ACTION$getParsedRichTextValue",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        HTML = "<p style=\"text-align: center;\"><img class=\"sfdcCbImage\" src=\"{!contentAsset.footer_agi_expanded.1}\" /></p>"
                    },
                    Version = "55.0",
                    Storable = true
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "121;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController/ACTION$canViewFlow",
                    CallingDescriptor = "markup://forceCommunity:flowCommunity",
                    Params = new JSONObjects.ActionParams()
                    {
                        FlowName = "OrderProductSearchFlow"
                    },
                    Version = "55.0"
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "145;a",
                    Descriptor = "serviceComponent://ui.chatter.components.aura.components.forceChatter.groups.GroupAnnouncementController/ACTION$getAnnouncement",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        GroupId = "0F96e000000fysaCAA"
                    },
                    Storable = true
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "146;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.richText.RichTextController/ACTION$getParsedRichTextValue",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        HTML = "<p><b style=\"color: rgb(68, 68, 68); font-size: 36px;\">Que bom te ver por aqui,</b><b style=\"color: rgb(0, 0, 0); font-size: 36px;\"> </b><b style=\"color: rgb(0, 102, 204); font-size: 36px;\">Caio</b><b style=\"font-size: 36px;\"> :)</b></p><p>&nbsp;</p>"
                    },
                    Version = "55.0",
                    Storable = true
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "147;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.richText.RichTextController/ACTION$getParsedRichTextValue",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        HTML = "<p><img class=\"sfdcCbImage\" src=\"{!contentAsset.digitacao.1}\" style=\"width: 568.641px; height: 78.4219px;\" /></p>"
                    },
                    Version = "55.0",
                    Storable = true
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "135;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController/ACTION$canViewFlow",
                    CallingDescriptor = "markup://forceCommunity:flowCommunity",
                    Params = new JSONObjects.ActionParams()
                    {
                        FlowName = "NewAccountSimulationFlow"
                    },
                    Version = "55.0"
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-analytics-dashboard-components-lightning.DashboardComponent.getAdditionalParameters=1&ui-analytics-dashboard-components-lightning.DashboardComponent.isFeedEnabled=1&ui-chatter-components-aura-components-forceChatter-groups.GroupAnnouncement.getAnnouncement=1&ui-communities-components-aura-components-forceCommunity-flowCommunity.FlowCommunity.canViewFlow=2&ui-communities-components-aura-components-forceCommunity-richText.RichText.getParsedRichTextValue=4",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 05

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "148;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardComponentController/ACTION$getSitePathPrefix",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-analytics-dashboard-components-lightning.DashboardComponent.getSitePathPrefix=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 06

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "171;a",
                    Descriptor = "aura://ComponentController/ACTION$getComponent",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Name = "markup://forceCommunity:globalNavigation",
                        Attributes = new JSONObjects.Attributes()
                        {
                            NavigationMenuEditorRefresh = "Default_Navigation1",
                            HideHomeText = false,
                            HideAppLauncher = false
                        }
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.Component.getComponent=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 07 - GET
                hdrs.Remove("X-SFDC-Page-Scope-Id");
                hdrs.Remove("Content-Type");
                hdrs.Remove("Origin");

                response = DoGet("/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK" +
                           "&displayMode=view" +
                           "&networkId=0DB6e000000k9hL" +
                           "&userId=" + keys["UserId"],
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 08
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                hdrs.Add("Origin", "https://agibank.force.com");

                objRequest = new MessageRequest();

                List<string> menuItemTypeSkip = new List<string>();
                menuItemTypeSkip.Add("SystemLink");
                menuItemTypeSkip.Add("Event");

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "173;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.navigationMenu.NavigationMenuDataProviderController/ACTION$getNavigationMenu",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        NavigationLinkSetIdOrName = "Default_Navigation1",
                        IncludeImageUrl = false,
                        AddHomeMenuItem = true,
                        MenuItemTypesToSkip = menuItemTypeSkip,
                        MasterLabel = "Default Navigation"
                    },
                    Storable = true
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-communities-components-aura-components-forceCommunity-navigationMenu.NavigationMenuDataProvider.getNavigationMenu=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 09

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "193;a",
                    Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$runInterview",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        FlowDevName = "OrderProductSearchFlow",
                        Arguments = "",
                        EnableTrace = false,
                        EnableRollbackMode = false,
                        DebugAsUserId = ""
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "213;a",
                    Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$runInterview",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.NewAccountSimulationFlow()
                    {
                        FlowDevName = "NewAccountSimulationFlow",
                        EnableTrace = false,
                        EnableRollbackMode = false,
                        DebugAsUserId = ""
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);


                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-interaction-runtime-components-controllers.FlowRuntime.runInterview=2",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                var serializedEncodedState = response.Content.Substring(response.Content.LastIndexOf("serializedEncodedState") + 25);
                serializedEncodedState = serializedEncodedState.Substring(0, serializedEncodedState.IndexOf("\""));

                UpdateKeys("serializedEncodedState", serializedEncodedState);

                #endregion

                #region POST 10 GET JSON
                hdrs.Remove("X-SFDC-Page-Scope-Id");
                hdrs.Remove("Content-Type");
                hdrs.Remove("Origin");

                response = DoGet("//_nc_external/system/security/session/SessionTimeServlet?buster=1655993430566",
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");
                #endregion

                #region POST 11

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "249;a",
                    Descriptor = "serviceComponent://ui.identity.components.sessiontimeoutwarn.SessionTimeoutWarnController/ACTION$getSessionTimeoutConfig",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "259;a",
                    Descriptor = "serviceComponent://ui.search.components.forcesearch.sgdp.PermsAndPrefsCacheController/ACTION$getPermsAndPrefs",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                hdrs["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8";

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-identity-components-sessiontimeoutwarn.SessionTimeoutWarn.getSessionTimeoutConfig=1&ui-search-components-forcesearch-sgdp.PermsAndPrefsCache.getPermsAndPrefs=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 12

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "3;a",
                    Descriptor = "serviceComponent://ui.force.components.controllers.theme.ThemeCssVarLoaderController/ACTION$getThemeVariables",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { },
                    Storable = true
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "5;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$medianFunctionSupported",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "6;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$getActions",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        DashboardId = "01Z6e000001DeZoEAK"
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "7;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$describe",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        DashboardId = "01Z6e000001DeZoEAK",
                        NetworkId = "0DB6e000000k9hL",
                        RequestOrigin = ""
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK") +
                   "&aura.view=" +
                   "&networkId=0DB6e000000k9hL" +
                   "&userId=" + keys["UserId"] +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/aura?r=0&ui-analytics-dashboard-components-lightning.DashboardApp.describe=1&ui-analytics-dashboard-components-lightning.DashboardApp.getActions=1&ui-analytics-dashboard-components-lightning.DashboardApp.medianFunctionSupported=1&ui-force-components-controllers-theme.ThemeCssVarLoader.getThemeVariables=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 13

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "8;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$showDynamicGaugeChartControls",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK") +
                   "&aura.view=" +
                   "&networkId=0DB6e000000k9hL" +
                   "&userId=" + keys["UserId"] +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/aura?r=1&ui-analytics-dashboard-components-lightning.DashboardApp.showDynamicGaugeChartControls=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 14

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "9;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$getStatus",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        DashboardId = "01Z6e000001DeZoEAK",
                        NetworkId = "0DB6e000000k9hL"
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK") +
                   "&aura.view=" +
                   "&networkId=0DB6e000000k9hL" +
                   "&userId=" + keys["UserId"] +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/aura?r=2&ui-analytics-dashboard-components-lightning.DashboardApp.getStatus=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST 15

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "10;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$getActions",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { DashboardId = "01Z6e000001DeZoEAK" }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = fwuid,
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = ApplicationMarkupSiteforceCommunityApp,
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"//,
                                                                                                  //ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK") +
                   "&aura.view=" +
                   "&networkId=0DB6e000000k9hL" +
                   "&userId=" + keys["UserId"] +
                   "&aura.token=" + WebUtility.UrlEncode(auraToken);

                response = DoPost("/aura?r=3&ui-analytics-dashboard-components-lightning.DashboardApp.getActions=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public bool BuscaCPF(string cpf, string nome, string sobrenome, ref bool flClienteNovo, ref string erro, ref string erroSite)
        {
            try
            {
                flClienteNovo = false;

                var hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                #region POST 00

                var objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "193;a",
                    Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$runInterview",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        FlowDevName = "OrderProductSearchFlow",
                        Arguments = "",
                        EnableTrace = false,
                        EnableRollbackMode = false,
                        DebugAsUserId = ""
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "213;a",
                    Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$runInterview",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.NewAccountSimulationFlow()
                    {
                        FlowDevName = "NewAccountSimulationFlow",
                        EnableTrace = false,
                        EnableRollbackMode = false,
                        DebugAsUserId = ""
                    }
                });

                var context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA"
                    }
                };

                var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);


                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-interaction-runtime-components-controllers.FlowRuntime.runInterview=2",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                var serializedEncodedState = response.Content.Substring(response.Content.LastIndexOf("serializedEncodedState") + 25);
                serializedEncodedState = serializedEncodedState.Substring(0, serializedEncodedState.IndexOf("\""));

                UpdateKeys("serializedEncodedState", serializedEncodedState);

                #endregion

                #region POST 01 
                var fields = new List<Field>();

                fields.Add(new Field() { FieldSon = "AccountDocument", Value = cpf.PadLeft(11, '0'), IsVisible = true });

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "278;a",
                    Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$executeAction",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Action = "NEXT",
                        Interview = keys["serializedEncodedState"],
                        Fields = fields,
                        UIElementVisited = true,
                        EnableTrace = false,
                        LCErrors = null
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                        ComponentMarkupForceOutputField = "PAfMGVlv6w0Av2uZ3rs0WQ",
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest).Replace("}}]}", ",\"lcErrors\":{}}}]}")) +
                  "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                  "&aura.pageURI=%2Fs%2F" +
                  "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");

                #region CADASTRA CLIENTE: Este é um cliente novo! Informe os dados abaixo para continuar.
                if (response.Content.Contains("Este é um cliente novo! Informe os dados abaixo para continuar."))
                {
                    //throw new Exception("CLIENTE NOVO - PULAR");

                    flClienteNovo = true;

                    serializedEncodedState = response.Content.Substring(response.Content.LastIndexOf("serializedEncodedState") + 25);
                    serializedEncodedState = serializedEncodedState.Substring(0, serializedEncodedState.IndexOf("\""));

                    UpdateKeys("serializedEncodedState", serializedEncodedState);

                    hdrs.Add("X-SFDC-Request-Id", "51205790000e4b9f0c");

                    fields = new List<Field>();
                    fields.Add(new Field() { FieldSon = "AccountFirstName", Value = nome, IsVisible = true });
                    fields.Add(new Field() { FieldSon = "AccountLastName", Value = sobrenome, IsVisible = true });

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "313;a",
                        Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$executeAction",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Action = "NEXT",
                            Interview = keys["serializedEncodedState"],
                            Fields = fields,
                            UIElementVisited = true,
                            EnableTrace = false,
                            LCErrors = null
                        }
                    });

                    context = new JSONObjects.AuraContextRequest()
                    {
                        Mode = "PROD",
                        Fwuid = keys["fwuid"],
                        App = "siteforce:communityApp",
                        Dn = null,
                        Globals = null,
                        Uad = false,
                        Loaded = new JSONObjects.Loaded()
                        {
                            ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                            ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                            ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                            ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                            ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                            ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                            ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                            ComponentMarkupForceCommunityRecordDetail = "kXfXVV64BLdT0CWedtcfBw",
                            ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                        }
                    };

                    //CADASTRA CLIENTE
                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest).Replace("}}]}", ",\"lcErrors\":{}}}]}")) +
                    "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                    "&aura.pageURI=%2Fs%2F" +
                    "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/",
                               _accept: "*/*",
                               _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");

                    hdrs.Remove("X-SFDC-Request-Id");
                    return true;
                }
                #endregion

                var aux = response.Content.Substring(response.Content.IndexOf("\":\"NewAccountSimulationFlow\",\"value\":\"") + 38);
                aux = aux.Substring(0, aux.IndexOf("\""));
                UpdateKeys("NewAccountSimulationFlow", aux);
                #endregion

                #region POST 02
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "300;a",
                    Descriptor = "serviceComponent://ui.force.components.controllers.recordGlobalValueProvider.RecordGvpController/ACTION$getRecord",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordDescriptor = keys["NewAccountSimulationFlow"] + ".undefined.null.null.null.Name.VIEW.false.null.null.null"
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/detail") +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                aux = response.Content.Substring(response.Content.IndexOf(",\"records\":") + 11);
                aux = aux.Substring(aux.IndexOf(":{\"Account\"") + 1);
                aux = aux.Substring(0, aux.IndexOf(",\"recordTemplates\":") - 1);
                objCliente = JsonConvert.DeserializeObject<AccountClientResponse>(aux);

                return true;
            }
            catch (Exception ex)
            {
                erroSite = ex.Message;
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public bool ClicaSimulacao(ref string erro, ref string erroSite)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                #region POST 01

                var objRequest = new MessageRequest();

                //objRequest.Actions.Add(new JSONObjects.Action()
                //{
                //    Id = "1131;a",
                //    Descriptor = "aura://ApexActionController/ACTION$execute",
                //    CallingDescriptor = "UNKNOWN",
                //    Params = new JSONObjects.ActionParams()
                //    {
                //        Namespace = "",
                //        Classname = "OriginationController",
                //        Method = "getCurrent",
                //        Params = new JSONObjects.ActionParams()
                //        {
                //            AccountId = keys["NewAccountSimulationFlow"]
                //        },
                //        Cacheable = false,
                //        IsContinuation = false
                //    }
                //});

                //objRequest.Actions.Add(new JSONObjects.Action()
                //{
                //    Id = "1132;a",
                //    Descriptor = "aura://ApexActionController/ACTION$execute",
                //    CallingDescriptor = "UNKNOWN",
                //    Params = new JSONObjects.ActionParams()
                //    {
                //        Namespace = "",
                //        Classname = "TaskController",
                //        Method = "getTaskStepValues",
                //        Cacheable = false,
                //        IsContinuation = false
                //    }
                //});

                //var context = new JSONObjects.AuraContextRequest()
                //{
                //    Mode = "PROD",
                //    Fwuid = keys["fwuid"],
                //    App = "siteforce:communityApp",
                //    Dn = null,
                //    Globals = null,
                //    Uad = false,
                //    Loaded = new JSONObjects.Loaded()
                //    {
                //        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                //        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                //        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                //        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                //        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                //        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                //        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                //        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                //    }
                //};

                //var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                //   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                //   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=51b55") +
                //   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                //response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=2",
                //           strPost,
                //           headers: hdrs,
                //           _referer: "https://agibank.force.com/s/",
                //           _accept: "*/*",
                //           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 02

                objRequest = new MessageRequest();

                //objRequest.Actions.Add(new JSONObjects.Action()
                //{
                //    Id = "1133;a",
                //    Descriptor = "aura://ApexActionController/ACTION$execute",
                //    CallingDescriptor = "UNKNOWN",
                //    Params = new JSONObjects.ActionParams()
                //    {
                //        Namespace = "",
                //        Classname = "TaskController",
                //        Method = "getAccountTasksSimulationDeferred",
                //        Params = new JSONObjects.ActionParams()
                //        {
                //            AccountId = keys["NewAccountSimulationFlow"]
                //        },
                //        Cacheable = false,
                //        IsContinuation = false
                //    }
                //});

                //var context = new JSONObjects.AuraContextRequest()
                //{
                //    Mode = "PROD",
                //    Fwuid = keys["fwuid"],
                //    App = "siteforce:communityApp",
                //    Dn = null,
                //    Globals = null,
                //    Uad = false,
                //    Loaded = new JSONObjects.Loaded()
                //    {
                //        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                //        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                //        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                //        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                //        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                //        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                //        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                //        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                //    }
                //};

                //var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                //   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                //   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=51b55") +
                //   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                //response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                //           strPost,
                //           headers: hdrs,
                //           _referer: "https://agibank.force.com/s/",
                //           _accept: "*/*",
                //           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erroSite = ex.Message;
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public bool ClicaFonteINSS(ref string erro, ref string erroSite)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                #region POST 01
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                MessageRequest objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1141;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OriginationController",
                        Method = "startNew",
                        Params = new JSONObjects.ActionParams()
                        {
                            Command = new Command()
                            {
                                AccountId = keys["NewAccountSimulationFlow"],
                                AttendanceType = "Presential",
                                PaymentSourceType = "INSS Source"
                            }
                        },
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                JSONObjects.AuraContextRequest context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                    }
                };

                var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                    "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                    "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=51b55") +
                    "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");


                dynamic postResponse = JsonConvert.DeserializeObject(response.Content);

                // UpdateKeys("originationSrcUrl", postResponse.actions[0].returnValue.returnValue.content.OriginationSrcUrl);

                string attendanceNumber = postResponse.actions[0].returnValue.returnValue.content.OriginationSrcUrl;
                attendanceNumber = attendanceNumber.Substring(attendanceNumber.IndexOf("=") + 1);
                UpdateKeys("attendanceNumber", attendanceNumber);

                string taskId = postResponse.actions[0].returnValue.returnValue.content.TaskId;
                UpdateKeys("taskId", taskId);

                urlPadrao = postResponse.actions[0].returnValue.returnValue.content.OriginationSrcUrl;
                #endregion

                #region POST 02

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1142;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "DomainUtils",
                        Method = "isCommunityDomain",
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = keys["NewAccountSimulationFlow"]
                        },
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1132;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "TaskController",
                        Method = "getTaskStepValues",
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=51b55") +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 03

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1142;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "DomainUtils",
                        Method = "isCommunityDomain",
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = keys["NewAccountSimulationFlow"]
                        },
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1132;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "TaskController",
                        Method = "getTaskStepValues",
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":false}", ",\"dn\":[],\"globals\":{},\"uad\":false}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=51b55") +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region GET 04

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet("/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                                 headers: hdrs,
                                 _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "?tabset-11f0d=51b55");

                var auxURL = response.Content.Substring(response.Content.IndexOf("post\" action=\"/OriginationPage?id=") + 34);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("OriginationPageId", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("csrf\":\"") + 7);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("csrf", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("', 'network', '") + 15);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("'"));
                UpdateKeys("network", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("$VFRM.RemotingProviderImpl(") + 27);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("apexremote\"}));") + 12);
                vfrmRemotingProviderImplResponse = JsonConvert.DeserializeObject<VfrmRemotingProviderImplResponse>(auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewState\" name=\"com.salesforce.visualforce.ViewState\" value=\"") + 93);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewState = auxURL;
                UpdateKeys("auxViewState", auxViewState);

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateVersion\" name=\"com.salesforce.visualforce.ViewStateVersion\" value=\"") + 107);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateVersion = auxURL;
                UpdateKeys("auxViewStateVersion", auxViewStateVersion);

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateMAC\" name=\"com.salesforce.visualforce.ViewStateMAC\" value=\"") + 99);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateMAC = auxURL;
                UpdateKeys("auxViewStateMAC", auxViewStateMAC);

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateCSRF\" name=\"com.salesforce.visualforce.ViewStateCSRF\" value=\"") + 101);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateCSRF = auxURL;
                UpdateKeys("auxViewStateCSRF", auxViewStateCSRF);
                #endregion

                #region POST 05
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                hdrs.Add("Connection", "keep-alive");
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                strPost = "AJAXREQUEST=_viewRoot" +
                    "&thepage%3Aform=thepage%3Aform" +
                    "&com.salesforce.visualforce.ViewState=" + WebUtility.UrlEncode(auxViewState) +
                    "&com.salesforce.visualforce.ViewStateVersion=" + WebUtility.UrlEncode(auxViewStateVersion) +
                    "&com.salesforce.visualforce.ViewStateMAC=" + WebUtility.UrlEncode(auxViewStateMAC) +
                    "&com.salesforce.visualforce.ViewStateCSRF=" + WebUtility.UrlEncode(auxViewStateCSRF) +
                    "&newUrl=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D" + keys["attendanceNumber"] +
                    "&thepage%3Aform%3Aj_id37=thepage%3Aform%3Aj_id37" +
                    "&";

                //1º
                response = DoPost("/OriginationPage?id=" + keys["NewAccountSimulationFlow"],
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");


                auxURL = response.Content.Substring(response.Content.IndexOf("post\" action=\"/OriginationPage?id=") + 34);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("OriginationPageId", auxURL);

                //auxURL = response.Content.Substring(response.Content.IndexOf("$VFRM.RemotingProviderImpl(") + 27);
                //auxURL = auxURL.Substring(0, auxURL.IndexOf("apexremote\"}));") + 12);
                //vfrmRemotingProviderImplResponse = JsonConvert.DeserializeObject<VfrmRemotingProviderImplResponse>(auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewState\" name=\"com.salesforce.visualforce.ViewState\" value=\"") + 93);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                auxViewState = auxURL;
                keys["auxViewState"] = auxViewState;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateVersion\" name=\"com.salesforce.visualforce.ViewStateVersion\" value=\"") + 107);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                auxViewStateVersion = auxURL;
                keys["auxViewStateVersion"] = auxViewStateVersion;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateMAC\" name=\"com.salesforce.visualforce.ViewStateMAC\" value=\"") + 99);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                auxViewStateMAC = auxURL;
                keys["auxViewStateMAC"] = auxViewStateMAC;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateCSRF\" name=\"com.salesforce.visualforce.ViewStateCSRF\" value=\"") + 101);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                auxViewStateCSRF = auxURL;
                keys["auxViewStateCSRF"] = auxViewStateCSRF;
                #endregion


                #region GET 06

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet("/c/accountHighlightContainerApp.app?aura.format=JSON&aura.formatAdapter=LIGHTNING_OUT",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(auxURL) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true");

                //OU USAR DYNAMIC
                accountHighlightContainerApp = JsonConvert.DeserializeObject<AccountHighlightContainerApp>(response.Content);
                #endregion

                #region GET 07

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-product-sale-originacao.agibank-prd.in");

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/?attendanceNumber=" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region GET 08

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", "0");
                hdrs.Add("user-id", "0");

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "?state-safe=true",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                #endregion

                #region GET 09

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region POST 10
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "2;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountController",
                        Method = "getHighlight",
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = keys["NewAccountSimulationFlow"]
                        },
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "3;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "NewCaseButtonController",
                        Method = "isVisible",
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "4;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountOpportunitiesController",
                        Method = "isVisible",
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com//aura?r=0&aura.ApexAction.execute=3 ",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 11
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "5;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = keys["NewAccountSimulationFlow"]
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("//aura?r=2&aura.RecordUi.getRecordWithFields=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 12
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "6;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = keys["NewAccountSimulationFlow"]
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                strPost = strPost.Replace("%7D%7D%5D%7D", WebUtility.UrlEncode(",\"fields\":[\"Account.Rating\"]") + "%7D%7D%5D%7D");

                response = DoPost("//aura?r=2&aura.RecordUi.getRecordWithFields=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 13
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "7;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "ContactController",
                        Method = "getByAccountId",
                        Params = new ActionParams()
                        {
                            AccountId = keys["NewAccountSimulationFlow"]
                        },
                        Cacheable = true,
                        IsContinuation = false
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("//aura?r=3&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 14
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "8;a",
                    Descriptor = "aura://RecordUiController/ACTION$getObjectInfo",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        ObjectApiName = "OperationalRecord__c"
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("//aura?r=4&aura.RecordUi.getObjectInfo=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 15
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "9;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OperationalRecordController",
                        Method = "validateUserPermissionButtonOperationalRecord",
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("//aura?r=5&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 16
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "10;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OperationalRecordController",
                        Method = "findAssetByAccountIdAndGroup",
                        Params = new ActionParams()
                        {
                            AccountId = keys["NewAccountSimulationFlow"]
                        },
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("//aura?r=6&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 17
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "11;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AlertController",
                        Method = "getAlerts",
                        Params = new ActionParams()
                        {
                            AccountId = keys["NewAccountSimulationFlow"]
                        },
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("//aura?r=7&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST 18
                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "12;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountController",
                        Method = "createTask",
                        Params = new ActionParams()
                        {
                            AccountId = keys["NewAccountSimulationFlow"]
                        },
                        Cacheable = false,
                        IsContinuation = false
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "13;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = keys["NewAccountSimulationFlow"]
                    }
                });

                context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "c:accountHighlightContainerApp",
                    Dn = null,
                    Globals = null,
                    Uad = true,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp
                    }
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest).Replace("}}]}", ",\"fields\":[\"Account.RegistrationStatus__c\"],\"optionalFields\":[\"Account.Rating\"]}}]}")) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace(",\"uad\":true}", ",\"dn\":[],\"globals\":{},\"uad\":true}")) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + keys["NewAccountSimulationFlow"] +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("//aura?r=8&aura.ApexAction.execute=1&aura.RecordUi.getRecordWithFields=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region GET 19

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region GET 19

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region GET 20

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erroSite = ex.Message;
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public bool ContinuarSemConsulta(ref string erro, ref string erroSite)
        {
            try
            {
                #region PATCH 01
                var retornoPATCH = "";

                var hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                retornoPATCH = DoPatch("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                           "{\"benefitChosenAuthorization\":\"NO_AUTHORIZATION\",\"payerSource\":{\"name\":\"INSS\",\"identifier\":\"INSS\"}}",
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");

                #endregion

                #region GET 02

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region GET 03

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", "0");
                hdrs.Add("user-id", "0");

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "?state-safe=true",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region GET 04

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "/available-offers",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region PUT 05

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                CustomerOffersRequest objRequestPut = new CustomerOffersRequest();

                objRequestPut.Products = new List<Product>();

                objRequestPut.Products.Add(new Product()
                {
                    Id = "USER_REGISTRATION",
                    Title = "Usuário de canais digitais",
                    Subtitle = "Usuário de acesso aos canais digitais Agibank.",
                    ProductOfferId = "22745e6cdffc49b891dd4c66f775f847",
                    Version = 1,
                    Income = new Income() { Benefit = null },
                    AutoSelected = true,
                    Hidden = true,
                    Rules = new List<Rule>(),
                    Warnings = null,
                    Simulations = null,
                    PaymentInformation = null
                });

                objRequestPut.Products[0].Rules.Add(
                    new Rule()
                    {
                        Id = "PoliticaUsuarioJaPossuiCadastro",
                        Description = "É possível que o serviço de consulta ao usuário no LDAP esteja indisponível.",
                        Status = "APPROVED"
                    });

                objRequestPut.Products.Add(new Product()
                {
                    Id = "COMPLETE_OFFER",
                    Title = "Oferta GEV 1.0",
                    Subtitle = "Conta corrente + Cartão de crédito + produtos Agibank.",
                    Income = new Income() { Benefit = null },
                    AutoSelected = false,
                    Hidden = false,
                    Checked = true
                });

                JSONObjects.AuraContextRequest context = new JSONObjects.AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = keys["fwuid"],
                    App = "siteforce:communityApp",
                    Dn = null,
                    Globals = null,
                    Uad = false,
                    Loaded = new JSONObjects.Loaded()
                    {
                        ApplicationMarkupSiteforceCommunityApp = keys["ApplicationMarkupSiteforceCommunityApp"],
                        ComponentMarkupInstrumentationO11YCoreCollector = "nhzmTezpWWIR9I1zHeyEWA",
                        ComponentMarkupForceCommunityGlobalNavigation = "TjrRcSemg-A49HiA0z5z_A",
                        ComponentMarkupForceCommunityDashboard = "GEUKm0j8OnKj91vFq93__Q",
                        ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "ZeJEBFRwO51QEsAJrDkSOg",
                        ComponentMarkupForceCommunityFlowCommunity = "aeRT_DF-8PdCr8xrTilWtw",
                        ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg",
                        ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q"
                    }
                };

                var strPost = JsonConvert.SerializeObject(objRequestPut);
                strPost = strPost.Replace("\"person\":null,", "\"person\":{},");
                strPost = strPost.Replace("\"income\":{},", "\"income\":{\"benefit\":{}},");
                strPost = strPost.Replace("\"warnings\":null,", "\"warnings\":[],");
                strPost = strPost.Replace("\"simulations\":null,", "\"simulations\":[],");
                strPost = strPost.Replace("\"paymentInformation\":null", "\"paymentInformation\":[]");
                strPost = strPost.Replace("\"warnings\":[],\"simulations\":[],\"paymentInformation\":[],\"checked\":true", "\"checked\":true");

                var responsePut = DoPut("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "/customers/",//+ attendancesData.Customer.IdentificationDocument.Number + "/offers?document-type=CPF",
                           strPost,
                           headers: hdrs,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.62");
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erroSite = ex.Message;
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public bool SelecionaOfertaGEV(DataClientPutRequest dataClientePut, DateTime DtPadrao, ref string erro, ref string erroSite)
        {
            try
            {
                dataClientePut.ExternalId = keys["attendanceNumber"];
                dataClientePut.Consultant.TaxId = attendancesData.UserId;
                dataClientePut.ActualStoreId = keys["attendanceNumber"];

                var hdrs = new Dictionary<string, string>();

                #region GET 02
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion



                #region POST 2.5

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Host", "agibank.force.com");

                var data = new List<string>();
                data.Add(keys["taskId"]);
                data.Add("Simulator");

                Ms msAux = vfrmRemotingProviderImplResponse.Actions.OriginationTabController.Ms.Where(ms => ms.Name == "changeStep").FirstOrDefault();

                var apexRemoteRQST = new ApexRemoteRequest()
                {
                    Action = "OriginationTabController",
                    Method = "changeStep",
                    Data = data,
                    Type = "rpc",
                    Tid = msAux.Len,
                    Ctx = new Ctx()
                    {
                        Csrf = msAux.Csrf,
                        Vid = vfrmRemotingProviderImplResponse.Vf.Vid,
                        Ns = msAux.Ns,
                        Ver = msAux.Ver
                    }
                };

                response = DoPost("/apexremote",
                                 JsonConvert.SerializeObject(apexRemoteRQST),
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/apex/OriginationPage?url=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%" + keys["attendanceNumber"] +
                                 "&taskId=" + keys["taskId"] + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true");

                apexRemoteRSPItem = JsonConvert.DeserializeObject<ApexRemoteResponseItem>(response.Content.Substring(1, response.Content.Length - 2));

                var auxURL = response.Content.Substring(response.Content.IndexOf("userId=") + 7);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("&"));
                UpdateKeys("userId", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("post\" action=\"/OriginationPage?id=") + 34);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("OriginationPageId", auxURL);
                #endregion


                #region POST 03
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                //hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                var strPost = "AJAXREQUEST=_viewRoot" +
                    "&thepage%3Aform=thepage%3Aform" +
                    "&com.salesforce.visualforce.ViewState=" + WebUtility.UrlEncode(keys["auxViewState"]) +
                    "&com.salesforce.visualforce.ViewStateVersion=" + WebUtility.UrlEncode(keys["auxViewStateVersion"]) +
                    "&com.salesforce.visualforce.ViewStateMAC=" + WebUtility.UrlEncode(keys["auxViewStateMAC"]) +
                    "&com.salesforce.visualforce.ViewStateCSRF=" + WebUtility.UrlEncode(keys["auxViewStateCSRF"]) +
                    "&newUrl=" + WebUtility.UrlEncode(apexRemoteRSPItem.Result.Content.SimulatorSrcUrl.ToString()) +
                    "&thepage%3Aform%3Aj_id37=thepage%3Aform%3Aj_id37" +
                    "&";

                //2º
                response = DoPost("/OriginationPage?id=" + keys["NewAccountSimulationFlow"],
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + keys["taskId"] + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");


                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewState\" name=\"com.salesforce.visualforce.ViewState\" value=\"") + 93);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewState = auxURL;
                keys["auxViewState"] = auxViewState;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateVersion\" name=\"com.salesforce.visualforce.ViewStateVersion\" value=\"") + 107);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateVersion = auxURL;
                keys["auxViewStateVersion"] = auxViewStateVersion;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateMAC\" name=\"com.salesforce.visualforce.ViewStateMAC\" value=\"") + 99);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateMAC = auxURL;
                keys["auxViewStateMAC"] = auxViewStateMAC;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateCSRF\" name=\"com.salesforce.visualforce.ViewStateCSRF\" value=\"") + 101);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateCSRF = auxURL;
                keys["auxViewStateCSRF"] = auxViewStateCSRF;
                #endregion

                #region GET 04
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                response = DoGet(apexRemoteRSPItem.Result.Content.SimulatorSrcUrl.ToString(),
                                 headers: hdrs,
                                 _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region GET 05

                auxURL = apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString();
                auxURL = auxURL.Substring(auxURL.LastIndexOf('/') + 1);
                UpdateKeys("externalId", auxURL);

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SEARCH_ATTENDANCE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/data/" + auxURL,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT 06
                var retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SEARCH_ATTENDANCE");
                //.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL,
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");

                #endregion

                #region GET 07
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "COMPLETE_OFFER");
                ////hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/data/" + auxURL,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET 08
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "COMPLETE_OFFER");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/data/" + auxURL,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT 09
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "COMPLETE_OFFER");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL,
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                #region PUT 10
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "ATTENDANCE_TYPE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL,
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                #region PUT 11
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SEARCH_PERSON");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                dataClientePut.Income = new IncomeType();

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL,
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                #region GET 12
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_PHONES_BY_DOCUMENT");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/",//+ attendancesData.Customer.IdentificationDocument.Number + "/phones?activated=true&hot=true",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET 13
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_PHONES_BY_DOCUMENT");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/",//+ attendancesData.Customer.IdentificationDocument.Number + "/phones?activated=true&hot=true",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region POST 13.5
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "NOT_INFORMED_PHONE");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoPost("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/events",
                                "{\"reason\":\"Cliente com telefone temporariamente indisponível\"}",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT 14
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL,
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                #region GET 13
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_PHONES_BY_DOCUMENT");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v2/documents/required-documents/" + auxURL,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region --------
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v2/documents/required-documents/" + auxURL,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion  

                #region GET 14
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DISTANCE_AUTHORIZATION");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL + "/dataprev-grants",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion  

                #region POST 15
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "PHONE_FOLLOW_WITHOUT_DATAPREV");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DISTANCE_AUTHORIZATION");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoPost("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/events",
                                "{}",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET 16
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DISTANCE_AUTHORIZATION");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/customer-proposals/",//+ attendancesData.Customer.IdentificationDocument.Number + "/benefits",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET 17
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_PERSONAL");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v1/cep/" + dataClientePut.PostCode,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v1/cep/" + dataClientePut.PostCode,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT 18
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_PERSONAL");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                DataClientPutRequest auxDataClientePut = dataClientePut;

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL,
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                #region PUT 19
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_BENEFIT");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                auxDataClientePut = dataClientePut;

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + auxURL,
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                #region GET 20
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_ADDITIONAL");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/" + DtPadrao.ToString("yyyy-MM-dd"),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT 21
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_ADDITIONAL");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                auxDataClientePut = dataClientePut;

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                #region GET 22
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_CONFIRM");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/" + DtPadrao.ToString("yyyy-MM-dd"),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT 23
                retornoPut = "";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_CONFIRM");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                auxDataClientePut = dataClientePut;

                retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                           JsonConvert.SerializeObject(dataClientePut),
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erroSite = ex.Message;
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public DadosClienteProduto Simular(DataClientPutRequest dataClientePut, ref string erro, ref string erroSite)
        {
            DadosClienteProduto dadosCliente = new DadosClienteProduto();

            try
            {
                dataClientePut.ExternalId = keys["attendanceNumber"];
                dataClientePut.Consultant.TaxId = attendancesData.UserId;
                dataClientePut.ActualStoreId = keys["attendanceNumber"];

                #region
                var hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Access-Control-Request-Headers", "    action,actualstoreid,attendancestatus,externalid,step,storeid,userid");
                hdrs.Add("Access-Control-Request-Method", "POST");

                var retornoOptions = DoOptions("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/" + keys["externalId"] + "/connectDocument/true",
                                "",
                                 headers: hdrs,
                                 _accept: "",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion;

                #region POST 01 - https://prd-gateway.agibank.com.br/simulator-service/v3/simulations
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                //hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SIMULATED");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SIMULATE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoPost("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/" + keys["externalId"] + "/connectDocument/true",
                                "",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region POST 02 - /apexremote
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("X-User-Agent", "Visualforce-Remoting");
                hdrs.Add("Origin", "https://agibank.force.com");

                Ms msAux = vfrmRemotingProviderImplResponse.Actions.OriginationTabController.Ms.Where(ms => ms.Name == "changeStep").FirstOrDefault();

                var data = new List<string>();
                data.Add(keys["taskId"]);
                data.Add("GEV");

                var apexRemoteRQST = new ApexRemoteRequest()
                {
                    Action = "OriginationTabController",
                    Method = "changeStep",
                    Data = data,
                    Type = "rpc",
                    Tid = 3,
                    Ctx = new Ctx()
                    {
                        Csrf = msAux.Csrf,
                        Vid = vfrmRemotingProviderImplResponse.Vf.Vid,
                        Ns = msAux.Ns,
                        Ver = msAux.Ver
                    }
                };

                response = DoPost("/apexremote",
                                 JsonConvert.SerializeObject(apexRemoteRQST),
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"] +
                                 "&taskId=" + keys["taskId"] + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true");

                var auxURL = response.Content.Substring(response.Content.IndexOf("userId=") + 7);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("&"));
                UpdateKeys("userId", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("post\" action=\"/OriginationPage?id=") + 34);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("OriginationPageId", auxURL);
                #endregion

                #region POST 03 - /OriginationPage?id=0018Z00002hDeS6QAK
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                var strPost = "AJAXREQUEST=_viewRoot" +
                    "&thepage%3Aform=thepage%3Aform" +
                    "&com.salesforce.visualforce.ViewState=" + WebUtility.UrlEncode(keys["auxViewState"]) +
                    "&com.salesforce.visualforce.ViewStateVersion=" + WebUtility.UrlEncode(keys["auxViewStateVersion"]) +
                    "&com.salesforce.visualforce.ViewStateMAC=" + WebUtility.UrlEncode(keys["auxViewStateMAC"]) +
                    "&com.salesforce.visualforce.ViewStateCSRF=" + WebUtility.UrlEncode(keys["auxViewStateCSRF"]) +
                    "&newUrl=" + WebUtility.UrlEncode(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString()) +
                    "&thepage%3Aform%3Aj_id37=thepage%3Aform%3Aj_id37" +
                    "&";

                //3º
                response = DoPost("/OriginationPage?id=" + keys["NewAccountSimulationFlow"],
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + keys["taskId"] + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");

                CookieCollection auxCookie = response.Cookies;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewState\" name=\"com.salesforce.visualforce.ViewState\" value=\"") + 93);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewState = auxURL;
                keys["auxViewState"] = auxViewState;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateVersion\" name=\"com.salesforce.visualforce.ViewStateVersion\" value=\"") + 107);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateVersion = auxURL;
                keys["auxViewStateVersion"] = auxViewStateVersion;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateMAC\" name=\"com.salesforce.visualforce.ViewStateMAC\" value=\"") + 99);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateMAC = auxURL;
                keys["auxViewStateMAC"] = auxViewStateMAC;

                auxURL = response.Content.Substring(response.Content.IndexOf("id=\"com.salesforce.visualforce.ViewStateCSRF\" name=\"com.salesforce.visualforce.ViewStateCSRF\" value=\"") + 101);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var auxViewStateCSRF = auxURL;
                keys["auxViewStateCSRF"] = auxViewStateCSRF;
                #endregion

                #region GET 04 - /Venda.UI.Web/Atendimento/Embedded/f1741e91e7af0f57433030499a68bd66/
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Upgrade-Insecure-Requests", "1");

                response = DoGet(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")),
                                 headers: hdrs,
                                 _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/",
                                 cookies: auxCookie);

                var embeddedContent = response.Content;
                #endregion

                #region GET 04.5 - /Venda.UI.Web/Agenda/ConsultarEventos?from=1656644400000&to=1659322800000&utc_offset=180&browser_timezone=America%2FArgentina%2FBuenos_Aires
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Agenda/ConsultarEventos?from=1656644400000&to=1659322800000&utc_offset=180&browser_timezone=America%2FArgentina%2FBuenos_Aires",
                                 headers: hdrs,
                                 _accept: "application/json, text/javascript, */*; q=0.01",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 04.5 - /Venda.UI.Web/Agenda/ConsultarEventos?from=1656644400000&to=1659322800000&utc_offset=180&browser_timezone=America%2FArgentina%2FBuenos_Aires
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")) + "Content/html/calendar/month.html?_=1658347343539",
                                 headers: hdrs,
                                 _accept: "application/json, text/javascript, */*; q=0.01",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 05 - /Venda.UI.Web/Atendimento/Detail/92492779
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/Detail/" + keys["externalId"],
                                 headers: hdrs,
                                 _accept: "application/json, text/javascript, */*; q=0.01",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));

                auxURL = response.Content.Substring(response.Content.IndexOf("var atendimentoViewModel = ") + 27);
                auxURL = auxURL.Substring(0, auxURL.LastIndexOf("}") + 1);

                dynamic atendimentoViewModel = JsonConvert.DeserializeObject(auxURL);
                #endregion

                #region POST 06
                //hdrs = new Dictionary<string, string>();
                //hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                //hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                //hdrs.Add("Host", "agibank.force.com");
                //hdrs.Add("Origin", "https://agibank.force.com");
                //hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                //#region MONTA URL
                //auxURL = embeddedContent.Substring(embeddedContent.IndexOf("data-dtconfig=\"") + 15);
                //auxURL = auxURL.Substring(0, auxURL.IndexOf("\"><"));

                //var auxURLList = auxURL.Split('|');

                //auxURL = "";
                //auxURL += auxURLList.Where(i => i.Contains("reportUrl=")).FirstOrDefault().Substring("reportUrl=".Length) + "?type=js3";
                //auxURL += "&flavor=post";
                //auxURL += "&vi=MEFJDADRGFRKANPOJHWUNCHLKUVEALPD-0";
                //auxURL += "&modifiedSince=" + auxURLList.Where(i => i.Contains("lastModification=")).FirstOrDefault().Substring("lastModification=".Length);
                //auxURL += "&rf=" + apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString();
                //auxURL += "&" + auxURLList.Where(i => i.Contains("bp=")).FirstOrDefault();
                //auxURL += "&" + auxURLList.Where(i => i.Contains("app=")).FirstOrDefault();
                //auxURL += "&crc=2295350673";
                //auxURL += "&en=" + auxURLList.Where(i => i.Contains("cuc=")).FirstOrDefault().Substring("cuc=".Length);
                //auxURL += "&end=1";
                //#endregion

                //#region MONTA STR POST
                //var auxCalendar = embeddedContent.Substring(embeddedContent.IndexOf("/Venda.UI.Web/bundles/calendar"));
                //auxCalendar = auxCalendar.Substring(0, auxCalendar.IndexOf("\""));

                //strPost = "$a=1|1|_load_|_load_|-|1658103452392|1658103453334|dn|84|svtrg|1|svm|i1^sk0^sh0|tvtrg|1|tvm|i1^sk0^sh0|lr|https://agibank.force.com/" +
                //    ",2|9|_event_|1658103452392|_vc_|V|-1^pc|VCD|1050|VCDS|0|VCS|999|VCO|2007|VCI|0|S|-1" +
                //    ",2|10|_event_|1658103452392|_wv_|lcpT|-5|fcp|-5|fp|-6|cls|0|lt|383" +
                //    ",2|2|this.options.templates[this.options.view] is not a function|_error_|-|1658103453291|1658103453291|dn|-1" +
                //    ",3|3|TypeError|_type_|-|1658103453293|1658103453293|dn|-1" +
                //    ",3|4|https://portal.agiplan.com.br" + auxCalendar + "^p1^p8912|_location_|-|1658103453294|1658103453294|dn|-1" +
                //    ",3|5|TypeError: this.options.templates[this.options.view] is not a function^p    at t._render (https://portal.agiplan.com.br" + auxCalendar + ":1:8912)^p    at t.view (https://portal.agiplan.com.br" + auxCalendar + ":1:13901)^p    at new t (https://portal.agiplan.com.br" + auxCalendar + ":1:4248)^p    at n.fn.calendar (https://portal.agiplan.com.br" + auxCalendar + ":1:22652)^p    at https://portal.agiplan.com.br" + auxCalendar + ":1:23333^p    at https://portal.agiplan.com.br" + auxCalendar + ":1:24533|_stack_|-|1658103453296|1658103453296|dn|-1" +
                //    ",3|6|364|_ts_|-|1658103453297|1658103453297|dn|-1" +
                //    ",3|7|1|_source_|-|1658103453299|1658103453299|dn|-1" +
                //    ",2|8|_onload_|_load_|-|1658103453334|1658103453334|dn|84|svtrg|1|svm|i1^sk0^sh0|tvtrg|1|tvm|i1^sk0^sh0" +
                //    ",1|11|_event_|1658103452392|_view_|tvtrg|1|tvm|i1^sk0^sh0" +
                //    "$rId=RID_-" + auxURLList.Where(i => i.Contains("rid=")).FirstOrDefault().Substring("rid=".Length) +
                //    "$rpId=2057969961" + auxURLList.Where(i => i.Contains("rpid=")).FirstOrDefault().Substring("rpid=".Length) +
                //    "$domR=1658103453331" +
                //    "$tvn=" + apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")).Replace("https://portal.agiplan.com.br", "") +
                //    "$tvt=1658103452392" +
                //    "$tvm=i1;k0;h0" +
                //    "$tvtrg=1" +
                //    "$w=2400" +
                //    "$h=988" +
                //    "$sw=1920" +
                //    "$sh=1080" +
                //    "$nt=a0b1658103452392e6f6g6h8i183j60k183l415m416o910p910q936r939s942t942u14114v13814w13814M2057969961V0" +
                //    "$ni=4g|10" +
                //    "$fd=j2.1.1^sg1.2.23" +
                //    "$url=" + apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString() +
                //    "$title=Atendimento" +
                //    "$app=" + auxURLList.Where(i => i.Contains("app=")).FirstOrDefault().Substring("app=".Length) +
                //    "$vi=MEFJDADRGFRKANPOJHWUNCHLKUVEALPD-0" +
                //    "$fId=303452927_766" +
                //    "$v=" + auxURLList.Where(i => i.Contains("dtVersion=")).FirstOrDefault().Substring("dtVersion=".Length) +
                //    "$vID=16581034529318PLMNH0LLE2H8M9DFPP2HD3B315L4DLP" +
                //    "$nV=1" +
                //    "$nVAT=1" +
                //    "$time=1658103454451" +
                //    "";

                //#endregion

                ////response = DoPost(auxURL,
                ////           WebUtility.UrlEncode(strPost),
                ////           headers: hdrs,
                ////           _referer: "https://agibank.force.com/apex/OriginationPage?url=" + WebUtility.UrlEncode(urlPadrao.ToString()) + "&taskId=" + keys["taskId"] + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                ////           _accept: "*/*",
                ////           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region GET 07
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/SomarPropostaAditivoDesconto?atendimentoCodigo=" + keys["externalId"],
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 08
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/GetHistoricoOcorrencias?cpfCnpj=",//+ attendancesData.Customer.IdentificationDocument.Number,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 09
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/ObterCidadesDoEstado",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 10
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/GetHistoricoProposta?cpf=",//+ attendancesData.Customer.IdentificationDocument.Number,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 12
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/GetHistoricoFatura?cpfCnpj=",//+ attendancesData.Customer.IdentificationDocument.Number,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 11
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/ConsultarHistoricoSeguros?cpf=",// + attendancesData.Customer.IdentificationDocument.Number,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region POST 13
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");

                hdrs.Add("Action", "SIMULATED");
                hdrs.Add("actualStoreId", attendancesData.StoreId);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SIMULATE");
                //hdrs.Add("storeId", attendancesData.CostCenter);
                hdrs.Add("userId", keys["userId"]);

                response = DoPost("/Venda.UI.Web/Atendimento/AtendimentoVerificaPontoAptoTelefonica",
                                "",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region POST 14
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");

                response = DoPost("/Venda.UI.Web/Atendimento/VerificarAtendimentoFinalizado",
                                "{\"atendimentoCodigo\":" + keys["externalId"] + "}",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region POST 15
                SalvaDadosIdentificacaoRequest salvaDados = new SalvaDadosIdentificacaoRequest()
                {
                    DataNascimentoString = DateTime.Parse(dataClientePut.Birthday).ToString("dd/MM/yyyy"),
                    Confirma = true,
                    Etapa = 2,
                    AtendimentoCliente = new SalvaDadosIdentificacaoRequestAtendimentoCliente()
                };

                try
                {
                    if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].regraPagamentoCodigo == null)
                        atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].regraPagamentoCodigo = 2033;


                    salvaDados.AtendimentoCliente.AtendimentoClienteCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoClienteCodigo;

                    salvaDados.AtendimentoCliente.AtendimentoClienteCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoClienteCodigo;
                    salvaDados.AtendimentoCliente.AtendimentoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoCodigo;
                    salvaDados.AtendimentoCliente.RegraPagamentoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].regraPagamentoCodigo;
                    salvaDados.AtendimentoCliente.CpfCnpj = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].cpfCnpj;
                    salvaDados.AtendimentoCliente.Nome = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].nome;
                    salvaDados.AtendimentoCliente.DataNascimento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataNascimento.ToString("yyyy-MM-dd") + "T00:00:00";
                    salvaDados.AtendimentoCliente.DataNascimentoString = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataNascimento.ToString("dd/MM/yyyy");
                    salvaDados.AtendimentoCliente.AceitaReceberSms = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].aceitaReceberSMS;
                    salvaDados.AtendimentoCliente.AceitaReceberEmail = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].aceitaReceberEmail;
                    salvaDados.AtendimentoCliente.AceitaReceberMensagemSac = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].aceitaReceberMensagemSAC;
                    salvaDados.AtendimentoCliente.NaturezaOcupacaoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].naturezaOcupacaoCodigo;
                    salvaDados.AtendimentoCliente.Matricula = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].matricula;
                    salvaDados.AtendimentoCliente.Skype = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].skype;
                    salvaDados.AtendimentoCliente.BloqueiaCpfTela = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].bloqueiaCpfTela;
                    salvaDados.AtendimentoCliente.ClienteNovo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].clienteNovo;
                    salvaDados.AtendimentoCliente.ClienteRestritivo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].clienteRestritivo;
                    salvaDados.AtendimentoCliente.TipoRestritividade = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].tipoRestritividade;
                    salvaDados.AtendimentoCliente.MensagemRestritividade = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].mensagemRestritividade;
                    salvaDados.AtendimentoCliente.ErroHistoricoContrato = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].erroHistoricoContrato;
                    salvaDados.AtendimentoCliente.Peso = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].peso;
                    salvaDados.AtendimentoCliente.Altura = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].altura;
                    salvaDados.AtendimentoCliente.TipoDocumentoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].tipoDocumentoCodigo;
                    salvaDados.AtendimentoCliente.DocumentoIdentificacao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].documentoIdentificacao;
                    salvaDados.AtendimentoCliente.OrgaoExpedidorCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].orgaoExpedidorCodigo;
                    salvaDados.AtendimentoCliente.UfExpedicao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].ufExpedicao;
                    salvaDados.AtendimentoCliente.DataExpedicao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataExpedicao;
                    salvaDados.AtendimentoCliente.DataExpedicaoString = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataExpedicaoString;
                    salvaDados.AtendimentoCliente.Sexo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].sexo;
                    salvaDados.AtendimentoCliente.NacionalidadeCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].nacionalidadeCodigo;
                    salvaDados.AtendimentoCliente.NaturalidadeEstadoUf = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].naturalidadeEstadoUF;
                    salvaDados.AtendimentoCliente.NaturalidadeCidadeCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].naturalidadeCidadeCodigo;
                    salvaDados.AtendimentoCliente.NomePai = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].nomePai;
                    salvaDados.AtendimentoCliente.NomeMae = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].nomeMae;
                    salvaDados.AtendimentoCliente.OcupacaoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].ocupacaoCodigo;
                    salvaDados.AtendimentoCliente.EstadoCivilCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].estadoCivilCodigo;
                    salvaDados.AtendimentoCliente.ConjugeNome = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].conjugeNome;
                    salvaDados.AtendimentoCliente.EscolaridadeCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].escolaridadeCodigo;
                    salvaDados.AtendimentoCliente.Ppe = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].ppe;
                    salvaDados.AtendimentoCliente.ConjugeCpf = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].conjugeCpf;
                    salvaDados.AtendimentoCliente.BiometriaFacialMotivoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].biometriaFacialMotivoCodigo;
                    salvaDados.AtendimentoCliente.BiometriaFacialMotivoPontoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].biometriaFacialMotivoPontoCodigo;
                    salvaDados.AtendimentoCliente.EnvioEmailRestricaoBiometriaFacial = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].envioEmailRestricaoBiometriaFacial;
                    salvaDados.AtendimentoCliente.DivergenciaBiometriaFacial = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].divergenciaBiometriaFacial;
                    salvaDados.AtendimentoCliente.IndisponibilidadeBiometriaFacial = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].indisponibilidadeBiometriaFacial;
                    salvaDados.AtendimentoCliente.StatusBiometriaFacial = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].statusBiometriaFacial;
                    salvaDados.AtendimentoCliente.PatrimonioCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].patrimonioCodigo;
                    salvaDados.AtendimentoCliente.Atendimento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimento;
                    salvaDados.AtendimentoCliente.RegraPagamento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].regraPagamento;
                    salvaDados.AtendimentoCliente.ProcuradorCpf = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].procuradorCpf;
                    salvaDados.AtendimentoCliente.DataValidadeFoto = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataValidadeFoto;
                    salvaDados.AtendimentoCliente.OrigemCapturaBiometria = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].origemCapturaBiometria;
                    salvaDados.AtendimentoCliente.ScoreAcesso = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].scoreAcesso;
                    salvaDados.AtendimentoCliente.Liveness = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].liveness;
                    salvaDados.AtendimentoCliente.ClienteAlfabetizado = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].clienteAlfabetizado;
                    salvaDados.AtendimentoCliente.DataNascimentoDataPrev = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataNascimentoDataPrev;
                    salvaDados.AtendimentoCliente.EnderecoProspeccao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoProspeccao;
                    salvaDados.AtendimentoCliente.ClienteContaCorrente = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].clienteContaCorrente;
                    salvaDados.AtendimentoCliente.PossuiContaCorrente = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].possuiContaCorrente;

                    salvaDados.AtendimentoCliente.ErroList = new List<object>();
                    salvaDados.AtendimentoCliente.ReferenciaList = new List<object>();
                    salvaDados.AtendimentoCliente.ContratoHistoricoList = new List<object>();
                    salvaDados.AtendimentoCliente.AtendimentoClienteEmailList = new List<object>();
                    //salvaDados.AtendimentoCliente.AtendimentoClienteTelefoneList = new List<object>();
                    salvaDados.AtendimentoCliente.AtendimentoClienteTestemunhaList = new List<object>();

                    if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial != null)
                    {
                        salvaDados.AtendimentoCliente.EnderecoResidencial = new AtendimentoClienteEndereco()
                        {
                            AtendimentoClienteEnderecoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.atendimentoClienteEnderecoCodigo,
                            AtendimentoClienteCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.atendimentoClienteCodigo,
                            Cep = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.cep,
                            EstadoUf = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.estadoUF,
                            CidadeCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.cidadeCodigo,
                            BairroCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.bairroCodigo,
                            OutroBairroDescricao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.outroBairroDescricao,
                            TipoLogradouroCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoLogradouroCodigo,
                            Logradouro = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.logradouro,
                            Numero = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.numero,
                            SemNumero = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.semNumero,
                            Complemento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.complemento,
                            TipoResidenciaCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoResidenciaCodigo,
                            ValorParcelaFinanciamento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.valorParcelaFinanciamento,
                            ValorParcelaFinanciamentoString = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.valorParcelaFinanciamentoString,
                            TipoEndereco = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoEndereco,
                            AtendimentoCliente = new AtendimentoClienteEnderecoAtendimentoCliente() { },
                            TemDados = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.temDados,
                            EstadoUfDescricao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.estadoUfDescricao,
                            CidadeNome = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.cidadeNome,
                            BairroNome = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.bairroNome,
                            TipoLogradouroDescricao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoLogradouroDescricao
                        };
                    }

                    //TODO: FAZER FOREACH DOS ENDEREÇOS
                    salvaDados.AtendimentoCliente.AtendimentoClienteEnderecoList = new List<AtendimentoClienteEndereco>() { };
                    salvaDados.AtendimentoCliente.AtendimentoClienteEnderecoList.Add(salvaDados.AtendimentoCliente.EnderecoResidencial);

                    salvaDados.AtendimentoCliente.AtendimentoClienteReferenciaList = new List<AtendimentoClienteReferenciaList>() { };

                    if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoClienteReferenciaList != null)
                    {
                        var ct = 0;
                        dynamic cliRef = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoClienteReferenciaList[ct];


                        while (cliRef != null)
                        {
                            salvaDados.AtendimentoCliente.AtendimentoClienteReferenciaList.Add(new AtendimentoClienteReferenciaList()
                            {
                                AtendimentoClienteReferenciaCodigo = cliRef.atendimentoClienteReferenciaCodigo,
                                AtendimentoClienteCodigo = cliRef.atendimentoClienteCodigo,
                                Nome = cliRef.nome,
                                GrauRelacionamentoCodigo = cliRef.grauRelacionamentoCodigo,
                                TipoTelefoneCodigo = cliRef.tipoTelefoneCodigo,
                                Ddd = cliRef.ddd,
                                Numero = cliRef.numero,
                                AtendimentoCliente = new AtendimentoCliente()
                            });
                            ct++;

                            try
                            {
                                cliRef = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoClienteReferenciaList[ct];
                            }
                            catch (Exception ex)
                            {
                                cliRef = null;
                            }
                        }
                    }

                    salvaDados.AtendimentoCliente.AtendimentoClienteEndereco = salvaDados.AtendimentoCliente.EnderecoResidencial;
                }
                catch (Exception ex)
                {
                    var x = ex;
                }

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");

                strPost = JsonConvert.SerializeObject(salvaDados);

                strPost.Replace("\"erroList\":null", "\"erroList\":[]");
                strPost.Replace("\"referenciaList\":null", "\"referenciaList\":[]");
                strPost.Replace("\"contratoHistoricoList\":null", "\"contratoHistoricoList\":[]");
                strPost.Replace("\"atendimentoClienteEmailList\":null", "\"atendimentoClienteEmailList\":[]");
                strPost.Replace("\"atendimentoClienteTelefoneList\":null", "\"atendimentoClienteTelefoneList\":[]");
                strPost.Replace("\"atendimentoClienteTestemunhaList\":null", "\"atendimentoClienteTestemunhaList\":[]");

                response = DoPost("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/SalvaDadosIdentificacao",
                                strPost,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 16
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/BuscarMensagemCartoes?cpfCnpj=",// + attendancesData.Customer.IdentificationDocument.Number,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region GET 18
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("/Venda.UI.Web/Atendimento/ObterMensagemMaisDeUmaContaAgibank?atendimentoCodigo=" + salvaDados.AtendimentoCliente.AtendimentoCodigo + "&cpfCnpj=" + salvaDados.AtendimentoCliente.CpfCnpj,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));


                try
                {
                    var testeTexto = response.Content;
                    testeTexto = testeTexto.Replace("\"atendimentoClienteList\":[{\"$ref\":\"4\"}],", "");
                    testeTexto = testeTexto.Replace("\"atendimentoCliente\":{\"$ref\":\"4\"}", "");
                    //testeTexto = testeTexto.Replace("\"atendimentoCliente\":{\"$ref\":\"4\"}},", "");

                    ObterUltimaOperacaoResponse teste = JsonConvert.DeserializeObject<ObterUltimaOperacaoResponse>(testeTexto);
                }
                catch (Exception ex)
                {

                }
                #endregion

                #region GET 17
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                //response = DoGet("/Venda.UI.Web/Atendimento/ObterUltimaOperacao?atendimentoCodigo=" + keys["externalId"] + "&atualizar=false",
                response = DoGet("/Venda.UI.Web/Atendimento/ObterUltimaOperacao?atendimentoCodigo=" + keys["externalId"] + "&atualizar=true",
                             headers: hdrs,
                             _accept: "application/json, text/plain, */*",
                             _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                             _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                //ObterUltimaOperacaoResponse ultOp = JsonConvert.DeserializeObject<ObterUltimaOperacaoResponse>(response.Content);
                dynamic ultOp = JsonConvert.DeserializeObject(response.Content);

                try
                {
                    var testeTexto = response.Content;
                    testeTexto = testeTexto.Replace("\"atendimentoClienteList\":[{\"$ref\":\"4\"}],", "");
                    testeTexto = testeTexto.Replace("\"atendimentoCliente\":{\"$ref\":\"4\"}", "");
                    //testeTexto = testeTexto.Replace("\"atendimentoCliente\":{\"$ref\":\"4\"}},", "");

                    ObterUltimaOperacaoResponse teste = JsonConvert.DeserializeObject<ObterUltimaOperacaoResponse>(testeTexto);
                }
                catch (Exception ex)
                {

                }
                #endregion

                #region POST 18.5
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");

                response = DoPost("/Venda.UI.Web/Atendimento/ConsultaClientePossuiMaisDeUmaContaLiberada",
                                "{\"atendimentoCodigo\":" + keys["externalId"] + ",\"cpfcnpj\":\"" + dataClientePut.Document + "\"}",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));
                #endregion

                #region POST 18
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");

                #region MONTA POST
                JSONObjects.SimularRequest SimularRequestContext = new SimularRequest()
                {
                    Cpf = dataClientePut.Document,
                    ValorCredito = 80000,
                    ValorParcela = 0,
                    ManterSalarioContaAgiplan = null,
                    AtualizandoAtendimentoTelefonico = false,
                    AtualizandoSimulacao = false,
                    SimularDemaisPrazos = false
                };

                SimularRequestContext.Operacao = new Operacao()
                {
                    AtendimentoCodigo = ultOp.atendimentoOperacao.atendimentoCodigo,
                    AtendimentoOperacaoCodigo = ultOp.atendimentoOperacao.atendimentoOperacaoCodigo,
                    RegraPagamentoCodigo = ultOp.regraPagamento.regraPagamentoCodigo,
                    RegraPagamentoNome = ultOp.regraPagamento.nome,
                    DomicilioEstadoUf = ultOp.atendimentoOperacao.domicilioEstadoUf,
                    InstituicaoCodigo = ultOp.atendimentoOperacao.instituicaoCodigo,
                    GrupoInstituicaoCodigo = ultOp.atendimentoOperacao.grupoInstituicaoCodigo,
                    NaturezaOcupacaoCodigo = ultOp.atendimentoOperacao.naturezaOcupacaoCodigo,
                    SituacaoFuncionalCodigo = ultOp.atendimentoOperacao.situacaoFuncionalCodigo,
                    Matricula = ultOp.atendimentoOperacao.matricula,
                    DataPermanenciaOrgao = ultOp.atendimentoOperacao.dataPermanenciaOrgao,
                    BancoCodigo = ultOp.atendimentoOperacao.bancoCodigo,
                    NumeroAgencia = ultOp.atendimentoOperacao.numeroAgencia,
                    TipoOperacaoCefCodigo = ultOp.atendimentoOperacao.tipoOperacaoCefCodigo,
                    NumeroConta = ultOp.atendimentoOperacao.numeroConta,
                    TipoContaCodigo = ultOp.atendimentoOperacao.tipoContaCodigo,
                    ValorRendaBruta = ultOp.atendimentoOperacao.valorRendaBruta,
                    ValorRendaLiquida = ultOp.atendimentoOperacao.valorRendaLiquida,
                    ValorTipoDespesa = ultOp.atendimentoOperacao.valorTipoDespesa,
                    ValorTipoDespesaOriginal = ultOp.atendimentoOperacao.valorTipoDespesaOriginal,
                    NaoPossuiTipoDespesa = ultOp.atendimentoOperacao.naoPossuiTipoDespesa,
                    ValorAditivoDesconto = ultOp.atendimentoOperacao.valorAditivoDesconto,
                    ValorAditivoDescontoOriginal = ultOp.atendimentoOperacao.valorAditivoDescontoOriginal,
                    NaoPossuiAditivoDesconto = false,
                    NaoPossuiProventosBeneficio = true,
                    NaoPossuiDebitosBeneficio = true,
                    NaoPossuiEmprestimosBeneficio = true,
                    DiaRecebimentoSalario = null,
                    AlteracaoDadosCadastrais = false,
                    ExibirEmModoSiape = false,
                    UpagSigla = null,
                    UpagNome = null,
                    UpagCodigo = ultOp.atendimentoOperacao.upagCodigo,
                    MatriculaInstituidor = ultOp.atendimentoOperacao.matriculaInstituidor,
                    InformouRenda = true,
                    DataRecebimentoSalario = ultOp.atendimentoOperacao.dataRecebimentoSalario.Value.ToString("dd/MM/yyyy"),
                    EspecieCodigo = ultOp.atendimentoOperacao.especieCodigo,
                    DataPermanenciaOrgaoObrigatoria = ultOp.atendimentoOperacao.dataPermanenciaOrgaoObrigatoria,
                    EhInstituicaoGrupoInss = true,
                    EhInstituicaoGrupoSiape = false,
                    MaximoDiasContraCheque = 365,
                    MaximoDiasDataFuturaContraCheque = 45,
                    MeioPagamentoCodigo = ultOp.atendimentoOperacao.meioPagamentoCodigo,
                    MeioPagamentoSimulador = ultOp.atendimentoOperacao.meioPagamentoSimulador,
                    PossuiCartaoRmc = null,
                    ValorProventosBeneficio = ultOp.atendimentoOperacao.valorProventosBeneficio,
                    ValorProventosBeneficioOriginal = ultOp.atendimentoOperacao.valorProventosBeneficioOriginal,
                    ValorDebitosBeneficio = ultOp.atendimentoOperacao.valorDebitosBeneficio,
                    ValorDebitosBeneficioOriginal = ultOp.atendimentoOperacao.valorDebitosBeneficioOriginal,
                    ValorEmprestimosBeneficio = ultOp.atendimentoOperacao.valorEmprestimosBeneficio,
                    ValorEmprestimosBeneficioOriginal = ultOp.atendimentoOperacao.valorEmprestimosBeneficioOriginal,
                    ValorMargemConsignavel = ultOp.atendimentoOperacao.valorMargemConsignavel,
                    ValorMargemDisponivel = ultOp.atendimentoOperacao.valorMargemDisponivel,
                    AgenciaDv = ultOp.atendimentoOperacao.agenciaDv,
                    BureauHigienizacaoCodigo = ultOp.atendimentoOperacao.bureauHigienizacaoCodigo,
                    MatriculaMascara = "000.000.000-0",
                    ValorPrestacao = 0,
                    ValorCompra = 80000,
                    StatusContaCorrente = ultOp.atendimentoOperacao.statusContaCorrente,
                    BancoAgiplan = null,
                    BancoCedente = ultOp.atendimentoOperacao.bancoCedente,
                    AgenciaCedente = ultOp.atendimentoOperacao.agenciaCedente,
                    ContaCedente = ultOp.atendimentoOperacao.contaCedente,
                    BancoCredito = ultOp.atendimentoOperacao.bancoCredito,
                    AgenciaCredito = ultOp.atendimentoOperacao.agenciaCredito,
                    AgenciaNumero = null,
                    ContaCredito = ultOp.atendimentoOperacao.contaCredito,
                    TipoOperacaoCreditoCefCodigo = ultOp.atendimentoOperacao.tipoOperacaoCreditoCefCodigo,
                    TipoContaCreditoCodigo = 1,
                    TipoContaSalario = ultOp.atendimentoOperacao.tipoContaSalario,
                    ContaAtributo = ultOp.atendimentoOperacao.contaAtributo,
                    UsuarioOperacaoCodigo = ultOp.atendimentoOperacao.usuarioOperacaoCodigo,
                    DeclaracaoFinsDeAberturaCodigo = ultOp.atendimentoOperacao.declaracaoFinsDeAberturaCodigo,
                    IdConta = ultOp.atendimentoOperacao.idConta,
                    IdCartao = ultOp.atendimentoOperacao.idCartao,
                    ValorAutorizacaoDebitoCp = ultOp.atendimentoOperacao.valorAutorizacaoDebitoCp,
                    ValorAutorizacaoDebitoSeguro = ultOp.atendimentoOperacao.valorAutorizacaoDebitoSeguro,
                    BancoAverbacao = ultOp.atendimentoOperacao.bancoAverbacao,
                    AgenciaAverbacao = ultOp.atendimentoOperacao.agenciaAverbacao,
                    TipoOperacaoCefAverbacaoCodigo = ultOp.atendimentoOperacao.tipoOperacaoCefAverbacaoCodigo,
                    ContaAverbacao = ultOp.atendimentoOperacao.contaAverbacao,
                    TipoContaAverbacaoCodigo = 1,
                    ClienteDomiciliado = ultOp.atendimentoOperacao.clienteDomiciliado,
                    DataCessacaoBeneficio = ultOp.atendimentoOperacao.dataCessacaoBeneficio,
                    RendaEstimada = ultOp.atendimentoOperacao.rendaEstimada,
                    DiaPagamentoCalculado = false,
                    AnoExpedicaoBeneficio = ultOp.atendimentoOperacao.anoExpedicaoBeneficio,
                    ManterSalarioBancoAgiplan = ultOp.atendimentoOperacao.manterSalarioBancoAgiplan,
                    BancoNumeroSimulador = ultOp.atendimentoOperacao.bancoNumeroSimulador,
                    AtendimentoSimulador = false,
                    DadosAverbacaoOrigemMotor = false,
                    DataCessacaoMotor = null,
                    DataHoraOperacao = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.00"),
                    EspecieValor = 0,
                    OperacaoSimulador = true,
                    PagarCpAgibank = false,
                    PossuiAditivoDesconto = true
                };

                if (ultOp.atendimentoOperacao.especie != null)
                {
                    SimularRequestContext.Operacao.Especie = new Especie() { };

                    SimularRequestContext.Operacao.Especie.EspecieCodigo = ultOp.atendimentoOperacao.especie.especieCodigo;
                    SimularRequestContext.Operacao.Especie.EspecieValor = ultOp.atendimentoOperacao.especie.especieValor;
                    SimularRequestContext.Operacao.Especie.EspecieNome = ultOp.atendimentoOperacao.especie.especieNome;
                    SimularRequestContext.Operacao.Especie.TipoEspecieNome = ultOp.atendimentoOperacao.especie.tipoEspecieNome;
                    SimularRequestContext.Operacao.Especie.EspecieSituacao = ultOp.atendimentoOperacao.especie.especieSituacao;
                    SimularRequestContext.Operacao.Especie.TipoEspecieSituacao = ultOp.atendimentoOperacao.especie.tipoEspecieSituacao;
                    SimularRequestContext.Operacao.Especie.EspecieConsignado = ultOp.atendimentoOperacao.especie.especieConsignado;
                    SimularRequestContext.Operacao.Especie.EspecieDomicilio = ultOp.atendimentoOperacao.especie.especieDomicilio;
                    SimularRequestContext.Operacao.Especie.EspecieAgidebito = ultOp.atendimentoOperacao.especie.especieAgidebito;
                    SimularRequestContext.Operacao.Especie.TipoEspeciePrazoPermanencia = ultOp.atendimentoOperacao.especie.tipoEspeciePrazoPermanencia;
                    SimularRequestContext.Operacao.Especie.TipoEspecieDecimoTerceiro = ultOp.atendimentoOperacao.especie.tipoEspecieDecimoTerceiro;
                    SimularRequestContext.Operacao.Especie.TipoEspecieCodigo = ultOp.atendimentoOperacao.especie.tipoEspecieCodigo;
                    SimularRequestContext.Operacao.Especie.ValorFormatadoSicred = ultOp.atendimentoOperacao.especie.valorFormatadoSicred;
                    SimularRequestContext.Operacao.Especie.DataPermanenciaOrgaoObrigatoria = ultOp.atendimentoOperacao.especie.dataPermanenciaOrgaoObrigatoria;
                }
                #endregion

                response = DoPost("/Venda.UI.Web/Atendimento/Simular",
                                JsonConvert.SerializeObject(SimularRequestContext),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#")));

                if (response.Headers.Where(h => h.Name == "x-mensageerror").Count() > 0)
                {
                    erro = response.Headers.Where(h => h.Name == "x-mensageerror").FirstOrDefault().Value.ToString();
                    return dadosCliente;
                }

                var simular = JsonConvert.DeserializeObject<SimularResponse>(response.Content);

                if (simular.Data.ErroList != null && simular.Data.ErroList.Count > 0)
                {
                    erro = String.Join(" | ", simular.Data.ErroList);
                    return dadosCliente;
                }

                var auxProdutos = response.Content.Substring(response.Content.IndexOf("\"produtoList\":") + 14);
                auxProdutos = auxProdutos.Substring(0, auxProdutos.IndexOf("\"produtoRemovidoList"));
                auxProdutos = auxProdutos.Substring(0, auxProdutos.LastIndexOf("],") + 1);

                List<ProdutoResponse> produtos = JsonConvert.DeserializeObject<List<ProdutoResponse>>(auxProdutos);
                dadosCliente.Produtos = produtos.ToList();
                #endregion

            }
            catch (Exception ex)
            {
                erroSite = ex.Message;
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
            }

            return dadosCliente;
        }


        #region WEBREQUEST

        private RestResponse DoGet(string url, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null, CookieCollection cookies = null)
        {
            UpdateHeaders(_userAgent);

            var rqst = new RestRequest(url);

            if (_accept != "" && _accept != accept)
                rqst.AddOrUpdateHeader("Accept", _accept);

            if (_referer != "" && _referer != referer)
                rqst.AddOrUpdateHeader("Referer", _referer);

            rqst.AddOrUpdateHeader("KeepAlive", keepAlive);
            rqst.AddOrUpdateHeader("User-Agent", userAgent);

            if (headers != null)
                foreach (var h in headers)
                    rqst.AddOrUpdateHeader(h.Key, h.Value);

            if (cookies != null)
            {
                //foreach (var c in cookies)
                //client.CookieContainer.Add(c);
            }

            return Get(rqst);
        }

        private RestResponse DoPost(string url, string body, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null)
        {
            UpdateHeaders(_userAgent);

            var rqst = new RestRequest(url);

            if (_accept != "" && _accept != accept)
                rqst.AddOrUpdateHeader("Accept", _accept);

            if (_referer != "" && _referer != referer)
                rqst.AddOrUpdateHeader("Referer", _referer);

            rqst.AddOrUpdateHeader("KeepAlive", keepAlive);
            rqst.AddOrUpdateHeader("User-Agent", userAgent);

            if (headers != null)
                foreach (var h in headers)
                    rqst.AddOrUpdateHeader(h.Key, h.Value);

            rqst.AddBody(body);

            return Post(rqst);
        }

        private string DoPut(string url, string body, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null)
        {
            //UpdateHeaders(_userAgent);

            try
            {
                byte[] toBytes = System.Text.Encoding.ASCII.GetBytes(body);

                using (var client = new System.Net.WebClient())
                {
                    if (_accept != "" && _accept != accept)
                        client.Headers.Add("Accept", _accept);

                    if (_referer != "" && _referer != referer)
                        client.Headers.Add("Referer", _referer);

                    client.Headers.Add("User-Agent", userAgent);

                    if (headers != null)
                        foreach (var h in headers)
                            client.Headers.Add(h.Key, h.Value);

                    return System.Text.Encoding.ASCII.GetString(client.UploadData(url, "PUT", toBytes));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string DoPatch(string url, string body, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null)
        {
            //UpdateHeaders(_userAgent);

            byte[] toBytes = System.Text.Encoding.ASCII.GetBytes(body);

            using (var client = new System.Net.WebClient())
            {
                if (_accept != "" && _accept != accept)
                    client.Headers.Add("Accept", _accept);

                if (_referer != "" && _referer != referer)
                    client.Headers.Add("Referer", _referer);

                client.Headers.Add("User-Agent", userAgent);

                if (headers != null)
                    foreach (var h in headers)
                        client.Headers.Add(h.Key, h.Value);

                return System.Text.Encoding.ASCII.GetString(client.UploadData(url, "PATCH", toBytes));
            }
        }
        private string DoOptions(string url, string body, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null)
        {
            //UpdateHeaders(_userAgent);

            try
            {
                byte[] toBytes = System.Text.Encoding.ASCII.GetBytes(body);

                using (var client = new System.Net.WebClient())
                {
                    if (_accept != "" && _accept != accept)
                        client.Headers.Add("Accept", _accept);

                    if (_referer != "" && _referer != referer)
                        client.Headers.Add("Referer", _referer);

                    client.Headers.Add("User-Agent", userAgent);

                    if (headers != null)
                        foreach (var h in headers)
                            client.Headers.Add(h.Key, h.Value);

                    return System.Text.Encoding.ASCII.GetString(client.UploadData(url, "OPTIONS", toBytes));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private RestResponse Get(RestRequest rqst)
        {
            var response = client.Get(rqst);

            //UpdateKeys();

            return response;
        }
        private RestResponse Post(RestRequest rqst)
        {
            var response = client.Post(rqst);

            //UpdateKeys();

            return response;
        }
        private void UpdateHeaders(string _userAgent = "")
        {
            if (_userAgent != "" && _userAgent != userAgent)
                userAgent = _userAgent;
        }

        private HtmlDocument StringToHTML(string htmlDocument)
        {
            HtmlDocument html = new HtmlDocument();

            html.LoadHtml(htmlDocument);

            return html;
        }

        private void UpdateKeys(string key, string value)
        {
            if (keys.ContainsKey(key))
                keys[key] = value;
            else
                keys.Add(key, value);
        }

        private string countURL()
        {
            cntURL++;
            return cntURL.ToString();
        }

        #endregion
    }
}
