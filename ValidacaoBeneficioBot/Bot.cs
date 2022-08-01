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
    public class Bot
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
        //DataClientResponse dataClient;
        VfrmRemotingProviderImplResponse vfrmRemotingProviderImplResponse;
        JSONObjects.SimularRequest SimularRequestContext;

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
                hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

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
                hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");
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

        public bool BuscaCPF(string cpf, string nome, string sobrenome, ref bool flClienteNovo, ref string erro)
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
                hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");


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
                    throw new Exception("CLIENTE NOVO - PULAR");
                    
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
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
                return false;
            }
        }

        public bool ClicaSimulacao(ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                #region POST 01

                MessageRequest objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1122;a",
                    Descriptor = "aura://ComponentController/ACTION$getComponent",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Name = "markup://siteforce:regionLoaderWrapper",
                        Attributes = new JSONObjects.Attributes()
                        {
                            ItemId = new Guid("c6587688-0875-4447-9e25-3989316bc04b"),//FIXO
                            Params = new JSONObjects.AttributesParams()
                            {
                                Viewid = new Guid(keys["view_uuid"]),
                                ViewUddid = "0I36e00000Ep09J",
                                EntityName = "Account",
                                AudienceName = "BPO",
                                RecordId = keys["NewAccountSimulationFlow"],
                                RecordName = "detail",
                                PicassoId = keys["BPOId"],
                                RouteId = keys["BPOId"]
                            }
                        }
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
                    "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-')) +
                    "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.Component.getComponent=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");

                var aux = response.Content.Substring(response.Content.IndexOf("\"},\"regionName\":{\"descriptor\":\"regionName\",\"value\":\"") + 52);
                aux = aux.Substring(0, aux.IndexOf("\""));
                UpdateKeys("RegionNameValue", aux);
                #endregion

                #region POST 02

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1131;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OriginationController",
                        Method = "getCurrent",
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
                   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=" + keys["RegionNameValue"]) +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=2",
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
                    Id = "1133;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "TaskController",
                        Method = "getAccountTasksSimulationDeferred",
                        Params = new JSONObjects.ActionParams()
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
                   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=" + keys["RegionNameValue"]) +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
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

        public bool ClicaINSS(ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

                #region POST 01

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
                    "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=" + keys["RegionNameValue"]) +
                    "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");


                dynamic postResponse = JsonConvert.DeserializeObject(response.Content);

                string attendanceNumber = postResponse.actions[0].returnValue.returnValue.content.OriginationSrcUrl;
                attendanceNumber = attendanceNumber.Substring(attendanceNumber.IndexOf("=") + 1);
                UpdateKeys("attendanceNumber", attendanceNumber);

                string taskId = postResponse.actions[0].returnValue.returnValue.content.TaskId;
                UpdateKeys("taskId", taskId);

                string auxURL = postResponse.actions[0].returnValue.returnValue.content.OriginationSrcUrl;
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
                   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=" + keys["RegionNameValue"]) +
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
                   "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=" + keys["RegionNameValue"]) +
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

                response = DoGet("/apex/OriginationPage?url=" + WebUtility.UrlEncode(auxURL) + "&taskId=" + taskId + "&id=" + keys["NewAccountSimulationFlow"] + "&corban=true&enableScroll=true",
                                 headers: hdrs,
                                 _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "?tabset-11f0d=" + keys["RegionNameValue"]);

                auxURL = response.Content.Substring(response.Content.IndexOf("post\" action=\"/OriginationPage?id=") + 34);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("OriginationPageId", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("$VFRM.RemotingProviderImpl(") + 27);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("apexremote\"}));") + 12);
                vfrmRemotingProviderImplResponse = JsonConvert.DeserializeObject<VfrmRemotingProviderImplResponse>(auxURL);
                #endregion

                #region GET 05

                //hdrs = new Dictionary<string, string>();

                //hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                //hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                //hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                //hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");
                //response = DoGet("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "?state-safe=true",
                //                 headers: hdrs,
                //                 _accept: "*/*",
                //                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                //                 _referer: "https://origination-product-sale-originacao.agibank-prd.in/");

                //dataClient = JsonConvert.DeserializeObject<DataClientResponse>(response.Content);
                #endregion

                //#region POST 06
                //Ms msAux = vfrmRemotingProviderImplResponse.Actions.OriginationTabController.Ms.Where(ms => ms.Name == "changeStep").FirstOrDefault();

                //var data = new List<string>();
                //data.Add(keys["taskId"]);
                //data.Add("Simulator");

                //var apexRemoteRQST = new ApexRemoteRequest()
                //{
                //    Action = "OriginationTabController",
                //    Method = "changeStep",
                //    Data = data,
                //    Type = "rpc",
                //    Tid = msAux.Len,
                //    Ctx = new Ctx()
                //    {
                //        Csrf = msAux.Csrf,
                //        Vid = vfrmRemotingProviderImplResponse.Vf.Vid,
                //        Ns = msAux.Ns,
                //        Ver = msAux.Ver
                //    }
                //};

                //response = DoPost("/apexremote",
                //                 JsonConvert.SerializeObject(apexRemoteRQST), 
                //                 headers: hdrs,
                //                 _accept: "*/*",
                //                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                //                 _referer: "https://agibank.force.com/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"] +
                //                 ";&taskId=" + keys["taskId"] + "&id=" + keys["OriginationPageId"] + "&corban=true&enableScroll=true");
                //#endregion

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

        public DadosClienteProduto BuscaOfertasDisponiveis(string cpf, string nomeCompleto, DataClientPutRequest dataClientePut, ref string erro)
        {
            DadosClienteProduto dadosCliente = new DadosClienteProduto();

            try
            {
                dadosCliente = new DadosClienteProduto()
                {
                    Nome = nomeCompleto,
                    CPF = cpf
                };

                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region POST 01

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Host", "agibank.force.com");

                var data = new List<string>();
                data.Add(keys["taskId"]);
                data.Add("Simulator");
                //data.Add("GEV");

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
                                 _referer: "https://agibank.force.com/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"] +
                                 ";&taskId=" + keys["taskId"] + "&id=" + keys["OriginationPageId"] + "&corban=true&enableScroll=true");

                ApexRemoteResponseItem apexRemoteRSPItem = JsonConvert.DeserializeObject<ApexRemoteResponseItem>(response.Content.Substring(1, response.Content.Length - 2));
                #endregion

                #region CLIENTE NOVO - INSERÇÃO DE DADOS
                //if (dataClientePut != null)
                //{
                //    var retornoPut = "";

                //    hdrs = new Dictionary<string, string>();

                //    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                //    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                //    hdrs.Add("Host", "prd-gateway.agibank.com.br");
                //    hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                //    hdrs.Add("Content-Type", "application/json");

                //    hdrs.Add("Action", "SAVE_PERSON");
                //    hdrs.Add("actualStoreId", dataClient.StoreId.ToString());
                //    hdrs.Add("attendanceStatus", "");
                //    hdrs.Add("externalId", apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("Detail/") + 7));
                //    hdrs.Add("storeId", dataClient.CostCenter.ToString());

                //    auxURL = apexRemoteRSPItem.Result.Content.SimulatorSrcUrl.ToString().Substring(apexRemoteRSPItem.Result.Content.SimulatorSrcUrl.ToString().IndexOf("&userId=") + 8);
                //    auxURL = auxURL.Substring(0, auxURL.IndexOf('&'));

                //    hdrs.Add("userId", auxURL);

                //    dataClientePut.ExternalId = hdrs["externalId"];
                //    dataClientePut.Consultant.TaxId = hdrs["userId"];

                //    hdrs.Add("step", "ATTENDANCE_TYPE");
                //    retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + hdrs["externalId"],
                //               JsonConvert.SerializeObject(dataClientePut),
                //               headers: hdrs,
                //               _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                //               _accept: "application/json, text/plain, */*",
                //               _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");

                //    hdrs["step"] = "SEARCH_PERSON";
                //    retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + hdrs["externalId"],
                //               JsonConvert.SerializeObject(dataClientePut),
                //               headers: hdrs,
                //               _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                //               _accept: "application/json, text/plain, */*",
                //               _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");

                //    hdrs["step"] = "PHONE";
                //    retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + hdrs["externalId"],
                //         JsonConvert.SerializeObject(dataClientePut),
                //         headers: hdrs,
                //         _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                //         _accept: "application/json, text/plain, */*",
                //         _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");

                //    hdrs["step"] = "DATA_PERSONAL";
                //    retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + hdrs["externalId"],
                //                      JsonConvert.SerializeObject(dataClientePut),
                //                      headers: hdrs,
                //                      _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                //                      _accept: "application/json, text/plain, */*",
                //                      _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");

                //    hdrs["step"] = "DATA_BENEFIT";
                //    retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + hdrs["externalId"],
                //                  JsonConvert.SerializeObject(dataClientePut),
                //                  headers: hdrs,
                //                  _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                //                  _accept: "application/json, text/plain, */*",
                //                  _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");


                //    retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + hdrs["externalId"],
                //               JsonConvert.SerializeObject(dataClientePut),
                //               headers: hdrs,
                //               _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                //               _accept: "application/json, text/plain, */*",
                //               _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49");

                //    hdrs["step"] = "DATA_CONFIRM";

                //    retornoPut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + hdrs["externalId"],
                //               JsonConvert.SerializeObject(dataClientePut),
                //               headers: hdrs,
                //               _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                //               _accept: "application/json, text/plain, */*",
                //               _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");

                //    //RETORNANDO VAZIO PARA QUE O PROCESSO SEJA REFEITO COM O CLIENTE JA CADASTRADO
                //    return new DadosClienteProduto();
                //}
                #endregion

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.66 Safari/537.36 Edg/103.0.1264.44");

                response = DoGet(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#/Detail")),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _referer: "https://agibank.force.com/");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/Detail/" + apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("Detail/") + 7),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#/Detail")));

                auxURL = response.Content.Substring(response.Content.IndexOf("var atendimentoViewModel = ") + 27);
                auxURL = auxURL.Substring(0, auxURL.LastIndexOf("}") + 1);

                dynamic atendimentoViewModel = JsonConvert.DeserializeObject(auxURL);

                hdrs.Add("Content-Type", "application/json");

                SimularRequestContext = new JSONObjects.SimularRequest()
                {
                    Operacao = new Operacao()
                    {
                        AtendimentoCodigo = long.Parse(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("Detail/") + 7)),
                        AtendimentoOperacaoCodigo = 0,
                        RegraPagamentoCodigo = 2031,
                        RegraPagamentoNome = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].regraPagamentoNome, //"INSS - 0001.01 - 1º DIA ÚTIL",
                        DomicilioEstadoUf = "MG",
                        InstituicaoCodigo = 3419,
                        GrupoInstituicaoCodigo = 3,
                        NaturezaOcupacaoCodigo = null,
                        SituacaoFuncionalCodigo = null,
                        Matricula = "5369988460",
                        DataPermanenciaOrgao = null,
                        BancoCodigo = "341",
                        NumeroAgencia = "6572",
                        TipoOperacaoCefCodigo = null,
                        NumeroConta = "",
                        TipoContaCodigo = null,
                        ValorRendaBruta = 1212,
                        ValorRendaLiquida = 975.9,
                        ValorTipoDespesa = null,
                        ValorTipoDespesaOriginal = null,
                        NaoPossuiTipoDespesa = true,
                        ValorAditivoDesconto = null,
                        ValorAditivoDescontoOriginal = null,
                        NaoPossuiAditivoDesconto = true,
                        NaoPossuiProventosBeneficio = true,
                        NaoPossuiDebitosBeneficio = true,
                        NaoPossuiEmprestimosBeneficio = true,
                        DiaRecebimentoSalario = null,
                        AlteracaoDadosCadastrais = false,
                        ExibirEmModoSiape = false,
                        UpagSigla = null,
                        UpagNome = null,
                        UpagCodigo = null,
                        MatriculaInstituidor = null,
                        InformouRenda = true,
                        DataRecebimentoSalario = "01/06/ 2022",
                        EspecieCodigo = 9,
                        Especie = new Especie()
                        {
                            EspecieCodigo = 9,
                            EspecieValor = 32,
                            EspecieNome = "Aposentadoria por invalidez previdenciária",
                            TipoEspecieNome = "Aposentadoria",
                            EspecieSituacao = 1,
                            TipoEspecieSituacao = 1,
                            EspecieConsignado = "S",
                            EspecieDomicilio = "S",
                            EspecieAgidebito = "S",
                            TipoEspeciePrazoPermanencia = "N",
                            TipoEspecieDecimoTerceiro = "S",
                            TipoEspecieCodigo = 3,
                            ValorFormatadoSicred = " 32",
                            DataPermanenciaOrgaoObrigatoria = false
                        },
                        DataPermanenciaOrgaoObrigatoria = false,
                        EhInstituicaoGrupoInss = true,
                        EhInstituicaoGrupoSiape = false,
                        MaximoDiasContraCheque = 365,
                        MaximoDiasDataFuturaContraCheque = 45,
                        MeioPagamentoCodigo = 1,
                        MeioPagamentoSimulador = 1,
                        PossuiCartaoRmc = "False",
                        ValorProventosBeneficio = null,
                        ValorProventosBeneficioOriginal = null,
                        ValorDebitosBeneficio = null,
                        ValorDebitosBeneficioOriginal = null,
                        ValorEmprestimosBeneficio = null,
                        ValorEmprestimosBeneficioOriginal = null,
                        ValorMargemConsignavel = null,
                        ValorMargemDisponivel = null,
                        AgenciaDv = null,
                        BureauHigienizacaoCodigo = null,
                        MatriculaMascara = "000.000.000-0",
                        ValorPrestacao = 0,
                        ValorCompra = 80000,
                        StatusContaCorrente = null,
                        BancoAgiplan = null,
                        BancoCedente = null,
                        AgenciaCedente = null,
                        ContaCedente = null,
                        BancoCredito = null,
                        AgenciaCredito = null,
                        ContaCredito = null,
                        TipoOperacaoCreditoCefCodigo = null,
                        TipoContaCreditoCodigo = 1,
                        TipoContaSalario = 3,
                        ContaAtributo = null,
                        UsuarioOperacaoCodigo = 62788,
                        DeclaracaoFinsDeAberturaCodigo = null,
                        IdConta = null,
                        IdCartao = null,
                        ValorAutorizacaoDebitoCp = null,
                        ValorAutorizacaoDebitoSeguro = null,
                        BancoAverbacao = "341",
                        AgenciaAverbacao = "6572",
                        TipoOperacaoCefAverbacaoCodigo = null,
                        ContaAverbacao = null,
                        TipoContaAverbacaoCodigo = 1,
                        ClienteDomiciliado = null,
                        DataCessacaoBeneficio = null,
                        RendaEstimada = null,
                        DiaPagamentoCalculado = false,
                        AnoExpedicaoBeneficio = 2009,
                        ManterSalarioBancoAgiplan = null,
                        BancoNumeroSimulador = "341"
                    },
                    Cpf = dadosCliente.CPF,
                    ValorCredito = 80000,
                    ValorParcela = 0,
                    ManterSalarioContaAgiplan = null,
                    AtualizandoAtendimentoTelefonico = false,
                    AtualizandoSimulacao = false,
                    SimularDemaisPrazos = false
                };

                #region OLD
                //auxURL = Convert.ToString(atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].especie);

                //if (auxURL != "")
                //{
                //    auxURL = auxURL.Substring(auxURL.IndexOf(":") + 3);
                //    auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));

                //    var auxExpecie = Convert.ToString(atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].especie).Replace("{", "").Replace("}", "").Replace("\r\n", "").Trim();

                //    var auxRef = response.Content.Substring(response.Content.IndexOf("\"$id\":\"" + auxURL + "\""));
                //    auxRef = auxRef.Substring(0, auxRef.IndexOf("}"));
                //    auxRef = auxRef.Substring(12);//RETIRA O $id

                //    auxURL = Convert.ToString(atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0]);
                //    auxURL = auxURL.Replace(auxExpecie, auxRef);
                //}
                //else
                //{
                //    auxURL = Convert.ToString(atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0]);
                //}

                //SimularRequestContext.Operacao = JsonConvert.DeserializeObject<Operacao>(auxURL);

                //try
                //{
                //    SimularRequestContext.Operacao = JsonConvert.DeserializeObject<Operacao>(atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0]);
                //    SimularRequestContext.Operacao.RegraPagamentoNome = atendimentoViewModel.atendimentoOperacaoList[0].regraPagamento.nome;
                //    SimularRequestContext.Operacao.DiaRecebimentoSalario = null;
                //    SimularRequestContext.Operacao.AlteracaoDadosCadastrais = false;
                //    SimularRequestContext.Operacao.ExibirEmModoSiape = false;
                //    SimularRequestContext.Operacao.UpagSigla = null;
                //    SimularRequestContext.Operacao.UpagNome = null;
                //    SimularRequestContext.Operacao.InformouRenda = true;
                //    SimularRequestContext.Operacao.DataRecebimentoSalario = DateTime.Parse(atendimentoViewModel.atendimentoOperacaoList[0].dataRecebimentoSalario).ToString("dd/MM/yyyy");
                //    SimularRequestContext.Operacao.EhInstituicaoGrupoSiape = false;
                //    SimularRequestContext.Operacao.MaximoDiasContraCheque = 365;
                //    SimularRequestContext.Operacao.MaximoDiasDataFuturaContraCheque = 45;
                //    SimularRequestContext.Operacao.PossuiCartaoRmc = "False";
                //    SimularRequestContext.Operacao.MatriculaMascara = "000.000.000-0";
                //    SimularRequestContext.Operacao.ValorPrestacao = 0;
                //    SimularRequestContext.Operacao.ValorCompra = 80000;
                //    SimularRequestContext.Operacao.StatusContaCorrente = null;
                //    SimularRequestContext.Operacao.ClienteDomiciliado = null;
                //}
                //catch (Exception ex)
                //{
                //    var teste = ex;
                //}

                //try
                //{

                //    SimularRequestContext.Operacao = new Operacao() { };

                //    SimularRequestContext.Operacao.AtendimentoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].atendimentoCodigo;
                //    SimularRequestContext.Operacao.AtendimentoOperacaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].atendimentoOperacaoCodigo;
                //    SimularRequestContext.Operacao.RegraPagamentoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].regraPagamentoCodigo;
                //    SimularRequestContext.Operacao.RegraPagamentoNome = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].regraPagamentoNome;
                //    SimularRequestContext.Operacao.DomicilioEstadoUf = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DomicilioEstadoUf;
                //    SimularRequestContext.Operacao.InstituicaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].InstituicaoCodigo;
                //    SimularRequestContext.Operacao.GrupoInstituicaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].GrupoInstituicaoCodigo;
                //    SimularRequestContext.Operacao.NaturezaOcupacaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NaturezaOcupacaoCodigo;
                //    SimularRequestContext.Operacao.SituacaoFuncionalCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].SituacaoFuncionalCodigo;
                //    SimularRequestContext.Operacao.Matricula = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].Matricula;
                //    SimularRequestContext.Operacao.DataPermanenciaOrgao = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DataPermanenciaOrgao;
                //    SimularRequestContext.Operacao.BancoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].BancoCodigo;
                //    SimularRequestContext.Operacao.NumeroAgencia = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NumeroAgencia;
                //    SimularRequestContext.Operacao.TipoOperacaoCefCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].TipoOperacaoCefCodigo;
                //    SimularRequestContext.Operacao.NumeroConta = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NumeroConta;
                //    SimularRequestContext.Operacao.TipoContaCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].TipoContaCodigo;
                //    SimularRequestContext.Operacao.ValorRendaBruta = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorRendaBruta;
                //    SimularRequestContext.Operacao.ValorRendaLiquida = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorRendaLiquida;
                //    SimularRequestContext.Operacao.ValorTipoDespesa = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorTipoDespesa;
                //    SimularRequestContext.Operacao.ValorTipoDespesaOriginal = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorTipoDespesaOriginal;
                //    SimularRequestContext.Operacao.NaoPossuiTipoDespesa = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NaoPossuiTipoDespesa;
                //    SimularRequestContext.Operacao.ValorAditivoDesconto = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorAditivoDesconto;
                //    SimularRequestContext.Operacao.ValorAditivoDescontoOriginal = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorAditivoDescontoOriginal;
                //    SimularRequestContext.Operacao.NaoPossuiAditivoDesconto = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NaoPossuiAditivoDesconto;
                //    SimularRequestContext.Operacao.NaoPossuiProventosBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NaoPossuiProventosBeneficio;
                //    SimularRequestContext.Operacao.NaoPossuiDebitosBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NaoPossuiDebitosBeneficio;
                //    SimularRequestContext.Operacao.NaoPossuiEmprestimosBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].NaoPossuiEmprestimosBeneficio;
                //    SimularRequestContext.Operacao.DiaRecebimentoSalario = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DiaRecebimentoSalario;
                //    SimularRequestContext.Operacao.AlteracaoDadosCadastrais = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].AlteracaoDadosCadastrais;
                //    SimularRequestContext.Operacao.ExibirEmModoSiape = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ExibirEmModoSiape;
                //    SimularRequestContext.Operacao.UpagSigla = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].UpagSigla;
                //    SimularRequestContext.Operacao.UpagNome = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].UpagNome;
                //    SimularRequestContext.Operacao.UpagCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].UpagCodigo;
                //    SimularRequestContext.Operacao.MatriculaInstituidor = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].MatriculaInstituidor;
                //    SimularRequestContext.Operacao.InformouRenda = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].InformouRenda;
                //    SimularRequestContext.Operacao.DataRecebimentoSalario = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DataRecebimentoSalario;
                //    SimularRequestContext.Operacao.EspecieCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].EspecieCodigo;
                //    SimularRequestContext.Operacao.DataPermanenciaOrgaoObrigatoria = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DataPermanenciaOrgaoObrigatoria;
                //    SimularRequestContext.Operacao.EhInstituicaoGrupoInss = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].EhInstituicaoGrupoInss;
                //    SimularRequestContext.Operacao.EhInstituicaoGrupoSiape = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].EhInstituicaoGrupoSiape;
                //    SimularRequestContext.Operacao.MaximoDiasContraCheque = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].MaximoDiasContraCheque;
                //    SimularRequestContext.Operacao.MaximoDiasDataFuturaContraCheque = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].MaximoDiasDataFuturaContraCheque;
                //    SimularRequestContext.Operacao.MeioPagamentoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].MeioPagamentoCodigo;
                //    SimularRequestContext.Operacao.MeioPagamentoSimulador = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].MeioPagamentoSimulador;
                //    SimularRequestContext.Operacao.PossuiCartaoRmc = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].PossuiCartaoRmc;
                //    SimularRequestContext.Operacao.ValorProventosBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorProventosBeneficio;
                //    SimularRequestContext.Operacao.ValorProventosBeneficioOriginal = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorProventosBeneficioOriginal;
                //    SimularRequestContext.Operacao.ValorDebitosBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorDebitosBeneficio;
                //    SimularRequestContext.Operacao.ValorDebitosBeneficioOriginal = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorDebitosBeneficioOriginal;
                //    SimularRequestContext.Operacao.ValorEmprestimosBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorEmprestimosBeneficio;
                //    SimularRequestContext.Operacao.ValorEmprestimosBeneficioOriginal = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorEmprestimosBeneficioOriginal;
                //    SimularRequestContext.Operacao.ValorMargemConsignavel = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorMargemConsignavel;
                //    SimularRequestContext.Operacao.ValorMargemDisponivel = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorMargemDisponivel;
                //    SimularRequestContext.Operacao.AgenciaDv = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].AgenciaDv;
                //    SimularRequestContext.Operacao.BureauHigienizacaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].BureauHigienizacaoCodigo;
                //    SimularRequestContext.Operacao.MatriculaMascara = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].MatriculaMascara;
                //    SimularRequestContext.Operacao.ValorPrestacao = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorPrestacao;
                //    SimularRequestContext.Operacao.ValorCompra = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorCompra;
                //    SimularRequestContext.Operacao.StatusContaCorrente = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].StatusContaCorrente;
                //    SimularRequestContext.Operacao.BancoAgiplan = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].BancoAgiplan;
                //    SimularRequestContext.Operacao.BancoCedente = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].BancoCedente;
                //    SimularRequestContext.Operacao.AgenciaCedente = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].AgenciaCedente;
                //    SimularRequestContext.Operacao.ContaCedente = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ContaCedente;
                //    SimularRequestContext.Operacao.BancoCredito = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].BancoCredito;
                //    SimularRequestContext.Operacao.AgenciaCredito = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].AgenciaCredito;
                //    SimularRequestContext.Operacao.ContaCredito = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ContaCredito;
                //    SimularRequestContext.Operacao.TipoOperacaoCreditoCefCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].TipoOperacaoCreditoCefCodigo;
                //    SimularRequestContext.Operacao.TipoContaCreditoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].TipoContaCreditoCodigo;
                //    SimularRequestContext.Operacao.TipoContaSalario = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].TipoContaSalario;
                //    SimularRequestContext.Operacao.ContaAtributo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ContaAtributo;
                //    SimularRequestContext.Operacao.UsuarioOperacaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].UsuarioOperacaoCodigo;
                //    SimularRequestContext.Operacao.DeclaracaoFinsDeAberturaCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DeclaracaoFinsDeAberturaCodigo;
                //    SimularRequestContext.Operacao.IdConta = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].IdConta;
                //    SimularRequestContext.Operacao.IdCartao = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].IdCartao;
                //    SimularRequestContext.Operacao.ValorAutorizacaoDebitoCp = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorAutorizacaoDebitoCp;
                //    SimularRequestContext.Operacao.ValorAutorizacaoDebitoSeguro = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ValorAutorizacaoDebitoSeguro;
                //    SimularRequestContext.Operacao.BancoAverbacao = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].BancoAverbacao;
                //    SimularRequestContext.Operacao.AgenciaAverbacao = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].AgenciaAverbacao;
                //    SimularRequestContext.Operacao.TipoOperacaoCefAverbacaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].TipoOperacaoCefAverbacaoCodigo;
                //    SimularRequestContext.Operacao.ContaAverbacao = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ContaAverbacao;
                //    SimularRequestContext.Operacao.TipoContaAverbacaoCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].TipoContaAverbacaoCodigo;
                //    SimularRequestContext.Operacao.ClienteDomiciliado = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ClienteDomiciliado;
                //    SimularRequestContext.Operacao.DataCessacaoBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DataCessacaoBeneficio;
                //    SimularRequestContext.Operacao.RendaEstimada = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].RendaEstimada;
                //    SimularRequestContext.Operacao.DiaPagamentoCalculado = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].DiaPagamentoCalculado;
                //    SimularRequestContext.Operacao.AnoExpedicaoBeneficio = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].AnoExpedicaoBeneficio;
                //    SimularRequestContext.Operacao.ManterSalarioBancoAgiplan = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].ManterSalarioBancoAgiplan;
                //    SimularRequestContext.Operacao.BancoNumeroSimulador = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].BancoNumeroSimulador;

                //    //SimularRequestContext.Operacao.Especie = new Especie() 
                //    //{ 
                //    //EspecieCodigo = atendimentoViewModel.atendimentoModel.atendimentoOperacaoList[0].especie
                //    //};
                //}
                //catch (Exception ex)
                //{
                //    var teste = ex;
                //}
                #endregion

                dynamic operacao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoOperacaoList[0];
                dynamic cliente = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0];

                SimularRequestContext.Operacao = new Operacao()
                {
                    AtendimentoCodigo = cliente.atendimentoCodigo,
                    AtendimentoOperacaoCodigo = operacao.atendimentoOperacaoCodigo,
                    RegraPagamentoCodigo = cliente.regraPagamentoCodigo,
                    DomicilioEstadoUf = operacao.domicilioEstadoUf,
                    InstituicaoCodigo = operacao.instituicaoCodigo,
                    GrupoInstituicaoCodigo = operacao.grupoInstituicaoCodigo,
                    NaturezaOcupacaoCodigo = cliente.naturezaOcupacaoCodigo,
                    SituacaoFuncionalCodigo = operacao.situacaoFuncionalCodigo,
                    Matricula = cliente.matricula,
                    DataPermanenciaOrgao = operacao.dataPermanenciaOrgao,
                    BancoCodigo = operacao.bancoCodigo,
                    NumeroAgencia = operacao.numeroAgencia,
                    TipoOperacaoCefCodigo = operacao.tipoOperacaoCefCodigo,
                    NumeroConta = operacao.numeroConta,
                    TipoContaCodigo = operacao.tipoContaCodigo,
                    ValorRendaBruta = operacao.valorRendaBruta,
                    ValorRendaLiquida = operacao.valorRendaLiquida,
                    ValorTipoDespesa = operacao.valorTipoDespesa,
                    ValorTipoDespesaOriginal = operacao.valorTipoDespesaOriginal,
                    NaoPossuiTipoDespesa = operacao.naoPossuiTipoDespesa,
                    ValorAditivoDesconto = operacao.valorAditivoDesconto,
                    ValorAditivoDescontoOriginal = operacao.valorAditivoDescontoOriginal,
                    NaoPossuiAditivoDesconto = operacao.naoPossuiAditivoDesconto,
                    NaoPossuiProventosBeneficio = operacao.naoPossuiProventosBeneficio,
                    NaoPossuiDebitosBeneficio = operacao.naoPossuiDebitosBeneficio,
                    NaoPossuiEmprestimosBeneficio = operacao.naoPossuiEmprestimosBeneficio,
                    DiaRecebimentoSalario = operacao.diaRecebimentoSalario,
                    AlteracaoDadosCadastrais = operacao.alteracaoDadosCadastrais,
                    ExibirEmModoSiape = operacao.exibirEmModoSiape,
                    UpagSigla = operacao.upagSigla,
                    UpagNome = operacao.upagNome,
                    UpagCodigo = operacao.upagCodigo,
                    MatriculaInstituidor = operacao.matriculaInstituidor,
                    InformouRenda = operacao.informouRenda,
                    DataRecebimentoSalario = operacao.dataRecebimentoSalario,
                    EspecieCodigo = operacao.especieCodigo,
                    DataPermanenciaOrgaoObrigatoria = operacao.dataPermanenciaOrgaoObrigatoria,
                    EhInstituicaoGrupoInss = operacao.ehInstituicaoGrupoInss,
                    EhInstituicaoGrupoSiape = operacao.ehInstituicaoGrupoSiape,
                    MaximoDiasContraCheque = operacao.maximoDiasContraCheque,
                    MaximoDiasDataFuturaContraCheque = operacao.maximoDiasDataFuturaContraCheque,
                    MeioPagamentoCodigo = operacao.meioPagamentoCodigo,
                    MeioPagamentoSimulador = operacao.meioPagamentoSimulador,
                    PossuiCartaoRmc = operacao.possuiCartaoRmc,
                    ValorProventosBeneficio = operacao.valorProventosBeneficio,
                    ValorProventosBeneficioOriginal = operacao.valorProventosBeneficioOriginal,
                    ValorDebitosBeneficio = operacao.valorDebitosBeneficio,
                    ValorDebitosBeneficioOriginal = operacao.valorDebitosBeneficioOriginal,
                    ValorEmprestimosBeneficio = operacao.valorEmprestimosBeneficio,
                    ValorEmprestimosBeneficioOriginal = operacao.valorEmprestimosBeneficioOriginal,
                    ValorMargemConsignavel = operacao.valorMargemConsignavel,
                    ValorMargemDisponivel = operacao.valorMargemDisponivel,
                    AgenciaDv = operacao.agenciaDv,
                    BureauHigienizacaoCodigo = operacao.bureauHigienizacaoCodigo,
                    MatriculaMascara = operacao.matriculaMascara,
                    ValorPrestacao = operacao.valorPrestacao,
                    ValorCompra = operacao.valorCompra,
                    StatusContaCorrente = operacao.statusContaCorrente,
                    BancoAgiplan = operacao.bancoAgiplan,
                    BancoCedente = operacao.bancoCedente,
                    AgenciaCedente = operacao.agenciaCedente,
                    ContaCedente = operacao.contaCedente,
                    BancoCredito = operacao.bancoCredito,
                    AgenciaCredito = operacao.agenciaCredito,
                    ContaCredito = operacao.contaCredito,
                    TipoOperacaoCreditoCefCodigo = operacao.tipoOperacaoCreditoCefCodigo,
                    TipoContaCreditoCodigo = operacao.tipoContaCreditoCodigo,
                    TipoContaSalario = operacao.tipoContaSalario,
                    ContaAtributo = operacao.contaAtributo,
                    UsuarioOperacaoCodigo = operacao.usuarioOperacaoCodigo,
                    DeclaracaoFinsDeAberturaCodigo = operacao.declaracaoFinsDeAberturaCodigo,
                    IdConta = operacao.idConta,
                    IdCartao = operacao.idCartao,
                    ValorAutorizacaoDebitoCp = operacao.valorAutorizacaoDebitoCp,
                    ValorAutorizacaoDebitoSeguro = operacao.valorAutorizacaoDebitoSeguro,
                    BancoAverbacao = operacao.bancoAverbacao,
                    AgenciaAverbacao = operacao.agenciaAverbacao,
                    TipoOperacaoCefAverbacaoCodigo = operacao.tipoOperacaoCefAverbacaoCodigo,
                    ContaAverbacao = operacao.contaAverbacao,
                    TipoContaAverbacaoCodigo = operacao.tipoContaAverbacaoCodigo,
                    ClienteDomiciliado = operacao.clienteDomiciliado,
                    DataCessacaoBeneficio = operacao.dataCessacaoBeneficio,
                    RendaEstimada = operacao.rendaEstimada,
                    DiaPagamentoCalculado = operacao.diaPagamentoCalculado,
                    AnoExpedicaoBeneficio = operacao.anoExpedicaoBeneficio,
                    ManterSalarioBancoAgiplan = operacao.manterSalarioBancoAgiplan,
                    BancoNumeroSimulador = operacao.bancoNumeroSimulador,
                };

                if (cliente.regraPagamento != null)
                    SimularRequestContext.Operacao.RegraPagamentoNome = cliente.regraPagamento.regraPagamentoNome;

                if (operacao.especie != null)
                {
                    SimularRequestContext.Operacao.Especie = new Especie() { };

                    SimularRequestContext.Operacao.Especie.EspecieCodigo = operacao.especie.especieCodigo;
                    SimularRequestContext.Operacao.Especie.EspecieValor = operacao.especie.especieValor;
                    SimularRequestContext.Operacao.Especie.EspecieNome = operacao.especie.especieNome;
                    SimularRequestContext.Operacao.Especie.TipoEspecieNome = operacao.especie.tipoEspecieNome;
                    SimularRequestContext.Operacao.Especie.EspecieSituacao = operacao.especie.especieSituacao;
                    SimularRequestContext.Operacao.Especie.TipoEspecieSituacao = operacao.especie.tipoEspecieSituacao;
                    SimularRequestContext.Operacao.Especie.EspecieConsignado = operacao.especie.especieConsignado;
                    SimularRequestContext.Operacao.Especie.EspecieDomicilio = operacao.especie.especieDomicilio;
                    SimularRequestContext.Operacao.Especie.EspecieAgidebito = operacao.especie.especieAgidebito;
                    SimularRequestContext.Operacao.Especie.TipoEspeciePrazoPermanencia = operacao.especie.tipoEspeciePrazoPermanencia;
                    SimularRequestContext.Operacao.Especie.TipoEspecieDecimoTerceiro = operacao.especie.tipoEspecieDecimoTerceiro;
                    SimularRequestContext.Operacao.Especie.TipoEspecieCodigo = operacao.especie.tipoEspecieCodigo;
                    SimularRequestContext.Operacao.Especie.ValorFormatadoSicred = operacao.especie.valorFormatadoSicred;
                    SimularRequestContext.Operacao.Especie.DataPermanenciaOrgaoObrigatoria = operacao.especie.dataPermanenciaOrgaoObrigatoria;
                }

                #region NOVO GET
                //hdrs = new Dictionary<string, string>();
                //hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                //hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                //hdrs.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.66 Safari/537.36 Edg/103.0.1264.44");

                //response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/ObterUltimaOperacao?atendimentoCodigo=" + apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("Detail/") + 7) + "&atualizar=false",
                //                 headers: hdrs,
                //                 _accept: "application/json, text/plain, */*",
                //                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#/Detail")));
                #endregion



                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.66 Safari/537.36 Edg/103.0.1264.44");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");

                response = DoPost("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/Simular",
                                 JsonConvert.SerializeObject(SimularRequestContext),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().Substring(0, apexRemoteRSPItem.Result.Content.GevAtendimentoDetailSrcUrl.ToString().IndexOf("#/Detail")));

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

                //var auxSimulacoes = response.Content.Substring(response.Content.IndexOf("\"produtoList\":") + 14);
                //auxSimulacoes = auxSimulacoes.Substring(0, auxProdutos.IndexOf("\"produtoRemovidoList"));
                //auxSimulacoes = auxSimulacoes.Substring(0, auxProdutos.LastIndexOf("],") + 1);

                //List<SimulacaoResponse> simulacoes = JsonConvert.DeserializeObject<List<SimulacaoResponse>>(auxSimulacoes);
                //dadosCliente.Simulacoes = simulacoes.ToList();

            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro = ex.InnerException.Message;
            }

            return dadosCliente;
        }

        public bool ClicaTextoSMS()
        {
            var hdrs = new Dictionary<string, string>();

            hdrs.Add("Accept-Encoding", "gzip, deflate, br");
            hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            hdrs.Add("Host", "agibank.force.com");
            hdrs.Add("Origin", "https://agibank.force.com");
            hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            hdrs.Add("X-SFDC-Page-Scope-Id", "069e2060-87a6-432c-9d3d-03eefa546ec5");

            #region POST 01

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
                "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=" + keys["RegionNameValue"]) +
                "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

            response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                       strPost,
                       headers: hdrs,
                       _referer: "https://agibank.force.com/s/",
                       _accept: "*/*",
                       _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");

            var aux = response.Content.Substring(response.Content.IndexOf("\"},\"regionName\":{\"descriptor\":\"regionName\",\"value\":\"") + 52);
            aux = aux.Substring(0, aux.IndexOf("\""));
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
               "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + keys["NewAccountSimulationFlow"] + "/" + objCliente.Account.Record.Fields.Name.Value.ToLower().Replace(' ', '-') + "tabset-11f0d=" + keys["RegionNameValue"]) +
               "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

            response = DoPost("/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                       strPost,
                       headers: hdrs,
                       _referer: "https://agibank.force.com/s/",
                       _accept: "*/*",
                       _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
            #endregion

            return true;
        }

        #region WEBREQUEST

        private RestResponse DoGet(string url, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null)
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

        private void UpdateHeaders(string _userAgent = "")
        {
            if (_userAgent != "" && _userAgent != userAgent)
                userAgent = _userAgent;
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
        private RestResponse Put(RestRequest rqst)
        {
            var response = client.Put(rqst);

            //UpdateKeys();

            return response;
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

