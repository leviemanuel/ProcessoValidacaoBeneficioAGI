using HtmlAgilityPack;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ValidacaoBeneficioBot.JSONObjects;
using ValidacaoBeneficioBot.Objs;

namespace ValidacaoBeneficioBot
{
    public class Bot3
    {
        private string urlSite = "https://agibank.force.com";
        private string urlAPI = "https://api.agibank.com.br";
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
        AuraContextRequest context;
        CurrentUserResponse currentUser;
        RecordResponse recordResponse;
        dynamic VFRMRemotingProviderImpl;

        public async void Teste()
        {
            try
            {
                client = new RestClient(urlSite);

                HttpResponseMessage response2;

                var hdrs = new Dictionary<string, string>();

                #region /s/

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response2 = await DoGetTask(urlSite + "/s/",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");

                #endregion

                #region /services/auth/sso/Agibank?startURL=%2Fs%2F 
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response2 = await DoGetTask(urlSite + "/services/auth/sso/Agibank?startURL=%2Fs%2F",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                    _referer: "https://agibank.force.com/s/");
                #endregion

                #region oauth2/authorize?response_type=code&client_id=WklRjqY1Ei_ftgpfpDCHruwQEOka&redirect_uri=https%3A%2F%2Fagibank.force.com%2Fservices%2Fauthcallback%2FAgibank&scope=openid+refresh_token&state=CAAAAYIemX89MDAwMDAwMDAwMDAwMDAwAAAA7k0OZktYik0OM4HM6xVpOxf-wKcxkCmOUZIJnfT3GVh_E3M3zRTjcQIQRFKEOnI0JyNANCvwo7WU2qox_6MLArE81gA3aD1RQ6sdokvNnpepc2F_34AkpnTs9Jmn4EccQBfCvBYftAwpgr8TefIn1gM6tNdzTKvyYfIBsv5hQMzCb7wHoGuMFF-i-4vo3f7fDlZhhZWOsd8vWXWrL6quKkq60S7dk8xTj1av2lglWj2PC7aNgP6HPwq7SUpkZk5A1Q%3D%3D
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                //response = DoGet(response.Headers.Where(h => h.Name == "Location").FirstOrDefault().Value.ToString(),
                //    headers: hdrs,
                //    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                //    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                //    _referer: "https://agibank.force.com/");
                #endregion

                #region /authenticationendpoint/login.do?client_id=WklRjqY1Ei_ftgpfpDCHruwQEOka&commonAuthCallerPath=%2Foauth2%2Fauthorize&forceAuth=false&passiveAuth=false&redirect_uri=https%3A%2F%2Fagibank.force.com%2Fservices%2Fauthcallback%2FAgibank&response_type=code&scope=openid+refresh_token&state=CAAAAYIemX89MDAwMDAwMDAwMDAwMDAwAAAA7k0OZktYik0OM4HM6xVpOxf-wKcxkCmOUZIJnfT3GVh_E3M3zRTjcQIQRFKEOnI0JyNANCvwo7WU2qox_6MLArE81gA3aD1RQ6sdokvNnpepc2F_34AkpnTs9Jmn4EccQBfCvBYftAwpgr8TefIn1gM6tNdzTKvyYfIBsv5hQMzCb7wHoGuMFF-i-4vo3f7fDlZhhZWOsd8vWXWrL6quKkq60S7dk8xTj1av2lglWj2PC7aNgP6HPwq7SUpkZk5A1Q%3D%3D&tenantDomain=carbon.super&sessionDataKey=00cf04f0-9ef4-402e-ad05-519b64cc9564&relyingParty=WklRjqY1Ei_ftgpfpDCHruwQEOka&type=oidc&sp=admin_Salesforce_PRODUCTION&isSaaSApp=false&authenticators=BasicAuthenticator:LOCAL 
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                //response = DoGet(response.Headers.Where(h => h.Name == "Location").FirstOrDefault().Value.ToString(),
                //    headers: hdrs,
                //    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                //    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                //    _referer: "https://agibank.force.com/");

                //var urlItens = response2.ResponseUri.Query.Split('&');

                var urlItens = response2.RequestMessage.RequestUri.Query.Split('&');

                UpdateKeys("sessionDataKey", urlItens.FirstOrDefault(i => i.Contains("sessionDataKey=")).Split('=')[1]);
                UpdateKeys("scope", urlItens.FirstOrDefault(i => i.Contains("scope=")).Split('=')[1]);
                UpdateKeys("state", urlItens.FirstOrDefault(i => i.Contains("state=")).Split('=')[1]);
                UpdateKeys("tenantDomain", urlItens.FirstOrDefault(i => i.Contains("tenantDomain=")).Split('=')[1]);
                UpdateKeys("client_id", urlItens.FirstOrDefault(i => i.Contains("client_id=")).Split('=')[1]);
                UpdateKeys("relyingParty", urlItens.FirstOrDefault(i => i.Contains("relyingParty=")).Split('=')[1]);
                UpdateKeys("type", urlItens.FirstOrDefault(i => i.Contains("type=")).Split('=')[1]);
                UpdateKeys("sp", urlItens.FirstOrDefault(i => i.Contains("sp=")).Split('=')[1]);
                UpdateKeys("authenticators", urlItens.FirstOrDefault(i => i.Contains("authenticators=")).Split('=')[1]);
                #endregion

                #region /logincontext?sessionDataKey=00cf04f0-9ef4-402e-ad05-519b64cc9564&relyingParty=WklRjqY1Ei_ftgpfpDCHruwQEOka&tenantDomain=carbon.super&_=1658369853473
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "api.agibank.com.br");

                var auxURL = response.Content.Substring(response.Content.IndexOf("input type=\"hidden\" name=\"sessionDataKey\" value='") + 49);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("'/>"));
                UpdateKeys("sessionDataKey", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("if(clientIdsHashArray.includes(\"") + 49);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("relyingParty", auxURL);

                response2 = await DoGetTask("https://api.agibank.com.br/logincontext?sessionDataKey=" + keys["sessionDataKey"] + "&relyingParty=" + keys["relyingParty"] + "&tenantDomain=carbon.super&_=1658369853473",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                    _referer: response.ResponseUri.ToString());
                #endregion
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
            }
        }

        public bool BotInicialize(ref string erro)
        {
            try
            {
                client = new RestClient(urlSite);

                var hdrs = new Dictionary<string, string>();

                #region /s/

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet(urlSite + "/s/",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33");

                #endregion

                #region /services/auth/sso/Agibank?startURL=%2Fs%2F 
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet(urlSite + "/services/auth/sso/Agibank?startURL=%2Fs%2F",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                    _referer: "https://agibank.force.com/s/");
                #endregion

                #region oauth2/authorize?response_type=code&client_id=WklRjqY1Ei_ftgpfpDCHruwQEOka&redirect_uri=https%3A%2F%2Fagibank.force.com%2Fservices%2Fauthcallback%2FAgibank&scope=openid+refresh_token&state=CAAAAYIemX89MDAwMDAwMDAwMDAwMDAwAAAA7k0OZktYik0OM4HM6xVpOxf-wKcxkCmOUZIJnfT3GVh_E3M3zRTjcQIQRFKEOnI0JyNANCvwo7WU2qox_6MLArE81gA3aD1RQ6sdokvNnpepc2F_34AkpnTs9Jmn4EccQBfCvBYftAwpgr8TefIn1gM6tNdzTKvyYfIBsv5hQMzCb7wHoGuMFF-i-4vo3f7fDlZhhZWOsd8vWXWrL6quKkq60S7dk8xTj1av2lglWj2PC7aNgP6HPwq7SUpkZk5A1Q%3D%3D
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                //response = DoGet(response.Headers.Where(h => h.Name == "Location").FirstOrDefault().Value.ToString(),
                //    headers: hdrs,
                //    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                //    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                //    _referer: "https://agibank.force.com/");
                #endregion

                #region /authenticationendpoint/login.do?client_id=WklRjqY1Ei_ftgpfpDCHruwQEOka&commonAuthCallerPath=%2Foauth2%2Fauthorize&forceAuth=false&passiveAuth=false&redirect_uri=https%3A%2F%2Fagibank.force.com%2Fservices%2Fauthcallback%2FAgibank&response_type=code&scope=openid+refresh_token&state=CAAAAYIemX89MDAwMDAwMDAwMDAwMDAwAAAA7k0OZktYik0OM4HM6xVpOxf-wKcxkCmOUZIJnfT3GVh_E3M3zRTjcQIQRFKEOnI0JyNANCvwo7WU2qox_6MLArE81gA3aD1RQ6sdokvNnpepc2F_34AkpnTs9Jmn4EccQBfCvBYftAwpgr8TefIn1gM6tNdzTKvyYfIBsv5hQMzCb7wHoGuMFF-i-4vo3f7fDlZhhZWOsd8vWXWrL6quKkq60S7dk8xTj1av2lglWj2PC7aNgP6HPwq7SUpkZk5A1Q%3D%3D&tenantDomain=carbon.super&sessionDataKey=00cf04f0-9ef4-402e-ad05-519b64cc9564&relyingParty=WklRjqY1Ei_ftgpfpDCHruwQEOka&type=oidc&sp=admin_Salesforce_PRODUCTION&isSaaSApp=false&authenticators=BasicAuthenticator:LOCAL 
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                //response = DoGet(response.Headers.Where(h => h.Name == "Location").FirstOrDefault().Value.ToString(),
                //    headers: hdrs,
                //    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                //    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                //    _referer: "https://agibank.force.com/");

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
                #endregion

                #region /logincontext?sessionDataKey=00cf04f0-9ef4-402e-ad05-519b64cc9564&relyingParty=WklRjqY1Ei_ftgpfpDCHruwQEOka&tenantDomain=carbon.super&_=1658369853473
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "api.agibank.com.br");

                var auxURL = response.Content.Substring(response.Content.IndexOf("input type=\"hidden\" name=\"sessionDataKey\" value='") + 49);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("'/>"));
                UpdateKeys("sessionDataKey", auxURL);

                auxURL = response.Content.Substring(response.Content.IndexOf("if(clientIdsHashArray.includes(\"") + 49);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                UpdateKeys("relyingParty", auxURL);

                response = DoGet("https://api.agibank.com.br/logincontext?sessionDataKey=" + keys["sessionDataKey"] + "&relyingParty=" + keys["relyingParty"] + "&tenantDomain=carbon.super&_=1658369853473",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                    _referer: response.ResponseUri.ToString());
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }
        }

        public bool Login(string user, string pass, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                #region POST /commonauth 
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "api.agibank.com.br");
                hdrs.Add("Origin", "https://api.agibank.com.br");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded");

                var auxReferer = urlAPI + @"authenticationendpoint/login.do?client_id=" + keys["client_id"] + "&" +
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
                                        "authenticators=" + keys["authenticators"];

                response = DoPost(urlAPI + "/commonauth",
                                  @"username=" + user + "&password=" + WebUtility.UrlEncode(pass) + "&sessionDataKey=" + keys["sessionDataKey"],
                                  headers: hdrs,
                                  _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                  _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.39",
                                  _referer: auxReferer);

                var url = "";
                var auxURL = "<meta http-equiv=\"Refresh\" content=\"0; URL=https://agibank.force.com/secur/frontdoor.jsp?sid=";
                auxURL = response.Content.Substring(response.Content.IndexOf(auxURL) + auxURL.Length);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));

                url = "/secur/frontdoor.jsp?sid=" + WebUtility.HtmlDecode(auxURL);
                #endregion

                #region GET /oauth2/authorize?sessionDataKey=b68ef3b2-156c-4bb4-b3fc-fe7fb52764f7
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                //response = DoGet("/oauth2/authorize?sessionDataKey=" + keys["sessionDataKey"],
                //             headers: hdrs,
                //             _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                //             _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                //             _referer: auxReferer);
                #endregion

                #region GET /services/authcallback/Agibank?code=bd05feb1-fd93-34b1-8c99-57c2d1b359bc&state=CAAAAYIexYHoMDAwMDAwMDAwMDAwMDAwAAAA7tbSxkWgNMqz7VY5vRN1B_d0cNMDuTJEIBd28ZH7NWcrog0qzB46v74QXbXZKj-4zq0QjoDstJnqTpdgi9cVE6K3mSOvSv5NilesxghEjd1IHMvHeX2PeNjG0eKBR98r0LvN2tsP3RG2t4Kf2z6dtQDDqRF7DTLk0U69vonfUNbdWOAUqvq_aVUnFdsW3g2_ZRSU6UeWidPP5fe4fLchTJQuwOOktl4Ke98gGxQafXiz&session_state=4195e6071b504406f7bd3f17472b86cebc4df8814d142a8766ab9ecc280fd36f.Qi03II3GCrSUNuqKsZ6z7A
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                //response = DoGet(response.ResponseUri.ToString(),
                //             headers: hdrs,
                //             _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                //             _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                //             _referer: "https://api.agibank.com.br/");

                #endregion

                #region GET /secur/frontdoor.jsp?sid=00D5A0000015Tb0%21AQMAQOvtxqEtfceMHCHF523.yJn3qK8AVhFnaMhzkb6WfVYj.dCKdQyGXJNo1NhROR381yMl_Hlj9TnVaXoNhltcY_mvHTRO&retURL=%2Fs%2F&apv=1&allp=1&untethered=&cshc=e00000CpOw5A0000015Tb0&refURL=https%3A%2F%2Fagibank.force.com%2Fsecur%2Ffrontdoor.jsp&fromSsoFlow=1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                auxURL = RetornaAuxSubstring(response.Content, "SfdcApp.projectOneNavigator.handleRedirect('", "')");

                response = DoGet(auxURL,
                             headers: hdrs,
                             _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                             _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                             _referer: response.ResponseUri.ToString());

                #endregion

                NavegaHome(response.ResponseUri.ToString());

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }
        }

        private bool NavegaHome(string auxReferer)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region GET /s/
                hdrs = new Dictionary<string, string>();
                auxReferer = auxURL;

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet(urlSite + "/s/",
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                    _referer: auxReferer);

                context = JsonConvert.DeserializeObject<JSONObjects.AuraContextRequest>(RetornaAuxSubstring(response.Content, "&aura.app=markup://siteforce:communityApp&aura.mode=PROD\",\"context\":", ",\"attributes\":{\""));

                var auraToken = RetornaAuxSubstring(response.Content, "\",\"pathPrefix\":\"\",\"token\":\"", "\",\"staticResourceDomain");
                UpdateKeys("aura.token", auraToken);
                #endregion

                #region GET /s/sfsites/l/%7B%22mode%22%3A%22PROD%22%2C%22app%22%3A%22siteforce%3AcommunityApp%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fsiteforce%3AcommunityApp%22%3A%22LpCTzuyqBUeCUwKaXXlwUA%22%7D%2C%22mlr%22%3A1%2C%22pathPrefix%22%3A%22%22%2C%22dns%22%3A%22c%22%2C%22ls%22%3A1%2C%22lrmc%22%3A%22533941497%22%7D/bootstrap.js?aura.attributes=%7B%22authenticated%22%3A%22true%22%2C%22brandingSetId%22%3A%22174f992c-43e9-44fd-8cea-8213cf228cc1%22%2C%22formFactor%22%3A%22LARGE%22%2C%22isHybrid%22%3A%22false%22%2C%22language%22%3A%22pt_BR%22%2C%22pageId%22%3A%2258fa18a5-efd3-4c30-9bdf-887f8c780504%22%2C%22publishedChangelistNum%22%3A%2225%22%2C%22schema%22%3A%22Published%22%2C%22themeLayoutType%22%3A%22Inner%22%2C%22viewType%22%3A%22Published%22%7D&jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..p_HLOwAguZrx8PpV0kpURoqll47qCAglrAKJ-DD0kFg
                hdrs = new Dictionary<string, string>();
                auxReferer = auxURL;

                auxURL = response.Content;
                auxURL = auxURL.Substring(auxURL.LastIndexOf("><script src=\"/s/sfsites/l/%7B%22mode%22%3A%22PROD") + 14);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\"></"));

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet(auxURL,
                    headers: hdrs,
                    _accept: "*/*",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                    _referer: "https://agibank.force.com/s/");

                auxURL = RetornaAuxSubstring(response.Content, "values\":{\"CurrentUser\":", "}},{\"type");

                currentUser = JsonConvert.DeserializeObject<CurrentUserResponse>(auxURL);
                #endregion

                #region POST /s/sfsites/aura?r=0&ui-comm-runtime-components-aura-components-siteforce-controller.PubliclyCacheableComponentLoader.getAudienceTargetedPageComponent=1

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                var objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "2;a",
                    Descriptor = "serviceComponent://ui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableComponentLoaderController/ACTION$getAudienceTargetedPageComponent",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Attributes = new Attributes()
                        {
                            ViewId = new Guid("e962af37-6fb7-4647-b043-6844784a6ad3"),//TODO
                            RouteType = "home",
                            ThemeLayoutType = "Inner",
                            Params = new AttributesParams()
                            {
                                Viewid = new Guid("7170e41d-7e6f-4a3d-94ba-ac63c2576cb4"),//TODO
                                ViewUddid = "",
                                EntityName = "",
                                AudienceName = "",
                                PicassoId = "",
                                RouteId = ""
                            },
                            PageLoadType = "AUDIENCE_TARGETED_PAGE_CONTENT",
                            HasAttrVaringCmps = false
                        },
                        PublishedChangelistNum = 25,
                        BrandingSetId = new Guid("174f992c-43e9-44fd-8cea-8213cf228cc1")
                    }
                });

                //context.Loaded.ComponentMarkupFlowruntimeFlowRuntimeForFlexiPage = "-5daKiCvGVZANVvqKEoy2Q";
                //context.Loaded.ComponentMarkupForceCommunityDashboard = "AiCYJU2L1bxRJx7dSn1bjw";
                //context.Loaded.ComponentMarkupForceCommunityFlowCommunity = "2aHA7kue5UGz8eJ4g8pZbQ";
                //context.Loaded.ComponentMarkupForceCommunityGlobalNavigation = "hMmasIzVdWEZ3ka9-lPn0w";
                //context.Loaded.ComponentMarkupForceCommunityGroupAnnouncement = "P4M42Q1bH-ULweP4K3yAHg";
                //context.Loaded.ComponentMarkupForceCommunityRichTextInline = "HRtpLMxEd9S_qFnNhOYX_Q";
                //context.Loaded.ComponentMarkupInstrumentationO11YCoreCollector = "8089lZkrpgraL8-V8KZXNw";
                //context.Loaded.ComponentMarkupSiteforceRegionLoaderWrapper = "iB-z_tJpr_VgV-1n1WmpOg";

                var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                    "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                    "&aura.pageURI=%2Fs%2F" +
                    "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-comm-runtime-components-aura-components-siteforce-controller.PubliclyCacheableComponentLoader.getAudienceTargetedPageComponent=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");
                //}\n};\n});\n"}],"loaded":{
                auxURL = response.Content.Substring(response.Content.IndexOf("{\"APPLICATION@markup://siteforce:communityApp"));
                auxURL = auxURL.Substring(0, auxURL.IndexOf(",\"globalValueProviders"));

                context.Loaded = JsonConvert.DeserializeObject<Loaded>(auxURL);

                #endregion

                #region POST /s/sfsites/aura?r=1&aura.Component.getComponent=1&ui-analytics-dashboard-components-lightning.DashboardComponent.getAdditionalParameters=1&ui-analytics-dashboard-components-lightning.DashboardComponent.isFeedEnabled=1&ui-chatter-components-aura-components-forceChatter-groups.GroupAnnouncement.getAnnouncement=1&ui-chatter-components-messages.Messages.getMessagingPermAndPref=1&ui-communities-components-aura-components-forceCommunity-flowCommunity.FlowCommunity.canViewFlow=2&ui-communities-components-aura-components-forceCommunity-richText.RichText.getParsedRichTextValue=4&ui-force-components-controllers-hostConfig.HostConfig.getConfigData=1&ui-self-service-components-profileMenu.ProfileMenu.getProfileMenuResponse=1 HTTP/1.1

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                strPost = "message=%7B%22actions%22%3A%5B%7B%22id%22%3A%22142%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.chatter.components.messages.MessagesController%2FACTION%24getMessagingPermAndPref%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%2241%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.self.service.components.profileMenu.ProfileMenuController%2FACTION%24getProfileMenuResponse%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FselfService%3AprofileMenuAPI%22%2C%22params%22%3A%7B%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22147%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.force.components.controllers.hostConfig.HostConfigController%2FACTION%24getConfigData%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22106%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24isFeedEnabled%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22dashboardId%22%3A%2201Z6e000001DeZoEAK%22%7D%7D%2C%7B%22id%22%3A%22107%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24getAdditionalParameters%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%7D%2C%7B%22id%22%3A%22149%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%20style%3D%5C%22text-align%3A%20center%3B%5C%22%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.footer_agi_expanded.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22116%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FforceCommunity%3AflowCommunity%22%2C%22params%22%3A%7B%22flowName%22%3A%22OrderProductSearchFlow%22%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22150%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.chatter.components.aura.components.forceChatter.groups.GroupAnnouncementController%2FACTION%24getAnnouncement%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22groupId%22%3A%220F96e000000fysaCAA%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22151%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cb%20style%3D%5C%22color%3A%20rgb(68%2C%2068%2C%2068)%3B%20font-size%3A%2036px%3B%5C%22%3EQue%20bom%20te%20ver%20por%20aqui%2C%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%200%2C%200)%3B%20font-size%3A%2036px%3B%5C%22%3E%20%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%20102%2C%20204)%3B%20font-size%3A%2036px%3B%5C%22%3ECaio%3C%2Fb%3E%3Cb%20style%3D%5C%22font-size%3A%2036px%3B%5C%22%3E%20%3A)%3C%2Fb%3E%3C%2Fp%3E%3Cp%3E%26nbsp%3B%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22152%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.digitacao.1%7D%5C%22%20style%3D%5C%22width%3A%20568.641px%3B%20height%3A%2078.4219px%3B%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22130%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FforceCommunity%3AflowCommunity%22%2C%22params%22%3A%7B%22flowName%22%3A%22NewAccountSimulationFlow%22%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22153%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.buscar_proposta.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22148%3Ba%22%2C%22descriptor%22%3A%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22name%22%3A%22markup%3A%2F%2FforceCommunity%3AglobalNavigation%22%2C%22attributes%22%3A%7B%22NavigationMenuEditorRefresh%22%3A%22Default_Navigation1%22%2C%22hideHomeText%22%3Afalse%2C%22hideAppLauncher%22%3Afalse%7D%7D%7D%5D%7D&aura.context=%7B%22mode%22%3A%22PROD%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22app%22%3A%22siteforce%3AcommunityApp%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fsiteforce%3AcommunityApp%22%3A%22LpCTzuyqBUeCUwKaXXlwUA%22%2C%22COMPONENT%40markup%3A%2F%2Fflowruntime%3AflowRuntimeForFlexiPage%22%3A%22-5daKiCvGVZANVvqKEoy2Q%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3Adashboard%22%3A%22AiCYJU2L1bxRJx7dSn1bjw%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3AflowCommunity%22%3A%222aHA7kue5UGz8eJ4g8pZbQ%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3AglobalNavigation%22%3A%22hMmasIzVdWEZ3ka9-lPn0w%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3AgroupAnnouncement%22%3A%22P4M42Q1bH-ULweP4K3yAHg%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3ArichTextInline%22%3A%22HRtpLMxEd9S_qFnNhOYX_Q%22%2C%22COMPONENT%40markup%3A%2F%2Finstrumentation%3Ao11yCoreCollector%22%3A%228089lZkrpgraL8-V8KZXNw%22%2C%22COMPONENT%40markup%3A%2F%2Fsiteforce%3AregionLoaderWrapper%22%3A%22iB-z_tJpr_VgV-1n1WmpOg%22%7D%2C%22dn%22%3A%5B%5D%2C%22globals%22%3A%7B%7D%2C%22uad%22%3Afalse%7D&aura.pageURI=%2Fs%2F" +
                    "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.Component.getComponent=1&ui-analytics-dashboard-components-lightning.DashboardComponent.getAdditionalParameters=1&ui-analytics-dashboard-components-lightning.DashboardComponent.isFeedEnabled=1&ui-chatter-components-aura-components-forceChatter-groups.GroupAnnouncement.getAnnouncement=1&ui-chatter-components-messages.Messages.getMessagingPermAndPref=1&ui-communities-components-aura-components-forceCommunity-flowCommunity.FlowCommunity.canViewFlow=2&ui-communities-components-aura-components-forceCommunity-richText.RichText.getParsedRichTextValue=4&ui-force-components-controllers-hostConfig.HostConfig.getConfigData=1&ui-self-service-components-profileMenu.ProfileMenu.getProfileMenuResponse=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");
                UpdateKeys("currentNetworkId", RetornaAuxSubstring(response.Content, ",\"currentNetworkId\":\"", "\""));

                auxURL = RetornaAuxSubstring(response.Content, "\"loaded\":", ",\"globalValueProviders");

                context.Loaded = JsonConvert.DeserializeObject<Loaded>(auxURL);
                #endregion

                #region POST /s/sfsites/aura?r=2&ui-comm-runtime-components-aura-components-siteforce-controller.PubliclyCacheableAttributeLoader.getComponentAttributes=1 

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "143;a",
                    Descriptor = "serviceComponent://ui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableAttributeLoaderController/ACTION$getComponentAttributes",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        ViewOrThemeLayoutId = new Guid("4d92a357-2ba2-417f-93ee-8f53cdb55dd5"),//TODO
                        PublishedChangelistNum = 25,
                        AudienceKey = "11FxOYiYfpMxmANj4kGJzg"//TODO
                    },
                    Version = "55.0",
                    Storable = true
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-comm-runtime-components-aura-components-siteforce-controller.PubliclyCacheableAttributeLoader.getComponentAttributes=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=3&ui-analytics-dashboard-components-lightning.DashboardComponent.getSitePathPrefix=1 HTTP/1.1

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "154;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardComponentController/ACTION$getSitePathPrefix",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-analytics-dashboard-components-lightning.DashboardComponent.getSitePathPrefix=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region GET /desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK&displayMode=view&networkId=0DB6e000000k9hL&userId=0056e00000CpOw5AAF HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet("https://agibank.force.com/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK&displayMode=view&networkId=" + keys["currentNetworkId"] + "&userId=" + currentUser.Id,
                    headers: hdrs,
                    _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                    _referer: "https://agibank.force.com/s/");

                var newAuraToken = RetornaAuxSubstring(response.Content, "\",\"pathPrefix\":\"\",\"token\":\"", "\",\"staticResourceDomain");
                UpdateKeys("new.aura.token", newAuraToken);

                UpdateKeys("aura.context", RetornaAuxSubstring(WebUtility.UrlDecode(response.Content), "\"desktopDashboards:dashboardApp\",\"loaded\":", ",\"styleContext\""));

                #endregion

                #region POST /s/sfsites/aura?r=4&ui-communities-components-aura-components-forceCommunity-navigationMenu.NavigationMenuDataProvider.getNavigationMenu=1&ui-interaction-runtime-components-controllers.FlowRuntime.runInterview=2 HTTP/1.1

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "192;a",
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
                    Id = "212;a",
                    Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$runInterview",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        FlowDevName = "NewAccountSimulationFlow",
                        Arguments = "[]",
                        EnableTrace = false,
                        EnableRollbackMode = false,
                        DebugAsUserId = ""
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "221;a",
                    Descriptor = "serviceComponent://ui.communities.components.aura.components.forceCommunity.navigationMenu.NavigationMenuDataProviderController/ACTION$getNavigationMenu",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        NavigationLinkSetIdOrName = "Default_Navigation1",
                        IncludeImageUrl = false,
                        AddHomeMenuItem = true,
                        MenuItemTypesToSkip = new List<string>() { "SystemLink", "Event" },
                        MasterLabel = "Default Navigation"
                    },
                    Storable = true
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-communities-components-aura-components-forceCommunity-navigationMenu.NavigationMenuDataProvider.getNavigationMenu=1&ui-interaction-runtime-components-controllers.FlowRuntime.runInterview=2",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                auxURL = response.Content.Substring(response.Content.LastIndexOf("serializedEncodedState\":\"") + 25);
                auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));
                var serializedEncodedState = auxURL;

                UpdateKeys("serializedEncodedState", serializedEncodedState);

                #endregion

                #region POST /s/sfsites/aura?r=5&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1 HTTP/1.1

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                strPost = "message=%7B%22actions%22%3A%5B%7B%22id%22%3A%22252%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.instrumentation.components.beacon.InstrumentationBeaconController%2FACTION%24sendData%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22batch%22%3A%5B%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A2283.79%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AcommunityApp%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22user%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communitynavigation%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22link%5C%22%2C%5C%22scope%5C%22%3A%5C%22communitynavigation%5C%22%2C%5C%22context%5C%22%3A%7B%5C%22unifiedEventType%5C%22%3A%5C%22COMMUNITY_PAGE_NAVIGATION%5C%22%2C%5C%22referrer%5C%22%3A%5C%22%2Fs%2F%5C%22%2C%5C%22requestURI%5C%22%3A%5C%22%2Fs%2F%5C%22%2C%5C%22entityId%5C%22%3Anull%7D%7D%2C%5C%22sequence%5C%22%3A1%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A2328.89%2C%5C%22duration%5C%22%3A0%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22resolveUrl%5C%22%2C%5C%22pageType%5C%22%3A%5C%22comm__namedPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22Home%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3AnewDefs%5C%22%2C%5C%22ts%5C%22%3A2342.5%2C%5C%22duration%5C%22%3A0%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22newDefs%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22componentDefs%5C%22%3A%5B%5C%22markup%3A%2F%2Fsiteforce%3AruntimeComponent%5C%22%2C%5C%22layout%3A%2F%2Fsiteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c1658372762824%5C%22%5D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A2345.1%2C%5C%22duration%5C%22%3A7%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3Anull%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c1658372762824%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3Anull%7D%5D%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22Audience-pageLoaderCreate%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Abootstrap%5C%22%2C%5C%22ts%5C%22%3A0%2C%5C%22duration%5C%22%3A2283%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2019.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%222%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Atrue%2C%5C%22cmp%5C%22%3A%5C%22siteforce%3ApubliclyCacheableComponentLoader%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableComponentLoaderController%2FACTION%24getAudienceTargetedPageComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A92%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A124%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A9%2C%5C%22duration%5C%22%3A333%7D%5D%2C%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A221%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22siteforce%3AcommunityApp%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A176.8%7D%2C%7B%5C%22name%5C%22%3A%5C%22ui%3Alabel%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A0.59%7D%2C%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c25%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A35.09%7D%2C%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c1658372762824%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A8.5%7D%5D%7D%5D%7D%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22bootstrap%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22framework%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22cache%5C%22%3A%7B%5C%22appCache%5C%22%3Afalse%2C%5C%22gvps%5C%22%3Atrue%7D%2C%5C%22execInlineJs%5C%22%3A787%2C%5C%22appCssLoading%5C%22%3Anull%2C%5C%22visibilityStateStart%5C%22%3A%5C%22visible%5C%22%2C%5C%22execAuraJs%5C%22%3A914%2C%5C%22runInitAsync%5C%22%3A953%2C%5C%22runAfterContextCreated%5C%22%3A1234%2C%5C%22runAfterInitDefsReady%5C%22%3A1234%2C%5C%22execBootstrapJs%5C%22%3A1940%2C%5C%22runAfterBootstrapReady%5C%22%3A1943%2C%5C%22AuraFrameworkEPT%5C%22%3A1943%2C%5C%22appCreationStart%5C%22%3A1989%2C%5C%22appCreationEnd%5C%22%3A2167%2C%5C%22appRenderingStart%5C%22%3A2167%2C%5C%22appRenderingEnd%5C%22%3A2283%2C%5C%22bootstrapEPT%5C%22%3A2283%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22mode%5C%22%3A%5C%22PROD%5C%22%2C%5C%22maxAllowedParallelXHRCounts%5C%22%3A6%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22timing%5C%22%3A%7B%5C%22navigationStart%5C%22%3A1658372759439%2C%5C%22fetchStart%5C%22%3A1658372759445%2C%5C%22readyStart%5C%22%3A6%2C%5C%22dnsStart%5C%22%3A1658372759445%2C%5C%22dnsEnd%5C%22%3A1658372759445%2C%5C%22lookupDomainTime%5C%22%3A0%2C%5C%22connectStart%5C%22%3A1658372759445%2C%5C%22connectEnd%5C%22%3A1658372759445%2C%5C%22connectTime%5C%22%3A0%2C%5C%22requestStart%5C%22%3A1658372759447%2C%5C%22responseStart%5C%22%3A1658372760164%2C%5C%22responseEnd%5C%22%3A1658372760166%2C%5C%22requestTime%5C%22%3A719%2C%5C%22domLoading%5C%22%3A1658372760171%2C%5C%22domInteractive%5C%22%3A1658372761775%2C%5C%22initDomTreeTime%5C%22%3A1609%2C%5C%22contentLoadStart%5C%22%3A1658372761775%2C%5C%22contentLoadEnd%5C%22%3A1658372761775%2C%5C%22domComplete%5C%22%3A1658372761776%2C%5C%22domReadyTime%5C%22%3A1%2C%5C%22loadEventStart%5C%22%3A1658372761776%2C%5C%22loadEventEnd%5C%22%3A1658372761776%2C%5C%22loadEventTime%5C%22%3A0%2C%5C%22loadTime%5C%22%3A2331%2C%5C%22unloadEventStart%5C%22%3A1658372760170%2C%5C%22unloadEventEnd%5C%22%3A1658372760170%2C%5C%22unloadEventTime%5C%22%3A0%2C%5C%22appCacheTime%5C%22%3A0%2C%5C%22redirectTime%5C%22%3A0%7D%2C%5C%22type%5C%22%3A%5C%22WARM%5C%22%2C%5C%22allRequests%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2Fs%2F%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22navigation%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22duration%5C%22%3A726%2C%5C%22startTime%5C%22%3A0%2C%5C%22fetchStart%5C%22%3A5%2C%5C%22serverTime%5C%22%3A386%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A8%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A140033%2C%5C%22encodedBodySize%5C%22%3A139733%2C%5C%22decodedBodySize%5C%22%3A139733%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A724%2C%5C%22transfer%5C%22%3A1%7D%2C%7B%5C%22name%5C%22%3A%5C%22%2Faura_%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A22%2C%5C%22startTime%5C%22%3A735%2C%5C%22fetchStart%5C%22%3A735%2C%5C%22serverTime%5C%22%3A57%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A735%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A795001%2C%5C%22decodedBodySize%5C%22%3A795001%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2%2C%5C%22transfer%5C%22%3A20%7D%2C%7B%5C%22name%5C%22%3A%5C%22app.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A45%2C%5C%22startTime%5C%22%3A737%2C%5C%22fetchStart%5C%22%3A737%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A738%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A2323183%2C%5C%22decodedBodySize%5C%22%3A2323183%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A4%2C%5C%22transfer%5C%22%3A41%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2Fs%2Fsfsites%2Fruntimedownload%2Ffonts.css%3FlastMod%3D1645010501000%26brandSet%3D174f992c-43e9-44fd-8cea-8213cf228cc1%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A11%2C%5C%22startTime%5C%22%3A741%2C%5C%22fetchStart%5C%22%3A741%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A742%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A270366%2C%5C%22decodedBodySize%5C%22%3A270366%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A4%2C%5C%22transfer%5C%22%3A7%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2Fs%2Fsfsites%2Fl%2F%257B%2522mode%2522%253A%2522PROD%2522%252C%2522app%2522%253A%2522siteforce%253AcommunityApp%2522%252C%2522fwuid%2522%253A%2522QPQi8lbYE8YujG6og6Dqgw%2522%252C%2522loaded%2522%253A%257B%2522APPLICATION%2540markup%253A%252F%252Fsiteforce%253AcommunityApp%2522%253A%2522LpCTzuyqBUeCUwKaXXlwUA%2522%257D%252C%2522mlr%2522%253A1%252C%2522pathPrefix%2522%253A%2522%2522%252C%2522dns%2522%253A%2522c%2522%252C%2522ls%2522%253A1%252C%2522lrmc%2522%253A%2522533941497%2522%257D%2Fresources.js%3Fpv%3D16583396570001196944436%26rv%3D1658272158000%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22script%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A7%2C%5C%22startTime%5C%22%3A742%2C%5C%22fetchStart%5C%22%3A742%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A742%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A4713%2C%5C%22decodedBodySize%5C%22%3A4713%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A5%2C%5C%22transfer%5C%22%3A1%7D%2C%7B%5C%22name%5C%22%3A%5C%22bootstrap.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22script%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22duration%5C%22%3A1172%2C%5C%22startTime%5C%22%3A743%2C%5C%22fetchStart%5C%22%3A743%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A747%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A687988%2C%5C%22encodedBodySize%5C%22%3A687688%2C%5C%22decodedBodySize%5C%22%3A687688%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1169%2C%5C%22transfer%5C%22%3A2%7D%2C%7B%5C%22name%5C%22%3A%5C%22app.css%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A5%2C%5C%22startTime%5C%22%3A788%2C%5C%22fetchStart%5C%22%3A788%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A789%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A1001436%2C%5C%22decodedBodySize%5C%22%3A1001436%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1%2C%5C%22transfer%5C%22%3A4%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2Ffile-asset%2Fblue_104%3Fv%3D1%26amp%3Bheight%3D300%26amp%3Bwidth%3D300%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22css%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A1%2C%5C%22startTime%5C%22%3A2190%2C%5C%22fetchStart%5C%22%3A2190%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A2190%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A3715%2C%5C%22decodedBodySize%5C%22%3A3715%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1%2C%5C%22transfer%5C%22%3A0%7D%5D%2C%5C%22requestAuraJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22%2Faura_%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A22%2C%5C%22startTime%5C%22%3A735%2C%5C%22fetchStart%5C%22%3A735%2C%5C%22serverTime%5C%22%3A57%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A735%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A795001%2C%5C%22decodedBodySize%5C%22%3A795001%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2%2C%5C%22transfer%5C%22%3A20%7D%2C%5C%22requestAppJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22app.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A45%2C%5C%22startTime%5C%22%3A737%2C%5C%22fetchStart%5C%22%3A737%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A738%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A2323183%2C%5C%22decodedBodySize%5C%22%3A2323183%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A4%2C%5C%22transfer%5C%22%3A41%7D%2C%5C%22requestBootstrapJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22bootstrap.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22script%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22duration%5C%22%3A1172%2C%5C%22startTime%5C%22%3A743%2C%5C%22fetchStart%5C%22%3A743%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A747%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A687988%2C%5C%22encodedBodySize%5C%22%3A687688%2C%5C%22decodedBodySize%5C%22%3A687688%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1169%2C%5C%22transfer%5C%22%3A2%7D%2C%5C%22requestAppCss%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22app.css%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A5%2C%5C%22startTime%5C%22%3A788%2C%5C%22fetchStart%5C%22%3A788%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A789%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A1001436%2C%5C%22decodedBodySize%5C%22%3A1001436%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1%2C%5C%22transfer%5C%22%3A4%7D%2C%5C%22connection%5C%22%3A%7B%5C%22rtt%5C%22%3A1000%2C%5C%22downlink%5C%22%3A1.15%7D%2C%5C%22visibilityStateEnd%5C%22%3A%5C%22visible%5C%22%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A2813.19%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3Adashboard%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22user%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-sfxDashboardInit%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22displayMode%5C%22%3A%5C%22view%5C%22%2C%5C%22context%5C%22%3A%5C%22%5C%22%2C%5C%22height%5C%22%3A0%2C%5C%22hideOnError%5C%22%3Afalse%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A2%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A2879.39%2C%5C%22duration%5C%22%3A552%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2898.5%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A4%2C%5C%22requestLength%5C%22%3A2892%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22192%3Ba%5C%22%2C%5C%22212%3Ba%5C%22%2C%5C%22221%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%222898390000bb0cc09c%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A10483%2C%5C%22xhrDuration%5C%22%3A517%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2899%2C%5C%22fetchStart%5C%22%3A2899%2C%5C%22requestStart%5C%22%3A2899%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A516%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A10791%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A349%2C%5C%22xhrDelay%5C%22%3A14%7D%2C%5C%22duration%5C%22%3A531%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2892.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22216%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3AnavigationMenuBase%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.navigationMenu.NavigationMenuDataProviderController%2FACTION%24getNavigationMenu%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22params%5C%22%3A%7B%5C%22navigationLinkSetIdOrName%5C%22%3A%5C%22Default_Navigation1%5C%22%2C%5C%22includeImageUrl%5C%22%3Afalse%2C%5C%22addHomeMenuItem%5C%22%3Atrue%2C%5C%22menuItemTypesToSkip%5C%22%3A%5C%22%5B%5C%5C%5C%22SystemLink%5C%5C%5C%22%2C%5C%5C%5C%22Event%5C%5C%5C%22%5D%5C%22%2C%5C%22masterLabel%5C%22%3A%5C%22Default%20Navigation%5C%22%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A3%2C%5C%22duration%5C%22%3A5%7D%5D%2C%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A11.88%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22flowruntime%3AflowRuntimeForFlexiPage%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A6.38%7D%2C%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3AglobalNavigation%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A5.5%7D%5D%7D%5D%2C%5C%22custom%5C%22%3A%5B%7B%5C%22ns%5C%22%3A%5C%22flowruntime%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntimeCommunity.onInit%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A2880.89%2C%5C%22context%5C%22%3A%7B%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22forceCommunity%3AflowCommunity%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22flowruntime%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntimeForFlexiPage.onInit%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A2881.29%2C%5C%22context%5C%22%3Anull%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeForFlexiPage%5C%22%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22flowRuntimeController.onInitialized%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22flowDevName%5C%22%3A%5C%22OrderProductSearchFlow%5C%22%2C%5C%22consumerIdentifier%5C%22%3A%5C%22flowRuntime%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%5C%22LWCMarksEnabled%5C%22%3Afalse%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A2886.89%2C%5C%22duration%5C%22%3A545%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2898.5%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A4%2C%5C%22requestLength%5C%22%3A2892%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22192%3Ba%5C%22%2C%5C%22212%3Ba%5C%22%2C%5C%22221%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%222898390000bb0cc09c%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A10483%2C%5C%22xhrDuration%5C%22%3A517%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2899%2C%5C%22fetchStart%5C%22%3A2899%2C%5C%22requestStart%5C%22%3A2899%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A516%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A10791%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A349%2C%5C%22xhrDelay%5C%22%3A14%7D%2C%5C%22duration%5C%22%3A531%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2892.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22216%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3AnavigationMenuBase%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.navigationMenu.NavigationMenuDataProviderController%2FACTION%24getNavigationMenu%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22params%5C%22%3A%7B%5C%22navigationLinkSetIdOrName%5C%22%3A%5C%22Default_Navigation1%5C%22%2C%5C%22includeImageUrl%5C%22%3Afalse%2C%5C%22addHomeMenuItem%5C%22%3Atrue%2C%5C%22menuItemTypesToSkip%5C%22%3A%5C%22%5B%5C%5C%5C%22SystemLink%5C%5C%5C%22%2C%5C%5C%5C%22Event%5C%5C%5C%22%5D%5C%22%2C%5C%22masterLabel%5C%22%3A%5C%22Default%20Navigation%5C%22%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A3%2C%5C%22duration%5C%22%3A5%7D%2C%7B%5C%22ts%5C%22%3A2898.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22192%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A21%2C%5C%22db%5C%22%3A3%2C%5C%22xhrServerTime%5C%22%3A349%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A533%7D%5D%2C%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A5.5%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3AglobalNavigation%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A5.5%7D%5D%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22flowRuntimeController.onInitialized%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22consumerIdentifier%5C%22%3A%5C%22flowRuntime%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A3434.39%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-click%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22screenName%5C%22%3A%5C%22SeacrhOrderItemScreen%5C%22%2C%5C%22flowDevName%5C%22%3A%5C%22OrderProductSearchFlow%5C%22%2C%5C%22sectionsCount%5C%22%3A0%2C%5C%22columnsCount%5C%22%3A0%2C%5C%22screenFieldCounts%5C%22%3A%7B%5C%22flowruntime%3AdisplayTextLwc%5C%22%3A1%2C%5C%22flowruntime%3ASTRING.INPUT%5C%22%3A1%7D%2C%5C%22totalFieldsCount%5C%22%3A2%2C%5C%22customerAuraLcCount%5C%22%3A0%2C%5C%22customerLwcLcCount%5C%22%3A0%2C%5C%22outOfTheBoxLcCount%5C%22%3A0%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A3%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A3509.89%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-click%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22screenName%5C%22%3A%5C%22AccountDocumentStep%5C%22%2C%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22sectionsCount%5C%22%3A0%2C%5C%22columnsCount%5C%22%3A0%2C%5C%22screenFieldCounts%5C%22%3A%7B%5C%22flowruntime%3AdisplayTextLwc%5C%22%3A1%2C%5C%22flowruntime%3ASTRING.INPUT%5C%22%3A1%7D%2C%5C%22totalFieldsCount%5C%22%3A2%2C%5C%22customerAuraLcCount%5C%22%3A0%2C%5C%22customerLwcLcCount%5C%22%3A0%2C%5C%22outOfTheBoxLcCount%5C%22%3A0%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A4%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPageView%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3ApageView%5C%22%2C%5C%22ts%5C%22%3A2017.5%2C%5C%22duration%5C%22%3A1617%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2375.19%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A2%2C%5C%22requestLength%5C%22%3A2011%2C%5C%22background%5C%22%3Atrue%2C%5C%22actionDefs%5C%22%3A%5B%5C%22143%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%222375190000e7f97398%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2027%2C%5C%22xhrDuration%5C%22%3A269%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2375%2C%5C%22fetchStart%5C%22%3A2375%2C%5C%22requestStart%5C%22%3A2376%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A268%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2327%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A112%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A271%7D%2C%7B%5C%22ts%5C%22%3A2394.29%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A3%2C%5C%22requestLength%5C%22%3A1762%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22154%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2223941900000aa647cf%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1793%2C%5C%22xhrDuration%5C%22%3A416%2C%5C%22xhrStall%5C%22%3A249%2C%5C%22startTime%5C%22%3A2395%2C%5C%22fetchStart%5C%22%3A2395%2C%5C%22requestStart%5C%22%3A2645%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A415%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2093%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A23%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A418%7D%2C%7B%5C%22ts%5C%22%3A2373.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A1%2C%5C%22requestLength%5C%22%3A6706%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22142%3Ba%5C%22%2C%5C%2241%3Ba%5C%22%2C%5C%22147%3Ba%5C%22%2C%5C%22106%3Ba%5C%22%2C%5C%22107%3Ba%5C%22%2C%5C%22149%3Ba%5C%22%2C%5C%22116%3Ba%5C%22%2C%5C%22150%3Ba%5C%22%2C%5C%22151%3Ba%5C%22%2C%5C%22152%3Ba%5C%22%2C%5C%22130%3Ba%5C%22%2C%5C%22153%3Ba%5C%22%2C%5C%22148%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%222373600000f24433c7%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A13299%2C%5C%22xhrDuration%5C%22%3A473%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2374%2C%5C%22fetchStart%5C%22%3A2374%2C%5C%22requestStart%5C%22%3A2375%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A472%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A13601%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A304%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A474%7D%2C%7B%5C%22ts%5C%22%3A2898.5%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A4%2C%5C%22requestLength%5C%22%3A2892%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22192%3Ba%5C%22%2C%5C%22212%3Ba%5C%22%2C%5C%22221%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%222898390000bb0cc09c%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A10483%2C%5C%22xhrDuration%5C%22%3A517%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2899%2C%5C%22fetchStart%5C%22%3A2899%2C%5C%22requestStart%5C%22%3A2899%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A516%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A10791%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A349%2C%5C%22xhrDelay%5C%22%3A14%7D%2C%5C%22duration%5C%22%3A531%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2019.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%222%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Atrue%2C%5C%22cmp%5C%22%3A%5C%22siteforce%3ApubliclyCacheableComponentLoader%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableComponentLoaderController%2FACTION%24getAudienceTargetedPageComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A92%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A124%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A9%2C%5C%22duration%5C%22%3A333%7D%2C%7B%5C%22ts%5C%22%3A2094.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%2230%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceChatter%3AmessagesManager%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.chatter.components.messages.MessagesController%2FACTION%24getMessagingPermAndPref%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A268%2C%5C%22duration%5C%22%3A268%7D%2C%7B%5C%22ts%5C%22%3A2163%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%2278%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Atrue%2C%5C%22cmp%5C%22%3A%5C%22siteforce%3ApubliclyCacheableAttributeLoader%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.comm.runtime.components.aura.components.siteforce.controller.PubliclyCacheableAttributeLoaderController%2FACTION%24getComponentAttributes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A199%2C%5C%22duration%5C%22%3A199%7D%2C%7B%5C%22ts%5C%22%3A2166.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%2285%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22force%3AhostConfig%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.force.components.controllers.hostConfig.HostConfigController%2FACTION%24getConfigData%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A4%2C%5C%22enqueueWait%5C%22%3A196%2C%5C%22duration%5C%22%3A200%7D%2C%7B%5C%22ts%5C%22%3A2317.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22111%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A53%2C%5C%22duration%5C%22%3A53%7D%2C%7B%5C%22ts%5C%22%3A2324.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22121%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceChatter%3AgroupAnnouncement%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.chatter.components.aura.components.forceChatter.groups.GroupAnnouncementController%2FACTION%24getAnnouncement%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A47%2C%5C%22duration%5C%22%3A47%7D%2C%7B%5C%22ts%5C%22%3A2325.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22124%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A47%2C%5C%22duration%5C%22%3A47%7D%2C%7B%5C%22ts%5C%22%3A2326.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22127%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A46%2C%5C%22duration%5C%22%3A46%7D%2C%7B%5C%22ts%5C%22%3A2351.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22138%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A21%2C%5C%22duration%5C%22%3A21%7D%2C%7B%5C%22ts%5C%22%3A2392.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22154%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3Adashboard%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24getSitePathPrefix%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A22%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A5%2C%5C%22duration%5C%22%3A425%7D%2C%7B%5C%22ts%5C%22%3A2104.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%2241%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22selfService%3AprofileMenuAPI%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.self.service.components.profileMenu.ProfileMenuController%2FACTION%24getProfileMenuResponse%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A88%2C%5C%22enqueueWait%5C%22%3A181%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A28%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A304%2C%5C%22boxCarCount%5C%22%3A13%7D%2C%5C%22callbackTime%5C%22%3A15%2C%5C%22duration%5C%22%3A760%7D%2C%7B%5C%22ts%5C%22%3A2373.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22147%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22force%3AhostConfig%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.force.components.controllers.hostConfig.HostConfigController%2FACTION%24getConfigData%5C%22%2C%5C%22refresh%5C%22%3Atrue%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A6%2C%5C%22db%5C%22%3A1%2C%5C%22xhrServerTime%5C%22%3A304%2C%5C%22boxCarCount%5C%22%3A13%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A491%7D%2C%7B%5C%22ts%5C%22%3A2314.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22106%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3Adashboard%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24isFeedEnabled%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A6%2C%5C%22enqueueWait%5C%22%3A52%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A304%2C%5C%22boxCarCount%5C%22%3A13%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A550%7D%2C%7B%5C%22ts%5C%22%3A2314.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22107%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3Adashboard%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24getAdditionalParameters%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A6%2C%5C%22enqueueWait%5C%22%3A52%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A304%2C%5C%22boxCarCount%5C%22%3A13%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A550%7D%2C%7B%5C%22ts%5C%22%3A2319.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22116%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3AflowCommunity%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A6%2C%5C%22enqueueWait%5C%22%3A47%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A3%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A304%2C%5C%22boxCarCount%5C%22%3A13%7D%2C%5C%22callbackTime%5C%22%3A15%2C%5C%22duration%5C%22%3A560%7D%2C%7B%5C%22ts%5C%22%3A2327%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22130%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3AflowCommunity%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A6%2C%5C%22enqueueWait%5C%22%3A40%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A304%2C%5C%22boxCarCount%5C%22%3A13%7D%2C%5C%22callbackTime%5C%22%3A6%2C%5C%22duration%5C%22%3A560%7D%2C%7B%5C%22ts%5C%22%3A2368.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22148%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3AglobalNavigation%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A4%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A6%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A304%2C%5C%22boxCarCount%5C%22%3A13%7D%2C%5C%22callbackTime%5C%22%3A6%2C%5C%22duration%5C%22%3A525%7D%2C%7B%5C%22ts%5C%22%3A2892.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22216%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3AnavigationMenuBase%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.navigationMenu.NavigationMenuDataProviderController%2FACTION%24getNavigationMenu%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22params%5C%22%3A%7B%5C%22navigationLinkSetIdOrName%5C%22%3A%5C%22Default_Navigation1%5C%22%2C%5C%22includeImageUrl%5C%22%3Afalse%2C%5C%22addHomeMenuItem%5C%22%3Atrue%2C%5C%22menuItemTypesToSkip%5C%22%3A%5C%22%5B%5C%5C%5C%22SystemLink%5C%5C%5C%22%2C%5C%5C%5C%22Event%5C%5C%5C%22%5D%5C%22%2C%5C%22masterLabel%5C%22%3A%5C%22Default%20Navigation%5C%22%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A3%2C%5C%22duration%5C%22%3A5%7D%2C%7B%5C%22ts%5C%22%3A2879.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22192%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.interaction.runtime.components.controllers.FlowRuntimeController%2FACTION%24runInterview%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A4%2C%5C%22enqueueWait%5C%22%3A15%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A21%2C%5C%22db%5C%22%3A3%2C%5C%22xhrServerTime%5C%22%3A349%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A552%7D%2C%7B%5C%22ts%5C%22%3A2886.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22212%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.interaction.runtime.components.controllers.FlowRuntimeController%2FACTION%24runInterview%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A4%2C%5C%22enqueueWait%5C%22%3A7%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A10%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A349%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A545%7D%5D%2C%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A101.48%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3AglobalNavigation%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A5.5%7D%2C%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c25%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A35.09%7D%2C%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c1658372762824%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A8.5%7D%2C%7B%5C%22name%5C%22%3A%5C%22ui%3Amenu%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A12.69%7D%2C%7B%5C%22name%5C%22%3A%5C%22flowruntime%3AflowRuntimeForFlexiPage%5C%22%2C%5C%22createCount%5C%22%3A2%2C%5C%22createTimeTotal%5C%22%3A21.07%7D%5D%7D%5D%2C%5C%22custom%5C%22%3A%5B%7B%5C%22ns%5C%22%3A%5C%22flowruntime%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntimeCommunity.onInit%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A2865.69%2C%5C%22context%5C%22%3A%7B%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22forceCommunity%3AflowCommunity%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22flowruntime%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntimeForFlexiPage.onInit%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A2866.6%2C%5C%22context%5C%22%3Anull%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeForFlexiPage%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22flowruntime%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntimeCommunity.onInit%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A2880.89%2C%5C%22context%5C%22%3A%7B%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22forceCommunity%3AflowCommunity%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22flowruntime%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntimeForFlexiPage.onInit%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A2881.29%2C%5C%22context%5C%22%3Anull%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeForFlexiPage%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22ltng%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntime%3AscreenFieldInfo%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A3465.1%2C%5C%22context%5C%22%3A%7B%5C%22flowruntime%3AdisplayTextLwc%5C%22%3A1%2C%5C%22flowruntime%3AflowScreenInput%5C%22%3A1%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22ltng%5C%22%2C%5C%22name%5C%22%3A%5C%22performance%3AbuildComponentTree%5C%22%2C%5C%22ts%5C%22%3A3437.79%2C%5C%22context%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22STARTED%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22duration%5C%22%3A34%7D%2C%7B%5C%22ns%5C%22%3A%5C%22ltng%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntime%3AscreenFieldInfo%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A3513.39%2C%5C%22context%5C%22%3A%7B%5C%22flowruntime%3AdisplayTextLwc%5C%22%3A1%2C%5C%22flowruntime%3AflowScreenInput%5C%22%3A1%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22ltng%5C%22%2C%5C%22name%5C%22%3A%5C%22performance%3AbuildComponentTree%5C%22%2C%5C%22ts%5C%22%3A3511.39%2C%5C%22context%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22STARTED%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22duration%5C%22%3A7%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22ept%5C%22%3A1607%2C%5C%22previousPage%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22unknown%5C%22%2C%5C%22attributes%5C%22%3A%7B%7D%7D%2C%5C%22attributes%5C%22%3A%7B%5C%22designTime%5C%22%3Afalse%2C%5C%22domain%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%5C%22%2C%5C%22template%5C%22%3A%5C%22PRM%20Community%20Template%5C%22%2C%5C%22priorityDuration%5C%22%3A%7B%5C%22Audience_duration%5C%22%3A8%2C%5C%22Audience_creation_complete%5C%22%3A335%7D%2C%5C%22longTaskTotal%5C%22%3A0%2C%5C%22longestTask%5C%22%3A0%2C%5C%22network%5C%22%3A%7B%5C%22rtt%5C%22%3A1000%2C%5C%22downlink%5C%22%3A1.15%2C%5C%22maxAllowedParallelXHRs%5C%22%3A6%7D%2C%5C%22cores%5C%22%3A4%2C%5C%22eptDeviation%5C%22%3Afalse%2C%5C%22density%5C%22%3A%5C%22UNKNOWN%5C%22%2C%5C%22totalEpt%5C%22%3A3624.5%2C%5C%22bootstrapType%5C%22%3A%5C%22WARM%5C%22%2C%5C%22defaultCmp%5C%22%3A%5B%5D%2C%5C%22gates%5C%22%3A%7B%5C%22lds.useNewTrackedFieldBehavior%5C%22%3Afalse%2C%5C%22scenarioTrackerEnabled.instrumentation.ltng%5C%22%3Atrue%2C%5C%22scenarioTrackerMarksEnabled.instrumentation.ltng%5C%22%3Afalse%2C%5C%22ui.services.PageScopedCache.enabled%5C%22%3Atrue%2C%5C%22browserIdleTime.instrumentation.ltng%5C%22%3Afalse%2C%5C%22clientTelemetry.instrumentation.ltng%5C%22%3Atrue%2C%5C%22componentProfiler.instrumentation.ltng%5C%22%3Afalse%2C%5C%22o11yAuraActionsEnabled.instrumentation.ltng%5C%22%3Afalse%2C%5C%22o11yEnabled.instrumentation.ltng%5C%22%3Atrue%2C%5C%22LWCMarksEnabled%5C%22%3Afalse%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%7D%2C%5C%22cacheStats%5C%22%3A%7B%5C%22AuraStorage_actions%5C%22%3A%7B%5C%22hits%5C%22%3A14%2C%5C%22misses%5C%22%3A0%7D%2C%5C%22total%5C%22%3A%7B%5C%22hits%5C%22%3A14%2C%5C%22misses%5C%22%3A0%7D%7D%2C%5C%22complexity%5C%22%3Anull%2C%5C%22sequence%5C%22%3A1%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A3636.39%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22defs%5C%22%3A%5B%5C%22markup%3A%2F%2Faura%3Aapplication%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AbaseApp%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AcommunityApp%5C%22%2C%5C%22markup%3A%2F%2Faura%3Acomponent%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3ArouterInitializer%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3ApageLoader%5C%22%2C%5C%22layout%3A%2F%2Fsiteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c25%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3ApubliclyCacheableComponentLoader%5C%22%2C%5C%22markup%3A%2F%2Fui%3AasyncComponentManager%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AtoastManager%5C%22%2C%5C%22markup%3A%2F%2Faura%3Ahtml%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AvisualMessageQueue%5C%22%2C%5C%22markup%3A%2F%2Faura%3Aiteration%5C%22%2C%5C%22markup%3A%2F%2Faura%3Aexpression%5C%22%2C%5C%22markup%3A%2F%2Faura%3Aif%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AhoverPrototypeManager%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AhoverPrototype%5C%22%2C%5C%22markup%3A%2F%2Fone%3AactionsManager%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AtargetInteractionHandler%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3Aconditional%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AmassErrorsManager%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3ApanelsContainer%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AspinnerManager%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AloadingBalls%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3ApanelManager%5C%22%2C%5C%22markup%3A%2F%2Fui%3ApanelManager2%5C%22%2C%5C%22markup%3A%2F%2Fone%3ApanelManager%5C%22%2C%5C%22markup%3A%2F%2Fui%3AcontainerManager%5C%22%2C%5C%22markup%3A%2F%2FforceContent%3AfilesManager%5C%22%2C%5C%22markup%3A%2F%2FforceContent%3AmodalPreviewManager%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AhostConfig%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AsignalCollector%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchGDP%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchGDPCache%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchGDPCacheActivity%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchGDPCacheMrus%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchGDPCacheResultsFilters%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchGDPCacheScopes%5C%22%2C%5C%22markup%3A%2F%2Fsearch_lightning%3Astore%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AsystemErrorHandler%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AcustomerErrorHandler%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AalohaUrlService%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AnavigationProvider%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3Aqb%5C%22%2C%5C%22markup%3A%2F%2Finstrumentation%3Abeacon%5C%22%2C%5C%22markup%3A%2F%2Finstrumentation%3Ao11yCoreCollector%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AquickActionManager%5C%22%2C%5C%22markup%3A%2F%2FforceChatter%3AmessagesManager%5C%22%2C%5C%22markup%3A%2F%2FforceChatter%3AeditManager%5C%22%2C%5C%22markup%3A%2F%2FsalesforceIdentity%3AsessionTimeoutWarn%5C%22%2C%5C%22markup%3A%2F%2FsalesforceIdentity%3AsessionTimeoutWatcher%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AlogoutHandler%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AsessionLib%5C%22%2C%5C%22markup%3A%2F%2Fcommunity_runtime%3Aservices%5C%22%2C%5C%22layout%3A%2F%2Fsiteforce-generatedpage-Inner.c25%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AprmBody%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AruntimeRegion%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AruntimeComponent%5C%22%2C%5C%22markup%3A%2F%2FselfService%3AuserProfileMenu%5C%22%2C%5C%22markup%3A%2F%2FselfService%3AprofileMenuAPI%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AcontentArea%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AglobalSearchInput%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AbaseSearch%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3Abase%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AbaseSearch%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AgroupContainer%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AgroupContainer%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AbaseSearchInput%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3Ainput%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AinputDesktop%5C%22%2C%5C%22markup%3A%2F%2Fui%3AdataProvider%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AoptionDataProvider%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AinputDataProvider%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AinputDesktopDataProvider%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AactionDataProvider%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AmruDataProvider%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AtypeAheadDataProvider%5C%22%2C%5C%22markup%3A%2F%2Fui%3AresizeObserver%5C%22%2C%5C%22markup%3A%2F%2Fforce%3Aicon%5C%22%2C%5C%22markup%3A%2F%2Flightning%3Aicon%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AinputDesktopPillWrapper%5C%22%2C%5C%22markup%3A%2F%2Fui%3Ainput%5C%22%2C%5C%22markup%3A%2F%2Fui%3Aautocomplete%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AsearchInputListHeader%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AfilterPanelTrigger%5C%22%2C%5C%22markup%3A%2F%2Faura%3Atext%5C%22%2C%5C%22markup%3A%2F%2Fui%3AinputTextForAutocomplete%5C%22%2C%5C%22markup%3A%2F%2FforceSearch%3AexperimentContextInitializer%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AskipLink%5C%22%2C%5C%22markup%3A%2F%2Fcommunity_navigation%3AglobalNavigationTrigger%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3ApubliclyCacheableAttributeLoader%5C%22%2C%5C%22markup%3A%2F%2FforceChatter%3AfeedEventsProcessor%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3ApsscFeedsProxy%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AruntimeMode%5C%22%2C%5C%22markup%3A%2F%2Fui%3Alabel%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AiconSvgTemplatesUtility%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AhiddenRegion%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AseoAssistant%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AsldsTwoCol66Layout%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3Adashboard%5C%22%2C%5C%22markup%3A%2F%2FdesktopDashboards%3Adashboard%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AworkspaceAPI%5C%22%2C%5C%22markup%3A%2F%2FanalyticsHome%3AanalyticsDataProvider%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AinlineSpinner%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AdotsSpinner%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3ArichText%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3ArichTextInline%5C%22%2C%5C%22markup%3A%2F%2Fui%3AoutputRichText%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AoutputRichText%5C%22%2C%5C%22markup%3A%2F%2Faura%3AunescapedHtml%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AflowCommunity%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AgroupAnnouncement%5C%22%2C%5C%22markup%3A%2F%2FforceChatter%3AgroupAnnouncement%5C%22%2C%5C%22markup%3A%2F%2Faura%3ArenderIf%5C%22%2C%5C%22markup%3A%2F%2Fui%3Aimage%5C%22%2C%5C%22markup%3A%2F%2Fui%3AoutputText%5C%22%2C%5C%22layout%3A%2F%2Fsiteforce-generatedpage-7170e41d-7e6f-4a3d-94ba-ac63c2576cb4.c1658372762824%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AglobalNavigation%5C%22%2C%5C%22markup%3A%2F%2Fui%3Apopup%5C%22%2C%5C%22markup%3A%2F%2Fui%3Amenu%5C%22%2C%5C%22markup%3A%2F%2Fui%3Ainteractive%5C%22%2C%5C%22markup%3A%2F%2Fui%3ApopupTrigger%5C%22%2C%5C%22markup%3A%2F%2Fui%3AmenuTrigger%5C%22%2C%5C%22markup%3A%2F%2FselfService%3AprofileMenuTrigger%5C%22%2C%5C%22markup%3A%2F%2Fui%3ApopupTarget%5C%22%2C%5C%22markup%3A%2F%2Fui%3AmenuList%5C%22%2C%5C%22markup%3A%2F%2Fui%3AmenuItem%5C%22%2C%5C%22markup%3A%2F%2Fui%3AactionMenuItem%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AflowRuntimeForFlexiPage%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AflowRuntime%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AflowRuntimeV2%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AruntimeLib%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3Aspinner%5C%22%2C%5C%22markup%3A%2F%2Fcommunity_navigation%3AglobalNavigationList%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AnavigationMenuBase%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3AnavigationMenuBaseInternal%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3Aheader%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AhelpIcon%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AdisplayTextLwc%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AvisibilityWrapperV2%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AflowScreenInput%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AoneColumn%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3Abody%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AactionBase%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AactionButton%5C%22%2C%5C%22markup%3A%2F%2Flightning%3Abutton%5C%22%2C%5C%22markup%3A%2F%2Fflowruntime%3AactionBar%5C%22%5D%2C%5C%22pageCounter%5C%22%3A1%2C%5C%22phase%5C%22%3A%5C%22EPT%5C%22%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22scope%5C%22%3A%5C%22defsUsage%5C%22%7D%2C%5C%22sequence%5C%22%3A5%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%5D%2C%22traces%22%3A%22%5B%5D%22%2C%22metrics%22%3A%22%5B%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageReceived.beforeEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372763065%2C%5C%22value%5C%22%3A%5B37088%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageSent.beforeEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372763065%2C%5C%22value%5C%22%3A%5B15079%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22pageview.ept.ms%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372763076%2C%5C%22value%5C%22%3A%5B1607%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372762958%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372762958%2C%5C%22value%5C%22%3A%5B38%2C8%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372762962%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372762962%2C%5C%22value%5C%22%3A%5B0%2C1%5D%7D%5D%22%2C%22o11yLogs%22%3A%22CiEKBG8xMXkRM1PcgusheEIYASAAKAAyCDIzOC4yNC4wOAAS%2FAUKG3NmLmluc3RydW1lbnRhdGlvbi5BY3Rpdml0eRLcBQkA2HqC6yF4QhK%2FBAogYTI4YWQ5Mjk2ODEyNGRmZmMyMTQ2NzI2NDkzZWEwNzMSD0xleFJvb3RBY3Rpdml0eRkAANDMzDKYQCL6AwoUc2YubGV4LlBhZ2V2aWV3RHJhZnQS4QMIAREAAAAAAByZQCkAAAAAAKh5QEEAAAAAAAAAAEkAAAAAAAAAAGgAmAEAogEEV0FSTbIBK3NjZW5hcmlvVHJhY2tlckVuYWJsZWQuaW5zdHJ1bWVudGF0aW9uLmx0bmeyASN1aS5zZXJ2aWNlcy5QYWdlU2NvcGVkQ2FjaGUuZW5hYmxlZLIBJGNsaWVudFRlbGVtZXRyeS5pbnN0cnVtZW50YXRpb24ubHRuZ7IBIG8xMXlFbmFibGVkLmluc3RydW1lbnRhdGlvbi5sdG5nugEebGRzLnVzZU5ld1RyYWNrZWRGaWVsZEJlaGF2aW9yugEwc2NlbmFyaW9UcmFja2VyTWFya3NFbmFibGVkLmluc3RydW1lbnRhdGlvbi5sdG5nugEkYnJvd3NlcklkbGVUaW1lLmluc3RydW1lbnRhdGlvbi5sdG5nugEmY29tcG9uZW50UHJvZmlsZXIuaW5zdHJ1bWVudGF0aW9uLmx0bme6AStvMTF5QXVyYUFjdGlvbnNFbmFibGVkLmluc3RydW1lbnRhdGlvbi5sdG5n8AEEqgIPUExBQ0VIT0xERVJfVVJMugIOUExBQ0VIT0xERVJfSUTIAgHYAqyqghPgAumtjRGJAwAAAAAAoHxAQAFQAFgAGQAAAGBmO6BAKAEyFnNpdGVmb3JjZTpjb21tdW5pdHlBcHA6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCM2dSFQoRc2YubGV4LkFwcFBheWxvYWQSABoAIgA%3D%22%7D%7D%5D%7D&aura.context=%7B%22mode%22%3A%22PROD%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22app%22%3A%22siteforce%3AcommunityApp%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fsiteforce%3AcommunityApp%22%3A%22LpCTzuyqBUeCUwKaXXlwUA%22%2C%22COMPONENT%40markup%3A%2F%2Fflowruntime%3AflowRuntimeForFlexiPage%22%3A%22-5daKiCvGVZANVvqKEoy2Q%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3Adashboard%22%3A%22AiCYJU2L1bxRJx7dSn1bjw%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3AflowCommunity%22%3A%222aHA7kue5UGz8eJ4g8pZbQ%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3AglobalNavigation%22%3A%22hMmasIzVdWEZ3ka9-lPn0w%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3AgroupAnnouncement%22%3A%22P4M42Q1bH-ULweP4K3yAHg%22%2C%22COMPONENT%40markup%3A%2F%2FforceCommunity%3ArichTextInline%22%3A%22HRtpLMxEd9S_qFnNhOYX_Q%22%2C%22COMPONENT%40markup%3A%2F%2Finstrumentation%3Ao11yCoreCollector%22%3A%228089lZkrpgraL8-V8KZXNw%22%2C%22COMPONENT%40markup%3A%2F%2Fsiteforce%3AregionLoaderWrapper%22%3A%22iB-z_tJpr_VgV-1n1WmpOg%22%7D%2C%22dn%22%3A%5B%5D%2C%22globals%22%3A%7B%7D%2C%22uad%22%3Afalse%7D&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=6&ui-identity-components-sessiontimeoutwarn.SessionTimeoutWarn.getSessionTimeoutConfig=1&ui-search-components-forcesearch-sgdp.PermsAndPrefsCache.getPermsAndPrefs=1 HTTP/1.1

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "253;a",
                    Descriptor = "serviceComponent://ui.identity.components.sessiontimeoutwarn.SessionTimeoutWarnController/ACTION$getSessionTimeoutConfig",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "263;a",
                    Descriptor = "serviceComponent://ui.search.components.forcesearch.sgdp.PermsAndPrefsCacheController/ACTION$getPermsAndPrefs",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-identity-components-sessiontimeoutwarn.SessionTimeoutWarn.getSessionTimeoutConfig=1&ui-search-components-forcesearch-sgdp.PermsAndPrefsCache.getPermsAndPrefs=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                #endregion

                #region /AURA - OUTRO SITE

                #region POST /aura?r=0&ui-analytics-dashboard-components-lightning.DashboardApp.describe=1&ui-analytics-dashboard-components-lightning.DashboardApp.getActions=1&ui-analytics-dashboard-components-lightning.DashboardApp.medianFunctionSupported=1&ui-force-components-controllers-theme.ThemeCssVarLoader.getThemeVariables=1 HTTP/1.1
                //Atualiza aura.token
                UpdateKeys("aura.token", keys["new.aura.token"]);

                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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
                        DashboardId = "01Z6e000001DeZoEAK"//TODO
                    }
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "7;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$describe",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        DashboardId = "01Z6e000001DeZoEAK",//TODO
                        NetworkId = "0DB6e000000k9hL",//TODO
                        RequestOrigin = ""
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode("{\"mode\":\"PROD\",\"fwuid\":\"" + context.Fwuid + "\",\"app\":\"desktopDashboards:dashboardApp\",\"loaded\":" + keys["aura.context"] + ",\"dn\":[],\"globals\":{},\"uad\":true}") +
                          "&aura.pageURI=/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK" +
                          "&displayMode=view" +
                          "&networkId=" + keys["currentNetworkId"] +
                          "&userId=" + currentUser.Id +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/aura?r=0&ui-analytics-dashboard-components-lightning.DashboardApp.describe=1&ui-analytics-dashboard-components-lightning.DashboardApp.getActions=1&ui-analytics-dashboard-components-lightning.DashboardApp.medianFunctionSupported=1&ui-force-components-controllers-theme.ThemeCssVarLoader.getThemeVariables=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK&displayMode=view&networkId=" + keys["currentNetworkId"] + "&userId=" + currentUser.Id,
                           _accept: "*/*");

                #endregion

                #region POST /aura?r=1&ui-analytics-dashboard-components-lightning.DashboardApp.showDynamicGaugeChartControls=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "8;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$showDynamicGaugeChartControls",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams() { }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode("{\"mode\":\"PROD\",\"fwuid\":\"" + context.Fwuid + "\",\"app\":\"desktopDashboards:dashboardApp\",\"loaded\":" + keys["aura.context"] + ",\"dn\":[],\"globals\":{},\"uad\":true}") +
                          "&aura.pageURI=/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK" +
                          "&displayMode=view" +
                          "&networkId=" + keys["currentNetworkId"] +
                          "&userId=" + currentUser.Id +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/aura?r=1&ui-analytics-dashboard-components-lightning.DashboardApp.showDynamicGaugeChartControls=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK&displayMode=view&networkId=" + keys["currentNetworkId"] + "&userId=" + currentUser.Id,
                           _accept: response.ResponseUri.ToString());

                #endregion

                #region POST /aura?r=2&ui-analytics-dashboard-components-lightning.DashboardApp.getStatus=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "9;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$getStatus",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        DashboardId = "01Z6e000001DeZoEAK",
                        NetworkId = keys["currentNetworkId"]
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode("{\"mode\":\"PROD\",\"fwuid\":\"" + context.Fwuid + "\",\"app\":\"desktopDashboards:dashboardApp\",\"loaded\":" + keys["aura.context"] + ",\"dn\":[],\"globals\":{},\"uad\":true}") +
                          "&aura.pageURI=/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK" +
                          "&displayMode=view" +
                          "&networkId=" + keys["currentNetworkId"] +
                          "&userId=" + currentUser.Id +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/aura?r=2&ui-analytics-dashboard-components-lightning.DashboardApp.getStatus=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK&displayMode=view&networkId=" + keys["currentNetworkId"] + "&userId=" + currentUser.Id,
                           _accept: response.ResponseUri.ToString());

                #endregion

                #region POST /aura?r=3&ui-analytics-dashboard-components-lightning.DashboardApp.getActions=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "10;a",
                    Descriptor = "serviceComponent://ui.analytics.dashboard.components.lightning.DashboardAppController/ACTION$getActions",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        DashboardId = "01Z6e000001DeZoEAK"
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode("{\"mode\":\"PROD\",\"fwuid\":\"" + context.Fwuid + "\",\"app\":\"desktopDashboards:dashboardApp\",\"loaded\":" + keys["aura.context"] + ",\"dn\":[],\"globals\":{},\"uad\":true}") +
                          "&aura.pageURI=/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK" +
                          "&displayMode=view" +
                          "&networkId=" + keys["currentNetworkId"] +
                          "&userId=" + currentUser.Id +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/aura?r=3&ui-analytics-dashboard-components-lightning.DashboardApp.getActions=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/desktopDashboards/dashboardApp.app?dashboardId=01Z6e000001DeZoEAK&displayMode=view&networkId=" + keys["currentNetworkId"] + "&userId=" + currentUser.Id,
                           _accept: response.ResponseUri.ToString());

                #endregion

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool BuscaCliente(string cpf, string nome, string sobrenome, ref bool clienteNovo, ref string erro)
        {
            try
            {

                var hdrs = new Dictionary<string, string>();
                clienteNovo = false;
                var auxURL = "";

                #region POST /s/sfsites/aura?r=7&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                var fields = new List<Field>();

                fields.Add(new Field() { FieldSon = "AccountDocument", Value = cpf.PadLeft(11, '0'), IsVisible = true });

                var objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "282;a",
                    Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$executeAction",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Action = "NEXT",
                        Interview = keys["serializedEncodedState"],
                        Fields = fields,
                        UIElementVisited = true,
                        EnableTrace = false,
                        LCErrors = new object()
                    }
                });

                context.Dn = new List<Globals>();
                context.Globals = new Globals();
                context.Uad = false;

                var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context)) +
                   "&aura.pageURI=%2Fs%2F" +
                   "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/",
                           _accept: "*/*");

                clienteNovo = response.Content.Contains("Este é um cliente novo! Informe os dados abaixo para continuar.");
                var recordId = RetornaAuxSubstring(response.Content, "serializedEncodedState\":\"", "\",");

                #endregion

                if (clienteNovo)
                {
                    auxURL = response.Content.Substring(response.Content.LastIndexOf("serializedEncodedState\":\"") + 25);
                    auxURL = auxURL.Substring(0, auxURL.IndexOf("\""));

                    //var serializedEncodedState = RetornaAuxSubstring(response.Content, "NewAccountSimulationFlow\", \"value\":\"", "\",");
                    UpdateKeys("serializedEncodedState", auxURL);

                    #region POST /s/sfsites/aura?r=8&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    fields.Add(new Field() { FieldSon = "AccountDocument", Value = cpf.PadLeft(11, '0'), IsVisible = true });

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "282;a",
                        Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$executeAction",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Action = "NEXT",
                            Interview = keys["serializedEncodedState"],
                            Fields = fields,
                            UIElementVisited = true,
                            EnableTrace = true,
                            LCErrors = new object()
                        },


                    });

                    auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22305%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.instrumentation.components.beacon.InstrumentationBeaconController%2FACTION%24sendData%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22batch%22%3A%5B%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A3646.5%2C%5C%22duration%5C%22%3A385%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3649.29%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A6%2C%5C%22requestLength%5C%22%3A2012%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22253%3Ba%5C%22%2C%5C%22263%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2236491900001485ba45%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2370%2C%5C%22xhrDuration%5C%22%3A182%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A3649%2C%5C%22fetchStart%5C%22%3A3649%2C%5C%22requestStart%5C%22%3A3650%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A182%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2670%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A22%2C%5C%22xhrDelay%5C%22%3A198%7D%2C%5C%22duration%5C%22%3A380%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3649.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22253%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A22%2C%5C%22boxCarCount%5C%22%3A2%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A380%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-search-sgdp-fetch-getPermsAndPrefs%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22tStart%5C%22%3A1658372763083%2C%5C%22cacheHit%5C%22%3Afalse%2C%5C%22etCacheGet%5C%22%3A2%2C%5C%22actionId%5C%22%3A%5C%22263%3Ba%5C%22%2C%5C%22tSending%5C%22%3A1658372763470%2C%5C%22etDataCopy%5C%22%3A0%2C%5C%22tEnd%5C%22%3A1658372763470%2C%5C%22name%5C%22%3A%5C%22DEFAULT%5C%22%2C%5C%22groupId%5C%22%3A%5C%22COMMUNITIES%5C%22%2C%5C%22requestType%5C%22%3A%5C%22getPermsAndPrefs%5C%22%2C%5C%22etTransaction%5C%22%3A387%2C%5C%22requestId%5C%22%3A%5C%22forceSearchInputDesktop%3A154%3A0%5C%22%2C%5C%22requestCmp%5C%22%3A%5C%22forceSearchInputDesktop%5C%22%2C%5C%22requestCmpId%5C%22%3A%5C%22154%3A0%5C%22%2C%5C%22sourceCmp%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22time%5C%22%3A1658372763471%2C%5C%22page%5C%22%3A%7B%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A3645.5%2C%5C%22duration%5C%22%3A576%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3649.29%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A6%2C%5C%22requestLength%5C%22%3A2012%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22253%3Ba%5C%22%2C%5C%22263%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2236491900001485ba45%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2370%2C%5C%22xhrDuration%5C%22%3A182%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A3649%2C%5C%22fetchStart%5C%22%3A3649%2C%5C%22requestStart%5C%22%3A3650%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A182%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2670%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A22%2C%5C%22xhrDelay%5C%22%3A198%7D%2C%5C%22duration%5C%22%3A380%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3649.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22253%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A22%2C%5C%22boxCarCount%5C%22%3A2%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A380%7D%2C%7B%5C%22ts%5C%22%3A3646.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22263%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.search.components.forcesearch.sgdp.PermsAndPrefsCacheController%2FACTION%24getPermsAndPrefs%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A2%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A22%2C%5C%22boxCarCount%5C%22%3A2%7D%2C%5C%22callbackTime%5C%22%3A2%2C%5C%22duration%5C%22%3A385%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-search-sgdp-request-getPermsAndPrefs%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22tStart%5C%22%3A1658372763083%2C%5C%22cacheHit%5C%22%3Afalse%2C%5C%22etCacheGet%5C%22%3A2%2C%5C%22actionId%5C%22%3A%5C%22263%3Ba%5C%22%2C%5C%22tSending%5C%22%3A1658372763470%2C%5C%22etDataCopy%5C%22%3A0%2C%5C%22tEnd%5C%22%3A1658372763661%2C%5C%22name%5C%22%3A%5C%22DEFAULT%5C%22%2C%5C%22groupId%5C%22%3A%5C%22COMMUNITIES%5C%22%2C%5C%22requestType%5C%22%3A%5C%22getPermsAndPrefs%5C%22%2C%5C%22etTransaction%5C%22%3A578%2C%5C%22requestId%5C%22%3A%5C%22forceSearchInputDesktop%3A154%3A0%5C%22%2C%5C%22requestCmp%5C%22%3A%5C%22forceSearchInputDesktop%5C%22%2C%5C%22requestCmpId%5C%22%3A%5C%22154%3A0%5C%22%2C%5C%22etSendDataWait%5C%22%3A191%2C%5C%22sourceCmp%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22time%5C%22%3A1658372763661%2C%5C%22page%5C%22%3A%7B%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A1578.79%2C%5C%22pageStartTime%5C%22%3A1658372762257%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Dashboard%5C%22%2C%5C%22context%5C%22%3A%5C%22%5C%22%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22Load%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%7D%2C%5C%22sequence%5C%22%3A6%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A0%2C%5C%22duration%5C%22%3A1593%2C%5C%22pageStartTime%5C%22%3A1658372762257%2C%5C%22marks%5C%22%3A%7B%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A81.89%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A81.89%7D%5D%7D%5D%7D%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22bootstrap%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22framework%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22cache%5C%22%3A%7B%5C%22appCache%5C%22%3Afalse%2C%5C%22gvps%5C%22%3Afalse%7D%2C%5C%22execBootstrapJs%5C%22%3A1222%2C%5C%22execInlineJs%5C%22%3A1222%2C%5C%22appCssLoading%5C%22%3Anull%2C%5C%22visibilityStateStart%5C%22%3A%5C%22visible%5C%22%2C%5C%22execAuraJs%5C%22%3A1327%2C%5C%22runInitAsync%5C%22%3A1416%2C%5C%22runAfterContextCreated%5C%22%3A1427%2C%5C%22runAfterInitDefsReady%5C%22%3A1427%2C%5C%22runAfterBootstrapReady%5C%22%3A1428%2C%5C%22AuraFrameworkEPT%5C%22%3A1428%2C%5C%22appCreationStart%5C%22%3A1475%2C%5C%22appCreationEnd%5C%22%3A1557%2C%5C%22appRenderingStart%5C%22%3A1557%2C%5C%22appRenderingEnd%5C%22%3A1592%2C%5C%22bootstrapEPT%5C%22%3A1593%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22mode%5C%22%3A%5C%22PROD%5C%22%2C%5C%22maxAllowedParallelXHRCounts%5C%22%3A6%2C%5C%22pageStartTime%5C%22%3A1658372762257%2C%5C%22timing%5C%22%3A%7B%5C%22navigationStart%5C%22%3A1658372762257%2C%5C%22fetchStart%5C%22%3A1658372762263%2C%5C%22readyStart%5C%22%3A6%2C%5C%22dnsStart%5C%22%3A1658372762263%2C%5C%22dnsEnd%5C%22%3A1658372762263%2C%5C%22lookupDomainTime%5C%22%3A0%2C%5C%22connectStart%5C%22%3A1658372762263%2C%5C%22connectEnd%5C%22%3A1658372762263%2C%5C%22connectTime%5C%22%3A0%2C%5C%22requestStart%5C%22%3A1658372762265%2C%5C%22responseStart%5C%22%3A1658372762854%2C%5C%22responseEnd%5C%22%3A1658372762856%2C%5C%22requestTime%5C%22%3A591%2C%5C%22domLoading%5C%22%3A1658372762859%2C%5C%22domInteractive%5C%22%3A1658372763665%2C%5C%22initDomTreeTime%5C%22%3A809%2C%5C%22contentLoadStart%5C%22%3A1658372763665%2C%5C%22contentLoadEnd%5C%22%3A1658372763667%2C%5C%22domComplete%5C%22%3A1658372763667%2C%5C%22domReadyTime%5C%22%3A2%2C%5C%22loadEventStart%5C%22%3A1658372763668%2C%5C%22loadEventEnd%5C%22%3A1658372763668%2C%5C%22loadEventTime%5C%22%3A0%2C%5C%22loadTime%5C%22%3A1405%2C%5C%22unloadEventStart%5C%22%3A0%2C%5C%22unloadEventEnd%5C%22%3A0%2C%5C%22unloadEventTime%5C%22%3A0%2C%5C%22appCacheTime%5C%22%3A0%2C%5C%22redirectTime%5C%22%3A0%7D%2C%5C%22type%5C%22%3A%5C%22WARM%5C%22%2C%5C%22allRequests%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2FdesktopDashboards%2FdashboardApp.app%3FdashboardId%3D01Z6e000001DeZoEAK%26displayMode%3Dview%26networkId%3D0DB6e000000k9hL%26userId%3D0056e00000CpOw5AAF%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22navigation%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22duration%5C%22%3A600%2C%5C%22startTime%5C%22%3A0%2C%5C%22fetchStart%5C%22%3A7%2C%5C%22serverTime%5C%22%3A132%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A9%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A330621%2C%5C%22encodedBodySize%5C%22%3A330321%2C%5C%22decodedBodySize%5C%22%3A330321%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A599%2C%5C%22transfer%5C%22%3A1%7D%2C%7B%5C%22name%5C%22%3A%5C%22app.css%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A14%2C%5C%22startTime%5C%22%3A606%2C%5C%22fetchStart%5C%22%3A606%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A607%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A1033083%2C%5C%22decodedBodySize%5C%22%3A1033083%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1%2C%5C%22transfer%5C%22%3A13%7D%2C%7B%5C%22name%5C%22%3A%5C%22%2Faura_%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A13%2C%5C%22startTime%5C%22%3A607%2C%5C%22fetchStart%5C%22%3A607%2C%5C%22serverTime%5C%22%3A28%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A608%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A795001%2C%5C%22decodedBodySize%5C%22%3A795001%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A3%2C%5C%22transfer%5C%22%3A10%7D%2C%7B%5C%22name%5C%22%3A%5C%22appcore.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A8%2C%5C%22startTime%5C%22%3A609%2C%5C%22fetchStart%5C%22%3A609%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A609%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A230968%2C%5C%22decodedBodySize%5C%22%3A230968%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2%2C%5C%22transfer%5C%22%3A6%7D%2C%7B%5C%22name%5C%22%3A%5C%22app.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A157%2C%5C%22startTime%5C%22%3A609%2C%5C%22fetchStart%5C%22%3A609%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A610%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A2742765%2C%5C%22decodedBodySize%5C%22%3A2742765%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A4%2C%5C%22transfer%5C%22%3A153%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2FprojRes%2Finsights%2Fgen%2Fstatic%2Fdashboards%2Fjs%2FlightningDashboard.app.cc54f9ce16bf20938979.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22script%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A120%2C%5C%22startTime%5C%22%3A718%2C%5C%22fetchStart%5C%22%3A718%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A719%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A4700280%2C%5C%22decodedBodySize%5C%22%3A4700280%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2%2C%5C%22transfer%5C%22%3A118%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2Fl%2F%257B%2522mode%2522%253A%2522PROD%2522%252C%2522app%2522%253A%2522desktopDashboards%253AdashboardApp%2522%252C%2522fwuid%2522%253A%2522QPQi8lbYE8YujG6og6Dqgw%2522%252C%2522loaded%2522%253A%257B%2522APPLICATION%2540markup%253A%252F%252FdesktopDashboards%253AdashboardApp%2522%253A%2522dghqF0d_-1GyB2E7z2jaSA%2522%257D%252C%2522mlr%2522%253A1%252C%2522pathPrefix%2522%253A%2522%2522%252C%2522dns%2522%253A%2522c%2522%252C%2522ls%2522%253A1%252C%2522lrmc%2522%253A%2522533941497%2522%257D%2Fresources.js%3Fpv%3D16583396570001196944436%26rv%3D1658272158000%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22script%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A3%2C%5C%22startTime%5C%22%3A719%2C%5C%22fetchStart%5C%22%3A719%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A719%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A4713%2C%5C%22decodedBodySize%5C%22%3A4713%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2%2C%5C%22transfer%5C%22%3A1%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2F_slds%2Ficons%2Fstandard-sprite%2Fsvg%2Fsymbols.svg%23dashboard%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22use%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A3%2C%5C%22startTime%5C%22%3A1571%2C%5C%22fetchStart%5C%22%3A1571%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A1572%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A300430%2C%5C%22decodedBodySize%5C%22%3A300430%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1%2C%5C%22transfer%5C%22%3A2%7D%5D%2C%5C%22requestAppCss%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22app.css%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A14%2C%5C%22startTime%5C%22%3A606%2C%5C%22fetchStart%5C%22%3A606%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A607%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A1033083%2C%5C%22decodedBodySize%5C%22%3A1033083%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1%2C%5C%22transfer%5C%22%3A13%7D%2C%5C%22requestAuraJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22%2Faura_%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A13%2C%5C%22startTime%5C%22%3A607%2C%5C%22fetchStart%5C%22%3A607%2C%5C%22serverTime%5C%22%3A28%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A608%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A795001%2C%5C%22decodedBodySize%5C%22%3A795001%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A3%2C%5C%22transfer%5C%22%3A10%7D%2C%5C%22requestAppCoreJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22appcore.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A8%2C%5C%22startTime%5C%22%3A609%2C%5C%22fetchStart%5C%22%3A609%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A609%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A230968%2C%5C%22decodedBodySize%5C%22%3A230968%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2%2C%5C%22transfer%5C%22%3A6%7D%2C%5C%22requestAppJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22app.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A157%2C%5C%22startTime%5C%22%3A609%2C%5C%22fetchStart%5C%22%3A609%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A610%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A2742765%2C%5C%22decodedBodySize%5C%22%3A2742765%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A4%2C%5C%22transfer%5C%22%3A153%7D%2C%5C%22connection%5C%22%3A%7B%5C%22rtt%5C%22%3A1000%2C%5C%22downlink%5C%22%3A1.15%7D%2C%5C%22visibilityStateEnd%5C%22%3A%5C%22visible%5C%22%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A1581.39%2C%5C%22duration%5C%22%3A2142%2C%5C%22pageStartTime%5C%22%3A1658372762257%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2150.69%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A1%2C%5C%22requestLength%5C%22%3A1166%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%228%3Ba%5C%22%5D%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1172%2C%5C%22xhrDuration%5C%22%3A184%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2151%2C%5C%22fetchStart%5C%22%3A2151%2C%5C%22requestStart%5C%22%3A2152%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A183%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A1472%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A26%2C%5C%22xhrDelay%5C%22%3A3%7D%2C%5C%22duration%5C%22%3A187%7D%2C%7B%5C%22ts%5C%22%3A2239.09%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A2%2C%5C%22requestLength%5C%22%3A1232%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%229%3Ba%5C%22%5D%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A3211%2C%5C%22xhrDuration%5C%22%3A209%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2239%2C%5C%22fetchStart%5C%22%3A2239%2C%5C%22requestStart%5C%22%3A2240%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A207%2C%5C%22transfer%5C%22%3A2%2C%5C%22transferSize%5C%22%3A3511%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A62%2C%5C%22xhrDelay%5C%22%3A20%7D%2C%5C%22duration%5C%22%3A229%7D%2C%7B%5C%22ts%5C%22%3A2779.59%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A3%2C%5C%22requestLength%5C%22%3A1192%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%2210%3Ba%5C%22%5D%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A3373%2C%5C%22xhrDuration%5C%22%3A218%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2780%2C%5C%22fetchStart%5C%22%3A2780%2C%5C%22requestStart%5C%22%3A2780%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A217%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3674%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A53%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A220%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A1595.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%223%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A59%2C%5C%22db%5C%22%3A4%2C%5C%22xhrServerTime%5C%22%3A350%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A2%2C%5C%22duration%5C%22%3A531%7D%2C%7B%5C%22ts%5C%22%3A1595.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%225%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A350%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A531%7D%2C%7B%5C%22ts%5C%22%3A1595.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%226%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A36%2C%5C%22db%5C%22%3A15%2C%5C%22xhrServerTime%5C%22%3A350%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A532%7D%2C%7B%5C%22ts%5C%22%3A1582.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%227%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24describe%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A209%2C%5C%22db%5C%22%3A45%2C%5C%22xhrServerTime%5C%22%3A350%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A545%7D%2C%7B%5C%22ts%5C%22%3A2150.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%228%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24showDynamicGaugeChartControls%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A26%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A187%7D%2C%7B%5C%22ts%5C%22%3A2239%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%229%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24getStatus%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A37%2C%5C%22db%5C%22%3A22%2C%5C%22xhrServerTime%5C%22%3A62%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A230%7D%2C%7B%5C%22ts%5C%22%3A2779.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%2210%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24getActions%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A29%2C%5C%22db%5C%22%3A12%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A220%7D%5D%2C%5C%22custom%5C%22%3A%5B%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22describeApiCall%5C%22%2C%5C%22ts%5C%22%3A1582.39%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22duration%5C%22%3A565%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A564%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22asyncPolling_1%5C%22%2C%5C%22ts%5C%22%3A2238.79%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22numRefreshing%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A232%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_1%5C%22%2C%5C%22ts%5C%22%3A2519.89%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWQAA0%5C%22%5D%2C%5C%22numRequested%5C%22%3A1%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_2%5C%22%2C%5C%22ts%5C%22%3A2632.59%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWRAA0%5C%22%2C%5C%2201a6e000003SbWSAA0%5C%22%2C%5C%2201a6e000003SbWTAA0%5C%22%2C%5C%2201a6e000003SbWUAA0%5C%22%5D%2C%5C%22numRequested%5C%22%3A4%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_3%5C%22%2C%5C%22ts%5C%22%3A2691.59%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWVAA0%5C%22%2C%5C%2201a6e000003SbWWAA0%5C%22%2C%5C%2201a6e000003SbWXAA0%5C%22%2C%5C%2201a6e000003SbWYAA0%5C%22%5D%2C%5C%22numRequested%5C%22%3A4%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_4%5C%22%2C%5C%22ts%5C%22%3A2744.59%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWZAA0%5C%22%2C%5C%2201a6e000003SbWaAAK%5C%22%2C%5C%2201a6e000003SbWbAAK%5C%22%5D%2C%5C%22numRequested%5C%22%3A3%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22firstComponentRendered%5C%22%2C%5C%22ts%5C%22%3A1581.69%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWQAA0%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A2079%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22viewportRendering%5C%22%2C%5C%22ts%5C%22%3A1581.69%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A2136%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22legacyMark%5C%22%2C%5C%22ts%5C%22%3A1581.69%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A2136%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWQAA0%5C%22%2C%5C%22ts%5C%22%3A3661.09%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWQAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764823%2C%5C%22duration%5C%22%3A1154%2C%5C%22syncDuration%5C%22%3A9%2C%5C%22resetScroll-scrollTo%5C%22%3A12%2C%5C%22moduleImport%5C%22%3A1023%2C%5C%22script%5C%22%3A6%2C%5C%22animate%5C%22%3A61%2C%5C%22animate-scene%5C%22%3A60%2C%5C%22animate-scene-diffToModel%5C%22%3A3%2C%5C%22animate-scene-rendering%5C%22%3A3%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A2%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A2%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A61%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWRAA0%5C%22%2C%5C%22ts%5C%22%3A3681.69%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWRAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764919%2C%5C%22duration%5C%22%3A1059%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A27%2C%5C%22moduleImport%5C%22%3A912%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A40%2C%5C%22animate-scene%5C%22%3A40%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A40%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWSAA0%5C%22%2C%5C%22ts%5C%22%3A3686%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWSAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764920%2C%5C%22duration%5C%22%3A1058%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A25%2C%5C%22moduleImport%5C%22%3A912%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A36%2C%5C%22animate-scene%5C%22%3A36%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A36%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWTAA0%5C%22%2C%5C%22ts%5C%22%3A3691.39%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWTAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764922%2C%5C%22duration%5C%22%3A1056%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A24%2C%5C%22moduleImport%5C%22%3A912%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A30%2C%5C%22animate-scene%5C%22%3A30%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A31%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWUAA0%5C%22%2C%5C%22ts%5C%22%3A3694.69%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWUAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764923%2C%5C%22duration%5C%22%3A1055%2C%5C%22syncDuration%5C%22%3A1%2C%5C%22resetScroll-scrollTo%5C%22%3A24%2C%5C%22moduleImport%5C%22%3A912%2C%5C%22script%5C%22%3A0%2C%5C%22animate%5C%22%3A27%2C%5C%22animate-scene%5C%22%3A27%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A28%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWVAA0%5C%22%2C%5C%22ts%5C%22%3A3697.39%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWVAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764968%2C%5C%22duration%5C%22%3A1010%2C%5C%22syncDuration%5C%22%3A1%2C%5C%22resetScroll-scrollTo%5C%22%3A28%2C%5C%22moduleImport%5C%22%3A863%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A24%2C%5C%22animate-scene%5C%22%3A24%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A0%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A25%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWWAA0%5C%22%2C%5C%22ts%5C%22%3A3701.79%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWWAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764969%2C%5C%22duration%5C%22%3A1009%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A27%2C%5C%22moduleImport%5C%22%3A863%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A20%2C%5C%22animate-scene%5C%22%3A20%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A21%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWXAA0%5C%22%2C%5C%22ts%5C%22%3A3705.59%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWXAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764970%2C%5C%22duration%5C%22%3A1008%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A26%2C%5C%22moduleImport%5C%22%3A863%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A16%2C%5C%22animate-scene%5C%22%3A16%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A17%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWYAA0%5C%22%2C%5C%22ts%5C%22%3A3708.79%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWYAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372764972%2C%5C%22duration%5C%22%3A1007%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A24%2C%5C%22moduleImport%5C%22%3A863%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A13%2C%5C%22animate-scene%5C%22%3A13%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A14%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWZAA0%5C%22%2C%5C%22ts%5C%22%3A3711.39%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWZAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372765023%2C%5C%22duration%5C%22%3A956%2C%5C%22syncDuration%5C%22%3A1%2C%5C%22resetScroll-scrollTo%5C%22%3A29%2C%5C%22moduleImport%5C%22%3A806%2C%5C%22script%5C%22%3A0%2C%5C%22animate%5C%22%3A10%2C%5C%22animate-scene%5C%22%3A10%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A12%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWaAAK%5C%22%2C%5C%22ts%5C%22%3A3714.89%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWaAAK%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372765024%2C%5C%22duration%5C%22%3A955%2C%5C%22syncDuration%5C%22%3A1%2C%5C%22resetScroll-scrollTo%5C%22%3A29%2C%5C%22moduleImport%5C%22%3A806%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A7%2C%5C%22animate-scene%5C%22%3A7%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A0%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A8%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWbAAK%5C%22%2C%5C%22ts%5C%22%3A3718%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWbAAK%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658372765025%2C%5C%22duration%5C%22%3A954%2C%5C%22syncDuration%5C%22%3A0%2C%5C%22resetScroll-scrollTo%5C%22%3A28%2C%5C%22moduleImport%5C%22%3A806%2C%5C%22script%5C%22%3A0%2C%5C%22animate%5C%22%3A4%2C%5C%22animate-scene%5C%22%3A3%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A0%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A5%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-dashboardLoad%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22asyncLoadUniqueId%5C%22%3A%5C%2201Z6e000001DeZoEAK_0056e00000CpOw5AAF_desktopDashboards%3Adashboard_1658372763837%5C%22%2C%5C%22numberOfComponents%5C%22%3A12%2C%5C%22numberOfTableComponents%5C%22%3A0%2C%5C%22loadMetadataDuration%5C%22%3A565%2C%5C%22numRefreshing%5C%22%3A0%2C%5C%22viewportLoadComponent%5C%22%3A1164%2C%5C%22viewportLoadComponentFailCount%5C%22%3A0%2C%5C%22cumulativeLoadComponentsDuration%5C%22%3A0%2C%5C%22numberOfComponentsRenderedByCache%5C%22%3A12%2C%5C%22numberOfApiCallsAvoidedByCacheHit%5C%22%3A4%2C%5C%22numberOfComponentsWithVBarComboChart%5C%22%3A0%2C%5C%22dashboardTopNComponents%5C%22%3A%7B%5C%22numberOfTopNComponentsWithTableChart%5C%22%3A0%2C%5C%22numberOfTopNComponentsWithNonTableChart%5C%22%3A0%7D%2C%5C%22dashboardFilters%5C%22%3A%7B%5C%22numberOfFilters%5C%22%3A2%7D%2C%5C%22numberOfOptionsPerFilter%5C%22%3A%5B%5C%224%5C%22%2C%5C%221%5C%22%5D%2C%5C%22flexTableColumnsById%5C%22%3A%5C%22%5C%22%2C%5C%22EPT%5C%22%3A2080%2C%5C%22numVisibleComponents%5C%22%3A12%2C%5C%22numVisibleComponentsRendered%5C%22%3A12%2C%5C%22legacyTimer%5C%22%3A2137%2C%5C%22viewportEPT%5C%22%3A2142%2C%5C%22loadComponentsApiCallForViewportEpt%5C%22%3A0%2C%5C%22blurred%5C%22%3Afalse%2C%5C%22numberOfFilters%5C%22%3A0%2C%5C%22success%5C%22%3Atrue%2C%5C%22context%5C%22%3A%5C%22%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%5C%22LWCMarksEnabled%5C%22%3Afalse%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A17490.29%2C%5C%22duration%5C%22%3A473%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A17490.69%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A7%2C%5C%22requestLength%5C%22%3A4729%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22282%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22174906000003521a60%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A6742%2C%5C%22xhrDuration%5C%22%3A470%2C%5C%22xhrStall%5C%22%3A1%2C%5C%22startTime%5C%22%3A17491%2C%5C%22fetchStart%5C%22%3A17491%2C%5C%22requestStart%5C%22%3A17492%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A470%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A7044%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A309%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A472%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22flowRuntimeHelper.handleActionSelected.NEXT%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22consumerIdentifier%5C%22%3A%5C%22flowRuntime%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A17964.29%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-click%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22screenName%5C%22%3A%5C%22AccountDataStep%5C%22%2C%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22sectionsCount%5C%22%3A0%2C%5C%22columnsCount%5C%22%3A0%2C%5C%22screenFieldCounts%5C%22%3A%7B%5C%22flowruntime%3AdisplayTextLwc%5C%22%3A1%2C%5C%22flowruntime%3ASTRING.INPUT%5C%22%3A2%7D%2C%5C%22totalFieldsCount%5C%22%3A3%2C%5C%22customerAuraLcCount%5C%22%3A0%2C%5C%22customerLwcLcCount%5C%22%3A0%2C%5C%22outOfTheBoxLcCount%5C%22%3A0%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A7%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%5D%2C%22traces%22%3A%22%5B%5D%22%2C%22metrics%22%3A%22%5B%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22scenarioTime.ms%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372776832%2C%5C%22value%5C%22%3A%5B63%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372777413%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372777413%2C%5C%22value%5C%22%3A%5B9%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372777413%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372777413%2C%5C%22value%5C%22%3A%5B0%2C0%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22NEXT%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372776929%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22NEXT%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372776929%2C%5C%22value%5C%22%3A%5B0%5D%7D%5D%22%2C%22o11yLogs%22%3A%22CiEKBG8xMXkRzeRhhusheEIYASAAKAAyCDIzOC4yNC4wOAASrAMKHHNmLmluc3RydW1lbnRhdGlvbi5XZWJWaXRhbHMSswEJZ474hesheEISFwoDTENQEc%2F3U%2BNlHaNAGc%2F3U%2BNlHaNAGQAAANCM%2FM9AKAIyFnNpdGVmb3JjZTpjb21tdW5pdHlBcHA6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCM2dSFQoRc2YubGV4LkFwcFBheWxvYWQSABLVAQkA%2BPiF6yF4QhIXCgNGSUQRAAAAMDMzFUAZAAAAMDMzFUAZAAAAmNn%2Fz0AiIDlhOTY3MzU2MTY5YjRmYTU4YmYwZWMxMzhhMTlhOTU2KAMyFnNpdGVmb3JjZTpjb21tdW5pdHlBcHA6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCM2dSFQoRc2YubGV4LkFwcFBheWxvYWQSABoAIgA%3D%22%7D%7D%5D%7D";

                    auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                    auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId

                    strPost = "message=" + auxURL +
                      "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                      "&aura.pageURI=%2Fs%2F" +
                      "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/",
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=9&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    fields.Add(new Field() { FieldSon = "AccountFirstName", Value = nome, IsVisible = true });

                    fields.Add(new Field() { FieldSon = "AccountLastName", Value = sobrenome, IsVisible = true });

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "314;a",
                        Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$executeAction",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Action = "NEXT",
                            Interview = keys["serializedEncodedState"],
                            Fields = fields,
                            UIElementVisited = true,
                            EnableTrace = false,
                            LCErrors = new object()
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                      "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                      "&aura.pageURI=%2Fs%2F" +
                      "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/",
                               _accept: "*/*");

                    //auxURL = RetornaAuxSubstring(response.Content, "\"requestIds\":{\"", "\":[");
                    //auxURL = RetornaAuxSubstring(response.Content, "\"records\":{\"" + auxURL + "\":", "},\"recordTemplates\":{}");
                    //recordResponse = JsonConvert.DeserializeObject<RecordResponse>(auxURL);
                    auxURL = RetornaAuxSubstring(response.Content, "recordId\",\"isCollection\":false,\"value\":\"", "\"");

                    recordId = auxURL;
                    #endregion

                    #region POST /s/sfsites/aura?r=10&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "336;a",
                        Descriptor = "serviceComponent://ui.force.components.controllers.recordGlobalValueProvider.RecordGvpController/ACTION$getRecord",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            RecordDescriptor = recordId + ".undefined.null.null.null.Name.VIEW.false.null.null.null"
                        }
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                      "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                      "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/detail") +
                      "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/detail",
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=11&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "337;a",
                        Descriptor = "serviceComponent://ui.force.components.controllers.recordGlobalValueProvider.RecordGvpController/ACTION$getRecord",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            RecordDescriptor = recordId + ".undefined.null.null.null.RecordType;2DeveloperName.VIEW.true.null.null.null"
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/detail") +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/detail",
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=12&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "338;a",
                        Descriptor = "serviceComponent://ui.interaction.runtime.components.controllers.FlowRuntimeController/ACTION$executeAction",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Action = "FINISH",
                            Interview = keys["serializedEncodedState"],
                            Fields = fields,
                            UIElementVisited = true,
                            EnableTrace = false,
                            LCErrors = new object()
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/detail") +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/detail",
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=13&aura.Component.getComponent=8&ui-interaction-runtime-components-controllers.FlowRuntime.runInterview=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22142%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.chatter.components.messages.MessagesController%2FACTION%24getMessagingPermAndPref%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%2241%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.self.service.components.profileMenu.ProfileMenuController%2FACTION%24getProfileMenuResponse%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FselfService%3AprofileMenuAPI%22%2C%22params%22%3A%7B%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22147%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.force.components.controllers.hostConfig.HostConfigController%2FACTION%24getConfigData%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22106%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24isFeedEnabled%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22dashboardId%22%3A%2201Z6e000001DeZoEAK%22%7D%7D%2C%7B%22id%22%3A%22107%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24getAdditionalParameters%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%7D%2C%7B%22id%22%3A%22149%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%20style%3D%5C%22text-align%3A%20center%3B%5C%22%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.footer_agi_expanded.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22116%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FforceCommunity%3AflowCommunity%22%2C%22params%22%3A%7B%22flowName%22%3A%22OrderProductSearchFlow%22%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22150%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.chatter.components.aura.components.forceChatter.groups.GroupAnnouncementController%2FACTION%24getAnnouncement%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22groupId%22%3A%220F96e000000fysaCAA%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22151%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cb%20style%3D%5C%22color%3A%20rgb(68%2C%2068%2C%2068)%3B%20font-size%3A%2036px%3B%5C%22%3EQue%20bom%20te%20ver%20por%20aqui%2C%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%200%2C%200)%3B%20font-size%3A%2036px%3B%5C%22%3E%20%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%20102%2C%20204)%3B%20font-size%3A%2036px%3B%5C%22%3ECaio%3C%2Fb%3E%3Cb%20style%3D%5C%22font-size%3A%2036px%3B%5C%22%3E%20%3A)%3C%2Fb%3E%3C%2Fp%3E%3Cp%3E%26nbsp%3B%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22152%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.digitacao.1%7D%5C%22%20style%3D%5C%22width%3A%20568.641px%3B%20height%3A%2078.4219px%3B%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22130%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FforceCommunity%3AflowCommunity%22%2C%22params%22%3A%7B%22flowName%22%3A%22NewAccountSimulationFlow%22%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22153%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.buscar_proposta.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22148%3Ba%22%2C%22descriptor%22%3A%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22name%22%3A%22markup%3A%2F%2FforceCommunity%3AglobalNavigation%22%2C%22attributes%22%3A%7B%22NavigationMenuEditorRefresh%22%3A%22Default_Navigation1%22%2C%22hideHomeText%22%3Afalse%2C%22hideAppLauncher%22%3Afalse%7D%7D%7D%5D%7D";
                    auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                    auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                    auxURL = auxURL.Replace("0018Z00002hGxfeQAC", recordId);//userId

                    strPost = "message=" + auxURL +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.Component.getComponent=8&ui-interaction-runtime-components-controllers.FlowRuntime.runInterview=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=14&CMTD.EnhancedRelatedList_CC.getMetadataFields=5&CMTD.EnhancedRelatedList_CC.getObjectAccess=5&CMTD.EnhancedRelatedList_CC.getRecordTypes=5&ui-analytics-dashboard-components-lightning.DashboardComponent.getAdditionalParameters=1&ui-analytics-dashboard-components-lightning.DashboardComponent.isFeedEnabled=1&ui-chatter-components-aura-components-forceChatter-groups.GroupAnnouncement.getAnnouncement=1&ui-comm-runtime-components-aura-components-siteforce-qb.Quarterback.validateRoute=1&ui-communities-components-aura-components-forceCommunity-flowCommunity.FlowCommunity.canViewFlow=2&ui-communities-components-aura-components-forceCommunity-richText.RichText.getParsedRichTextValue=5&ui-communities-components-aura-components-forceCommunity-seoAssistant.SeoAssistant.getRecordAndTranslationData=1&ui-communities-components-aura-components-forceCommunity-tabset.Tabset.getLocalizedRegionLabels=1&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22364%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.force.components.controllers.recordGlobalValueProvider.RecordGvpController%2FACTION%24getRecord%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22recordDescriptor%22%3A%220018Z00002hGxfeQAC.0125A000001RcgjQAC.FULL.null.null.null.VIEW.true.null.Name%2CRecordType%3B2DeveloperName.null%22%7D%7D%2C%7B%22id%22%3A%22365%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.seoAssistant.SeoAssistantController%2FACTION%24getRecordAndTranslationData%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FforceCommunity%3AseoAssistant%22%2C%22params%22%3A%7B%22recordId%22%3A%220018Z00002hGxfeQAC%22%2C%22fields%22%3A%5B%5D%2C%22activeLanguageCodes%22%3A%5B%22pt_BR%22%2C%22en_US%22%5D%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22543%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%20style%3D%5C%22text-align%3A%20center%3B%5C%22%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.footer_agi_expanded.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22390%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22391%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetBenefitList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22392%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22413%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22414%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetLoanList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22415%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22436%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22437%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetAccountList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22438%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22459%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22460%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetCardList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22461%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22482%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22483%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetInsuranceList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22484%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22556%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.tabset.TabsetController%2FACTION%24getLocalizedRegionLabels%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22componentId%22%3A%2211f0d640-68d5-431c-9600-34b03b458fed%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22498%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.comm.runtime.components.aura.components.siteforce.qb.QuarterbackController%2FACTION%24validateRoute%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22routeId%22%3A%22e23ec990-e932-413f-9157-d68d449b39ef%22%2C%22viewParams%22%3A%7B%22viewid%22%3A%220076d481-f00c-413c-ad91-e083e79224cc%22%2C%22view_uddid%22%3A%220I36e00000Ep09J%22%2C%22entity_name%22%3A%22Account%22%2C%22audience_name%22%3A%22BPO%22%2C%22recordId%22%3A%220018Z00002hGxfeQAC%22%2C%22recordName%22%3A%22detail%22%2C%22picasso_id%22%3A%22e23ec990-e932-413f-9157-d68d449b39ef%22%2C%22routeId%22%3A%22e23ec990-e932-413f-9157-d68d449b39ef%22%7D%7D%7D%2C%7B%22id%22%3A%22572%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.chatter.components.aura.components.forceChatter.groups.GroupAnnouncementController%2FACTION%24getAnnouncement%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22groupId%22%3A%220F96e000000fysaCAA%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22573%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cb%20style%3D%5C%22color%3A%20rgb(68%2C%2068%2C%2068)%3B%20font-size%3A%2036px%3B%5C%22%3EQue%20bom%20te%20ver%20por%20aqui%2C%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%200%2C%200)%3B%20font-size%3A%2036px%3B%5C%22%3E%20%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%20102%2C%20204)%3B%20font-size%3A%2036px%3B%5C%22%3ECaio%3C%2Fb%3E%3Cb%20style%3D%5C%22font-size%3A%2036px%3B%5C%22%3E%20%3A)%3C%2Fb%3E%3C%2Fp%3E%3Cp%3E%26nbsp%3B%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22574%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.digitacao.1%7D%5C%22%20style%3D%5C%22width%3A%20568.641px%3B%20height%3A%2078.4219px%3B%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22508%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22flowName%22%3A%22NewAccountSimulationFlow%22%7D%7D%2C%7B%22id%22%3A%22575%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.buscar_proposta.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22512%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22flowName%22%3A%22OrderProductSearchFlow%22%7D%7D%2C%7B%22id%22%3A%22523%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24isFeedEnabled%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22dashboardId%22%3A%2201Z6e000001DeZoEAK%22%7D%7D%2C%7B%22id%22%3A%22524%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24getAdditionalParameters%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%7D%2C%7B%22id%22%3A%22576%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%20style%3D%5C%22text-align%3A%20center%3B%5C%22%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.footer_agi_expanded.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%5D%7D";
                    auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                    auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                    auxURL = auxURL.Replace("0018Z00002hGxfeQAC", recordId);//userId

                    strPost = "message=" + auxURL +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&CMTD.EnhancedRelatedList_CC.getMetadataFields=5&CMTD.EnhancedRelatedList_CC.getObjectAccess=5&CMTD.EnhancedRelatedList_CC.getRecordTypes=5&ui-analytics-dashboard-components-lightning.DashboardComponent.getAdditionalParameters=1&ui-analytics-dashboard-components-lightning.DashboardComponent.isFeedEnabled=1&ui-chatter-components-aura-components-forceChatter-groups.GroupAnnouncement.getAnnouncement=1&ui-comm-runtime-components-aura-components-siteforce-qb.Quarterback.validateRoute=1&ui-communities-components-aura-components-forceCommunity-flowCommunity.FlowCommunity.canViewFlow=2&ui-communities-components-aura-components-forceCommunity-richText.RichText.getParsedRichTextValue=5&ui-communities-components-aura-components-forceCommunity-seoAssistant.SeoAssistant.getRecordAndTranslationData=1&ui-communities-components-aura-components-forceCommunity-tabset.Tabset.getLocalizedRegionLabels=1&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=15&aura.ApexAction.execute=3 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "578;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "AccountController",
                            Method = "getHighlight",
                            Params = new JSONObjects.ActionParams()
                            {
                                AccountId = recordId
                            }

                        },
                    });

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "579;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "NewCaseButtonController",
                            Method = "isVisible",
                            Cacheable = true,
                            IsContinuation = false

                        },
                    });

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "580;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "AccountOpportunitiesController",
                            Method = "isVisible",
                            Cacheable = false,
                            IsContinuation = false

                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=3",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=16&aura.ApexAction.execute=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "592;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "AccountController",
                            Method = "getPrimaryEmail",
                            Params = new JSONObjects.ActionParams()
                            {
                                AccountId = recordId
                            },
                            Cacheable = true,
                            IsContinuation = false
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=17&aura.RecordUi.getRecordWithFields=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    fields.Add(new Field() { FieldSon = "Account.Rating" });

                    var optionalFields = new List<string>();
                    optionalFields.Add("Account.Name");
                    optionalFields.Add("Account.RecordType.DeveloperName");
                    optionalFields.Add("Account.RecordType.Id");
                    optionalFields.Add("Account.RecordTypeId");
                    optionalFields.Add("Account.SystemModstamp");

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "593;a",
                        Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "AccountController",
                            Method = "getPrimaryEmail",
                            Params = new JSONObjects.ActionParams()
                            {
                                RecordId = recordId,
                                Fields = null,
                                OptionalFields = optionalFields
                            },
                            Cacheable = true,
                            IsContinuation = false
                        },
                    });

                    auxURL = JsonConvert.SerializeObject(objRequest);
                    auxURL.Replace("fields:null", "fields:[\"Account.Rating\"]");

                    strPost = "message=" + WebUtility.UrlEncode(auxURL) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.RecordUi.getRecordWithFields=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=18&aura.ApexAction.execute=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "594;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "ContactController",
                            Method = "getByAccountId",
                            Params = new JSONObjects.ActionParams()
                            {
                                AccountId = recordId
                            },
                            Cacheable = true,
                            IsContinuation = false
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=19&aura.ApexAction.execute=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "600;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "OperationalRecordController",
                            Method = "validateUserPermissionButtonOperationalRecord",
                            Cacheable = false,
                            IsContinuation = false
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=20&aura.ApexAction.execute=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "601;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "OperationalRecordController",
                            Method = "findAssetByAccountIdAndGroup",
                            Params = new JSONObjects.ActionParams()
                            {
                                AccountId = recordId
                            },
                            Cacheable = false,
                            IsContinuation = false
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=21&aura.ApexAction.execute=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "602;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "AlertController",
                            Method = "getAlerts",
                            Params = new JSONObjects.ActionParams()
                            {
                                AccountId = recordId
                            },
                            Cacheable = false,
                            IsContinuation = false
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=22&aura.ApexAction.execute=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "603;a",
                        Descriptor = "aura://ApexActionController/ACTION$execute",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "AccountController",
                            Method = "createTask",
                            Params = new JSONObjects.ActionParams()
                            {
                                AccountId = recordId
                            },
                            Cacheable = false,
                            IsContinuation = false
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    UpdateKeys("taskId", RetornaAuxSubstring(response.Content, "Atendimento ao Cliente\", \"Id\":\"", "\"},\"errors"));

                    #endregion

                    #region POST /s/sfsites/aura?r=23&aura.RecordUi.getRecordWithFields=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    optionalFields = new List<string>();
                    optionalFields.Add("Account.Name");
                    optionalFields.Add("Account.Rating");
                    optionalFields.Add("Account.RecordType.DeveloperName");
                    optionalFields.Add("Account.RecordType.Id");
                    optionalFields.Add("Account.RecordTypeId");
                    optionalFields.Add("Account.SystemModstamp");

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "604;a",
                        Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            Namespace = "",
                            Classname = "AccountController",
                            Method = "createTask",
                            Params = new JSONObjects.ActionParams()
                            {
                                RecordId = recordId,
                                Fields = null
                            },
                            Cacheable = false,
                            IsContinuation = false
                        },
                    });

                    auxURL = JsonConvert.SerializeObject(objRequest);
                    auxURL.Replace("fields:null", "fields:[\"Account.RegistrationStatus__c\"]");

                    strPost = "message=" + WebUtility.UrlEncode(auxURL) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.RecordUi.getRecordWithFields=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=24&aura.RecordUi.getObjectInfo=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    fields = new List<Field>();

                    optionalFields = new List<string>();
                    optionalFields.Add("Account.Name");
                    optionalFields.Add("Account.Rating");
                    optionalFields.Add("Account.RecordType.DeveloperName");
                    optionalFields.Add("Account.RecordType.Id");
                    optionalFields.Add("Account.RecordTypeId");
                    optionalFields.Add("Account.SystemModstamp");

                    objRequest = new MessageRequest();

                    objRequest.Actions.Add(new JSONObjects.Action()
                    {
                        Id = "605;a",
                        Descriptor = "aura://RecordUiController/ACTION$getObjectInfo",
                        CallingDescriptor = "UNKNOWN",
                        Params = new JSONObjects.ActionParams()
                        {
                            ObjectApiName = "OperationalRecord__c"
                        },
                    });

                    strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.RecordUi.getObjectInfo=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=25&CMTD.EnhancedRelatedList_CC.getSObjectRecords=5&aura.Component.reportFailedAction=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22606%3Ba%22%2C%22descriptor%22%3A%22aura%3A%2F%2FComponentController%2FACTION%24reportFailedAction%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22failedAction%22%3A%22%22%2C%22failedId%22%3A0%2C%22clientError%22%3A%22%20%5BPromiseRejection%3A%20%5Bobject%20Object%5D%5D%22%2C%22additionalData%22%3A%22%7B%7D%22%2C%22clientStack%22%3A%22%7Banonymous%7D()%40https%3A%2F%2Fagibank.force.com%2Fs%2Fsfsites%2FauraFW%2Fjavascript%2FQPQi8lbYE8YujG6og6Dqgw%2Faura_prod.js%3A993%3A375%5Cnt()%40https%3A%2F%2Fagibank.force.com%2Fs%2Fsfsites%2FauraFW%2Fjavascript%2FQPQi8lbYE8YujG6og6Dqgw%2Faura_prod.js%3A1%3A6108%22%2C%22componentStack%22%3A%22%22%2C%22stacktraceIdGen%22%3A%22%22%2C%22level%22%3A%22ERROR%22%7D%7D%2C%7B%22id%22%3A%22609%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hGxfeQAC%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_Name%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_Segmentation%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Segmenta%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Segmentacao__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_PayMode%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Forma%20de%20Pagamento%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22PayMode__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_NextPayDate%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Dt.%20Pr%C3%B3x.%20Pagamento%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22NextPayDate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_NextUpdateProofLife%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Dt.%20Pr%C3%B3x.%20Prova%20de%20Vida%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22NextUpdateProofLife__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_Situation%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Situa%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Situation__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_SubStatusDescription%5C%22%2C%5C%22columnOrder%5C%22%3A7%2C%5C%22columnLabel%5C%22%3A%5C%22Sub%20Status%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22SubStatusDescription__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hGxfeQAC%22%2C%22filter%22%3A%22Group__c%20%3D%20'Benefit'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22611%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hGxfeQAC%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_Number%5C%22%2C%5C%22columnOrder%5C%22%3A0%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Number__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductName__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20de%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductType__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_IssueDate%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Data%20de%20Emiss%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22IssueDate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_GrossValue%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20Bruto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22GrossValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_NetValue%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20L%C3%ADquido%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22NetValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_ReleasedValue%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20Liberado%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ReleasedValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_InstallmentValue%5C%22%2C%5C%22columnOrder%5C%22%3A7%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20da%20Parcela%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22InstallmentValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_MonthlyRate%5C%22%2C%5C%22columnOrder%5C%22%3A8%2C%5C%22columnLabel%5C%22%3A%5C%22Taxa%20Mensal%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22MonthlyRate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_Status%5C%22%2C%5C%22columnOrder%5C%22%3A9%2C%5C%22columnLabel%5C%22%3A%5C%22Status%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Status%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hGxfeQAC%22%2C%22filter%22%3A%22Group__c%20%3D%20'Loan'%22%2C%22sortType%22%3A%22Status%20ASC%2C%20IssueDate__c%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22613%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hGxfeQAC%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_Name%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_Branch%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Ag%C3%AAncia%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Branch__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_AliasNumber%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Alias%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22AliasNumber__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Nome%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductName__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductType__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_Situation%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Situa%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Situation__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hGxfeQAC%22%2C%22filter%22%3A%22Group__c%20%3D%20'Account'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22615%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hGxfeQAC%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_Name%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Nome%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductName__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductType__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_PaymentDueDate%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Dt.%20Venc.%20%C3%9Altima%20Fatura%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22PaymentDueDate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_BillingAmount%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Vl.%20%C3%9Altima%20Fatura%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22BillingAmount__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_ClosingDay%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Melhor%20Dia%20de%20Compra%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ClosingDay__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_Situation%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Status%20da%20Conta%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Status%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hGxfeQAC%22%2C%22filter%22%3A%22Group__c%20%3D%20'CardSignature'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22617%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hGxfeQAC%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_Number%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22N%C3%BAmero%20do%20Seguro%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Number__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Nome%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Product2Id.Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Product2Id.Tipo__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_InstallmentValue%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20do%20Pr%C3%AAmio%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22InstallmentValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_Status%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Status%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Status%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hGxfeQAC%22%2C%22filter%22%3A%22Group__c%20%3D%20'Insurance'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%5D%7D";
                    auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                    auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                    auxURL = auxURL.Replace("0018Z00002hGxfeQAC", recordId);//userId
                    auxURL = auxURL.Replace("QPQi8lbYE8YujG6og6Dqgw", context.Fwuid);

                    strPost = "message=" + auxURL +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&CMTD.EnhancedRelatedList_CC.getSObjectRecords=5&aura.Component.reportFailedAction=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    #region POST /s/sfsites/aura?r=26&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1 HTTP/1.1
                    hdrs = new Dictionary<string, string>();
                    hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                    hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                    hdrs.Add("Host", "agibank.force.com");
                    hdrs.Add("Origin", "https://agibank.force.com");
                    hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                    auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22639%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.instrumentation.components.beacon.InstrumentationBeaconController%2FACTION%24sendData%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22batch%22%3A%5B%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A36533.79%2C%5C%22duration%5C%22%3A632%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A36534%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A9%2C%5C%22requestLength%5C%22%3A5416%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22314%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%223653400000048adc47%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A34020%2C%5C%22xhrDuration%5C%22%3A630%2C%5C%22xhrStall%5C%22%3A1%2C%5C%22startTime%5C%22%3A36534%2C%5C%22fetchStart%5C%22%3A36534%2C%5C%22requestStart%5C%22%3A36535%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A629%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A34321%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A476%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A631%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22flowRuntimeHelper.handleActionSelected.NEXT%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22consumerIdentifier%5C%22%3A%5C%22flowRuntime%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A37167.1%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-click%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22screenName%5C%22%3A%5C%22OpenAccountStep%5C%22%2C%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22sectionsCount%5C%22%3A0%2C%5C%22columnsCount%5C%22%3A0%2C%5C%22screenFieldCounts%5C%22%3A%7B%5C%22c%3AnewAccountSimulationFlowNavigator%5C%22%3A1%7D%2C%5C%22totalFieldsCount%5C%22%3A1%2C%5C%22customerAuraLcCount%5C%22%3A0%2C%5C%22customerLwcLcCount%5C%22%3A1%2C%5C%22outOfTheBoxLcCount%5C%22%3A0%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A8%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A37216.69%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22user%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communitynavigation%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22link%5C%22%2C%5C%22scope%5C%22%3A%5C%22communitynavigation%5C%22%2C%5C%22context%5C%22%3A%7B%5C%22unifiedEventType%5C%22%3A%5C%22COMMUNITY_PAGE_NAVIGATION%5C%22%2C%5C%22referrer%5C%22%3A%5C%22%2Fs%2F%5C%22%2C%5C%22requestURI%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%2C%5C%22entityId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%7D%7D%2C%5C%22sequence%5C%22%3A9%2C%5C%22page%5C%22%3A%7B%5C%22entity%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22entityType%5C%22%3A%5C%22Account%5C%22%2C%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A37221.89%2C%5C%22duration%5C%22%3A35204%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22pageTracker%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22pageId%5C%22%3A1%2C%5C%22phase%5C%22%3A%5C%22END%5C%22%2C%5C%22defaultCmp%5C%22%3A%5B%5D%2C%5C%22nonDefaultCmp%5C%22%3A%5B%5D%2C%5C%22backgroundTime%5C%22%3A0%2C%5C%22trxDeleted%5C%22%3A%7B%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A37222.19%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22defs%5C%22%3A%5B%5C%22markup%3A%2F%2Fc%3AnewAccountSimulationFlowNavigator%5C%22%5D%2C%5C%22pageCounter%5C%22%3A1%2C%5C%22phase%5C%22%3A%5C%22navFromPage%5C%22%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22scope%5C%22%3A%5C%22defsUsage%5C%22%7D%2C%5C%22sequence%5C%22%3A10%2C%5C%22page%5C%22%3A%7B%5C%22entity%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22entityType%5C%22%3A%5C%22Account%5C%22%2C%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A37212.5%2C%5C%22duration%5C%22%3A13%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AnavigationProvider%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22navigate%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22objectApiName%5C%22%3A%5C%22Account%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A37564.29%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Account%5C%22%2C%5C%22recordTypeSetInClient%5C%22%3Atrue%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22read%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%7D%2C%5C%22sequence%5C%22%3A11%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A37567.5%2C%5C%22duration%5C%22%3A0%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22resolveUrl%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A37352.69%2C%5C%22duration%5C%22%3A222%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A37352.89%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A12%2C%5C%22requestLength%5C%22%3A5174%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22338%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%223735289000045f3187%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2478%2C%5C%22xhrDuration%5C%22%3A216%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A37353%2C%5C%22fetchStart%5C%22%3A37353%2C%5C%22requestStart%5C%22%3A37354%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A216%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2778%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A64%2C%5C%22xhrDelay%5C%22%3A5%7D%2C%5C%22duration%5C%22%3A221%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22flowRuntimeHelper.handleActionSelected.FINISH%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22consumerIdentifier%5C%22%3A%5C%22flowRuntime%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A37575.5%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-click%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22screenName%5C%22%3Anull%2C%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22sectionsCount%5C%22%3A0%2C%5C%22columnsCount%5C%22%3A0%2C%5C%22screenFieldCounts%5C%22%3A%7B%7D%2C%5C%22totalFieldsCount%5C%22%3A0%2C%5C%22customerAuraLcCount%5C%22%3A0%2C%5C%22customerLwcLcCount%5C%22%3A0%2C%5C%22outOfTheBoxLcCount%5C%22%3A0%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A12%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A37926.1%2C%5C%22duration%5C%22%3A3%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22resolveUrl%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A37582.29%2C%5C%22duration%5C%22%3A363%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A13%2C%5C%22requestLength%5C%22%3A5621%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22345%3Ba%5C%22%2C%5C%22346%3Ba%5C%22%2C%5C%22347%3Ba%5C%22%2C%5C%22348%3Ba%5C%22%2C%5C%22349%3Ba%5C%22%2C%5C%22350%3Ba%5C%22%2C%5C%22351%3Ba%5C%22%2C%5C%22352%3Ba%5C%22%2C%5C%22355%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%223758260000070ee03e%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A8454%2C%5C%22xhrDuration%5C%22%3A203%2C%5C%22xhrStall%5C%22%3A1%2C%5C%22startTime%5C%22%3A37585%2C%5C%22fetchStart%5C%22%3A37585%2C%5C%22requestStart%5C%22%3A37587%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A202%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A8755%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A53%2C%5C%22xhrDelay%5C%22%3A145%7D%2C%5C%22duration%5C%22%3A348%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22345%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A351%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22346%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A352%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22347%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A352%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22348%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A353%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22349%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A354%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22350%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A355%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22351%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A5%2C%5C%22duration%5C%22%3A360%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22352%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A2%2C%5C%22duration%5C%22%3A362%7D%5D%2C%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A142.5%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-0076d481-f00c-413c-ad91-e083e79224cc.c25%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A129.8%7D%2C%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3AgroupAnnouncement%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A1.79%7D%2C%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3ArichTextInline%5C%22%2C%5C%22createCount%5C%22%3A4%2C%5C%22createTimeTotal%5C%22%3A3.88%7D%2C%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3AflowCommunity%5C%22%2C%5C%22createCount%5C%22%3A2%2C%5C%22createTimeTotal%5C%22%3A1.3%7D%2C%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3Adashboard%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A5.7%7D%5D%7D%5D%2C%5C%22custom%5C%22%3A%5B%7B%5C%22ns%5C%22%3A%5C%22formula%5C%22%2C%5C%22name%5C%22%3A%5C%22evaluate%5C%22%2C%5C%22ts%5C%22%3A37787.69%2C%5C%22context%5C%22%3A%7B%5C%22technology%5C%22%3A%5C%22Aura%5C%22%2C%5C%22formulaSize%5C%22%3A434%2C%5C%22feature%5C%22%3A%5C%22Audience%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22duration%5C%22%3A8%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22flowRuntimeController.onInitialized%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22consumerIdentifier%5C%22%3A%5C%22flowRuntime%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%5C%22forceRecordMarksEnabled%5C%22%3Afalse%2C%5C%22LWCMarksEnabled%5C%22%3Afalse%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A37946.1%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-click%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22screenName%5C%22%3A%5C%22AccountDocumentStep%5C%22%2C%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22sectionsCount%5C%22%3A0%2C%5C%22columnsCount%5C%22%3A0%2C%5C%22screenFieldCounts%5C%22%3A%7B%5C%22flowruntime%3AdisplayTextLwc%5C%22%3A1%2C%5C%22flowruntime%3ASTRING.INPUT%5C%22%3A1%7D%2C%5C%22totalFieldsCount%5C%22%3A2%2C%5C%22customerAuraLcCount%5C%22%3A0%2C%5C%22customerLwcLcCount%5C%22%3A0%2C%5C%22outOfTheBoxLcCount%5C%22%3A0%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A13%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A38170.19%2C%5C%22duration%5C%22%3A64%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AnavigationProvider%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22navigate%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A38255.19%2C%5C%22duration%5C%22%3A0%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AnavigationProvider%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22navigate%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A38587.89%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Account%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22read%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%2C%5C%22context%5C%22%3Anull%7D%2C%5C%22sequence%5C%22%3A14%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3AnewDefs%5C%22%2C%5C%22ts%5C%22%3A39895.5%2C%5C%22duration%5C%22%3A0%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AcommunityApp%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22newDefs%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22eventDefs%5C%22%3A%5B%5C%22markup%3A%2F%2Faura%3AserverActionError%5C%22%5D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A39917.5%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Account%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22read%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%2C%5C%22context%5C%22%3Anull%7D%2C%5C%22sequence%5C%22%3A15%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPageView%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3ApageView%5C%22%2C%5C%22ts%5C%22%3A37224.1%2C%5C%22duration%5C%22%3A4581%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A37322.69%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A10%2C%5C%22requestLength%5C%22%3A1901%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22336%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22373226900004b1cdf1%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2955%2C%5C%22xhrDuration%5C%22%3A235%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A37323%2C%5C%22fetchStart%5C%22%3A37323%2C%5C%22requestStart%5C%22%3A37324%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A235%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3256%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A85%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A237%7D%2C%7B%5C%22ts%5C%22%3A37352.89%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A12%2C%5C%22requestLength%5C%22%3A5174%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22338%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%223735289000045f3187%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2478%2C%5C%22xhrDuration%5C%22%3A216%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A37353%2C%5C%22fetchStart%5C%22%3A37353%2C%5C%22requestStart%5C%22%3A37354%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A216%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2778%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A64%2C%5C%22xhrDelay%5C%22%3A5%7D%2C%5C%22duration%5C%22%3A221%7D%2C%7B%5C%22ts%5C%22%3A37324.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A11%2C%5C%22requestLength%5C%22%3A1923%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22337%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22373246000001ef2299%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A3414%2C%5C%22xhrDuration%5C%22%3A458%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A37325%2C%5C%22fetchStart%5C%22%3A37325%2C%5C%22requestStart%5C%22%3A37325%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A457%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3716%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A295%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A459%7D%2C%7B%5C%22ts%5C%22%3A37582.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A13%2C%5C%22requestLength%5C%22%3A5621%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22345%3Ba%5C%22%2C%5C%22346%3Ba%5C%22%2C%5C%22347%3Ba%5C%22%2C%5C%22348%3Ba%5C%22%2C%5C%22349%3Ba%5C%22%2C%5C%22350%3Ba%5C%22%2C%5C%22351%3Ba%5C%22%2C%5C%22352%3Ba%5C%22%2C%5C%22355%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%223758260000070ee03e%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A8454%2C%5C%22xhrDuration%5C%22%3A203%2C%5C%22xhrStall%5C%22%3A1%2C%5C%22startTime%5C%22%3A37585%2C%5C%22fetchStart%5C%22%3A37585%2C%5C%22requestStart%5C%22%3A37587%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A202%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A8755%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A53%2C%5C%22xhrDelay%5C%22%3A145%7D%2C%5C%22duration%5C%22%3A348%7D%2C%7B%5C%22ts%5C%22%3A38149.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A16%2C%5C%22requestLength%5C%22%3A1969%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22592%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2238149600000c492941%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1828%2C%5C%22xhrDuration%5C%22%3A232%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A38150%2C%5C%22fetchStart%5C%22%3A38150%2C%5C%22requestStart%5C%22%3A38150%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A231%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2128%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A84%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A233%7D%2C%7B%5C%22ts%5C%22%3A38157.89%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A17%2C%5C%22requestLength%5C%22%3A2017%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22593%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2238157890000e6a1a7a%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A3008%2C%5C%22xhrDuration%5C%22%3A426%2C%5C%22xhrStall%5C%22%3A223%2C%5C%22startTime%5C%22%3A38158%2C%5C%22fetchStart%5C%22%3A38158%2C%5C%22requestStart%5C%22%3A38382%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A425%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3310%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A53%2C%5C%22xhrDelay%5C%22%3A3%7D%2C%5C%22duration%5C%22%3A429%7D%2C%7B%5C%22ts%5C%22%3A38167.79%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A18%2C%5C%22requestLength%5C%22%3A1969%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22594%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22381671000001785610%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2005%2C%5C%22xhrDuration%5C%22%3A540%2C%5C%22xhrStall%5C%22%3A327%2C%5C%22startTime%5C%22%3A38168%2C%5C%22fetchStart%5C%22%3A38168%2C%5C%22requestStart%5C%22%3A38496%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A326%2C%5C%22ttfb%5C%22%3A539%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2305%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A62%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A542%7D%2C%7B%5C%22ts%5C%22%3A38146%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A15%2C%5C%22requestLength%5C%22%3A2661%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22578%3Ba%5C%22%2C%5C%22579%3Ba%5C%22%2C%5C%22580%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22381460000009008ece%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A5808%2C%5C%22xhrDuration%5C%22%3A1322%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A38146%2C%5C%22fetchStart%5C%22%3A38146%2C%5C%22requestStart%5C%22%3A38147%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1321%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A6112%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A1164%2C%5C%22xhrDelay%5C%22%3A4%7D%2C%5C%22duration%5C%22%3A1326%7D%2C%7B%5C%22ts%5C%22%3A39482.1%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A19%2C%5C%22requestLength%5C%22%3A1945%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22600%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2239482100000904d35b%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2449%2C%5C%22xhrDuration%5C%22%3A223%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A39482%2C%5C%22fetchStart%5C%22%3A39482%2C%5C%22requestStart%5C%22%3A39483%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A221%2C%5C%22transfer%5C%22%3A2%2C%5C%22transferSize%5C%22%3A2749%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A63%2C%5C%22xhrDelay%5C%22%3A4%7D%2C%5C%22duration%5C%22%3A227%7D%2C%7B%5C%22ts%5C%22%3A39490.29%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A21%2C%5C%22requestLength%5C%22%3A1963%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22602%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2239490290000e5d8c94%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1899%2C%5C%22xhrDuration%5C%22%3A216%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A39490%2C%5C%22fetchStart%5C%22%3A39490%2C%5C%22requestStart%5C%22%3A39491%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A216%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2199%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A64%2C%5C%22xhrDelay%5C%22%3A8%7D%2C%5C%22duration%5C%22%3A224%7D%2C%7B%5C%22ts%5C%22%3A39483.1%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A20%2C%5C%22requestLength%5C%22%3A1994%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22601%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2239483100000504cf64%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1829%2C%5C%22xhrDuration%5C%22%3A228%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A39483%2C%5C%22fetchStart%5C%22%3A39483%2C%5C%22requestStart%5C%22%3A39484%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A228%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2129%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A79%2C%5C%22xhrDelay%5C%22%3A6%7D%2C%5C%22duration%5C%22%3A234%7D%2C%7B%5C%22ts%5C%22%3A39709.69%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A24%2C%5C%22requestLength%5C%22%3A1793%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22605%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2239709690000d8aa10a%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2512%2C%5C%22xhrDuration%5C%22%3A180%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A39713%2C%5C%22fetchStart%5C%22%3A39713%2C%5C%22requestStart%5C%22%3A39713%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A179%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2818%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A33%2C%5C%22xhrDelay%5C%22%3A5%7D%2C%5C%22duration%5C%22%3A185%7D%2C%7B%5C%22ts%5C%22%3A39507.79%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A23%2C%5C%22requestLength%5C%22%3A2055%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22604%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22395077900005aa8d1a%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A3067%2C%5C%22xhrDuration%5C%22%3A405%2C%5C%22xhrStall%5C%22%3A199%2C%5C%22startTime%5C%22%3A39508%2C%5C%22fetchStart%5C%22%3A39508%2C%5C%22requestStart%5C%22%3A39707%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A404%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3369%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A57%2C%5C%22xhrDelay%5C%22%3A4%7D%2C%5C%22duration%5C%22%3A409%7D%2C%7B%5C%22ts%5C%22%3A39498%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A22%2C%5C%22requestLength%5C%22%3A1966%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22603%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22394980000006c19160%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2246%2C%5C%22xhrDuration%5C%22%3A482%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A39499%2C%5C%22fetchStart%5C%22%3A39499%2C%5C%22requestStart%5C%22%3A39499%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A482%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2546%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A311%2C%5C%22xhrDelay%5C%22%3A5%7D%2C%5C%22duration%5C%22%3A487%7D%2C%7B%5C%22ts%5C%22%3A37993.5%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A14%2C%5C%22requestLength%5C%22%3A11919%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22364%3Ba%5C%22%2C%5C%22365%3Ba%5C%22%2C%5C%22543%3Ba%5C%22%2C%5C%22390%3Ba%5C%22%2C%5C%22391%3Ba%5C%22%2C%5C%22392%3Ba%5C%22%2C%5C%22413%3Ba%5C%22%2C%5C%22414%3Ba%5C%22%2C%5C%22415%3Ba%5C%22%2C%5C%22436%3Ba%5C%22%2C%5C%22437%3Ba%5C%22%2C%5C%22438%3Ba%5C%22%2C%5C%22459%3Ba%5C%22%2C%5C%22460%3Ba%5C%22%2C%5C%22461%3Ba%5C%22%2C%5C%22482%3Ba%5C%22%2C%5C%22483%3Ba%5C%22%2C%5C%22484%3Ba%5C%22%2C%5C%22556%3Ba%5C%22%2C%5C%22498%3Ba%5C%22%2C%5C%22572%3Ba%5C%22%2C%5C%22573%3Ba%5C%22%2C%5C%22574%3Ba%5C%22%2C%5C%22508%3Ba%5C%22%2C%5C%22575%3Ba%5C%22%2C%5C%22512%3Ba%5C%22%2C%5C%22523%3Ba%5C%22%2C%5C%22524%3Ba%5C%22%2C%5C%22576%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2237993500000a51b671%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A19911%2C%5C%22xhrDuration%5C%22%3A2313%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A37995%2C%5C%22fetchStart%5C%22%3A37995%2C%5C%22requestStart%5C%22%3A37996%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2312%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A20242%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A2138%2C%5C%22xhrDelay%5C%22%3A3%7D%2C%5C%22duration%5C%22%3A2316%7D%2C%7B%5C%22ts%5C%22%3A40331.69%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A25%2C%5C%22requestLength%5C%22%3A17229%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22606%3Ba%5C%22%2C%5C%22609%3Ba%5C%22%2C%5C%22611%3Ba%5C%22%2C%5C%22613%3Ba%5C%22%2C%5C%22615%3Ba%5C%22%2C%5C%22617%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2240331690000fe8008a%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2261%2C%5C%22xhrDuration%5C%22%3A1414%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A40332%2C%5C%22fetchStart%5C%22%3A40332%2C%5C%22requestStart%5C%22%3A40333%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1413%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2561%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A1259%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A1415%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A37322.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22336%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22force%3ArecordGlobalValueProvider%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.force.components.controllers.recordGlobalValueProvider.RecordGvpController%2FACTION%24getRecord%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A58%2C%5C%22db%5C%22%3A18%2C%5C%22xhrServerTime%5C%22%3A84%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A244%7D%2C%7B%5C%22ts%5C%22%3A37352.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22338%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.interaction.runtime.components.controllers.FlowRuntimeController%2FACTION%24executeAction%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A40%2C%5C%22db%5C%22%3A7%2C%5C%22xhrServerTime%5C%22%3A64%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A222%7D%2C%7B%5C%22ts%5C%22%3A37324.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22337%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22force%3ArecordGlobalValueProvider%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.force.components.controllers.recordGlobalValueProvider.RecordGvpController%2FACTION%24getRecord%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A270%2C%5C%22db%5C%22%3A20%2C%5C%22xhrServerTime%5C%22%3A294%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A462%7D%2C%7B%5C%22ts%5C%22%3A37581%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22345%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3AgroupAnnouncement%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A352%7D%2C%7B%5C%22ts%5C%22%3A37581.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22346%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3ArichTextInline%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A353%7D%2C%7B%5C%22ts%5C%22%3A37581.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22347%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3ArichTextInline%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A354%7D%2C%7B%5C%22ts%5C%22%3A37581.19%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22348%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3AflowCommunity%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A354%7D%2C%7B%5C%22ts%5C%22%3A37581.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22349%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3ArichTextInline%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A356%7D%2C%7B%5C%22ts%5C%22%3A37581.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22350%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3AflowCommunity%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A356%7D%2C%7B%5C%22ts%5C%22%3A37581.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22351%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3Adashboard%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A5%2C%5C%22duration%5C%22%3A361%7D%2C%7B%5C%22ts%5C%22%3A37581.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22352%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24getComponent%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22params%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22markup%3A%2F%2FforceCommunity%3ArichTextInline%5C%22%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A2%2C%5C%22duration%5C%22%3A363%7D%2C%7B%5C%22ts%5C%22%3A37582.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22355%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.interaction.runtime.components.controllers.FlowRuntimeController%2FACTION%24runInterview%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A15%2C%5C%22db%5C%22%3A3%2C%5C%22xhrServerTime%5C%22%3A53%2C%5C%22boxCarCount%5C%22%3A9%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A363%7D%2C%7B%5C%22ts%5C%22%3A37807.19%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22368%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A157%2C%5C%22duration%5C%22%3A157%7D%2C%7B%5C%22ts%5C%22%3A37923.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22494%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3Atabset%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.tabset.TabsetController%2FACTION%24getLocalizedRegionLabels%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A10%2C%5C%22enqueueWait%5C%22%3A41%2C%5C%22duration%5C%22%3A52%7D%2C%7B%5C%22ts%5C%22%3A37933.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22502%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceChatter%3AgroupAnnouncement%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.chatter.components.aura.components.forceChatter.groups.GroupAnnouncementController%2FACTION%24getAnnouncement%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A59%2C%5C%22duration%5C%22%3A59%7D%2C%7B%5C%22ts%5C%22%3A37934.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22504%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A58%2C%5C%22duration%5C%22%3A58%7D%2C%7B%5C%22ts%5C%22%3A37935.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22506%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A57%2C%5C%22duration%5C%22%3A57%7D%2C%7B%5C%22ts%5C%22%3A37937.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22510%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A55%2C%5C%22duration%5C%22%3A55%7D%2C%7B%5C%22ts%5C%22%3A37945.19%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22527%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A48%2C%5C%22duration%5C%22%3A48%7D%2C%7B%5C%22ts%5C%22%3A38149.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22592%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A65%2C%5C%22db%5C%22%3A10%2C%5C%22xhrServerTime%5C%22%3A84%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A234%7D%2C%7B%5C%22ts%5C%22%3A38157.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22593%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FRecordUiController%2FACTION%24getRecordWithFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A33%2C%5C%22db%5C%22%3A9%2C%5C%22xhrServerTime%5C%22%3A52%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A429%7D%2C%7B%5C%22ts%5C%22%3A38167.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22594%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A37%2C%5C%22db%5C%22%3A12%2C%5C%22xhrServerTime%5C%22%3A62%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A543%7D%2C%7B%5C%22ts%5C%22%3A38046.19%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22578%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A99%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A1044%2C%5C%22db%5C%22%3A66%2C%5C%22xhrServerTime%5C%22%3A1164%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1426%7D%2C%7B%5C%22ts%5C%22%3A38046.19%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22579%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A99%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A62%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1164%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1427%7D%2C%7B%5C%22ts%5C%22%3A38046.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22580%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A99%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A27%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1164%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1426%7D%2C%7B%5C%22ts%5C%22%3A39482%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22600%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22ERROR%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A36%2C%5C%22db%5C%22%3A1%2C%5C%22xhrServerTime%5C%22%3A63%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A227%7D%2C%7B%5C%22ts%5C%22%3A39490.19%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22602%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A46%2C%5C%22db%5C%22%3A9%2C%5C%22xhrServerTime%5C%22%3A64%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A224%7D%2C%7B%5C%22ts%5C%22%3A39483%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22601%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A51%2C%5C%22db%5C%22%3A10%2C%5C%22xhrServerTime%5C%22%3A79%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A235%7D%2C%7B%5C%22ts%5C%22%3A39527%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22605%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FRecordUiController%2FACTION%24getObjectInfo%5C%22%2C%5C%22state%5C%22%3A%5C%22ERROR%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A182%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A10%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A33%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A369%7D%2C%7B%5C%22ts%5C%22%3A39507.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22604%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FRecordUiController%2FACTION%24getRecordWithFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A30%2C%5C%22db%5C%22%3A9%2C%5C%22xhrServerTime%5C%22%3A57%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A409%7D%2C%7B%5C%22ts%5C%22%3A39498%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22603%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A293%2C%5C%22db%5C%22%3A92%2C%5C%22xhrServerTime%5C%22%3A311%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A490%7D%2C%7B%5C%22ts%5C%22%3A37804.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22364%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22force%3ArecordGlobalValueProvider%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.force.components.controllers.recordGlobalValueProvider.RecordGvpController%2FACTION%24getRecord%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A125%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A334%2C%5C%22db%5C%22%3A25%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2511%7D%2C%7B%5C%22ts%5C%22%3A37804.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22365%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3AseoAssistant%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.seoAssistant.SeoAssistantController%2FACTION%24getRecordAndTranslationData%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A124%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A34%2C%5C%22db%5C%22%3A7%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2511%7D%2C%7B%5C%22ts%5C%22%3A37874%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22390%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A55%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A110%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2443%7D%2C%7B%5C%22ts%5C%22%3A37874.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22391%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A55%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A206%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A4%2C%5C%22duration%5C%22%3A2447%7D%2C%7B%5C%22ts%5C%22%3A37874.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22392%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A55%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A92%2C%5C%22db%5C%22%3A4%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2447%7D%2C%7B%5C%22ts%5C%22%3A37883.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22413%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A45%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A24%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2438%7D%2C%7B%5C%22ts%5C%22%3A37883.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22414%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A45%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A359%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A2439%7D%2C%7B%5C%22ts%5C%22%3A37884%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22415%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A45%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A30%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2439%7D%2C%7B%5C%22ts%5C%22%3A37895.19%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22436%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A34%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A36%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2428%7D%2C%7B%5C%22ts%5C%22%3A37895.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22437%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A34%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A157%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A2429%7D%2C%7B%5C%22ts%5C%22%3A37895.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22438%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A33%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A23%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2429%7D%2C%7B%5C%22ts%5C%22%3A37905.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22459%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A24%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A23%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2420%7D%2C%7B%5C%22ts%5C%22%3A37906.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22460%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A23%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A159%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A2420%7D%2C%7B%5C%22ts%5C%22%3A37906.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22461%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A23%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A20%2C%5C%22db%5C%22%3A3%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2420%7D%2C%7B%5C%22ts%5C%22%3A37916.69%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22482%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A56%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2410%7D%2C%7B%5C%22ts%5C%22%3A37916.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22483%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A143%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A2413%7D%2C%7B%5C%22ts%5C%22%3A37916.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22484%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A21%2C%5C%22db%5C%22%3A3%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2413%7D%2C%7B%5C%22ts%5C%22%3A37926%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22498%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22siteforce%3AbaseApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.comm.runtime.components.aura.components.siteforce.qb.QuarterbackController%2FACTION%24validateRoute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A64%2C%5C%22enqueueWait%5C%22%3A3%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A14%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A2137%2C%5C%22boxCarCount%5C%22%3A29%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2404%7D%2C%7B%5C%22ts%5C%22%3A39724.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22606%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FComponentController%2FACTION%24reportFailedAction%5C%22%2C%5C%22caboose%5C%22%3Atrue%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A4%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A1259%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A2023%7D%2C%7B%5C%22ts%5C%22%3A40321.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22609%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A10%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A259%2C%5C%22db%5C%22%3A14%2C%5C%22xhrServerTime%5C%22%3A1259%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1428%7D%2C%7B%5C%22ts%5C%22%3A40323.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22611%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A8%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A267%2C%5C%22db%5C%22%3A8%2C%5C%22xhrServerTime%5C%22%3A1259%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1426%7D%2C%7B%5C%22ts%5C%22%3A40325.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22613%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A6%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A139%2C%5C%22db%5C%22%3A6%2C%5C%22xhrServerTime%5C%22%3A1259%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1426%7D%2C%7B%5C%22ts%5C%22%3A40327.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22615%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A4%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A355%2C%5C%22db%5C%22%3A8%2C%5C%22xhrServerTime%5C%22%3A1259%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A2%2C%5C%22duration%5C%22%3A1427%7D%2C%7B%5C%22ts%5C%22%3A40330.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22617%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A198%2C%5C%22db%5C%22%3A6%2C%5C%22xhrServerTime%5C%22%3A1259%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1424%7D%5D%2C%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A177.06%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22ui%3AtabItem%5C%22%2C%5C%22createCount%5C%22%3A5%2C%5C%22createTimeTotal%5C%22%3A7.29%7D%2C%7B%5C%22name%5C%22%3A%5C%22flowruntime%3AactionButton%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A4.4%7D%2C%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-0076d481-f00c-413c-ad91-e083e79224cc.c25%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A129.8%7D%2C%7B%5C%22name%5C%22%3A%5C%22forceCommunity%3Adashboard%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A5.7%7D%2C%7B%5C%22name%5C%22%3A%5C%22ui%3Atabset%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A9.5%7D%5D%7D%5D%2C%5C%22custom%5C%22%3A%5B%7B%5C%22ns%5C%22%3A%5C%22ltng%5C%22%2C%5C%22name%5C%22%3A%5C%22flowRuntime%3AscreenFieldInfo%5C%22%2C%5C%22phase%5C%22%3A%5C%22stamp%5C%22%2C%5C%22ts%5C%22%3A37949.29%2C%5C%22context%5C%22%3A%7B%5C%22flowruntime%3AdisplayTextLwc%5C%22%3A1%2C%5C%22flowruntime%3AflowScreenInput%5C%22%3A1%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%7D%2C%7B%5C%22ns%5C%22%3A%5C%22ltng%5C%22%2C%5C%22name%5C%22%3A%5C%22performance%3AbuildComponentTree%5C%22%2C%5C%22ts%5C%22%3A37947.5%2C%5C%22context%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22STARTED%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22duration%5C%22%3A8%7D%2C%7B%5C%22ns%5C%22%3A%5C%22formula%5C%22%2C%5C%22name%5C%22%3A%5C%22evaluate%5C%22%2C%5C%22ts%5C%22%3A37787.69%2C%5C%22context%5C%22%3A%7B%5C%22technology%5C%22%3A%5C%22Aura%5C%22%2C%5C%22formulaSize%5C%22%3A434%2C%5C%22feature%5C%22%3A%5C%22Audience%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22duration%5C%22%3A8%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22ept%5C%22%3A4579%2C%5C%22previousPage%5C%22%3A%7B%5C%22entity%5C%22%3A%5C%220018Z00002hGxfeQAC%5C%22%2C%5C%22entityType%5C%22%3A%5C%22Account%5C%22%2C%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%2C%5C%22attributes%5C%22%3A%7B%5C%22designTime%5C%22%3Afalse%2C%5C%22domain%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%5C%22%2C%5C%22template%5C%22%3A%5C%22PRM%20Community%20Template%5C%22%2C%5C%22priorityDuration%5C%22%3A%7B%7D%2C%5C%22eptDeviationReason%5C%22%3A%5C%22PageHasError%5C%22%2C%5C%22eptDeviationErrorType%5C%22%3A%5C%22system%5C%22%2C%5C%22eptDeviationErrorMsg%5C%22%3A%5C%22Error%3A%20%20%5BPromiseRejection%3A%20%5Bobject%20Object%5D%5D%5C%22%2C%5C%22eptDeviationErrorDisplayed%5C%22%3Afalse%2C%5C%22longTaskTotal%5C%22%3A450%2C%5C%22longestTask%5C%22%3A244%2C%5C%22network%5C%22%3A%7B%5C%22rtt%5C%22%3A750%2C%5C%22downlink%5C%22%3A1.15%2C%5C%22maxAllowedParallelXHRs%5C%22%3A6%7D%2C%5C%22cores%5C%22%3A4%2C%5C%22eptDeviation%5C%22%3Atrue%2C%5C%22density%5C%22%3A%5C%22UNKNOWN%5C%22%2C%5C%22totalEpt%5C%22%3A4579%2C%5C%22defaultCmp%5C%22%3A%5B%5D%2C%5C%22gates%5C%22%3A%7B%5C%22lds.useNewTrackedFieldBehavior%5C%22%3Afalse%2C%5C%22scenarioTrackerEnabled.instrumentation.ltng%5C%22%3Atrue%2C%5C%22scenarioTrackerMarksEnabled.instrumentation.ltng%5C%22%3Afalse%2C%5C%22ui.services.PageScopedCache.enabled%5C%22%3Atrue%2C%5C%22browserIdleTime.instrumentation.ltng%5C%22%3Afalse%2C%5C%22clientTelemetry.instrumentation.ltng%5C%22%3Atrue%2C%5C%22componentProfiler.instrumentation.ltng%5C%22%3Afalse%2C%5C%22o11yAuraActionsEnabled.instrumentation.ltng%5C%22%3Afalse%2C%5C%22o11yEnabled.instrumentation.ltng%5C%22%3Atrue%2C%5C%22forceRecordMarksEnabled%5C%22%3Afalse%2C%5C%22LWCMarksEnabled%5C%22%3Afalse%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%7D%2C%5C%22cacheStats%5C%22%3A%7B%5C%22AuraStorage_actions%5C%22%3A%7B%5C%22hits%5C%22%3A20%2C%5C%22misses%5C%22%3A0%7D%2C%5C%22AuraStorage_ldsObjectInfo%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A1%7D%2C%5C%22lds%3AgetObjectInfo%3Astorage%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A1%7D%2C%5C%22lds%3AApex.getApex%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A2%7D%2C%5C%22lds%3AUiApi.getObjectInfo%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A1%7D%2C%5C%22lds%3AUiApi.getRecord%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A2%7D%2C%5C%22AuraRecordStore%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A3%7D%2C%5C%22AuraRecordStore_others%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A2%7D%2C%5C%22AuraRecordStore_auraIf%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A1%7D%2C%5C%22total%5C%22%3A%7B%5C%22hits%5C%22%3A20%2C%5C%22misses%5C%22%3A13%7D%7D%2C%5C%22complexity%5C%22%3A%7B%5C%22ADS_fields%5C%22%3A9%7D%2C%5C%22sequence%5C%22%3A2%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A41807%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22defs%5C%22%3A%5B%5C%22markup%3A%2F%2Fforce%3ArecordGlobalValueProvider%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AadsBridge%5C%22%2C%5C%22layout%3A%2F%2Fsiteforce-generatedpage-0076d481-f00c-413c-ad91-e083e79224cc.c25%5C%22%2C%5C%22markup%3A%2F%2Fforce%3Arecord%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AsldsOneColLayout%5C%22%2C%5C%22markup%3A%2F%2Fc%3AaccountHighlight%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3Atabset%5C%22%2C%5C%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%5C%22%2C%5C%22markup%3A%2F%2Fltng%3Arequire%5C%22%2C%5C%22markup%3A%2F%2Flightning%3Aspinner%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AbuttonIcon%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AtooltipLibrary%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AprimitiveIcon%5C%22%2C%5C%22markup%3A%2F%2FCMTD%3AERL_List%5C%22%2C%5C%22markup%3A%2F%2Fforce%3ApageInfo%5C%22%2C%5C%22markup%3A%2F%2Flightning%3Anavigation%5C%22%2C%5C%22markup%3A%2F%2Fforce%3Aplaceholder%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3Aplaceholder%5C%22%2C%5C%22markup%3A%2F%2Fui%3Atabset%5C%22%2C%5C%22markup%3A%2F%2Fui%3AtabBar%5C%22%2C%5C%22markup%3A%2F%2Fui%3AtabOverflowMenuItem%5C%22%2C%5C%22markup%3A%2F%2Fui%3AmenuTriggerLink%5C%22%2C%5C%22markup%3A%2F%2Fui%3Atab%5C%22%2C%5C%22markup%3A%2F%2Fui%3AtabItem%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AiconSvgTemplatesCustom%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AiconSvgTemplatesStandard%5C%22%5D%2C%5C%22pageCounter%5C%22%3A2%2C%5C%22phase%5C%22%3A%5C%22EPT%5C%22%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22scope%5C%22%3A%5C%22defsUsage%5C%22%7D%2C%5C%22sequence%5C%22%3A16%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A41807.1%2C%5C%22pageStartTime%5C%22%3A1658372759439%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22locker-method-data%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22document.getElementsByTagName%5C%22%3A6%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3Anull%2C%5C%22sequence%5C%22%3A17%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hGxfeQAC%2Fdetail%5C%22%7D%7D%7D%22%7D%5D%2C%22traces%22%3A%22%5B%5D%22%2C%22metrics%22%3A%22%5B%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.Apex.getApex%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372797606%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799337%2C%5C%22value%5C%22%3A8%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.UiApi.getObjectInfo%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372798920%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.UiApi.getPicklistValues%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799337%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.UiApi.getRecord%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372798946%2C%5C%22value%5C%22%3A3%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22scenarioTime.ms%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372795883%2C%5C%22value%5C%22%3A%5B62%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageReceived.beforeEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372801243%2C%5C%22value%5C%22%3A%5B74389%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageSent.beforeEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372801243%2C%5C%22value%5C%22%3A%5B68227%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageReceived.afterEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372796662%2C%5C%22value%5C%22%3A%5B50343%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageSent.afterEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372796662%2C%5C%22value%5C%22%3A%5B126731%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsage.instrSizePct%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372796662%2C%5C%22value%5C%22%3A%5B1%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372797395%2C%5C%22value%5C%22%3A3%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372797395%2C%5C%22value%5C%22%3A%5B24%2C7%2C9%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372796631%2C%5C%22value%5C%22%3A5%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372796631%2C%5C%22value%5C%22%3A%5B0%2C1%2C1%2C1%2C0%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22NEXT%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372795973%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22NEXT%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372795973%2C%5C%22value%5C%22%3A%5B0%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22FINISH%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372796792%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22FINISH%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372796792%2C%5C%22value%5C%22%3A%5B0%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22name%5C%22%3A%5C%22ads-bridge-add-records-duration%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799754%2C%5C%22value%5C%22%3A%5B1%2C2%2C1%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22network-response.200%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799357%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22name%5C%22%3A%5C%22ads-bridge-emit-record-changed-duration%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799360%2C%5C%22value%5C%22%3A%5B1%2C2%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22network-response.403%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799336%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-policy-undefined%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799337%2C%5C%22value%5C%22%3A8%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799361%2C%5C%22value%5C%22%3A5%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count.Apex.getApex%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372798154%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count.UiApi.getRecord%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799361%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count.UiApi.getObjectInfo%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799337%2C%5C%22value%5C%22%3A1%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.Apex.getApex%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372797604%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799337%2C%5C%22value%5C%22%3A8%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.UiApi.getRecord%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372798947%2C%5C%22value%5C%22%3A3%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.UiApi.getObjectInfo%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372798920%2C%5C%22value%5C%22%3A1%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.UiApi.getPicklistValues%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372799337%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22PageNavWithoutST%5C%22%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AcommunityApp%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658372796664%2C%5C%22value%5C%22%3A1%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-ingest-duration%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799754%2C%5C%22value%5C%22%3A%5B1%2C1%2C0%2C0%2C0%2C0%2C0%2C0%2C0%2C1%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-size-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799754%2C%5C%22value%5C%22%3A%5B4%2C8%2C9%2C10%2C12%2C14%2C60%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-snapshot-subscriptions-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799754%2C%5C%22value%5C%22%3A%5B0%2C0%2C0%2C1%2C3%2C3%2C5%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-watch-subscriptions-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799754%2C%5C%22value%5C%22%3A%5B2%2C2%2C2%2C2%2C2%2C2%2C2%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-broadcast-duration%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799755%2C%5C%22value%5C%22%3A%5B0%2C0%2C0%2C1%2C0%2C0%2C0%2C0%2C0%2C3%2C0%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-lookup-duration%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799359%2C%5C%22value%5C%22%3A%5B0%2C0%2C0%2C0%2C0%2C0%2C0%2C0%2C0%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-duration.Apex.getApex%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372798154%2C%5C%22value%5C%22%3A%5B238%2C547%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22record-conflicts-resolved%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799358%2C%5C%22value%5C%22%3A%5B1%2C1%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-duration.UiApi.getRecord%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799360%2C%5C%22value%5C%22%3A%5B439%2C414%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-duration.UiApi.getObjectInfo%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658372799337%2C%5C%22value%5C%22%3A%5B416%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%5D%22%2C%22o11yLogs%22%3A%22CiEKBG8xMXkRM%2FstjOsheEIYAiAAKAAyCDIzOC4yNC4wOAASqBAKG3NmLmluc3RydW1lbnRhdGlvbi5BY3Rpdml0eRKDAgnNPEmL6yF4QhJYChBiZmVhOGNlMWEwYmI1Y2U5EgxBcGV4LmdldEFwZXgZAADAzMysbUAiKQoZc2YuaW5zdHJ1bWVudGF0aW9uLlNpbXBsZRIMCgpjYWNoZS1taXNzUABYABkAAAAAgKDiQCIgMTIyNDM1YWM2M2VhMjk0N2IzMDlmNmFlNzExNWI2MTQoBTIDbGRzOjkKEnNmLmxleC5QYWdlUGF5bG9hZBIjCAEiD1BMQUNFSE9MREVSX1VSTDIOUExBQ0VIT0xERVJfSURCFnNpdGVmb3JjZTpjb21tdW5pdHlBcHBKAjNnUhUKEXNmLmxleC5BcHBQYXlsb2FkEgAShgIJzXxJi%2BsheEISWwoQZDQyYmUzZTg2ZTJjN2I3NRIPVWlBcGkuZ2V0UmVjb3JkGQAAwMzMbHtAIikKGXNmLmluc3RydW1lbnRhdGlvbi5TaW1wbGUSDAoKY2FjaGUtbWlzc1AAWAAZAAAAAACh4kAiIDEyMjQzNWFjNjNlYTI5NDdiMzA5ZjZhZTcxMTViNjE0KAYyA2xkczo5ChJzZi5sZXguUGFnZVBheWxvYWQSIwgBIg9QTEFDRUhPTERFUl9VUkwyDlBMQUNFSE9MREVSX0lEQhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwSgIzZ1IVChFzZi5sZXguQXBwUGF5bG9hZBIAEoMCCQBoSovrIXhCElgKEGY1ODM1N2ZjYmYzODExODMSDEFwZXguZ2V0QXBleBkAAKCZmRmBQCIpChlzZi5pbnN0cnVtZW50YXRpb24uU2ltcGxlEgwKCmNhY2hlLW1pc3NQAFgAGQAAAGbWouJAIiAxMjI0MzVhYzYzZWEyOTQ3YjMwOWY2YWU3MTE1YjYxNCgHMgNsZHM6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCM2dSFQoRc2YubGV4LkFwcFBheWxvYWQSABKKAglnhpyL6yF4QhJfChBiMDk3YWVkMTYxMDVlZGQwEhNVaUFwaS5nZXRPYmplY3RJbmZvGQAAgJmZAXpAIikKGXNmLmluc3RydW1lbnRhdGlvbi5TaW1wbGUSDAoKY2FjaGUtbWlzc1AAWAAZAAAANBNH40AiIDEyMjQzNWFjNjNlYTI5NDdiMzA5ZjZhZTcxMTViNjE0KAgyA2xkczo5ChJzZi5sZXguUGFnZVBheWxvYWQSIwgBIg9QTEFDRUhPTERFUl9VUkwyDlBMQUNFSE9MREVSX0lEQhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwSgIzZ1IVChFzZi5sZXguQXBwUGF5bG9hZBIAEoYCCZopnovrIXhCElsKEDkwMDhjNjdmZjlmY2I3NzESD1VpQXBpLmdldFJlY29yZBkAAKCZmdl5QCIpChlzZi5pbnN0cnVtZW50YXRpb24uU2ltcGxlEgwKCmNhY2hlLW1pc3NQAFgAGQAAAJpZSuNAIiAxMjI0MzVhYzYzZWEyOTQ3YjMwOWY2YWU3MTE1YjYxNCgJMgNsZHM6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCM2dSFQoRc2YubGV4LkFwcFBheWxvYWQSABLdBQkzew%2BL6yF4QhLABAogMTIyNDM1YWM2M2VhMjk0N2IzMDlmNmFlNzExNWI2MTQSD0xleFJvb3RBY3Rpdml0eRkAAGZmZuSxQCL7AwoUc2YubGV4LlBhZ2V2aWV3RHJhZnQS4gMIAhEAAAAAAOOxQCkAAAAAAOOxQEEAAAAAACB8QEkAAAAAAIBuQGgAmAEAsgErc2NlbmFyaW9UcmFja2VyRW5hYmxlZC5pbnN0cnVtZW50YXRpb24ubHRuZ7IBI3VpLnNlcnZpY2VzLlBhZ2VTY29wZWRDYWNoZS5lbmFibGVksgEkY2xpZW50VGVsZW1ldHJ5Lmluc3RydW1lbnRhdGlvbi5sdG5nsgEgbzExeUVuYWJsZWQuaW5zdHJ1bWVudGF0aW9uLmx0bme6AR5sZHMudXNlTmV3VHJhY2tlZEZpZWxkQmVoYXZpb3K6ATBzY2VuYXJpb1RyYWNrZXJNYXJrc0VuYWJsZWQuaW5zdHJ1bWVudGF0aW9uLmx0bme6ASRicm93c2VySWRsZVRpbWUuaW5zdHJ1bWVudGF0aW9uLmx0bme6ASZjb21wb25lbnRQcm9maWxlci5pbnN0cnVtZW50YXRpb24ubHRuZ7oBK28xMXlBdXJhQWN0aW9uc0VuYWJsZWQuaW5zdHJ1bWVudGF0aW9uLmx0bmfwAQSqAg9QTEFDRUhPTERFUl9VUkyyAgRob21lugIOUExBQ0VIT0xERVJfSUTCAgdBY2NvdW502ALmjPkliQMAAAAAAOCXQEABUABYABkAAADM%2FCziQCgKMhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwOjkKEnNmLmxleC5QYWdlUGF5bG9hZBIjCAIiD1BMQUNFSE9MREVSX1VSTDIOUExBQ0VIT0xERVJfSURCFnNpdGVmb3JjZTpjb21tdW5pdHlBcHBKAjNnUhUKEXNmLmxleC5BcHBQYXlsb2FkEgAS5QEKDnNmLmxleC5QYWdlRW5kEtIBCc1kD4vrIXhCEhQIAREAAAAAoDDhQCkAAAAAAAAAABkAAAAA0CziQCIgNjJjNzRhYzQ2MWZhMTcyYjc1NTQ0MjQ1YmU5YTY3OGQoBDIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcDo5ChJzZi5sZXguUGFnZVBheWxvYWQSIwgBIg9QTEFDRUhPTERFUl9VUkwyDlBMQUNFSE9MREVSX0lEQhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwSgIzZ1IVChFzZi5sZXguQXBwUGF5bG9hZBIAGgAiAA%3D%3D%22%7D%7D%5D%7D";
                    auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                    auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                    auxURL = auxURL.Replace("0018Z00002hGxfeQAC", recordId);//userId
                    auxURL = auxURL.Replace("QPQi8lbYE8YujG6og6Dqgw", context.Fwuid);

                    strPost = "message=" + auxURL +
                              "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                              "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                              "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                    response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1",
                               strPost,
                               headers: hdrs,
                               _referer: "https://agibank.force.com/s/account/" + recordId + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                               _accept: "*/*");

                    #endregion

                    NavegaHome(response.ResponseUri.ToString());

                    return true;
                }
                else
                {
                    recordId = RetornaAuxSubstring(response.Content, "NewAccountSimulationFlow\",\"value\":\"", "\",\"objectType");
                }

                #region POST /s/sfsites/aura?r=8&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "303;a",
                    Descriptor = "serviceComponent://ui.force.components.controllers.recordGlobalValueProvider.RecordGvpController/ACTION$getRecord",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordDescriptor = recordId + "." + "0125A000001RcgjQAC" + ".null.null.null.Name.VIEW.false.null.Name," +
                                            "RecordType;2DeveloperName," +
                                            "BirthdayPlaceState__c," +
                                            "LastModifiedDate," +
                                            "PersonContactId," +
                                            "Mother__c," +
                                            "Citizenship__c," +
                                            "LastModifiedBy;2Id," +
                                            "RecordType;2Name," +
                                            "Salutation," +
                                            "BirthdayPlaceCity__c," +
                                            "IsDeceased__c," +
                                            "OccupationId__c," +
                                            "Father__c," +
                                            "SocialName__c," +
                                            "DeathKnowledgeDate__c," +
                                            "CreatedBy;2Id," +
                                            "CreatedById," +
                                            "CreatedBy;2Name," +
                                            "RecordTypeId," +
                                            "Education__c," +
                                            "DeathDate__c," +
                                            "RecordType;2Id," +
                                            "RelationshipStartDate__c," +
                                            "IsEmployee__c," +
                                            "IsPersonAccount," +
                                            "FirstName," +
                                            "MaritalStatus__c," +
                                            "Gender__c," +
                                            "RecordType;2IsPersonType," +
                                            "MiddleName," +
                                            "AgiCustomer__c," +
                                            "OccupationId__r;2Id," +
                                            "OccupationId__r;2Name," +
                                            "LastModifiedBy;2Name," +
                                            "SystemModstamp," +
                                            "Type," +
                                            "Suffix," +
                                            "Document__c," +
                                            "CreatedDate," +
                                            "LastName," +
                                            "Id," +
                                            "LastModifiedById.null"
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                  "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                  "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordId + "/detail") +
                  "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordId + "/detail",
                           _accept: "*/*");

                auxURL = RetornaAuxSubstring(response.Content, "\"requestIds\":{\"", "\":[");
                auxURL = RetornaAuxSubstring(response.Content, "\"records\":{\"" + auxURL + "\":", "},\"recordTemplates\":{}");
                recordResponse = JsonConvert.DeserializeObject<RecordResponse>(auxURL);
                #endregion

                #region POST /s/sfsites/aura?r=9&CMTD.EnhancedRelatedList_CC.getMetadataFields=5&CMTD.EnhancedRelatedList_CC.getObjectAccess=5&CMTD.EnhancedRelatedList_CC.getRecordTypes=5&ui-comm-runtime-components-aura-components-siteforce-qb.Quarterback.validateRoute=1&ui-communities-components-aura-components-forceCommunity-seoAssistant.SeoAssistant.getRecordAndTranslationData=1&ui-communities-components-aura-components-forceCommunity-tabset.Tabset.getLocalizedRegionLabels=1&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22364%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.force.components.controllers.recordGlobalValueProvider.RecordGvpController%2FACTION%24getRecord%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22recordDescriptor%22%3A%220018Z00002hGxfeQAC.0125A000001RcgjQAC.FULL.null.null.null.VIEW.true.null.Name%2CRecordType%3B2DeveloperName.null%22%7D%7D%2C%7B%22id%22%3A%22365%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.seoAssistant.SeoAssistantController%2FACTION%24getRecordAndTranslationData%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FforceCommunity%3AseoAssistant%22%2C%22params%22%3A%7B%22recordId%22%3A%220018Z00002hGxfeQAC%22%2C%22fields%22%3A%5B%5D%2C%22activeLanguageCodes%22%3A%5B%22pt_BR%22%2C%22en_US%22%5D%7D%2C%22version%22%3A%2255.0%22%7D%2C%7B%22id%22%3A%22543%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%20style%3D%5C%22text-align%3A%20center%3B%5C%22%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.footer_agi_expanded.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22390%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22391%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetBenefitList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22392%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22413%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22414%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetLoanList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22415%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22436%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22437%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetAccountList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22438%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22459%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22460%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetCardList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22461%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22482%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22483%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22relatedListName%22%3A%22AssetInsuranceList%22%2C%22objectAPIName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22484%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22Asset%22%7D%7D%2C%7B%22id%22%3A%22556%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.tabset.TabsetController%2FACTION%24getLocalizedRegionLabels%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22componentId%22%3A%2211f0d640-68d5-431c-9600-34b03b458fed%22%7D%2C%22version%22%3A%2255.0%22%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22498%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.comm.runtime.components.aura.components.siteforce.qb.QuarterbackController%2FACTION%24validateRoute%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22routeId%22%3A%22e23ec990-e932-413f-9157-d68d449b39ef%22%2C%22viewParams%22%3A%7B%22viewid%22%3A%220076d481-f00c-413c-ad91-e083e79224cc%22%2C%22view_uddid%22%3A%220I36e00000Ep09J%22%2C%22entity_name%22%3A%22Account%22%2C%22audience_name%22%3A%22BPO%22%2C%22recordId%22%3A%220018Z00002hGxfeQAC%22%2C%22recordName%22%3A%22detail%22%2C%22picasso_id%22%3A%22e23ec990-e932-413f-9157-d68d449b39ef%22%2C%22routeId%22%3A%22e23ec990-e932-413f-9157-d68d449b39ef%22%7D%7D%7D%2C%7B%22id%22%3A%22572%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.chatter.components.aura.components.forceChatter.groups.GroupAnnouncementController%2FACTION%24getAnnouncement%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22groupId%22%3A%220F96e000000fysaCAA%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22573%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cb%20style%3D%5C%22color%3A%20rgb(68%2C%2068%2C%2068)%3B%20font-size%3A%2036px%3B%5C%22%3EQue%20bom%20te%20ver%20por%20aqui%2C%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%200%2C%200)%3B%20font-size%3A%2036px%3B%5C%22%3E%20%3C%2Fb%3E%3Cb%20style%3D%5C%22color%3A%20rgb(0%2C%20102%2C%20204)%3B%20font-size%3A%2036px%3B%5C%22%3ECaio%3C%2Fb%3E%3Cb%20style%3D%5C%22font-size%3A%2036px%3B%5C%22%3E%20%3A)%3C%2Fb%3E%3C%2Fp%3E%3Cp%3E%26nbsp%3B%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22574%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.digitacao.1%7D%5C%22%20style%3D%5C%22width%3A%20568.641px%3B%20height%3A%2078.4219px%3B%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22508%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22flowName%22%3A%22NewAccountSimulationFlow%22%7D%7D%2C%7B%22id%22%3A%22575%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.buscar_proposta.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%2C%7B%22id%22%3A%22512%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.flowCommunity.FlowCommunityController%2FACTION%24canViewFlow%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22flowName%22%3A%22OrderProductSearchFlow%22%7D%7D%2C%7B%22id%22%3A%22523%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24isFeedEnabled%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22dashboardId%22%3A%2201Z6e000001DeZoEAK%22%7D%7D%2C%7B%22id%22%3A%22524%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardComponentController%2FACTION%24getAdditionalParameters%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%7D%7D%2C%7B%22id%22%3A%22576%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22html%22%3A%22%3Cp%20style%3D%5C%22text-align%3A%20center%3B%5C%22%3E%3Cimg%20class%3D%5C%22sfdcCbImage%5C%22%20src%3D%5C%22%7B!contentAsset.footer_agi_expanded.1%7D%5C%22%20%2F%3E%3C%2Fp%3E%22%7D%2C%22storable%22%3Atrue%7D%5D%7D";
                auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                auxURL = auxURL.Replace("0018Z00002hDeS6QAK", recordResponse.Account.Record.Id);//userId

                strPost = "message=" + auxURL +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&CMTD.EnhancedRelatedList_CC.getMetadataFields=5&CMTD.EnhancedRelatedList_CC.getObjectAccess=5&CMTD.EnhancedRelatedList_CC.getRecordTypes=5&ui-comm-runtime-components-aura-components-siteforce-qb.Quarterback.validateRoute=1&ui-communities-components-aura-components-forceCommunity-seoAssistant.SeoAssistant.getRecordAndTranslationData=1&ui-communities-components-aura-components-forceCommunity-tabset.Tabset.getLocalizedRegionLabels=1&ui-force-components-controllers-recordGlobalValueProvider.RecordGvp.getRecord=1&ui-interaction-runtime-components-controllers.FlowRuntime.executeAction=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=10&aura.ApexAction.execute=3 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "467;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountController",
                        Method = "getHighlight",
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        },
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "468;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "NewCaseButtonController",
                        Method = "isVisible",
                        Cacheable = false,
                        IsContinuation = false

                    },
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "469;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountOpportunitiesController",
                        Method = "isVisible",
                        Cacheable = false,
                        IsContinuation = false

                    },
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=3",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=11&aura.ApexAction.execute=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "476;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountController",
                        Method = "getPrimaryEmail",
                        Params = new JSONObjects.ActionParams()
                        {
                            RecordId = recordResponse.Account.Record.Id
                        },
                        Cacheable = true,
                        IsContinuation = false

                    },
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=12&aura.RecordUi.getRecordWithFields=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "477;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id,
                        Fields = null
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);
                auxURL = auxURL.Replace("}}]}", ",\"fields\":[\"Account.Rating\"]}}]}");

                strPost = "message=" + WebUtility.UrlEncode(auxURL) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.RecordUi.getRecordWithFields=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=13&aura.ApexAction.execute=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "478;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "ContactController",
                        Method = "getByAccountId",
                        Params = new ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id,
                        },
                        Cacheable = true,
                        IsContinuation = false
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=14&aura.ApexAction.execute=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "500;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OperationalRecordController",
                        Method = "validateUserPermissionButtonOperationalRecord",
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=15&aura.ApexAction.execute=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "501;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OperationalRecordController",
                        Method = "findAssetByAccountIdAndGroup",
                        Params = new ActionParams()
                        {
                            RecordId = recordResponse.Account.Record.Id,
                        },
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=16&aura.ApexAction.execute=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "502;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AlertController",
                        Method = "getAlerts",
                        Params = new ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id,
                        },
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=17&aura.ApexAction.execute=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "503;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountController",
                        Method = "createTask",
                        Params = new ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id,
                        },
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=18&aura.RecordUi.getRecordWithFields=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();
                var optionaFields = new List<string>();
                optionaFields.Add("Account.AgiCustomer__c");
                optionaFields.Add("Account.BirthdayPlaceCity__c");
                optionaFields.Add("Account.BirthdayPlaceState__c");
                optionaFields.Add("Account.Citizenship__c");
                optionaFields.Add("Account.CreatedBy.Id");
                optionaFields.Add("Account.CreatedBy.Name");
                optionaFields.Add("Account.CreatedById");
                optionaFields.Add("Account.CreatedDate");
                optionaFields.Add("Account.DeathDate__c");
                optionaFields.Add("Account.DeathKnowledgeDate__c");
                optionaFields.Add("Account.Document__c");
                optionaFields.Add("Account.Education__c");
                optionaFields.Add("Account.Father__c");
                optionaFields.Add("Account.FirstName");
                optionaFields.Add("Account.Gender__c");
                optionaFields.Add("Account.Id");
                optionaFields.Add("Account.IsDeceased__c");
                optionaFields.Add("Account.IsEmployee__c");
                optionaFields.Add("Account.IsPersonAccount");
                optionaFields.Add("Account.LastModifiedBy.Id");
                optionaFields.Add("Account.LastModifiedBy.Name");
                optionaFields.Add("Account.LastModifiedById");
                optionaFields.Add("Account.LastModifiedDate");
                optionaFields.Add("Account.LastName");
                optionaFields.Add("Account.MaritalStatus__c");
                optionaFields.Add("Account.MiddleName");
                optionaFields.Add("Account.Mother__c");
                optionaFields.Add("Account.Name");
                optionaFields.Add("Account.OccupationId__c");
                optionaFields.Add("Account.OccupationId__r");
                optionaFields.Add("Account.PersonContactId");
                optionaFields.Add("Account.Rating");
                optionaFields.Add("Account.RecordType.DeveloperName");
                optionaFields.Add("Account.RecordType.Id");
                optionaFields.Add("Account.RecordType.IsPersonType");
                optionaFields.Add("Account.RecordType.Name");
                optionaFields.Add("Account.RecordTypeId");
                optionaFields.Add("Account.RelationshipStartDate__c");
                optionaFields.Add("Account.Salutation");
                optionaFields.Add("Account.SocialName__c");
                optionaFields.Add("Account.Suffix");
                optionaFields.Add("Account.SystemModstamp");
                optionaFields.Add("Account.Type");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "504;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id,
                        Fields = null,
                        OptionalFields = optionaFields,
                    },
                }); ;

                auxURL = JsonConvert.SerializeObject(objRequest);
                auxURL = auxURL.Replace("\"fields\":null", "\"fields\":[\"Account.RegistrationStatus__c\"]");

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=19&CMTD.EnhancedRelatedList_CC.getSObjectRecords=5&aura.RecordUi.getObjectInfo=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();
                optionaFields = new List<string>();
                optionaFields.Add("Account.AgiCustomer__c");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "505;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id,
                        Fields = null
                    },
                }); ;

                auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22505%3Ba%22%2C%22descriptor%22%3A%22aura%3A%2F%2FRecordUiController%2FACTION%24getObjectInfo%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22objectApiName%22%3A%22OperationalRecord__c%22%7D%7D%2C%7B%22id%22%3A%22508%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hDeS6QAK%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_Name%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_Segmentation%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Segmenta%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Segmentacao__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_PayMode%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Forma%20de%20Pagamento%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22PayMode__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_NextPayDate%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Dt.%20Pr%C3%B3x.%20Pagamento%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22NextPayDate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_NextUpdateProofLife%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Dt.%20Pr%C3%B3x.%20Prova%20de%20Vida%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22NextUpdateProofLife__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_Situation%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Situa%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Situation__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetBenefitList_SubStatusDescription%5C%22%2C%5C%22columnOrder%5C%22%3A7%2C%5C%22columnLabel%5C%22%3A%5C%22Sub%20Status%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22SubStatusDescription__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hDeS6QAK%22%2C%22filter%22%3A%22Group__c%20%3D%20'Benefit'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22510%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hDeS6QAK%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_Number%5C%22%2C%5C%22columnOrder%5C%22%3A0%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Number__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductName__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20de%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductType__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_IssueDate%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Data%20de%20Emiss%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22IssueDate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_GrossValue%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20Bruto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22GrossValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_NetValue%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20L%C3%ADquido%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22NetValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_ReleasedValue%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20Liberado%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ReleasedValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_InstallmentValue%5C%22%2C%5C%22columnOrder%5C%22%3A7%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20da%20Parcela%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22InstallmentValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_MonthlyRate%5C%22%2C%5C%22columnOrder%5C%22%3A8%2C%5C%22columnLabel%5C%22%3A%5C%22Taxa%20Mensal%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22MonthlyRate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetLoanList_Status%5C%22%2C%5C%22columnOrder%5C%22%3A9%2C%5C%22columnLabel%5C%22%3A%5C%22Status%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Status%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hDeS6QAK%22%2C%22filter%22%3A%22Group__c%20%3D%20'Loan'%22%2C%22sortType%22%3A%22Status%20ASC%2C%20IssueDate__c%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22512%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hDeS6QAK%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_Name%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_Branch%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Ag%C3%AAncia%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Branch__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_AliasNumber%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Alias%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22AliasNumber__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Nome%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductName__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductType__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetAccountList_Situation%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Situa%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Situation__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hDeS6QAK%22%2C%22filter%22%3A%22Group__c%20%3D%20'Account'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22514%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hDeS6QAK%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_Name%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22Descri%C3%A7%C3%A3o%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Nome%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductName__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ProductType__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_PaymentDueDate%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Dt.%20Venc.%20%C3%9Altima%20Fatura%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22PaymentDueDate__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_BillingAmount%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Vl.%20%C3%9Altima%20Fatura%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22BillingAmount__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_ClosingDay%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Melhor%20Dia%20de%20Compra%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22ClosingDay__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3A%5C%22Badge%5C%22%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetCardList_Situation%5C%22%2C%5C%22columnOrder%5C%22%3A6%2C%5C%22columnLabel%5C%22%3A%5C%22Status%20da%20Conta%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Status%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hDeS6QAK%22%2C%22filter%22%3A%22Group__c%20%3D%20'CardSignature'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%2C%7B%22id%22%3A%22516%3Ba%22%2C%22descriptor%22%3A%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%22%2C%22callingDescriptor%22%3A%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%22%2C%22params%22%3A%7B%22recId%22%3A%220018Z00002hDeS6QAK%22%2C%22fieldsToDisplay%22%3A%22%5B%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3A%5C%22Id%5C%22%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_Number%5C%22%2C%5C%22columnOrder%5C%22%3A1%2C%5C%22columnLabel%5C%22%3A%5C%22N%C3%BAmero%20do%20Seguro%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Number__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_ProductName%5C%22%2C%5C%22columnOrder%5C%22%3A2%2C%5C%22columnLabel%5C%22%3A%5C%22Nome%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Product2Id.Name%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_ProductType%5C%22%2C%5C%22columnOrder%5C%22%3A3%2C%5C%22columnLabel%5C%22%3A%5C%22Tipo%20do%20Produto%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Product2Id.Tipo__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_InstallmentValue%5C%22%2C%5C%22columnOrder%5C%22%3A4%2C%5C%22columnLabel%5C%22%3A%5C%22Valor%20do%20Pr%C3%AAmio%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22InstallmentValue__c%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%2C%7B%5C%22uiType%5C%22%3Anull%2C%5C%22targetApiName%5C%22%3Anull%2C%5C%22isHeader%5C%22%3Afalse%2C%5C%22developerName%5C%22%3A%5C%22AssetInsuranceList_Status%5C%22%2C%5C%22columnOrder%5C%22%3A5%2C%5C%22columnLabel%5C%22%3A%5C%22Status%5C%22%2C%5C%22columnApiName%5C%22%3A%5C%22Status%5C%22%2C%5C%22colorCode%5C%22%3Anull%7D%5D%22%2C%22objectAPIName%22%3A%22Asset%22%2C%22parentIdField%22%3A%22AccountId%22%2C%22parentId%22%3A%220018Z00002hDeS6QAK%22%2C%22filter%22%3A%22Group__c%20%3D%20'Insurance'%22%2C%22sortType%22%3A%22CreatedDate%20DESC%22%2C%22maxLimit%22%3A50%7D%7D%5D%7D";
                auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                auxURL = auxURL.Replace("0018Z00002hGxfeQAC", recordResponse.Account.Record.Id);//userId
                auxURL = auxURL.Replace("QPQi8lbYE8YujG6og6Dqgw", context.Fwuid);

                strPost = "message=" + auxURL +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&CMTD.EnhancedRelatedList_CC.getSObjectRecords=5&aura.RecordUi.getObjectInfo=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=20&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();
                optionaFields = new List<string>();
                optionaFields.Add("Account.AgiCustomer__c");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "505;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id,
                        Fields = null
                    },
                }); ;

                auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22538%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.instrumentation.components.beacon.InstrumentationBeaconController%2FACTION%24sendData%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22batch%22%3A%5B%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A3360.1%2C%5C%22duration%5C%22%3A194%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3362.29%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A6%2C%5C%22requestLength%5C%22%3A2012%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22252%3Ba%5C%22%2C%5C%22262%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%223362290000fd0547cc%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2370%2C%5C%22xhrDuration%5C%22%3A179%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A3362%2C%5C%22fetchStart%5C%22%3A3362%2C%5C%22requestStart%5C%22%3A3363%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A178%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2670%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A21%2C%5C%22xhrDelay%5C%22%3A10%7D%2C%5C%22duration%5C%22%3A189%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3362.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22252%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A21%2C%5C%22boxCarCount%5C%22%3A2%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A190%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-search-sgdp-fetch-getPermsAndPrefs%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22tStart%5C%22%3A1658464794711%2C%5C%22cacheHit%5C%22%3Afalse%2C%5C%22etCacheGet%5C%22%3A1%2C%5C%22actionId%5C%22%3A%5C%22262%3Ba%5C%22%2C%5C%22tSending%5C%22%3A1658464794906%2C%5C%22etDataCopy%5C%22%3A0%2C%5C%22tEnd%5C%22%3A1658464794906%2C%5C%22name%5C%22%3A%5C%22DEFAULT%5C%22%2C%5C%22groupId%5C%22%3A%5C%22COMMUNITIES%5C%22%2C%5C%22requestType%5C%22%3A%5C%22getPermsAndPrefs%5C%22%2C%5C%22etTransaction%5C%22%3A195%2C%5C%22requestId%5C%22%3A%5C%22forceSearchInputDesktop%3A154%3A0%5C%22%2C%5C%22requestCmp%5C%22%3A%5C%22forceSearchInputDesktop%5C%22%2C%5C%22requestCmpId%5C%22%3A%5C%22154%3A0%5C%22%2C%5C%22sourceCmp%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22time%5C%22%3A1658464794906%2C%5C%22page%5C%22%3A%7B%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A3359.7%2C%5C%22duration%5C%22%3A308%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3362.29%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A6%2C%5C%22requestLength%5C%22%3A2012%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22252%3Ba%5C%22%2C%5C%22262%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%223362290000fd0547cc%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2370%2C%5C%22xhrDuration%5C%22%3A179%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A3362%2C%5C%22fetchStart%5C%22%3A3362%2C%5C%22requestStart%5C%22%3A3363%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A178%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2670%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A21%2C%5C%22xhrDelay%5C%22%3A10%7D%2C%5C%22duration%5C%22%3A189%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A3362.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22252%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A2%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A21%2C%5C%22boxCarCount%5C%22%3A2%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A190%7D%2C%7B%5C%22ts%5C%22%3A3360.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22262%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.search.components.forcesearch.sgdp.PermsAndPrefsCacheController%2FACTION%24getPermsAndPrefs%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A2%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A21%2C%5C%22boxCarCount%5C%22%3A2%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A194%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-search-sgdp-request-getPermsAndPrefs%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22tStart%5C%22%3A1658464794711%2C%5C%22cacheHit%5C%22%3Afalse%2C%5C%22etCacheGet%5C%22%3A1%2C%5C%22actionId%5C%22%3A%5C%22262%3Ba%5C%22%2C%5C%22tSending%5C%22%3A1658464794906%2C%5C%22etDataCopy%5C%22%3A0%2C%5C%22tEnd%5C%22%3A1658464795020%2C%5C%22name%5C%22%3A%5C%22DEFAULT%5C%22%2C%5C%22groupId%5C%22%3A%5C%22COMMUNITIES%5C%22%2C%5C%22requestType%5C%22%3A%5C%22getPermsAndPrefs%5C%22%2C%5C%22etTransaction%5C%22%3A309%2C%5C%22requestId%5C%22%3A%5C%22forceSearchInputDesktop%3A154%3A0%5C%22%2C%5C%22requestCmp%5C%22%3A%5C%22forceSearchInputDesktop%5C%22%2C%5C%22requestCmpId%5C%22%3A%5C%22154%3A0%5C%22%2C%5C%22etSendDataWait%5C%22%3A114%2C%5C%22sourceCmp%5C%22%3A%5C%22forceSearch%3AsearchGDPCachePermsAndPrefs%5C%22%2C%5C%22time%5C%22%3A1658464795020%2C%5C%22page%5C%22%3A%7B%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A1174.7%2C%5C%22pageStartTime%5C%22%3A1658464794020%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Dashboard%5C%22%2C%5C%22context%5C%22%3A%5C%22%5C%22%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22Load%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%7D%2C%5C%22sequence%5C%22%3A6%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A0%2C%5C%22duration%5C%22%3A1188%2C%5C%22pageStartTime%5C%22%3A1658464794020%2C%5C%22marks%5C%22%3A%7B%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A81.2%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A81.2%7D%5D%7D%5D%7D%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22bootstrap%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22framework%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22cache%5C%22%3A%7B%5C%22appCache%5C%22%3Afalse%2C%5C%22gvps%5C%22%3Afalse%7D%2C%5C%22execBootstrapJs%5C%22%3A892%2C%5C%22execInlineJs%5C%22%3A892%2C%5C%22appCssLoading%5C%22%3Anull%2C%5C%22visibilityStateStart%5C%22%3A%5C%22visible%5C%22%2C%5C%22execAuraJs%5C%22%3A930%2C%5C%22runInitAsync%5C%22%3A1013%2C%5C%22runAfterContextCreated%5C%22%3A1024%2C%5C%22runAfterInitDefsReady%5C%22%3A1024%2C%5C%22runAfterBootstrapReady%5C%22%3A1025%2C%5C%22AuraFrameworkEPT%5C%22%3A1025%2C%5C%22appCreationStart%5C%22%3A1071%2C%5C%22appCreationEnd%5C%22%3A1152%2C%5C%22appRenderingStart%5C%22%3A1152%2C%5C%22appRenderingEnd%5C%22%3A1188%2C%5C%22bootstrapEPT%5C%22%3A1188%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22mode%5C%22%3A%5C%22PROD%5C%22%2C%5C%22maxAllowedParallelXHRCounts%5C%22%3A6%2C%5C%22pageStartTime%5C%22%3A1658464794020%2C%5C%22timing%5C%22%3A%7B%5C%22navigationStart%5C%22%3A1658464794020%2C%5C%22fetchStart%5C%22%3A1658464794025%2C%5C%22readyStart%5C%22%3A5%2C%5C%22dnsStart%5C%22%3A1658464794025%2C%5C%22dnsEnd%5C%22%3A1658464794025%2C%5C%22lookupDomainTime%5C%22%3A0%2C%5C%22connectStart%5C%22%3A1658464794025%2C%5C%22connectEnd%5C%22%3A1658464794025%2C%5C%22connectTime%5C%22%3A0%2C%5C%22requestStart%5C%22%3A1658464794031%2C%5C%22responseStart%5C%22%3A1658464794504%2C%5C%22responseEnd%5C%22%3A1658464794508%2C%5C%22requestTime%5C%22%3A477%2C%5C%22domLoading%5C%22%3A1658464794631%2C%5C%22domInteractive%5C%22%3A1658464795027%2C%5C%22initDomTreeTime%5C%22%3A519%2C%5C%22contentLoadStart%5C%22%3A1658464795027%2C%5C%22contentLoadEnd%5C%22%3A1658464795029%2C%5C%22domComplete%5C%22%3A1658464795029%2C%5C%22domReadyTime%5C%22%3A2%2C%5C%22loadEventStart%5C%22%3A1658464795029%2C%5C%22loadEventEnd%5C%22%3A1658464795029%2C%5C%22loadEventTime%5C%22%3A0%2C%5C%22loadTime%5C%22%3A1004%2C%5C%22unloadEventStart%5C%22%3A0%2C%5C%22unloadEventEnd%5C%22%3A0%2C%5C%22unloadEventTime%5C%22%3A0%2C%5C%22appCacheTime%5C%22%3A0%2C%5C%22redirectTime%5C%22%3A0%7D%2C%5C%22type%5C%22%3A%5C%22WARM%5C%22%2C%5C%22allRequests%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2FdesktopDashboards%2FdashboardApp.app%3FdashboardId%3D01Z6e000001DeZoEAK%26displayMode%3Dview%26networkId%3D0DB6e000000k9hL%26userId%3D0056e00000CpOw5AAF%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22navigation%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22duration%5C%22%3A488%2C%5C%22startTime%5C%22%3A0%2C%5C%22fetchStart%5C%22%3A6%2C%5C%22serverTime%5C%22%3A138%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A11%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A330621%2C%5C%22encodedBodySize%5C%22%3A330321%2C%5C%22decodedBodySize%5C%22%3A330321%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A484%2C%5C%22transfer%5C%22%3A3%7D%2C%7B%5C%22name%5C%22%3A%5C%22app.css%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A25%2C%5C%22startTime%5C%22%3A615%2C%5C%22fetchStart%5C%22%3A615%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A615%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A1033083%2C%5C%22decodedBodySize%5C%22%3A1033083%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A3%2C%5C%22transfer%5C%22%3A22%7D%2C%7B%5C%22name%5C%22%3A%5C%22%2Faura_%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A22%2C%5C%22startTime%5C%22%3A615%2C%5C%22fetchStart%5C%22%3A615%2C%5C%22serverTime%5C%22%3A28%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A615%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A795001%2C%5C%22decodedBodySize%5C%22%3A795001%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A3%2C%5C%22transfer%5C%22%3A19%7D%2C%7B%5C%22name%5C%22%3A%5C%22appcore.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A9%2C%5C%22startTime%5C%22%3A615%2C%5C%22fetchStart%5C%22%3A615%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A616%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A230968%2C%5C%22decodedBodySize%5C%22%3A230968%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A6%2C%5C%22transfer%5C%22%3A3%7D%2C%7B%5C%22name%5C%22%3A%5C%22app.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A51%2C%5C%22startTime%5C%22%3A616%2C%5C%22fetchStart%5C%22%3A616%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A616%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A2742765%2C%5C%22decodedBodySize%5C%22%3A2742765%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A6%2C%5C%22transfer%5C%22%3A45%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2FprojRes%2Finsights%2Fgen%2Fstatic%2Fdashboards%2Fjs%2FlightningDashboard.app.cc54f9ce16bf20938979.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22script%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A77%2C%5C%22startTime%5C%22%3A629%2C%5C%22fetchStart%5C%22%3A629%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A631%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A4700280%2C%5C%22decodedBodySize%5C%22%3A4700280%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A4%2C%5C%22transfer%5C%22%3A73%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2Fl%2F%257B%2522mode%2522%253A%2522PROD%2522%252C%2522app%2522%253A%2522desktopDashboards%253AdashboardApp%2522%252C%2522fwuid%2522%253A%2522QPQi8lbYE8YujG6og6Dqgw%2522%252C%2522loaded%2522%253A%257B%2522APPLICATION%2540markup%253A%252F%252FdesktopDashboards%253AdashboardApp%2522%253A%2522dghqF0d_-1GyB2E7z2jaSA%2522%257D%252C%2522mlr%2522%253A1%252C%2522pathPrefix%2522%253A%2522%2522%252C%2522dns%2522%253A%2522c%2522%252C%2522ls%2522%253A1%252C%2522lrmc%2522%253A%2522533941497%2522%257D%2Fresources.js%3Fpv%3D16584472730001196944436%26rv%3D1658272158000%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22script%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A5%2C%5C%22startTime%5C%22%3A631%2C%5C%22fetchStart%5C%22%3A631%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A632%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A4713%2C%5C%22decodedBodySize%5C%22%3A4713%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A2%2C%5C%22transfer%5C%22%3A2%7D%2C%7B%5C%22name%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%2F_slds%2Ficons%2Fstandard-sprite%2Fsvg%2Fsymbols.svg%23dashboard%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22use%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A3%2C%5C%22startTime%5C%22%3A1167%2C%5C%22fetchStart%5C%22%3A1167%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A1168%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A300430%2C%5C%22decodedBodySize%5C%22%3A300430%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1%2C%5C%22transfer%5C%22%3A1%7D%5D%2C%5C%22requestAppCss%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22app.css%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A25%2C%5C%22startTime%5C%22%3A615%2C%5C%22fetchStart%5C%22%3A615%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A615%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A1033083%2C%5C%22decodedBodySize%5C%22%3A1033083%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A3%2C%5C%22transfer%5C%22%3A22%7D%2C%5C%22requestAuraJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22%2Faura_%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A22%2C%5C%22startTime%5C%22%3A615%2C%5C%22fetchStart%5C%22%3A615%2C%5C%22serverTime%5C%22%3A28%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A615%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A795001%2C%5C%22decodedBodySize%5C%22%3A795001%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A3%2C%5C%22transfer%5C%22%3A19%7D%2C%5C%22requestAppCoreJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22appcore.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A9%2C%5C%22startTime%5C%22%3A615%2C%5C%22fetchStart%5C%22%3A615%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A616%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A230968%2C%5C%22decodedBodySize%5C%22%3A230968%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A6%2C%5C%22transfer%5C%22%3A3%7D%2C%5C%22requestAppJs%5C%22%3A%7B%5C%22name%5C%22%3A%5C%22app.js%5C%22%2C%5C%22initiatorType%5C%22%3A%5C%22link%5C%22%2C%5C%22nextHopProtocol%5C%22%3A%5C%22%5C%22%2C%5C%22duration%5C%22%3A51%2C%5C%22startTime%5C%22%3A616%2C%5C%22fetchStart%5C%22%3A616%2C%5C%22redirect%5C%22%3A0%2C%5C%22requestStart%5C%22%3A616%2C%5C%22incompleteTimings%5C%22%3Afalse%2C%5C%22transferSize%5C%22%3A0%2C%5C%22encodedBodySize%5C%22%3A2742765%2C%5C%22decodedBodySize%5C%22%3A2742765%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A6%2C%5C%22transfer%5C%22%3A45%7D%2C%5C%22connection%5C%22%3A%7B%5C%22rtt%5C%22%3A50%2C%5C%22downlink%5C%22%3A5.6%7D%2C%5C%22visibilityStateEnd%5C%22%3A%5C%22visible%5C%22%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A1176.4%2C%5C%22duration%5C%22%3A2858%2C%5C%22pageStartTime%5C%22%3A1658464794020%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A2280.4%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A1%2C%5C%22requestLength%5C%22%3A1166%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%228%3Ba%5C%22%5D%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1172%2C%5C%22xhrDuration%5C%22%3A194%2C%5C%22xhrStall%5C%22%3A1%2C%5C%22startTime%5C%22%3A2281%2C%5C%22fetchStart%5C%22%3A2281%2C%5C%22requestStart%5C%22%3A2282%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A193%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A1472%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A29%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A196%7D%2C%7B%5C%22ts%5C%22%3A2392.3%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A2%2C%5C%22requestLength%5C%22%3A1232%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%229%3Ba%5C%22%5D%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A3211%2C%5C%22xhrDuration%5C%22%3A238%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2392%2C%5C%22fetchStart%5C%22%3A2392%2C%5C%22requestStart%5C%22%3A2393%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A237%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3511%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A61%2C%5C%22xhrDelay%5C%22%3A7%7D%2C%5C%22duration%5C%22%3A245%7D%2C%7B%5C%22ts%5C%22%3A2847.5%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A3%2C%5C%22requestLength%5C%22%3A1192%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%2210%3Ba%5C%22%5D%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A3373%2C%5C%22xhrDuration%5C%22%3A236%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A2848%2C%5C%22fetchStart%5C%22%3A2848%2C%5C%22requestStart%5C%22%3A2848%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A235%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3674%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A62%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A237%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A1190.3%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%223%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A72%2C%5C%22db%5C%22%3A4%2C%5C%22xhrServerTime%5C%22%3A483%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1072%7D%2C%7B%5C%22ts%5C%22%3A1190.3%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%225%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A483%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1073%7D%2C%7B%5C%22ts%5C%22%3A1190.3%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%226%3Ba%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A33%2C%5C%22db%5C%22%3A13%2C%5C%22xhrServerTime%5C%22%3A483%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1073%7D%2C%7B%5C%22ts%5C%22%3A1177.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%227%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24describe%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A236%2C%5C%22db%5C%22%3A49%2C%5C%22xhrServerTime%5C%22%3A483%2C%5C%22boxCarCount%5C%22%3A4%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1086%7D%2C%7B%5C%22ts%5C%22%3A2280.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%228%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24showDynamicGaugeChartControls%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A0%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A29%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A197%7D%2C%7B%5C%22ts%5C%22%3A2392.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%229%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24getStatus%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A33%2C%5C%22db%5C%22%3A17%2C%5C%22xhrServerTime%5C%22%3A61%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A246%7D%2C%7B%5C%22ts%5C%22%3A2847.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%2210%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.analytics.dashboard.components.lightning.DashboardAppController%2FACTION%24getActions%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A32%2C%5C%22db%5C%22%3A11%2C%5C%22xhrServerTime%5C%22%3A62%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A237%7D%5D%2C%5C%22custom%5C%22%3A%5B%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22describeApiCall%5C%22%2C%5C%22ts%5C%22%3A1176.7%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22duration%5C%22%3A1100%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A1099%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22asyncPolling_1%5C%22%2C%5C%22ts%5C%22%3A2391.9%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22numRefreshing%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A251%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_1%5C%22%2C%5C%22ts%5C%22%3A2668.4%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWQAA0%5C%22%5D%2C%5C%22numRequested%5C%22%3A1%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_2%5C%22%2C%5C%22ts%5C%22%3A2728.3%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWRAA0%5C%22%2C%5C%2201a6e000003SbWSAA0%5C%22%2C%5C%2201a6e000003SbWTAA0%5C%22%2C%5C%2201a6e000003SbWUAA0%5C%22%5D%2C%5C%22numRequested%5C%22%3A4%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_3%5C%22%2C%5C%22ts%5C%22%3A2774.4%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWVAA0%5C%22%2C%5C%2201a6e000003SbWWAA0%5C%22%2C%5C%2201a6e000003SbWXAA0%5C%22%2C%5C%2201a6e000003SbWYAA0%5C%22%5D%2C%5C%22numRequested%5C%22%3A4%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22loadComponentsApiCall_4%5C%22%2C%5C%22ts%5C%22%3A2811.9%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentIdList%5C%22%3A%5B%5C%2201a6e000003SbWZAA0%5C%22%2C%5C%2201a6e000003SbWaAAK%5C%22%2C%5C%2201a6e000003SbWbAAK%5C%22%5D%2C%5C%22numRequested%5C%22%3A3%2C%5C%22networkId%5C%22%3A%5C%220DB6e000000k9hL%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22duration%5C%22%3A0%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22firstComponentRendered%5C%22%2C%5C%22ts%5C%22%3A1176.5%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWRAA0%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A2783%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22viewportRendering%5C%22%2C%5C%22ts%5C%22%3A1176.5%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22success%5C%22%3Atrue%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A2850%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22legacyMark%5C%22%2C%5C%22ts%5C%22%3A1176.5%2C%5C%22context%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22duration%5C%22%3A2850%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWQAA0%5C%22%2C%5C%22ts%5C%22%3A4018.2%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWQAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Afalse%2C%5C%22isChartSkippedRendering%5C%22%3Atrue%2C%5C%22type%5C%22%3A%5C%22update%5C%22%2C%5C%22reason%5C%22%3A%5C%22noChange%5C%22%7D%2C%5C%22duration%5C%22%3A13%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWSAA0%5C%22%2C%5C%22ts%5C%22%3A4022.6%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWSAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Afalse%2C%5C%22isChartSkippedRendering%5C%22%3Atrue%2C%5C%22type%5C%22%3A%5C%22update%5C%22%2C%5C%22reason%5C%22%3A%5C%22noChange%5C%22%7D%2C%5C%22duration%5C%22%3A9%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWUAA0%5C%22%2C%5C%22ts%5C%22%3A4026.6%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWUAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Afalse%2C%5C%22isChartSkippedRendering%5C%22%3Atrue%2C%5C%22type%5C%22%3A%5C%22update%5C%22%2C%5C%22reason%5C%22%3A%5C%22noChange%5C%22%7D%2C%5C%22duration%5C%22%3A5%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWRAA0%5C%22%2C%5C%22ts%5C%22%3A3959.8%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWRAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796770%2C%5C%22duration%5C%22%3A1282%2C%5C%22syncDuration%5C%22%3A6%2C%5C%22resetScroll-scrollTo%5C%22%3A23%2C%5C%22moduleImport%5C%22%3A1103%2C%5C%22script%5C%22%3A3%2C%5C%22animate%5C%22%3A73%2C%5C%22animate-scene%5C%22%3A72%2C%5C%22animate-scene-diffToModel%5C%22%3A4%2C%5C%22animate-scene-rendering%5C%22%3A3%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A2%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A2%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A73%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWTAA0%5C%22%2C%5C%22ts%5C%22%3A3982.3%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWTAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796775%2C%5C%22duration%5C%22%3A1278%2C%5C%22syncDuration%5C%22%3A3%2C%5C%22resetScroll-scrollTo%5C%22%3A18%2C%5C%22moduleImport%5C%22%3A1103%2C%5C%22script%5C%22%3A2%2C%5C%22animate%5C%22%3A50%2C%5C%22animate-scene%5C%22%3A49%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A51%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWVAA0%5C%22%2C%5C%22ts%5C%22%3A3989.4%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWVAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796814%2C%5C%22duration%5C%22%3A1239%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A15%2C%5C%22moduleImport%5C%22%3A1067%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A43%2C%5C%22animate-scene%5C%22%3A43%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A44%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWWAA0%5C%22%2C%5C%22ts%5C%22%3A3993%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWWAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796816%2C%5C%22duration%5C%22%3A1237%2C%5C%22syncDuration%5C%22%3A3%2C%5C%22resetScroll-scrollTo%5C%22%3A13%2C%5C%22moduleImport%5C%22%3A1067%2C%5C%22script%5C%22%3A2%2C%5C%22animate%5C%22%3A40%2C%5C%22animate-scene%5C%22%3A40%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A40%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWXAA0%5C%22%2C%5C%22ts%5C%22%3A3998.1%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWXAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796817%2C%5C%22duration%5C%22%3A1236%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A13%2C%5C%22moduleImport%5C%22%3A1066%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A35%2C%5C%22animate-scene%5C%22%3A35%2C%5C%22animate-scene-diffToModel%5C%22%3A2%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A35%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWYAA0%5C%22%2C%5C%22ts%5C%22%3A4003.3%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWYAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796818%2C%5C%22duration%5C%22%3A1235%2C%5C%22syncDuration%5C%22%3A1%2C%5C%22resetScroll-scrollTo%5C%22%3A12%2C%5C%22moduleImport%5C%22%3A1065%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A29%2C%5C%22animate-scene%5C%22%3A29%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A0%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A30%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWZAA0%5C%22%2C%5C%22ts%5C%22%3A4006.4%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWZAA0%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796854%2C%5C%22duration%5C%22%3A1199%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A32%2C%5C%22moduleImport%5C%22%3A1010%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A26%2C%5C%22animate-scene%5C%22%3A26%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A27%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWaAAK%5C%22%2C%5C%22ts%5C%22%3A4009.6%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWaAAK%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796855%2C%5C%22duration%5C%22%3A1198%2C%5C%22syncDuration%5C%22%3A2%2C%5C%22resetScroll-scrollTo%5C%22%3A31%2C%5C%22moduleImport%5C%22%3A1011%2C%5C%22script%5C%22%3A1%2C%5C%22animate%5C%22%3A23%2C%5C%22animate-scene%5C%22%3A23%2C%5C%22animate-scene-diffToModel%5C%22%3A0%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A1%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A1%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A0%7D%2C%5C%22duration%5C%22%3A24%7D%2C%7B%5C%22ns%5C%22%3A%5C%22sfxDashboard%5C%22%2C%5C%22name%5C%22%3A%5C%22chartRendering_01a6e000003SbWbAAK%5C%22%2C%5C%22ts%5C%22%3A4014.1%2C%5C%22context%5C%22%3A%7B%5C%22componentId%5C%22%3A%5C%2201a6e000003SbWbAAK%5C%22%2C%5C%22numChartPoints%5C%22%3A1%2C%5C%22componentType%5C%22%3A%5C%22Metric%5C%22%2C%5C%22success%5C%22%3Atrue%2C%5C%22isChartSkippedRendering%5C%22%3Afalse%2C%5C%22name%5C%22%3A%5C%22render%5C%22%2C%5C%22startTime%5C%22%3A1658464796856%2C%5C%22duration%5C%22%3A1197%2C%5C%22syncDuration%5C%22%3A3%2C%5C%22resetScroll-scrollTo%5C%22%3A30%2C%5C%22moduleImport%5C%22%3A1011%2C%5C%22script%5C%22%3A2%2C%5C%22animate%5C%22%3A19%2C%5C%22animate-scene%5C%22%3A19%2C%5C%22animate-scene-diffToModel%5C%22%3A1%2C%5C%22animate-scene-rendering%5C%22%3A1%2C%5C%22animate-scene-rendering-remove-invisible%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test%5C%22%3A0%2C%5C%22animate-scene-rendering-visibility-test-tweener%5C%22%3A0%2C%5C%22animate-scene-rendering-accessibility%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A20%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22desktopDashboards%3AdashboardApp%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-dashboardLoad%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22dashboardId%5C%22%3A%5C%2201Z6e000001DeZoEAK%5C%22%2C%5C%22asyncLoadUniqueId%5C%22%3A%5C%2201Z6e000001DeZoEAK_0056e00000CpOw5AAF_desktopDashboards%3Adashboard_1658464795196%5C%22%2C%5C%22numberOfComponents%5C%22%3A12%2C%5C%22numberOfTableComponents%5C%22%3A0%2C%5C%22loadMetadataDuration%5C%22%3A1100%2C%5C%22numRefreshing%5C%22%3A0%2C%5C%22viewportLoadComponent%5C%22%3A1637%2C%5C%22viewportLoadComponentFailCount%5C%22%3A0%2C%5C%22cumulativeLoadComponentsDuration%5C%22%3A0%2C%5C%22numberOfComponentsRenderedByCache%5C%22%3A12%2C%5C%22numberOfApiCallsAvoidedByCacheHit%5C%22%3A4%2C%5C%22numberOfComponentsWithVBarComboChart%5C%22%3A0%2C%5C%22dashboardTopNComponents%5C%22%3A%7B%5C%22numberOfTopNComponentsWithTableChart%5C%22%3A0%2C%5C%22numberOfTopNComponentsWithNonTableChart%5C%22%3A0%7D%2C%5C%22dashboardFilters%5C%22%3A%7B%5C%22numberOfFilters%5C%22%3A2%7D%2C%5C%22numberOfOptionsPerFilter%5C%22%3A%5B%5C%224%5C%22%2C%5C%221%5C%22%5D%2C%5C%22flexTableColumnsById%5C%22%3A%5C%22%5C%22%2C%5C%22EPT%5C%22%3A2783%2C%5C%22numVisibleComponents%5C%22%3A12%2C%5C%22numVisibleComponentsRendered%5C%22%3A12%2C%5C%22legacyTimer%5C%22%3A2850%2C%5C%22viewportEPT%5C%22%3A2858%2C%5C%22loadComponentsApiCallForViewportEpt%5C%22%3A0%2C%5C%22blurred%5C%22%3Afalse%2C%5C%22numberOfFilters%5C%22%3A0%2C%5C%22success%5C%22%3Atrue%2C%5C%22context%5C%22%3A%5C%22%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%5C%22LWCMarksEnabled%5C%22%3Afalse%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A16966.29%2C%5C%22duration%5C%22%3A439%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A16966.5%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A7%2C%5C%22requestLength%5C%22%3A4723%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22281%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%221696650000086698e2%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A33771%2C%5C%22xhrDuration%5C%22%3A434%2C%5C%22xhrStall%5C%22%3A1%2C%5C%22startTime%5C%22%3A16967%2C%5C%22fetchStart%5C%22%3A16967%2C%5C%22requestStart%5C%22%3A16968%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A433%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A34072%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A251%2C%5C%22xhrDelay%5C%22%3A3%7D%2C%5C%22duration%5C%22%3A437%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22flowRuntimeHelper.handleActionSelected.NEXT%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22consumerIdentifier%5C%22%3A%5C%22flowRuntime%5C%22%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A17406.2%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3A%5C%22flowruntime%3AflowRuntimeV2%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-click%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22screenName%5C%22%3A%5C%22OpenAccountStep%5C%22%2C%5C%22flowDevName%5C%22%3A%5C%22NewAccountSimulationFlow%5C%22%2C%5C%22sectionsCount%5C%22%3A0%2C%5C%22columnsCount%5C%22%3A0%2C%5C%22screenFieldCounts%5C%22%3A%7B%5C%22c%3AnewAccountSimulationFlowNavigator%5C%22%3A1%7D%2C%5C%22totalFieldsCount%5C%22%3A1%2C%5C%22customerAuraLcCount%5C%22%3A0%2C%5C%22customerLwcLcCount%5C%22%3A1%2C%5C%22outOfTheBoxLcCount%5C%22%3A0%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22sequence%5C%22%3A7%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A17468%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22user%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communitynavigation%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22link%5C%22%2C%5C%22scope%5C%22%3A%5C%22communitynavigation%5C%22%2C%5C%22context%5C%22%3A%7B%5C%22unifiedEventType%5C%22%3A%5C%22COMMUNITY_PAGE_NAVIGATION%5C%22%2C%5C%22referrer%5C%22%3A%5C%22%2Fs%2F%5C%22%2C%5C%22requestURI%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hDeS6QAK%2Fdetail%5C%22%2C%5C%22entityId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%7D%7D%2C%5C%22sequence%5C%22%3A8%2C%5C%22page%5C%22%3A%7B%5C%22entity%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22entityType%5C%22%3A%5C%22Account%5C%22%2C%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A17470.39%2C%5C%22duration%5C%22%3A15708%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22pageTracker%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22pageId%5C%22%3A1%2C%5C%22phase%5C%22%3A%5C%22END%5C%22%2C%5C%22defaultCmp%5C%22%3A%5B%5D%2C%5C%22nonDefaultCmp%5C%22%3A%5B%5D%2C%5C%22backgroundTime%5C%22%3A0%2C%5C%22trxDeleted%5C%22%3A%7B%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A17471.89%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22defs%5C%22%3A%5B%5C%22markup%3A%2F%2Fc%3AnewAccountSimulationFlowNavigator%5C%22%5D%2C%5C%22pageCounter%5C%22%3A1%2C%5C%22phase%5C%22%3A%5C%22navFromPage%5C%22%2C%5C%22pageViewCounter%5C%22%3A1%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22scope%5C%22%3A%5C%22defsUsage%5C%22%7D%2C%5C%22sequence%5C%22%3A9%2C%5C%22page%5C%22%3A%7B%5C%22entity%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22entityType%5C%22%3A%5C%22Account%5C%22%2C%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A17461.7%2C%5C%22duration%5C%22%3A15%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AnavigationProvider%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22navigate%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22objectApiName%5C%22%3A%5C%22Account%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A17527.29%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Account%5C%22%2C%5C%22recordTypeSetInClient%5C%22%3Atrue%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22read%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%7D%2C%5C%22sequence%5C%22%3A10%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hDeS6QAK%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A17654.7%2C%5C%22duration%5C%22%3A1%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22resolveUrl%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A17668.29%2C%5C%22duration%5C%22%3A0%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22resolveUrl%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Aperformance%5C%22%2C%5C%22ts%5C%22%3A17901.7%2C%5C%22duration%5C%22%3A4%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AnavigationProvider%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22synthetic-communityembarcadero%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22methodName%5C%22%3A%5C%22navigate%5C%22%2C%5C%22pageType%5C%22%3A%5C%22standard__recordPage%5C%22%2C%5C%22pageAttributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22actionName%5C%22%3A%5C%22view%5C%22%7D%2C%5C%22success%5C%22%3Atrue%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A18283.1%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Account%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22read%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%2C%5C%22context%5C%22%3Anull%7D%2C%5C%22sequence%5C%22%3A11%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hDeS6QAK%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A19347.89%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22crud%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22read%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22recordId%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22recordType%5C%22%3A%5C%22Account%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22read%5C%22%2C%5C%22scope%5C%22%3A%5C%22force_record%5C%22%2C%5C%22context%5C%22%3Anull%7D%2C%5C%22sequence%5C%22%3A12%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hDeS6QAK%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPerformance%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3AnewDefs%5C%22%2C%5C%22ts%5C%22%3A20425.39%2C%5C%22duration%5C%22%3A0%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AcommunityApp%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22performance%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22newDefs%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22eventDefs%5C%22%3A%5B%5C%22markup%3A%2F%2Faura%3AserverActionError%5C%22%5D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A20482.5%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22locker-method-data%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22document.getElementsByTagName%5C%22%3A6%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3Anull%2C%5C%22sequence%5C%22%3A13%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hDeS6QAK%2Fdetail%5C%22%7D%7D%7D%22%7D%5D%2C%22traces%22%3A%22%5B%5D%22%2C%22metrics%22%3A%22%5B%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.Apex.getApex%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464809119%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811791%2C%5C%22value%5C%22%3A8%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.UiApi.getObjectInfo%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464810420%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.UiApi.getPicklistValues%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811791%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22request.UiApi.getRecord%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464810444%2C%5C%22value%5C%22%3A3%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22scenarioTime.ms%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464808226%2C%5C%22value%5C%22%3A%5B61%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageReceived.afterEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464808825%2C%5C%22value%5C%22%3A%5B40026%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageSent.afterEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464808825%2C%5C%22value%5C%22%3A%5B70617%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsage.instrSizePct%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464808825%2C%5C%22value%5C%22%3A%5B1%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464808789%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22BUILD_COMPONENT_TREE%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464808789%2C%5C%22value%5C%22%3A%5B30%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464808790%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.cfv%5C%22%2C%5C%22name%5C%22%3A%5C%22EVALUATE_VISIBILITY%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464808790%2C%5C%22value%5C%22%3A%5B1%2C0%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22NEXT%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464808318%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22NEXT%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464808318%2C%5C%22value%5C%22%3A%5B0%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22FINISH%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464809042%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22owner%5C%22%3A%5C%22flowclientruntime.navigation%5C%22%2C%5C%22name%5C%22%3A%5C%22NAVIGATION_ACTION%5C%22%2C%5C%22tags%5C%22%3A%7B%5C%22version%5C%22%3A%5C%22flowruntimeV2%5C%22%2C%5C%22navigationTarget%5C%22%3A%5C%22FINISH%5C%22%2C%5C%22status%5C%22%3A%5C%22success%5C%22%7D%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464809043%2C%5C%22value%5C%22%3A%5B1%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22name%5C%22%3A%5C%22ads-bridge-add-records-duration%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464810529%2C%5C%22value%5C%22%3A%5B6%2C1%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22network-response.200%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464810701%2C%5C%22value%5C%22%3A2%7D%2C%7B%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22name%5C%22%3A%5C%22ads-bridge-emit-record-changed-duration%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464810704%2C%5C%22value%5C%22%3A%5B2%2C2%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22name%5C%22%3A%5C%22network-response.403%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811789%2C%5C%22value%5C%22%3A1%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-policy-undefined%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811791%2C%5C%22value%5C%22%3A8%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811791%2C%5C%22value%5C%22%3A5%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count.Apex.getApex%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464809696%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count.UiApi.getRecord%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464810705%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-count.UiApi.getObjectInfo%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811791%2C%5C%22value%5C%22%3A1%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.Apex.getApex%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464809119%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811791%2C%5C%22value%5C%22%3A8%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.UiApi.getRecord%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464810445%2C%5C%22value%5C%22%3A3%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.UiApi.getObjectInfo%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464810420%2C%5C%22value%5C%22%3A1%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22request.UiApi.getPicklistValues%5C%22%2C%5C%22owner%5C%22%3A%5C%22LIGHTNING.lds.service%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464811791%2C%5C%22value%5C%22%3A2%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22PageNavWithoutST%5C%22%2C%5C%22owner%5C%22%3A%5C%22siteforce%3AcommunityApp%5C%22%2C%5C%22type%5C%22%3A%5C%22Counter%5C%22%2C%5C%22ts%5C%22%3A1658464808827%2C%5C%22value%5C%22%3A1%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-ingest-duration%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464810702%2C%5C%22value%5C%22%3A%5B4%2C0%2C0%2C0%2C0%2C0%2C0%2C1%2C1%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-size-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464811790%2C%5C%22value%5C%22%3A%5B46%2C48%2C50%2C59%2C60%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-snapshot-subscriptions-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464811790%2C%5C%22value%5C%22%3A%5B0%2C1%2C3%2C3%2C4%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-watch-subscriptions-count%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464811790%2C%5C%22value%5C%22%3A%5B2%2C2%2C2%2C2%2C2%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-broadcast-duration%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464811790%2C%5C%22value%5C%22%3A%5B0%2C0%2C2%2C0%2C0%2C0%2C1%2C0%2C2%2C0%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22store-lookup-duration%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464810703%2C%5C%22value%5C%22%3A%5B0%2C0%2C0%2C0%2C0%2C0%2C0%2C0%2C0%2C0%2C0%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-duration.Apex.getApex%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464809696%2C%5C%22value%5C%22%3A%5B383%2C576%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22record-conflicts-resolved%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464810702%2C%5C%22value%5C%22%3A%5B1%2C1%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-duration.UiApi.getRecord%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464810704%2C%5C%22value%5C%22%3A%5B530%2C260%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%2C%7B%5C%22name%5C%22%3A%5C%22cache-miss-duration.UiApi.getObjectInfo%5C%22%2C%5C%22owner%5C%22%3A%5C%22lds%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464811790%2C%5C%22value%5C%22%3A%5B1370%5D%2C%5C%22tags%5C%22%3A%7B%5C%22status%5C%22%3A%5C%22success%5C%22%7D%7D%5D%22%2C%22o11yLogs%22%3A%22CiEKBG8xMXkRZsazS0MieEIYAyAAKAAyCDIzOC4yNC4wOAASyAoKG3NmLmluc3RydW1lbnRhdGlvbi5BY3Rpdml0eRKDAgkzOwlLQyJ4QhJYChAyNDI4ZGE2ODJmZDE3NmFhEgxBcGV4LmdldEFwZXgZAACAZmbmd0AiKQoZc2YuaW5zdHJ1bWVudGF0aW9uLlNpbXBsZRIMCgpjYWNoZS1taXNzUABYABkAAAA0s1bRQCIgODk1NjM3MmMxOTRkOWYzYTQyYzg0NzYxYmY1ZTI3ZjQoBTIDbGRzOjkKEnNmLmxleC5QYWdlUGF5bG9hZBIjCAEiD1BMQUNFSE9MREVSX1VSTDIOUExBQ0VIT0xERVJfSURCFnNpdGVmb3JjZTpjb21tdW5pdHlBcHBKAjRnUhUKEXNmLmxleC5BcHBQYXlsb2FkEgAShgIJAGAJS0MieEISWwoQZjFjMTM5Mjc3NGQ0NzUzZBIPVWlBcGkuZ2V0UmVjb3JkGQAAMDMzj4BAIikKGXNmLmluc3RydW1lbnRhdGlvbi5TaW1wbGUSDAoKY2FjaGUtbWlzc1AAWAAZAAAAaEZX0UAiIDg5NTYzNzJjMTk0ZDlmM2E0MmM4NDc2MWJmNWUyN2Y0KAYyA2xkczo5ChJzZi5sZXguUGFnZVBheWxvYWQSIwgBIg9QTEFDRUhPTERFUl9VUkwyDlBMQUNFSE9MREVSX0lEQhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwSgI0Z1IVChFzZi5sZXguQXBwUGF5bG9hZBIAEoMCCTPzCUtDInhCElgKEDE1ZmE2MDY4N2Q1ZmYyMDgSDEFwZXguZ2V0QXBleBkAANDMzASCQCIpChlzZi5pbnN0cnVtZW50YXRpb24uU2ltcGxlEgwKCmNhY2hlLW1pc3NQAFgAGQAAADSTWdFAIiA4OTU2MzcyYzE5NGQ5ZjNhNDJjODQ3NjFiZjVlMjdmNCgHMgNsZHM6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCNGdSFQoRc2YubGV4LkFwcFBheWxvYWQSABKGAgkzy1xLQyJ4QhJbChBjZmE3OTljYTRhNmQ4NTc0Eg9VaUFwaS5nZXRSZWNvcmQZAACgmZk5cEAiKQoZc2YuaW5zdHJ1bWVudGF0aW9uLlNpbXBsZRIMCgpjYWNoZS1taXNzUABYABkAAAA086TSQCIgODk1NjM3MmMxOTRkOWYzYTQyYzg0NzYxYmY1ZTI3ZjQoCDIDbGRzOjkKEnNmLmxleC5QYWdlUGF5bG9hZBIjCAEiD1BMQUNFSE9MREVSX1VSTDIOUExBQ0VIT0xERVJfSURCFnNpdGVmb3JjZTpjb21tdW5pdHlBcHBKAjRnUhUKEXNmLmxleC5BcHBQYXlsb2FkEgASigIJmUFbS0MieEISXwoQMTk4MjA5YmRkNTY4MDBlNBITVWlBcGkuZ2V0T2JqZWN0SW5mbxkAAMjMzGiVQCIpChlzZi5pbnN0cnVtZW50YXRpb24uU2ltcGxlEgwKCmNhY2hlLW1pc3NQAFgAGQAAAMzMntJAIiA4OTU2MzcyYzE5NGQ5ZjNhNDJjODQ3NjFiZjVlMjdmNCgJMgNsZHM6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCNGdSFQoRc2YubGV4LkFwcFBheWxvYWQSABKsAwocc2YuaW5zdHJ1bWVudGF0aW9uLldlYlZpdGFscxKzAQnMZKVKQyJ4QhIXCgNMQ1ARMzMzMzN2oUAZMzMzMzN2oUAZAAAAMLOOz0AoAjIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcDo5ChJzZi5sZXguUGFnZVBheWxvYWQSIwgBIg9QTEFDRUhPTERFUl9VUkwyDlBMQUNFSE9MREVSX0lEQhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwSgI0Z1IVChFzZi5sZXguQXBwUGF5bG9hZBIAEtUBCczsp0pDInhCEhcKA0ZJRBEAAABoZmYYQBkAAABoZmYYQBkAAAAw86LPQCIgZjdmMzc1Zjc4NDY1ZTY0N2E3MGFiZmFlOGM1NzMyNGQoAzIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcDo5ChJzZi5sZXguUGFnZVBheWxvYWQSIwgBIg9QTEFDRUhPTERFUl9VUkwyDlBMQUNFSE9MREVSX0lEQhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwSgI0Z1IVChFzZi5sZXguQXBwUGF5bG9hZBIAEuUBCg5zZi5sZXguUGFnZUVuZBLSAQkzm%2FdKQyJ4QhIUCAERAAAAAICvzkApAAAAAAAAAAAZAAAANDMQ0UAiIDgzNjVkYmMyODNjY2MwMGY0MGE2MmNjZDFkMTlkZmE1KAQyFnNpdGVmb3JjZTpjb21tdW5pdHlBcHA6OQoSc2YubGV4LlBhZ2VQYXlsb2FkEiMIASIPUExBQ0VIT0xERVJfVVJMMg5QTEFDRUhPTERFUl9JREIWc2l0ZWZvcmNlOmNvbW11bml0eUFwcEoCNGdSFQoRc2YubGV4LkFwcFBheWxvYWQSABoAIgA%3D%22%7D%7D%5D%7D";
                auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                auxURL = auxURL.Replace("0018Z00002hGxfeQAC", recordResponse.Account.Record.Id);//userId
                auxURL = auxURL.Replace("QPQi8lbYE8YujG6og6Dqgw", context.Fwuid);

                strPost = "message=" + auxURL +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=21&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();
                optionaFields = new List<string>();
                optionaFields.Add("Account.AgiCustomer__c");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "505;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id,
                        Fields = null
                    },
                }); ;

                auxURL = "%7B%22actions%22%3A%5B%7B%22id%22%3A%22539%3Ba%22%2C%22descriptor%22%3A%22serviceComponent%3A%2F%2Fui.instrumentation.components.beacon.InstrumentationBeaconController%2FACTION%24sendData%22%2C%22callingDescriptor%22%3A%22UNKNOWN%22%2C%22params%22%3A%7B%22batch%22%3A%5B%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningPageView%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3ApageView%5C%22%2C%5C%22ts%5C%22%3A17474.7%2C%5C%22duration%5C%22%3A3012%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22marks%5C%22%3A%7B%5C%22transport%5C%22%3A%5B%7B%5C%22ts%5C%22%3A17524%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A8%2C%5C%22requestLength%5C%22%3A2646%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22303%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2217524000000b72c13b%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A6331%2C%5C%22xhrDuration%5C%22%3A373%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A17524%2C%5C%22fetchStart%5C%22%3A17524%2C%5C%22requestStart%5C%22%3A17525%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A372%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A6635%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A196%2C%5C%22xhrDelay%5C%22%3A42%7D%2C%5C%22duration%5C%22%3A415%7D%2C%7B%5C%22ts%5C%22%3A17756%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A11%2C%5C%22requestLength%5C%22%3A1980%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22476%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%221775600000008da6e6%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1827%2C%5C%22xhrDuration%5C%22%3A377%2C%5C%22xhrStall%5C%22%3A141%2C%5C%22startTime%5C%22%3A17756%2C%5C%22fetchStart%5C%22%3A17756%2C%5C%22requestStart%5C%22%3A17898%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A377%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2127%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A49%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A378%7D%2C%7B%5C%22ts%5C%22%3A17760.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A12%2C%5C%22requestLength%5C%22%3A1847%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22477%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2217760500000bf5ba73%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2295%2C%5C%22xhrDuration%5C%22%3A518%2C%5C%22xhrStall%5C%22%3A321%2C%5C%22startTime%5C%22%3A17763%2C%5C%22fetchStart%5C%22%3A17763%2C%5C%22requestStart%5C%22%3A18084%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A320%2C%5C%22ttfb%5C%22%3A517%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2596%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A47%2C%5C%22xhrDelay%5C%22%3A3%7D%2C%5C%22duration%5C%22%3A521%7D%2C%7B%5C%22ts%5C%22%3A17766.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A13%2C%5C%22requestLength%5C%22%3A1980%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22478%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2217766600000b03f934%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2016%2C%5C%22xhrDuration%5C%22%3A571%2C%5C%22xhrStall%5C%22%3A344%2C%5C%22startTime%5C%22%3A17767%2C%5C%22fetchStart%5C%22%3A17767%2C%5C%22requestStart%5C%22%3A18112%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A344%2C%5C%22ttfb%5C%22%3A570%2C%5C%22transfer%5C%22%3A1%2C%5C%22transferSize%5C%22%3A2316%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A58%2C%5C%22xhrDelay%5C%22%3A4%7D%2C%5C%22duration%5C%22%3A575%7D%2C%7B%5C%22ts%5C%22%3A17752.6%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A10%2C%5C%22requestLength%5C%22%3A2672%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22467%3Ba%5C%22%2C%5C%22468%3Ba%5C%22%2C%5C%22469%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22177526000001883e76%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A5841%2C%5C%22xhrDuration%5C%22%3A1305%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A17753%2C%5C%22fetchStart%5C%22%3A17753%2C%5C%22requestStart%5C%22%3A17753%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1304%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A6145%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A1125%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A1306%7D%2C%7B%5C%22ts%5C%22%3A17708%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A9%2C%5C%22requestLength%5C%22%3A11771%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22312%3Ba%5C%22%2C%5C%22313%3Ba%5C%22%2C%5C%22338%3Ba%5C%22%2C%5C%22339%3Ba%5C%22%2C%5C%22340%3Ba%5C%22%2C%5C%22361%3Ba%5C%22%2C%5C%22362%3Ba%5C%22%2C%5C%22363%3Ba%5C%22%2C%5C%22384%3Ba%5C%22%2C%5C%22385%3Ba%5C%22%2C%5C%22386%3Ba%5C%22%2C%5C%22407%3Ba%5C%22%2C%5C%22408%3Ba%5C%22%2C%5C%22409%3Ba%5C%22%2C%5C%22430%3Ba%5C%22%2C%5C%22431%3Ba%5C%22%2C%5C%22432%3Ba%5C%22%2C%5C%22465%3Ba%5C%22%2C%5C%22446%3Ba%5C%22%2C%5C%22452%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22177080000002f9fec1%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A18987%2C%5C%22xhrDuration%5C%22%3A1464%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A17709%2C%5C%22fetchStart%5C%22%3A17709%2C%5C%22requestStart%5C%22%3A17709%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1463%2C%5C%22transfer%5C%22%3A1%2C%5C%22transferSize%5C%22%3A19318%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A1289%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A1466%7D%2C%7B%5C%22ts%5C%22%3A19068.89%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A14%2C%5C%22requestLength%5C%22%3A1956%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22500%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%221906879000034072a4%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2449%2C%5C%22xhrDuration%5C%22%3A206%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A19069%2C%5C%22fetchStart%5C%22%3A19069%2C%5C%22requestStart%5C%22%3A19070%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A205%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2749%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A49%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A207%7D%2C%7B%5C%22ts%5C%22%3A19076.5%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A16%2C%5C%22requestLength%5C%22%3A1974%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22502%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2219076500000548ea2d%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1899%2C%5C%22xhrDuration%5C%22%3A206%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A19076%2C%5C%22fetchStart%5C%22%3A19076%2C%5C%22requestStart%5C%22%3A19077%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A205%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2199%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A56%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A207%7D%2C%7B%5C%22ts%5C%22%3A19074%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A15%2C%5C%22requestLength%5C%22%3A2005%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22501%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2219074000000230bed8%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A1828%2C%5C%22xhrDuration%5C%22%3A229%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A19074%2C%5C%22fetchStart%5C%22%3A19074%2C%5C%22requestStart%5C%22%3A19075%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A228%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A2128%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A66%2C%5C%22xhrDelay%5C%22%3A3%7D%2C%5C%22duration%5C%22%3A232%7D%2C%7B%5C%22ts%5C%22%3A19093%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A18%2C%5C%22requestLength%5C%22%3A3189%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22504%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%22190930000009ad6e9b%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A5944%2C%5C%22xhrDuration%5C%22%3A251%2C%5C%22xhrStall%5C%22%3A0%2C%5C%22startTime%5C%22%3A19093%2C%5C%22fetchStart%5C%22%3A19093%2C%5C%22requestStart%5C%22%3A19094%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A250%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A6248%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A71%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A252%7D%2C%7B%5C%22ts%5C%22%3A19081.7%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A17%2C%5C%22requestLength%5C%22%3A1977%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22503%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%2219081700000355d236%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2258%2C%5C%22xhrDuration%5C%22%3A557%2C%5C%22xhrStall%5C%22%3A1%2C%5C%22startTime%5C%22%3A19082%2C%5C%22fetchStart%5C%22%3A19082%2C%5C%22requestStart%5C%22%3A19084%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A555%2C%5C%22transfer%5C%22%3A1%2C%5C%22transferSize%5C%22%3A2558%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A373%2C%5C%22xhrDelay%5C%22%3A1%7D%2C%5C%22duration%5C%22%3A558%7D%2C%7B%5C%22ts%5C%22%3A19194%2C%5C%22context%5C%22%3A%7B%5C%22auraXHRId%5C%22%3A19%2C%5C%22requestLength%5C%22%3A16726%2C%5C%22background%5C%22%3Afalse%2C%5C%22actionDefs%5C%22%3A%5B%5C%22505%3Ba%5C%22%2C%5C%22508%3Ba%5C%22%2C%5C%22510%3Ba%5C%22%2C%5C%22512%3Ba%5C%22%2C%5C%22514%3Ba%5C%22%2C%5C%22516%3Ba%5C%22%5D%2C%5C%22requestId%5C%22%3A%5C%221919400000087d7278%5C%22%2C%5C%22status%5C%22%3A200%2C%5C%22statusText%5C%22%3A%5C%22OK%5C%22%2C%5C%22responseLength%5C%22%3A2974%2C%5C%22xhrDuration%5C%22%3A1229%2C%5C%22xhrStall%5C%22%3A80%2C%5C%22startTime%5C%22%3A19195%2C%5C%22fetchStart%5C%22%3A19195%2C%5C%22requestStart%5C%22%3A19275%2C%5C%22dns%5C%22%3A0%2C%5C%22tcp%5C%22%3A0%2C%5C%22ttfb%5C%22%3A1228%2C%5C%22transfer%5C%22%3A0%2C%5C%22transferSize%5C%22%3A3280%2C%5C%22nextHopProtocol%5C%22%3A%5C%22http%2F1.1%5C%22%2C%5C%22serverTime%5C%22%3A969%2C%5C%22xhrDelay%5C%22%3A2%7D%2C%5C%22duration%5C%22%3A1231%7D%5D%2C%5C%22actions%5C%22%3A%5B%7B%5C%22ts%5C%22%3A17543.7%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22316%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3ArichText%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.richText.RichTextController%2FACTION%24getParsedRichTextValue%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A150%2C%5C%22duration%5C%22%3A151%7D%2C%7B%5C%22ts%5C%22%3A17652.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22442%3Ba%5C%22%2C%5C%22abortable%5C%22%3Atrue%2C%5C%22storable%5C%22%3Atrue%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3Atabset%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.tabset.TabsetController%2FACTION%24getLocalizedRegionLabels%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Atrue%7D%2C%5C%22callbackTime%5C%22%3A12%2C%5C%22enqueueWait%5C%22%3A42%2C%5C%22duration%5C%22%3A54%7D%2C%7B%5C%22ts%5C%22%3A17523.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22303%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22force%3ArecordGlobalValueProvider%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.force.components.controllers.recordGlobalValueProvider.RecordGvpController%2FACTION%24getRecord%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A167%2C%5C%22db%5C%22%3A19%2C%5C%22xhrServerTime%5C%22%3A196%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A430%7D%2C%7B%5C%22ts%5C%22%3A17756%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22476%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A23%2C%5C%22db%5C%22%3A8%2C%5C%22xhrServerTime%5C%22%3A49%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A379%7D%2C%7B%5C%22ts%5C%22%3A17760.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22477%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FRecordUiController%2FACTION%24getRecordWithFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A1%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A25%2C%5C%22db%5C%22%3A8%2C%5C%22xhrServerTime%5C%22%3A47%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A522%7D%2C%7B%5C%22ts%5C%22%3A17766.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22478%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A36%2C%5C%22db%5C%22%3A12%2C%5C%22xhrServerTime%5C%22%3A57%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A575%7D%2C%7B%5C%22ts%5C%22%3A17740.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22467%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A1057%2C%5C%22db%5C%22%3A30%2C%5C%22xhrServerTime%5C%22%3A1125%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1319%7D%2C%7B%5C%22ts%5C%22%3A17740.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22468%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A25%2C%5C%22db%5C%22%3A1%2C%5C%22xhrServerTime%5C%22%3A1125%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1319%7D%2C%7B%5C%22ts%5C%22%3A17740.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22469%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A12%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A16%2C%5C%22db%5C%22%3A1%2C%5C%22xhrServerTime%5C%22%3A1125%2C%5C%22boxCarCount%5C%22%3A3%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1319%7D%2C%7B%5C%22ts%5C%22%3A17539.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22312%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22force%3ArecordGlobalValueProvider%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.force.components.controllers.recordGlobalValueProvider.RecordGvpController%2FACTION%24getRecord%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A117%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A16%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1637%7D%2C%7B%5C%22ts%5C%22%3A17540.7%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22313%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22forceCommunity%3AseoAssistant%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.communities.components.aura.components.forceCommunity.seoAssistant.SeoAssistantController%2FACTION%24getRecordAndTranslationData%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A116%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A61%2C%5C%22db%5C%22%3A16%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1637%7D%2C%7B%5C%22ts%5C%22%3A17606.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22338%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A50%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A61%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1572%7D%2C%7B%5C%22ts%5C%22%3A17606.7%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22339%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A50%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A172%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A5%2C%5C%22duration%5C%22%3A1578%7D%2C%7B%5C%22ts%5C%22%3A17606.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22340%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A50%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A79%2C%5C%22db%5C%22%3A4%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1578%7D%2C%7B%5C%22ts%5C%22%3A17615.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22361%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A42%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A21%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1569%7D%2C%7B%5C%22ts%5C%22%3A17615.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22362%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A41%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A157%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A2%2C%5C%22duration%5C%22%3A1571%7D%2C%7B%5C%22ts%5C%22%3A17615.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22363%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A41%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A39%2C%5C%22db%5C%22%3A3%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1571%7D%2C%7B%5C%22ts%5C%22%3A17625%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22384%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A32%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A22%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1562%7D%2C%7B%5C%22ts%5C%22%3A17625.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22385%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A32%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A129%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A2%2C%5C%22duration%5C%22%3A1564%7D%2C%7B%5C%22ts%5C%22%3A17625.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22386%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A31%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A25%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1564%7D%2C%7B%5C%22ts%5C%22%3A17635.5%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22407%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A21%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A21%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1554%7D%2C%7B%5C%22ts%5C%22%3A17635.7%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22408%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A21%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A140%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1556%7D%2C%7B%5C%22ts%5C%22%3A17635.7%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22409%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A21%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A22%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1556%7D%2C%7B%5C%22ts%5C%22%3A17646.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22430%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getObjectAccess%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A11%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A19%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1546%7D%2C%7B%5C%22ts%5C%22%3A17646.2%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22431%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getMetadataFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A11%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A148%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1547%7D%2C%7B%5C%22ts%5C%22%3A17646.29%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22432%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getRecordTypes%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A10%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A22%2C%5C%22db%5C%22%3A2%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1547%7D%2C%7B%5C%22ts%5C%22%3A17654.6%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22446%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22siteforce%3AbaseApp%5C%22%2C%5C%22def%5C%22%3A%5C%22serviceComponent%3A%2F%2Fui.comm.runtime.components.aura.components.siteforce.qb.QuarterbackController%2FACTION%24validateRoute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A51%2C%5C%22enqueueWait%5C%22%3A2%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A15%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A1288%2C%5C%22boxCarCount%5C%22%3A20%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1539%7D%2C%7B%5C%22ts%5C%22%3A19068.7%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22500%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22ERROR%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A28%2C%5C%22db%5C%22%3A1%2C%5C%22xhrServerTime%5C%22%3A48%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A208%7D%2C%7B%5C%22ts%5C%22%3A19076.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22502%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A36%2C%5C%22db%5C%22%3A7%2C%5C%22xhrServerTime%5C%22%3A55%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A208%7D%2C%7B%5C%22ts%5C%22%3A19073.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22501%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A46%2C%5C%22db%5C%22%3A8%2C%5C%22xhrServerTime%5C%22%3A65%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A233%7D%2C%7B%5C%22ts%5C%22%3A19093%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22504%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FRecordUiController%2FACTION%24getRecordWithFields%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A53%2C%5C%22db%5C%22%3A10%2C%5C%22xhrServerTime%5C%22%3A71%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A254%7D%2C%7B%5C%22ts%5C%22%3A19081.7%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22503%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FApexActionController%2FACTION%24execute%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A347%2C%5C%22db%5C%22%3A138%2C%5C%22xhrServerTime%5C%22%3A373%2C%5C%22boxCarCount%5C%22%3A1%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A558%7D%2C%7B%5C%22ts%5C%22%3A19119.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22505%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22none%5C%22%2C%5C%22def%5C%22%3A%5C%22aura%3A%2F%2FRecordUiController%2FACTION%24getObjectInfo%5C%22%2C%5C%22state%5C%22%3A%5C%22ERROR%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A75%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A7%2C%5C%22db%5C%22%3A0%2C%5C%22xhrServerTime%5C%22%3A968%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1306%7D%2C%7B%5C%22ts%5C%22%3A19184.79%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22508%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A9%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A233%2C%5C%22db%5C%22%3A12%2C%5C%22xhrServerTime%5C%22%3A968%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1242%7D%2C%7B%5C%22ts%5C%22%3A19187.1%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22510%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A1%2C%5C%22enqueueWait%5C%22%3A6%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A227%2C%5C%22db%5C%22%3A7%2C%5C%22xhrServerTime%5C%22%3A968%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A1%2C%5C%22duration%5C%22%3A1241%7D%2C%7B%5C%22ts%5C%22%3A19190%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22512%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A4%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A144%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A968%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A3%2C%5C%22duration%5C%22%3A1241%7D%2C%7B%5C%22ts%5C%22%3A19191.89%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22514%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A2%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A163%2C%5C%22db%5C%22%3A6%2C%5C%22xhrServerTime%5C%22%3A968%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1240%7D%2C%7B%5C%22ts%5C%22%3A19193.39%2C%5C%22context%5C%22%3A%7B%5C%22id%5C%22%3A%5C%22516%3Ba%5C%22%2C%5C%22abortable%5C%22%3Afalse%2C%5C%22storable%5C%22%3Afalse%2C%5C%22background%5C%22%3Afalse%2C%5C%22cmp%5C%22%3A%5C%22CMTD%3AEnhancedRelatedList%5C%22%2C%5C%22def%5C%22%3A%5C%22apex%3A%2F%2FCMTD.EnhancedRelatedList_CC%2FACTION%24getSObjectRecords%5C%22%2C%5C%22state%5C%22%3A%5C%22SUCCESS%5C%22%2C%5C%22cache%5C%22%3Afalse%7D%2C%5C%22xhrWait%5C%22%3A0%2C%5C%22enqueueWait%5C%22%3A0%2C%5C%22serverTime%5C%22%3A%7B%5C%22total%5C%22%3A147%2C%5C%22db%5C%22%3A5%2C%5C%22xhrServerTime%5C%22%3A968%2C%5C%22boxCarCount%5C%22%3A6%7D%2C%5C%22callbackTime%5C%22%3A0%2C%5C%22duration%5C%22%3A1240%7D%5D%2C%5C%22component%5C%22%3A%5B%7B%5C%22totalCreateTime%5C%22%3A141.12%2C%5C%22slowestCreates%5C%22%3A%5B%7B%5C%22name%5C%22%3A%5C%22force%3ArecordGlobalValueProvider%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A4.89%7D%2C%7B%5C%22name%5C%22%3A%5C%22siteforce-generatedpage-0076d481-f00c-413c-ad91-e083e79224cc.c25%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A119%7D%2C%7B%5C%22name%5C%22%3A%5C%22ui%3Atabset%5C%22%2C%5C%22createCount%5C%22%3A1%2C%5C%22createTimeTotal%5C%22%3A9.29%7D%2C%7B%5C%22name%5C%22%3A%5C%22ui%3Atab%5C%22%2C%5C%22createCount%5C%22%3A5%2C%5C%22createTimeTotal%5C%22%3A1.8%7D%2C%7B%5C%22name%5C%22%3A%5C%22ui%3AtabItem%5C%22%2C%5C%22createCount%5C%22%3A5%2C%5C%22createTimeTotal%5C%22%3A6.11%7D%5D%7D%5D%2C%5C%22custom%5C%22%3A%5B%7B%5C%22ns%5C%22%3A%5C%22formula%5C%22%2C%5C%22name%5C%22%3A%5C%22evaluate%5C%22%2C%5C%22ts%5C%22%3A17529.39%2C%5C%22context%5C%22%3A%7B%5C%22technology%5C%22%3A%5C%22Aura%5C%22%2C%5C%22formulaSize%5C%22%3A434%2C%5C%22feature%5C%22%3A%5C%22Audience%5C%22%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22duration%5C%22%3A5%7D%5D%7D%2C%5C%22owner%5C%22%3A%5C%22siteforce%3ArouterInitializer%5C%22%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22ept%5C%22%3A3010%2C%5C%22previousPage%5C%22%3A%7B%5C%22entity%5C%22%3A%5C%220018Z00002hDeS6QAK%5C%22%2C%5C%22entityType%5C%22%3A%5C%22Account%5C%22%2C%5C%22context%5C%22%3A%5C%22home%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2F%5C%22%7D%7D%2C%5C%22attributes%5C%22%3A%7B%5C%22designTime%5C%22%3Afalse%2C%5C%22domain%5C%22%3A%5C%22https%3A%2F%2Fagibank.force.com%5C%22%2C%5C%22template%5C%22%3A%5C%22PRM%20Community%20Template%5C%22%2C%5C%22priorityDuration%5C%22%3A%7B%7D%2C%5C%22eptDeviationReason%5C%22%3A%5C%22PageHasError%5C%22%2C%5C%22eptDeviationErrorType%5C%22%3A%5C%22system%5C%22%2C%5C%22eptDeviationErrorMsg%5C%22%3A%5C%22Error%3A%20%20%5BPromiseRejection%3A%20%5Bobject%20Object%5D%5D%5C%22%2C%5C%22eptDeviationErrorDisplayed%5C%22%3Afalse%2C%5C%22longTaskTotal%5C%22%3A266%2C%5C%22longestTask%5C%22%3A112%2C%5C%22network%5C%22%3A%7B%5C%22rtt%5C%22%3A50%2C%5C%22downlink%5C%22%3A5.6%2C%5C%22maxAllowedParallelXHRs%5C%22%3A6%7D%2C%5C%22cores%5C%22%3A4%2C%5C%22eptDeviation%5C%22%3Atrue%2C%5C%22density%5C%22%3A%5C%22UNKNOWN%5C%22%2C%5C%22totalEpt%5C%22%3A3010%2C%5C%22defaultCmp%5C%22%3A%5B%5D%2C%5C%22gates%5C%22%3A%7B%5C%22lds.useNewTrackedFieldBehavior%5C%22%3Afalse%2C%5C%22scenarioTrackerEnabled.instrumentation.ltng%5C%22%3Atrue%2C%5C%22scenarioTrackerMarksEnabled.instrumentation.ltng%5C%22%3Afalse%2C%5C%22ui.services.PageScopedCache.enabled%5C%22%3Atrue%2C%5C%22browserIdleTime.instrumentation.ltng%5C%22%3Afalse%2C%5C%22clientTelemetry.instrumentation.ltng%5C%22%3Atrue%2C%5C%22componentProfiler.instrumentation.ltng%5C%22%3Afalse%2C%5C%22o11yAuraActionsEnabled.instrumentation.ltng%5C%22%3Afalse%2C%5C%22o11yEnabled.instrumentation.ltng%5C%22%3Atrue%2C%5C%22forceRecordMarksEnabled%5C%22%3Afalse%2C%5C%22LWCMarksEnabled%5C%22%3Afalse%7D%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%7D%2C%5C%22cacheStats%5C%22%3A%7B%5C%22AuraStorage_actions%5C%22%3A%7B%5C%22hits%5C%22%3A13%2C%5C%22misses%5C%22%3A0%7D%2C%5C%22AuraStorage_ldsObjectInfo%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A1%7D%2C%5C%22lds%3AgetObjectInfo%3Astorage%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A1%7D%2C%5C%22lds%3AApex.getApex%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A2%7D%2C%5C%22lds%3AUiApi.getObjectInfo%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A1%7D%2C%5C%22lds%3AUiApi.getRecord%5C%22%3A%7B%5C%22hits%5C%22%3A0%2C%5C%22misses%5C%22%3A2%7D%2C%5C%22AuraRecordStore%5C%22%3A%7B%5C%22hits%5C%22%3A3%2C%5C%22misses%5C%22%3A0%7D%2C%5C%22AuraRecordStore_others%5C%22%3A%7B%5C%22hits%5C%22%3A2%2C%5C%22misses%5C%22%3A0%7D%2C%5C%22AuraRecordStore_auraIf%5C%22%3A%7B%5C%22hits%5C%22%3A1%2C%5C%22misses%5C%22%3A0%7D%2C%5C%22total%5C%22%3A%7B%5C%22hits%5C%22%3A19%2C%5C%22misses%5C%22%3A7%7D%7D%2C%5C%22complexity%5C%22%3A%7B%5C%22ADS_fields%5C%22%3A9%7D%2C%5C%22sequence%5C%22%3A2%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hDeS6QAK%2Fdetail%5C%22%7D%7D%7D%22%7D%2C%7B%22topic%22%3A%22ailtn%22%2C%22schemaType%22%3A%22LightningInteraction%22%2C%22payload%22%3A%22%7B%5C%22id%5C%22%3A%5C%22ltng%3Ainteraction%5C%22%2C%5C%22ts%5C%22%3A20488.39%2C%5C%22pageStartTime%5C%22%3A1658464791352%2C%5C%22owner%5C%22%3Anull%2C%5C%22unixTS%5C%22%3Afalse%2C%5C%22eventType%5C%22%3A%5C%22system%5C%22%2C%5C%22eventSource%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22defs%5C%22%3A%5B%5C%22markup%3A%2F%2Fforce%3ArecordGlobalValueProvider%5C%22%2C%5C%22markup%3A%2F%2Fforce%3AadsBridge%5C%22%2C%5C%22layout%3A%2F%2Fsiteforce-generatedpage-0076d481-f00c-413c-ad91-e083e79224cc.c25%5C%22%2C%5C%22markup%3A%2F%2Fforce%3Arecord%5C%22%2C%5C%22markup%3A%2F%2Fsiteforce%3AsldsOneColLayout%5C%22%2C%5C%22markup%3A%2F%2Fc%3AaccountHighlight%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3Atabset%5C%22%2C%5C%22markup%3A%2F%2FCMTD%3AEnhancedRelatedList%5C%22%2C%5C%22markup%3A%2F%2Fltng%3Arequire%5C%22%2C%5C%22markup%3A%2F%2Flightning%3Aspinner%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AbuttonIcon%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AtooltipLibrary%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AprimitiveIcon%5C%22%2C%5C%22markup%3A%2F%2FCMTD%3AERL_List%5C%22%2C%5C%22markup%3A%2F%2Fforce%3ApageInfo%5C%22%2C%5C%22markup%3A%2F%2Flightning%3Anavigation%5C%22%2C%5C%22markup%3A%2F%2Fforce%3Aplaceholder%5C%22%2C%5C%22markup%3A%2F%2FforceCommunity%3Aplaceholder%5C%22%2C%5C%22markup%3A%2F%2Fui%3Atabset%5C%22%2C%5C%22markup%3A%2F%2Fui%3AtabBar%5C%22%2C%5C%22markup%3A%2F%2Fui%3AtabOverflowMenuItem%5C%22%2C%5C%22markup%3A%2F%2Fui%3AmenuTriggerLink%5C%22%2C%5C%22markup%3A%2F%2Fui%3Atab%5C%22%2C%5C%22markup%3A%2F%2Fui%3AtabItem%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AiconSvgTemplatesCustom%5C%22%2C%5C%22markup%3A%2F%2Flightning%3AiconSvgTemplatesStandard%5C%22%5D%2C%5C%22pageCounter%5C%22%3A2%2C%5C%22phase%5C%22%3A%5C%22EPT%5C%22%2C%5C%22pageViewCounter%5C%22%3A2%2C%5C%22cdnEnabled%5C%22%3Afalse%2C%5C%22uriDefsEnabled%5C%22%3Afalse%2C%5C%22gates%5C%22%3A%7B%7D%7D%2C%5C%22locator%5C%22%3A%7B%5C%22target%5C%22%3A%5C%22defsUsage%5C%22%2C%5C%22scope%5C%22%3A%5C%22defsUsage%5C%22%7D%2C%5C%22sequence%5C%22%3A14%2C%5C%22page%5C%22%3A%7B%5C%22context%5C%22%3A%5C%22detail-001%5C%22%2C%5C%22attributes%5C%22%3A%7B%5C%22url%5C%22%3A%5C%22%2Fs%2Faccount%2F0018Z00002hDeS6QAK%2Fdetail%5C%22%7D%7D%7D%22%7D%5D%2C%22traces%22%3A%22%5B%5D%22%2C%22metrics%22%3A%22%5B%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageReceived.beforeEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464811838%2C%5C%22value%5C%22%3A%5B60849%5D%7D%2C%7B%5C%22owner%5C%22%3A%5C%22Instrumentation%5C%22%2C%5C%22name%5C%22%3A%5C%22bwUsageSent.beforeEpt.bytes%5C%22%2C%5C%22type%5C%22%3A%5C%22PercentileHistogram%5C%22%2C%5C%22ts%5C%22%3A1658464811838%2C%5C%22value%5C%22%3A%5B125654%5D%7D%5D%22%2C%22o11yLogs%22%3A%22CiEKBG8xMXkRACC0S0MieEIYASAAKAAyCDIzOC4yNC4wOAAS%2FQUKG3NmLmluc3RydW1lbnRhdGlvbi5BY3Rpdml0eRLdBQnMtPdKQyJ4QhLABAogODk1NjM3MmMxOTRkOWYzYTQyYzg0NzYxYmY1ZTI3ZjQSD0xleFJvb3RBY3Rpdml0eRkAAAAAAIenQCL7AwoUc2YubGV4LlBhZ2V2aWV3RHJhZnQS4gMIAhEAAAAAAISnQCkAAAAAAISnQEEAAAAAAKBwQEkAAAAAAABcQGgAmAEAsgErc2NlbmFyaW9UcmFja2VyRW5hYmxlZC5pbnN0cnVtZW50YXRpb24ubHRuZ7IBI3VpLnNlcnZpY2VzLlBhZ2VTY29wZWRDYWNoZS5lbmFibGVksgEkY2xpZW50VGVsZW1ldHJ5Lmluc3RydW1lbnRhdGlvbi5sdG5nsgEgbzExeUVuYWJsZWQuaW5zdHJ1bWVudGF0aW9uLmx0bme6AR5sZHMudXNlTmV3VHJhY2tlZEZpZWxkQmVoYXZpb3K6ATBzY2VuYXJpb1RyYWNrZXJNYXJrc0VuYWJsZWQuaW5zdHJ1bWVudGF0aW9uLmx0bme6ASRicm93c2VySWRsZVRpbWUuaW5zdHJ1bWVudGF0aW9uLmx0bme6ASZjb21wb25lbnRQcm9maWxlci5pbnN0cnVtZW50YXRpb24ubHRuZ7oBK28xMXlBdXJhQWN0aW9uc0VuYWJsZWQuaW5zdHJ1bWVudGF0aW9uLmx0bmfwAQSqAg9QTEFDRUhPTERFUl9VUkyyAgRob21lugIOUExBQ0VIT0xERVJfSUTCAgdBY2NvdW502ALl%2BOwiiQMAAAAAAIiUQEABUABYABkAAACYmRDRQCgKMhZzaXRlZm9yY2U6Y29tbXVuaXR5QXBwOjkKEnNmLmxleC5QYWdlUGF5bG9hZBIjCAIiD1BMQUNFSE9MREVSX1VSTDIOUExBQ0VIT0xERVJfSURCFnNpdGVmb3JjZTpjb21tdW5pdHlBcHBKAjRnUhUKEXNmLmxleC5BcHBQYXlsb2FkEgAaACIA%22%7D%7D%5D%7D";
                auxURL = auxURL.Replace("0DB6e000000k9hL", keys["currentNetworkId"]);//networkId
                auxURL = auxURL.Replace("0056e00000CpOw5AAF", currentUser.Id);//userId
                auxURL = auxURL.Replace("0018Z00002hGxfeQAC", recordResponse.Account.Record.Id);//userId
                auxURL = auxURL.Replace("QPQi8lbYE8YujG6og6Dqgw", context.Fwuid);

                strPost = "message=" + auxURL +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&ui-instrumentation-components-beacon.InstrumentationBeacon.sendData=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool ClicaSimulacao(string cpf, string nome, string sobrenome, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region POST /s/sfsites/aura?r=22&aura.Component.getComponent=1&aura.Component.reportFailedAction=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                var fields = new List<Field>();

                var objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "545;a",
                    Descriptor = "aura://ComponentController/ACTION$getComponent",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Name = "markup://siteforce:regionLoaderWrapper",
                        Attributes = new Attributes()
                        {
                            ItemId = new Guid("0076d481-f00c-413c-ad91-e083e79224cc"),
                            Params = new AttributesParams
                            {
                                Viewid = new Guid("0076d481-f00c-413c-ad91-e083e79224cc"),
                                ViewUddid = "0I36e00000Ep09J",
                                EntityName = "Account",
                                AudienceName = "BPO",
                                RecordId = recordResponse.Account.Record.Id,
                                RecordName = "detail",
                                PicassoId = "e23ec990-e932-413f-9157-d68d449b39ef",
                                RouteId = "e23ec990-e932-413f-9157-d68d449b39ef"
                            }
                        }
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                //response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                //           strPost,
                //           headers: hdrs,
                //           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                //           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=22&aura.Component.getComponent=1&aura.Component.reportFailedAction=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "517;a",
                    Descriptor = "aura://ComponentController/ACTION$reportFailedAction",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        FailedAction = "",
                        FailedId = 0,
                        ClientError = " [PromiseRejection: [object Object]]",
                        AdditionalData = "{}",
                        ClientStack = "{anonymous}()@https://agibank.force.com/s/sfsites/auraFW/javascript/QPQi8lbYE8YujG6og6Dqgw/aura_prod.js:993:375\nt()@https://agibank.force.com/s/sfsites/auraFW/javascript/QPQi8lbYE8YujG6og6Dqgw/aura_prod.js:1:6108",
                        ComponentStack = "",
                        StackTraceIdGen = "",
                        Level = "ERROR"
                    },
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "544;a",
                    Descriptor = "aura://ComponentController/ACTION$getComponent",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Name = "markup://siteforce:regionLoaderWrapper",
                        Attributes = new Attributes()
                        {
                            ItemId = new Guid("0076d481-f00c-413c-ad91-e083e79224cc"),
                            Params = new AttributesParams
                            {
                                Viewid = new Guid("0076d481-f00c-413c-ad91-e083e79224cc"),
                                ViewUddid = "0I36e00000Ep09J",
                                EntityName = "Account",
                                AudienceName = "BPO",
                                RecordId = recordResponse.Account.Record.Id,
                                RecordName = "detail",
                                PicassoId = "e23ec990-e932-413f-9157-d68d449b39ef",
                                RouteId = "e23ec990-e932-413f-9157-d68d449b39ef"
                            }
                        }
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                         "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                         "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) +
                         "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-'),
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=23&aura.ApexAction.execute=2 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "563;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OriginationController",
                        Method = "getCurrent",
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        },
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "564;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "TaskController",
                        Method = "getTaskStepValues",
                        Cacheable = false,
                        IsContinuation = false

                    },
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) + "?tabset-11f0d=51b55" +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=2",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-') + "?tabset-11f0d=51b55",
                           _accept: "*/*");

                #endregion

                #region POST /s/sfsites/aura?r=24&aura.ApexAction.execute=1 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "565;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "TaskController",
                        Method = "getAccountTasksSimulationDeferred",
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        },
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "564;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "TaskController",
                        Method = "getTaskStepValues",
                        Cacheable = false,
                        IsContinuation = false

                    },
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) + "?tabset-11f0d=51b55" +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-') + "?tabset-11f0d=51b55",
                           _accept: "*/*");

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool ClicaINSS(string cpf, string nome, string sobrenome, ref string erro)
        {
            var LinhaErro = "";

            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region POST /s/sfsites/aura?r=47&aura.ApexAction.execute=1 HTTP/1.1
                LinhaErro = "2801 - Entrou POST /s/sfsites/aura?r=47&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                var fields = new List<Field>();

                var objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "517;a",
                    Descriptor = "aura://ComponentController/ACTION$reportFailedAction",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        FailedAction = "",
                        FailedId = 0,
                        ClientError = " [PromiseRejection: [object Object]]",
                        AdditionalData = "{}",
                        ClientStack = "{anonymous}()@https://agibank.force.com/s/sfsites/auraFW/javascript/QPQi8lbYE8YujG6og6Dqgw/aura_prod.js:993:375\nt()@https://agibank.force.com/s/sfsites/auraFW/javascript/QPQi8lbYE8YujG6og6Dqgw/aura_prod.js:1:6108",
                        ComponentStack = "",
                        StackTraceIdGen = "",
                        Level = "ERROR"
                    },
                });

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1086;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "OriginationController",
                        Method = "startNew",
                        Params = new ActionParams()
                        {
                            Command = new Command()
                            {
                                AccountId = recordResponse.Account.Record.Id,
                                AttendanceType = "Presential",
                                PaymentSourceType = "INSS Source"
                            }
                        },
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                var strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                          "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                          "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) + "?tabset-11f0d=51b55" +
                          "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-') + "?tabset-11f0d=51b55",
                           _accept: "*/*");
                UpdateKeys("attendanceNumber", RetornaAuxSubstring(response.Content, "attendanceNumber=", "\""));
                UpdateKeys("taskId", RetornaAuxSubstring(response.Content, "TaskId\":\"", "\""));
                #endregion

                #region POST /s/sfsites/aura?r=48&aura.ApexAction.execute=1 HTTP/1.1
                LinhaErro = "2872 - POST /s/sfsites/aura?r=48&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                fields = new List<Field>();

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "1087;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "DomainUtils",
                        Method = "isCommunityDomain",
                        Cacheable = false,
                        IsContinuation = false
                    },
                });

                auxURL = JsonConvert.SerializeObject(objRequest);

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                         "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(context).Replace("\"dn\":null", "\"dn\":[]").Replace("\"globals\":null", "\"globals\":{}")) +
                         "&aura.pageURI=" + WebUtility.UrlEncode("/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-')) + "?tabset-11f0d=51b55" +
                         "&aura.token=" + WebUtility.UrlEncode(keys["aura.token"]);

                response = DoPost("https://agibank.force.com/s/sfsites/aura?r=" + countURL() + "&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-') + "?tabset-11f0d=51b55",
                           _accept: "*/*");


                #endregion

                #region GET /apex/OriginationPage?url=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D13031157&taskId=00T8Z00009mHDoQUAW&id=0018Z00002hGxfeQAC&corban=true&enableScroll=true HTTP/1.1
                LinhaErro = "2916 - GET /apex/OriginationPage?url=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D13031157&taskId=00T8Z00009mHDoQUAW&id=0018Z00002hGxfeQAC&corban=true&enableScroll=true HTTP/1.1";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet("https://agibank.force.com/apex/OriginationPage?url=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D" + keys["attendanceNumber"] +
                           "&taskId=" + keys["taskId"] + "&id=" + recordResponse.Account.Record.Id + "&corban=true&enableScroll=true",
                           headers: hdrs,
                           _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: "https://agibank.force.com/s/account/" + recordResponse.Account.Record.Id + "/" + (nome + " " + sobrenome).ToLower().Replace(' ', '-') + "?tabset-11f0d=51b55");

                //var newAuraToken = RetornaAuxSubstring(response.Content, "\",\"pathPrefix\":\"\",\"token\":\"", "\",\"staticResourceDomain");

                //UpdateKeys("new.aura.token", newAuraToken);

                //UpdateKeys("aura.context", RetornaAuxSubstring(WebUtility.UrlDecode(response.Content), "\"desktopDashboards:dashboardApp\",\"loaded\":", ",\"styleContext\""));

                UpdateKeys("ViewState", RetornaAuxSubstring(response.Content, "ViewState\" value=\"", "\""));
                UpdateKeys("ViewStateVersion", RetornaAuxSubstring(response.Content, "=\"com.salesforce.visualforce.ViewStateVersion\" value=\"", "\""));
                UpdateKeys("ViewStateCSRF", RetornaAuxSubstring(response.Content, "ViewStateCSRF\" value=\"", "\""));
                UpdateKeys("ViewStateMAC", RetornaAuxSubstring(response.Content, "ViewStateMAC\" value=\"", "\""));

                VFRMRemotingProviderImpl = JsonConvert.DeserializeObject(RetornaAuxSubstring(response.Content, "$VFRM.RemotingProviderImpl(", "));"));
                #endregion

                #region POST /OriginationPage?id=0018Z00002hGxfeQAC HTTP/1.1
                LinhaErro = " 2946 - POST /OriginationPage?id=0018Z00002hGxfeQAC HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");


                strPost = "AJAXREQUEST=_viewRoot" +
                          "&thepage%3Aform=thepage%3Aform" +
                          "&com.salesforce.visualforce.ViewState=" + WebUtility.UrlEncode(keys["ViewState"]) +
                          "&com.salesforce.visualforce.ViewStateVersion=" + WebUtility.UrlEncode(keys["ViewStateVersion"]) +
                          "&com.salesforce.visualforce.ViewStateMAC=" + WebUtility.UrlEncode(keys["ViewStateMAC"]) +
                          "&com.salesforce.visualforce.ViewStateCSRF=" + WebUtility.UrlEncode(keys["ViewStateCSRF"]) +
                          "&newUrl=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D" + keys["attendanceNumber"] +
                          "&thepage%3Aform%3Aj_id37=thepage%3Aform%3Aj_id37&";

                var auxReferer = response.ResponseUri.ToString();

                response = DoPost("https://agibank.force.com/OriginationPage?id=" + recordResponse.Account.Record.Id,
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*");

                UpdateKeys("ViewState", RetornaAuxSubstring(response.Content, "ViewState\" value=\"", "\""));
                UpdateKeys("ViewStateVersion", RetornaAuxSubstring(response.Content, "=\"com.salesforce.visualforce.ViewStateVersion\" value=\"", "\""));
                UpdateKeys("ViewStateCSRF", RetornaAuxSubstring(response.Content, "ViewStateCSRF\" value=\"", "\""));
                UpdateKeys("ViewStateMAC", RetornaAuxSubstring(response.Content, "ViewStateMAC\" value=\"", "\""));
                #endregion

                #region GET /c/accountHighlightContainerApp.app?aura.format=JSON&aura.formatAdapter=LIGHTNING_OUT HTTP/1.1
                LinhaErro = "2979 - GET /c/accountHighlightContainerApp.app?aura.format=JSON&aura.formatAdapter=LIGHTNING_OUT HTTP/1.1";

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                response = DoGet("https://agibank.force.com/c/accountHighlightContainerApp.app?aura.format=JSON&aura.formatAdapter=LIGHTNING_OUT",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: auxReferer);

                //OU USAR DYNAMIC
                accountHighlightContainerApp = JsonConvert.DeserializeObject<AccountHighlightContainerApp>(response.Content);
                var auxAuraToken = RetornaAuxSubstring(response.Content, "descriptor\":\"markup://c:accountHighlightContainerApp\",\"token\":\"", "\"");
                #endregion

                #region GET //l/%7B%22mode%22%3A%22PROD%22%2C%22app%22%3A%22c%3AaccountHighlightContainerApp%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fc%3AaccountHighlightContainerApp%22%3A%22Y7TmpRiaxoeUJ6leyXcmVA%22%7D%2C%22mlr%22%3A1%2C%22pathPrefix%22%3A%22%22%2C%22dns%22%3A%22c%22%2C%22ls%22%3A1%2C%22lrmc%22%3A%22533941497%22%7D/inline.js?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..p_HLOwAguZrx8PpV0kpURoqll47qCAglrAKJ-DD0kFg&ltngOut=true HTTP/1.1

                LinhaErro = "3000 - GET //l/%7B%22mode%22%3A%22PROD%22%2C%22app%22%3A%22c%3AaccountHighlightContainerApp%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fc%3AaccountHighlightContainerApp%22%3A%22Y7TmpRiaxoeUJ6leyXcmVA%22%7D%2C%22mlr%22%3A1%2C%22pathPrefix%22%3A%22%22%2C%22dns%22%3A%22c%22%2C%22ls%22%3A1%2C%22lrmc%22%3A%22533941497%22%7D/inline.js?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..p_HLOwAguZrx8PpV0kpURoqll47qCAglrAKJ-DD0kFg&ltngOut=true HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                auxURL = "//l/{\"mode\":\"PROD\"," +
                    "\"app\":\"c:accountHighlightContainerApp\"," +
                    "\"fwuid\":\"" + context.Fwuid + "\"," +
                    "\"loaded\":{\"APPLICATION@markup://c:accountHighlightContainerApp\":\"" + accountHighlightContainerApp.AuraConfig.Context.Loaded.ApplicationMarkupCAccountHighlightContainerApp + "\"}," +
                    "\"mlr\":1," +
                    "\"pathPrefix\":\"\"," +
                    "\"dns\":\"c\"," +
                    "\"ls\":1," +
                    "\"lrmc\":\"533941497\"}/inline.js?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..p_HLOwAguZrx8PpV0kpURoqll47qCAglrAKJ-DD0kFg&" +
                    "ltngOut=true";

                try
                {
                    //response = DoGet(auxURL,
                    //                 headers: hdrs,
                    //                 _accept: "*/*",
                    //                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                    //                 _referer: auxReferer);
                }
                catch (Exception ex)
                {
                    var x = ex;
                }
                #endregion

                #region GET //l/%7B%22mode%22%3A%22PROD%22%2C%22app%22%3A%22c%3AaccountHighlightContainerApp%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fc%3AaccountHighlightContainerApp%22%3A%22Y7TmpRiaxoeUJ6leyXcmVA%22%7D%2C%22mlr%22%3A1%2C%22pathPrefix%22%3A%22%22%2C%22dns%22%3A%22c%22%2C%22ls%22%3A1%2C%22lrmc%22%3A%22533941497%22%7D/bootstrap.js?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..p_HLOwAguZrx8PpV0kpURoqll47qCAglrAKJ-DD0kFg&ltngOut=true HTTP/1.1
                LinhaErro = " 3033 - GET //l/%7B%22mode%22%3A%22PROD%22%2C%22app%22%3A%22c%3AaccountHighlightContainerApp%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fc%3AaccountHighlightContainerApp%22%3A%22Y7TmpRiaxoeUJ6leyXcmVA%22%7D%2C%22mlr%22%3A1%2C%22pathPrefix%22%3A%22%22%2C%22dns%22%3A%22c%22%2C%22ls%22%3A1%2C%22lrmc%22%3A%22533941497%22%7D/bootstrap.js?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..p_HLOwAguZrx8PpV0kpURoqll47qCAglrAKJ-DD0kFg&ltngOut=true HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");

                try
                {
                    //response = DoGet("https://agibank.force.com//l/%7B%22mode%22%3A%22PROD%22%2C%22app%22%3A%22c%3AaccountHighlightContainerApp%22%2C%22fwuid%22%3A%22QPQi8lbYE8YujG6og6Dqgw%22%2C%22loaded%22%3A%7B%22APPLICATION%40markup%3A%2F%2Fc%3AaccountHighlightContainerApp%22%3A%22Y7TmpRiaxoeUJ6leyXcmVA%22%7D%2C%22mlr%22%3A1%2C%22pathPrefix%22%3A%22%22%2C%22dns%22%3A%22c%22%2C%22ls%22%3A1%2C%22lrmc%22%3A%22533941497%22%7D/bootstrap.js?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..p_HLOwAguZrx8PpV0kpURoqll47qCAglrAKJ-DD0kFg&ltngOut=true",
                    //             headers: hdrs,
                    //             _accept: "*/*",
                    //             _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                    //             _referer: auxReferer);
                }
                catch (Exception ex)
                {
                    var x = ex;
                }

                ////OU USAR DYNAMIC
                //accountHighlightContainerApp = JsonConvert.DeserializeObject<AccountHighlightContainerApp>(response.Content);
                #endregion

                #region GET /?attendanceNumber=13031157 HTTP/1.1
                LinhaErro = "3058 - GET /?attendanceNumber=13031157 HTTP/1.1";
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

                #region //AURA

                #region POST //aura?r=0&aura.ApexAction.execute=3 HTTP/1.1
                LinhaErro = "3075 - POST //aura?r=0&aura.ApexAction.execute=3 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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
                            AccountId = recordResponse.Account.Record.Id
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

                var auxAuraContext = new AuraContextRequest()
                {
                    Mode = "PROD",
                    Fwuid = "QPQi8lbYE8YujG6og6Dqgw",
                    App = "c:accountHighlightContainerApp",
                    Loaded = new Loaded()
                    {
                        ApplicationMarkupCAccountHighlightContainerApp = "Y7TmpRiaxoeUJ6leyXcmVA",
                    },
                    Dn = new List<Globals>(),
                    Globals = new Globals(),
                    Uad = true
                };

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=0&aura.ApexAction.execute=3",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1
                LinhaErro = "3166 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "5;a",
                    Descriptor = "aura://ApexActionController/ACTION$execute",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        Namespace = "",
                        Classname = "AccountController",
                        Method = "getPrimaryEmail",
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        },
                        Cacheable = true,
                        IsContinuation = false
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=1&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=2&aura.RecordUi.getRecordWithFields=1 HTTP/1.1
                LinhaErro = "3213 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                objRequest = new MessageRequest();

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "6;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id
                    }
                });

                auxURL = JsonConvert.SerializeObject(objRequest);
                auxURL = auxURL.Replace("}}]}", ",\"fields\":[\"Account.Rating\"]}}]}");//.Replace("\\\"", "\\""");

                strPost = "message=" + WebUtility.UrlEncode(auxURL) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=2&aura.RecordUi.getRecordWithFields=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=3&aura.ApexAction.execute=1 HTTP/1.1
                LinhaErro = "3255 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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
                        Params = new JSONObjects.ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        },
                        Cacheable = true,
                        IsContinuation = false
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=3&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=4&aura.RecordUi.getObjectInfo=1 HTTP/1.1
                LinhaErro = "3302 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"])) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=4&aura.RecordUi.getObjectInfo=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=5&aura.ApexAction.execute=1 HTTP/1.1
                LinhaErro = "3341 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=5&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=6&aura.ApexAction.execute=1 HTTP/1.1
                LinhaErro = "3384 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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
                        Cacheable = false,
                        IsContinuation = false,
                        Params = new ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        }
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=6&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=7&aura.ApexAction.execute=1 HTTP/1.1
                LinhaErro = "3431 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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
                        Cacheable = false,
                        IsContinuation = false,
                        Params = new ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        }
                    }
                });

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=7&aura.ApexAction.execute=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=8&aura.ApexAction.execute=1&aura.RecordUi.getRecordWithFields=1 HTTP/1.1
                LinhaErro = "3478 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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
                        Cacheable = false,
                        IsContinuation = false,
                        Params = new ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        }
                    }
                });

                var optionalFields = new List<string>();
                optionalFields.Add("Account.Rating");

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "13;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id,
                        OptionalFields = optionalFields
                    }
                });

                auxURL = JsonConvert.SerializeObject(objRequest);
                auxURL = auxURL.Replace("\"Account.Rating\"]", "\"Account.Rating\"],\"fields\":[\"Account.RegistrationStatus__c\"]");//

                strPost = "message=" + auxURL +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?" + WebUtility.UrlEncode("https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=") + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                response = DoPost("https://agibank.force.com//aura?r=8&aura.ApexAction.execute=1&aura.RecordUi.getRecordWithFields=1",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #region POST //aura?r=8&aura.ApexAction.execute=1&aura.RecordUi.getRecordWithFields=1 HTTP/1.1
                LinhaErro = "3543 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

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
                        Cacheable = false,
                        IsContinuation = false,
                        Params = new ActionParams()
                        {
                            AccountId = recordResponse.Account.Record.Id
                        }
                    }
                });

                optionalFields = new List<string>();
                optionalFields.Add("Account.Rating");

                objRequest.Actions.Add(new JSONObjects.Action()
                {
                    Id = "13;a",
                    Descriptor = "aura://RecordUiController/ACTION$getRecordWithFields",
                    CallingDescriptor = "UNKNOWN",
                    Params = new JSONObjects.ActionParams()
                    {
                        RecordId = recordResponse.Account.Record.Id,
                        OptionalFields = optionalFields
                    }
                });

                auxURL = JsonConvert.SerializeObject(objRequest);
                auxURL = auxURL.Replace("\"Account.Rating\"]", "\"Account.Rating\"],\"fields\":[\"Account.RegistrationStatus__c\"]");//

                strPost = "message=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(objRequest)) +
                   "&aura.context=" + WebUtility.UrlEncode(JsonConvert.SerializeObject(auxAuraContext)) +
                   "&aura.pageURI=" + WebUtility.UrlEncode("/apex/OriginationPage?url=https://origination-product-sale-originacao.agibank-prd.in?attendanceNumber=" + keys["attendanceNumber"]) +
                   "&taskId=" + keys["taskId"] +
                   "&id=" + recordResponse.Account.Record.Id +
                   "&corban=true" +
                   "&enableScroll=true" +
                   "&aura.token=" + WebUtility.UrlEncode(auxAuraToken);

                //response = DoPost("https://agibank.force.com//aura?r=8&aura.ApexAction.execute=1&aura.RecordUi.getRecordWithFields=1",
                //           strPost,
                //           headers: hdrs,
                //           _referer: auxReferer,
                //           _accept: "*/*",
                //           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.44");
                #endregion

                #endregion

                #region GET /v1/attendances/13031157?state-safe=true HTTP/1.1
                LinhaErro = "3610 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
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
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");

                try
                {
                    attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                }
                catch (Exception ex)
                {
                    attendancesData = new AttendancesData() { StoreId = "2722", UserId = "41642530883" };
                }

                #endregion

                #region GET /v1/attendances/13031157 HTTP/1.1 
                LinhaErro = "3638 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion

                #region GET /v1/income-sources HTTP/1.1 
                LinhaErro = "3656 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/v1/income-sources",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion

                #region GET /v1/attendances/13031157/authorization-types HTTP/1.1
                LinhaErro = "3674 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "/authorization-types",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion

                #region PATCH /v1/attendances/13031157 HTTP/1.1
                LinhaErro = "3692 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                auxURL = "{\"benefitChosenAuthorization\":\"NO_AUTHORIZATION\",\"payerSource\":{\"name\":\"INSS\",\"identifier\":\"INSS\"}}";

                var responsePatch = DoPatch("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                            auxURL,
                                            headers: hdrs,
                                            _accept: "*/*",
                                            _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion

                #region GET /v1/attendances/13031157 HTTP/1.1
                LinhaErro = "3714 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion

                #region GET /v1/attendances/13031157?state-safe=true HTTP/1.1 
                LinhaErro = "3732 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", "0");
                hdrs.Add("user-id", "0");

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "?state-safe=true",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");

                try
                {
                    attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                }
                catch (Exception ex)
                {
                    attendancesData = new AttendancesData() { StoreId = "2722", UserId = "41642530883" };
                }
                #endregion

                #region GET /v1/attendances/13031157/available-offers HTTP/1.1 
                LinhaErro = "3759 - POST //aura?r=1&aura.ApexAction.execute=1 HTTP/1.1";
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "/available-offers",
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");


                //attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = LinhaErro + "   -   " + ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool AceitaOfertaGEV(DataClientPutRequest dadosCliente, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region PUT /v1/attendances/13031157/customers/31951228120/offers?document-type=CPF HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                dynamic auxBody = JsonConvert.DeserializeObject(response.Content);

                var strPost = "{\"person\": " + auxBody.person + ", \"products\":" + auxBody.products + "}";
                strPost = strPost.Replace("\n", "").Replace("\r", "").Replace("}]}", ",\"checked\":true}]}");

                var responsePut = DoPut("https://origination-crm-service-comercial.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"] + "/customers/" + dadosCliente.Document + "/offers?document-type=CPF",
                                        body: strPost,
                                        headers: hdrs,
                                        _accept: "*/*",
                                        _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion

                #region GET /v1/attendances/13031157 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "origination-crm-service-comercial.agibank-prd.in");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("store-id", attendancesData.StoreId);
                hdrs.Add("user-id", attendancesData.UserId);

                response = DoGet("https://origination-product-sale-originacao.agibank-prd.in/v1/attendances/" + keys["attendanceNumber"],
                                 headers: hdrs,
                                 _accept: "*/*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37");
                #endregion

                #region POST /apexremote HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("X-User-Agent", "Visualforce-Remoting");

                string auxReferer = "https://agibank.force.com/apex/OriginationPage?url=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D" + keys["attendanceNumber"] +
                                    "&taskId=" + keys["taskId"] + "&id=" + recordResponse.Account.Record.Id + "&corban=true&enableScroll=true";

                strPost = "{\"action\": \"OriginationTabController\"," +
                   "\"method\": \"changeStep\"," +
                   "\"data\": [\"" + keys["taskId"] + "\"," +
                   "\"Simulator\"]," +
                   "\"type\": \"rpc\"," +
                   "\"tid\": 2," +
                   "\"ctx\": {" +
                   "\"csrf\": \"" + VFRMRemotingProviderImpl.actions.OriginationTabController.ms[0].csrf + "\"," +
                   "\"vid\": \"0665A000005ySZc\"," +
                   "\"ns\": \"\"," +
                   "\"ver\":48}}";

                response = DoPost("https://agibank.force.com/apexremote",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*");

                hdrs.Remove("X-User-Agent");
                UpdateKeys("GevAtendimentoDetailSrcUrl", RetornaAuxSubstring(response.Content, "GevAtendimentoDetailSrcUrl\":\"", "\""));
                UpdateKeys("SimulatorPhoneSrcUrl", RetornaAuxSubstring(response.Content, "SimulatorPhoneSrcUrl\":\"", "\""));
                #endregion

                #region POST /OriginationPage?id=0018Z00002hGxfeQAC HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                strPost = "AJAXREQUEST=_viewRoot" +
                          "&thepage%3Aform=thepage%3Aform" +
                          "&com.salesforce.visualforce.ViewState=" + WebUtility.UrlEncode(keys["ViewState"]) +
                          "&com.salesforce.visualforce.ViewStateVersion=" + WebUtility.UrlEncode(keys["ViewStateVersion"]) +
                          "&com.salesforce.visualforce.ViewStateMAC=" + WebUtility.UrlEncode(keys["ViewStateMAC"]) +
                          "&com.salesforce.visualforce.ViewStateCSRF=" + WebUtility.UrlEncode(keys["ViewStateCSRF"]) +
                          "&newUrl=https%3A%2F%2Foffer-engine-ui-comercial.agibank-prd.in" + keys["GevAtendimentoDetailSrcUrl"].Substring(keys["GevAtendimentoDetailSrcUrl"].LastIndexOf('/')) +
                          "%2Fcomplete-offer?document=" + dadosCliente.Document + "&" + keys["SimulatorPhoneSrcUrl"].Substring(keys["SimulatorPhoneSrcUrl"].IndexOf('&') + 1) +
                          "&thepage%3Aform%3Aj_id37=thepage%3Aform%3Aj_id37&";

                response = DoPost("https://agibank.force.com/OriginationPage?id=" + recordResponse.Account.Record.Id,
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*");

                UpdateKeys("ViewState", RetornaAuxSubstring(response.Content, "ViewState\" value=\"", "\""));
                UpdateKeys("ViewStateVersion", RetornaAuxSubstring(response.Content, "=\"com.salesforce.visualforce.ViewStateVersion\" value=\"", "\""));
                UpdateKeys("ViewStateCSRF", RetornaAuxSubstring(response.Content, "ViewStateCSRF\" value=\"", "\""));
                UpdateKeys("ViewStateMAC", RetornaAuxSubstring(response.Content, "ViewStateMAC\" value=\"", "\""));
                #endregion

                #region GET /92691925/complete-offer?document=31951228120&userId=62788&storeId=70035&actualStoreId=2722&consultantTaxId=41642530883 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "offer-engine-ui-comercial.agibank-prd.in");

                auxURL = "https://offer-engine-ui-comercial.agibank-prd.in/" + keys["attendanceNumber"] + "/complete-offer" + keys["SimulatorPhoneSrcUrl"].Substring(keys["SimulatorPhoneSrcUrl"].IndexOf("?"));

                response = DoGet(auxURL,
                                 headers: hdrs,
                                 _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://agibank.force.com/");
                #endregion

                #region GET /simulator-service/v3/simulations/data/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                auxURL = keys["SimulatorPhoneSrcUrl"].Substring(keys["SimulatorPhoneSrcUrl"].IndexOf('&'));
                UpdateKeys("userId", RetornaAuxSubstring(auxURL, "userId=", "&"));

                auxURL = auxURL.Substring(auxURL.IndexOf('&'));
                UpdateKeys("storeId", RetornaAuxSubstring(auxURL, "storeId=", "&"));

                auxURL = auxURL.Substring(auxURL.IndexOf('&'));
                UpdateKeys("actualStoreId", RetornaAuxSubstring(auxURL, "actualStoreId=", "&"));

                auxURL = auxURL.Substring(auxURL.IndexOf('&'));
                UpdateKeys("consultantTaxId", auxURL.Substring(auxURL.IndexOf("consultantTaxId=") + 16));

                UpdateKeys("externalId", keys["GevAtendimentoDetailSrcUrl"].Substring(keys["GevAtendimentoDetailSrcUrl"].LastIndexOf('/') + 1));

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Referer", "https://offer-engine-ui-comercial.agibank-prd.in/");

                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SEARCH_ATTENDANCE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/data/" + keys["externalId"],
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                #endregion

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SEARCH_ATTENDANCE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                attendancesData = new AttendancesData()
                {
                    Document = dadosCliente.Document,
                    FullName = dadosCliente.FullName,
                    Consultant = new Consultant() { TaxId = keys["consultantTaxId"] },
                    ExternalId = keys["externalId"],
                    AllowDataprev = false,
                    AllowDataprevRemotely = false,
                    StoreId = keys["storeId"],
                    UserId = keys["userId"],
                    Benefit = new Benefit() { BenefitKind = new BenefitKind() { } },
                    AdditionalDocuments = new List<AdditionalDocumentsType>() { },
                    Attachments = new List<object> { },
                    CreationDate = attendancesData.CreationDate,
                    HasValidToken = false,
                    AsyncTokenReceived = false,
                    LastUpdateDate = attendancesData.LastUpdateDate,
                    DurationSeconds = 0
                };

                responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                    body: JsonConvert.SerializeObject(attendancesData),
                                    headers: hdrs,
                                    _accept: "application/json, text/plain, */*",
                                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                #region GET /simulator-service/v3/simulations/data/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //UpdateKeys("externalId", keys["GevAtendimentoDetailSrcUrl"].Substring(keys["GevAtendimentoDetailSrcUrl"].LastIndexOf('/') +1));

                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "COMPLETE_OFFER");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/data/" + keys["externalId"],
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                #endregion

                #region GET /simulator-service/v3/simulations/data/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //UpdateKeys("externalId", keys["GevAtendimentoDetailSrcUrl"].Substring(keys["GevAtendimentoDetailSrcUrl"].LastIndexOf('/') +1));

                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "COMPLETE_OFFER");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/data/" + keys["externalId"],
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                #endregion

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "COMPLETE_OFFER");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                    //body: "{\"person\":{},\"products\":[{\"id\":\"COMPLETE_OFFER\",\"title\":\"Oferta GEV 1.0\",\"subtitle\":\"Conta corrente + Cartão de crédito + produtos Agibank.\",\"income\":{\"benefit\":{}},\"autoSelected\":false,\"hidden\":false,\"checked\":true}]}",
                                    body: JsonConvert.SerializeObject(attendancesData),
                                    headers: hdrs,
                                    _accept: "application/json, text/plain, */*",
                                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "ATTENDANCE_TYPE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var auxAttendancesData = new AttendancesData()
                {
                    Phone = null,
                    AdditionalDocuments = new List<AdditionalDocumentsType>(),
                    Benefit = new Benefit() { BenefitKind = new BenefitKind() },
                    Document = attendancesData.Document,
                    ExternalId = attendancesData.ExternalId,
                    FullName = attendancesData.FullName,
                    Income = new Income()
                    {
                        CalculatedPayday = null,
                        CalculatedIncome = null,
                        Discount = null,
                        EstimatedIncome = null,
                        EstimatedNetIncome = null,
                        GrossIncome = null,
                        NetIncome = null,
                        PaySource = null,
                        Payday = null,
                        PayDayOrigin = null
                    },
                    HasValidToken = false,
                    AttendanceType = null,
                    Consultant = new Consultant() { TaxId = currentUser.Id },
                    OriginalAttendanceType = null,
                    DataprevAllowanceType = null
                };

                responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                    //body: "{\"person\":{},\"products\":[{\"id\":\"COMPLETE_OFFER\",\"title\":\"Oferta GEV 1.0\",\"subtitle\":\"Conta corrente + Cartão de crédito + produtos Agibank.\",\"income\":{\"benefit\":{}},\"autoSelected\":false,\"hidden\":false,\"checked\":true}]}",
                                    body: JsonConvert.SerializeObject(auxAttendancesData),
                                    headers: hdrs,
                                    _accept: "application/json, text/plain, */*",
                                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool AtendimentoTelefonico(string cpf, string nome, string sobrenome, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "ATTENDANCE_TYPE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var auxPut = "{" +
                    "   \"phone\": null," +
                    "   \"additionalDocuments\": []," +
                    "   \"benefit\": {" +
                    "   \"benefitKind\": {}" +
                    "   }," +
                    "   \"document\": \"" + cpf + "\"," +
                    "   \"externalId\": \"" + keys["externalId"] + "\"," +
                    "   \"fullName\": \"" + nome + " " + sobrenome + "\"," +
                    "   \"income\": {                    " +
                    "      \"calculatedPayday\": null,   " +
                    "      \"calculatedIncome\": null,   " +
                    "      \"discount\": null,           " +
                    "      \"estimatedIncome\": null,    " +
                    "      \"estimatedNetIncome\": null, " +
                    "      \"grossIncome\": null,        " +
                    "      \"netIncome\": null,          " +
                    "      \"paySource\": null,          " +
                    "      \"payday\": null,             " +
                    "      \"payDayOrigin\": null        " +
                    "   },                               " +
                    "   \"hasValidToken\": false,        " +
                    "   \"attendanceType\": \"BY_PHONE\"," +
                    "   \"consultant\": {                " +
                    "      \"taxId\": \"" + attendancesData.Consultant.TaxId + "\"    " +
                    "   },                               " +
                    "   \"originalAttendanceType\": null," +
                    "   \"dataprevAllowanceType\": null  " +
                    "}";

                var responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                    //body: "{\"person\":{},\"products\":[{\"id\":\"COMPLETE_OFFER\",\"title\":\"Oferta GEV 1.0\",\"subtitle\":\"Conta corrente + Cartão de crédito + produtos Agibank.\",\"income\":{\"benefit\":{}},\"autoSelected\":false,\"hidden\":false,\"checked\":true}]}",
                                    body: auxPut,
                                    headers: hdrs,
                                    _accept: "application/json, text/plain, */*",
                                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                //#region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                //hdrs = new Dictionary<string, string>();

                //hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                //hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                //hdrs.Add("Host", "prd-gateway.agibank.com.br");
                //hdrs.Add("Content-Type", "application/json");
                //hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                //hdrs.Add("Action", "SAVE_PERSON");
                //hdrs.Add("actualStoreId", keys["actualStoreId"]);
                //hdrs.Add("attendanceStatus", "");
                //hdrs.Add("externalId", keys["externalId"]);
                //hdrs.Add("step", "ATTENDANCE_TYPE");
                //hdrs.Add("storeId", keys["storeId"]);
                //hdrs.Add("userId", keys["userId"]);

                // auxAttendancesData = new AttendancesData()
                //{
                //    Phone = null,
                //    AdditionalDocuments = new List<AdditionalDocumentsType>(),
                //    Benefit = new Benefit() { BenefitKind = new BenefitKind() },
                //    Document = attendancesData.Document,
                //    ExternalId = attendancesData.ExternalId,
                //    FullName = attendancesData.FullName,
                //    Income = new Income()
                //    {
                //        CalculatedPayday = null,
                //        CalculatedIncome = null,
                //        Discount = null,
                //        EstimatedIncome = null,
                //        EstimatedNetIncome = null,
                //        GrossIncome = null,
                //        NetIncome = null,
                //        PaySource = null,
                //        Payday = null,
                //        PayDayOrigin = null
                //    },
                //    HasValidToken = false,
                //    AttendanceType = "BY_PHONE",
                //    Consultant = new Consultant() { TaxId = currentUser.Id },
                //    OriginalAttendanceType = null,
                //    DataprevAllowanceType = null
                //};

                // responsePut = DoPut("https://origination-crm-service-comercial.agibank-prd.in/simulator-service/v3/clients/" + keys["attendanceNumber"],
                //                    //body: "{\"person\":{},\"products\":[{\"id\":\"COMPLETE_OFFER\",\"title\":\"Oferta GEV 1.0\",\"subtitle\":\"Conta corrente + Cartão de crédito + produtos Agibank.\",\"income\":{\"benefit\":{}},\"autoSelected\":false,\"hidden\":false,\"checked\":true}]}",
                //                    body: JsonConvert.SerializeObject(attendancesData),
                //                    headers: hdrs,
                //                    _accept: "*/*",
                //                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                //                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                //attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                //#endregion

                //#region GET /simulator-service/v3/clients/31951228120 HTTP/1.1
                //hdrs = new Dictionary<string, string>();
                //hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                //hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                //hdrs.Add("Host", "prd-gateway.agibank.com.br");
                ////hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //UpdateKeys("externalId", keys["GevAtendimentoDetailSrcUrl"].Substring(keys["GevAtendimentoDetailSrcUrl"].LastIndexOf('/') + 1));

                //hdrs.Add("actualStoreId", keys["actualStoreId"]);
                //hdrs.Add("attendanceStatus", "");
                //hdrs.Add("externalId", keys["externalId"]);
                //hdrs.Add("step", "SEARCH_PERSON");
                //hdrs.Add("storeId", keys["storeId"]);
                //hdrs.Add("userId", keys["userId"]);

                //response = DoGet("/simulator-service/v3/clients/" + cpf,
                //                 headers: hdrs,
                //                 _accept: "application/json, text/plain, */*",
                //                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                //                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                ////attendancesData = JsonConvert.DeserializeObject<AttendancesData>(response.Content);
                //#endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool ContinuarProcesso(string cpf, string nome, string sobrenome, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SEARCH_PERSON");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                //var auxAttendancesData = new AttendancesData()
                //{
                //    Phone = null,
                //    AdditionalDocuments = new List<AdditionalDocumentsType>(),
                //    Benefit = new Benefit() { BenefitKind = new BenefitKind() },
                //    Document = attendancesData.Document,
                //    ExternalId = attendancesData.ExternalId,
                //    FullName = attendancesData.FullName,
                //    Income = new Income() { },
                //    HasValidToken = false,
                //    AttendanceType = "BY_PHONE",
                //    Consultant = new Consultant() { TaxId = currentUser.Id },
                //    OriginalAttendanceType = null,
                //    DataprevAllowanceType = null,
                //    Birthday = null,
                //    PostCode = null
                //};

                var auxPut = "{" +
                    "   \"phone\": null," +
                    "   \"additionalDocuments\": []," +
                    "   \"benefit\": {" +
                    "   \"benefitKind\": {}" +
                    "   }," +
                    "   \"document\": \"" + cpf + "\"," +
                    "   \"externalId\": \"" + keys["externalId"] + "\"," +
                    "   \"fullName\": \"" + nome + " " + sobrenome + "\"," +
                    "   \"income\": {},                               " +
                    "   \"hasValidToken\": false,        " +
                    "   \"attendanceType\": \"BY_PHONE\"," +
                    "   \"consultant\": {                " +
                    "      \"taxId\": \"" + attendancesData.Consultant.TaxId + "\"    " +
                    "   },                               " +
                    "   \"originalAttendanceType\": \"BY_PHONE\"," +
                    "   \"dataprevAllowanceType\": null," +
                    "   \"birthday\": null," +
                    "   \"postCode\": null" +
                    "}";

                var responsePut = DoPut("https://origination-crm-service-comercial.agibank-prd.in/simulator-service/v3/clients/" + keys["externalId"],
                                    //body: "{\"person\":{},\"products\":[{\"id\":\"COMPLETE_OFFER\",\"title\":\"Oferta GEV 1.0\",\"subtitle\":\"Conta corrente + Cartão de crédito + produtos Agibank.\",\"income\":{\"benefit\":{}},\"autoSelected\":false,\"hidden\":false,\"checked\":true}]}",
                                    body: auxPut,
                                    headers: hdrs,
                                    _accept: "*/*",
                                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                //attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool ContinuarSemCadastro(string cpf, string nome, string sobrenome, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region GET /simulator-service/v3/clients/31951228120/phones?activated=true&hot=true HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                //hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_PHONES_BY_DOCUMENT");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + cpf + "/phones?activated=true&hot=true",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET /simulator-service/v3/clients/31951228120/phones?activated=true&hot=true HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                //hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_PHONES_BY_DOCUMENT");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + cpf + "/phones?activated=true&hot=true",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region POST /simulator-service/v3/simulations/events HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "NOT_INFORMED_PHONE");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);


                string auxReferer = "https://agibank.force.com//apex/OriginationPage?url=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D" + keys["attendanceNumber"] +
                                    "&taskId=" + keys["taskId"] + "&id=" + recordResponse.Account.Record.Id + "&corban=true&enableScroll=true";

                var strPost = "{\"reason\":\"Cliente com telefone temporariamente indisponível\"}";

                response = DoPost("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/events",
                           strPost,
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*");

                //UpdateKeys("GevAtendimentoDetailSrcUrl", RetornaAuxSubstring(response.Content, "GevAtendimentoDetailSrcUrl\":\"", "\""));
                //UpdateKeys("SimulatorPhoneSrcUrl", RetornaAuxSubstring(response.Content, "SimulatorPhoneSrcUrl\":\"", "\""));
                #endregion

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://origination-product-sale-originacao.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var auxPut = "{" +
                    "   \"phone\": null," +
                    "   \"additionalDocuments\": []," +
                    "   \"benefit\": {" +
                    "   \"benefitKind\": {}" +
                    "   }," +
                    "   \"document\": \"" + cpf + "\"," +
                    "   \"externalId\": \"" + keys["externalId"] + "\"," +
                    "   \"fullName\": \"" + nome + " " + sobrenome + "\"," +
                    "   \"income\": {},                               " +
                    "   \"hasValidToken\": false,        " +
                    "   \"attendanceType\": \"BY_PHONE\"," +
                    "   \"consultant\": {                " +
                    "      \"taxId\": \"" + attendancesData.Consultant.TaxId + "\"    " +
                    "   },                               " +
                    "   \"originalAttendanceType\": \"BY_PHONE\"," +
                    "   \"dataprevAllowanceType\": null," +
                    "   \"birthday\": null," +
                    "   \"postCode\": null" +
                    "}";

                var responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                    //body: "{\"person\":{},\"products\":[{\"id\":\"COMPLETE_OFFER\",\"title\":\"Oferta GEV 1.0\",\"subtitle\":\"Conta corrente + Cartão de crédito + produtos Agibank.\",\"income\":{\"benefit\":{}},\"autoSelected\":false,\"hidden\":false,\"checked\":true}]}",
                                    body: auxPut,
                                    headers: hdrs,
                                    _accept: "application/json, text/plain, */*",
                                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                #region GET /simulator-service/v2/documents/required-documents/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "prd-gateway.agibank.com.br");

                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "PHONE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v2/documents/required-documents/" + keys["externalId"],
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET /simulator-service/v3/clients/92691925/dataprev-grants HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DISTANCE_AUTHORIZATION");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"] + "/dataprev-grants",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region POST /simulator-service/v3/simulations/events HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "PHONE_FOLLOW_WITHOUT_DATAPREV");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DISTANCE_AUTHORIZATION");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                strPost = "{}";

                response = DoPost("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/events",
                           strPost,
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*");

                //UpdateKeys("GevAtendimentoDetailSrcUrl", RetornaAuxSubstring(response.Content, "GevAtendimentoDetailSrcUrl\":\"", "\""));
                //UpdateKeys("SimulatorPhoneSrcUrl", RetornaAuxSubstring(response.Content, "SimulatorPhoneSrcUrl\":\"", "\""));
                #endregion

                #region GET /simulator-service/v3/customer-proposals/31951228120/benefits HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_BENEFITS");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DISTANCE_AUTHORIZATION");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/customer-proposals/" + cpf + "/benefits",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool EtapaDadosPessoais(DataClientPutRequest dadosCliente, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region GET /simulator-service/v1/cep/18400490 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_PHONES_BY_DOCUMENT");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_PERSONAL");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v1/cep/" + dadosCliente.PostCode,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET /simulator-service/v1/cep/18400490 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_PHONES_BY_DOCUMENT");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_PERSONAL");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v1/cep/" + dadosCliente.PostCode,
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_PERSONAL");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var auxAttendancesData = new AttendancesData()
                {
                    Phone = null,
                    AdditionalDocuments = new List<AdditionalDocumentsType>(),
                    Benefit = new Benefit() { BenefitKind = new BenefitKind() },
                    Document = attendancesData.Document,
                    ExternalId = attendancesData.ExternalId,
                    FullName = attendancesData.FullName,
                    Income = new Income() { },
                    HasValidToken = false,
                    AttendanceType = "BY_PHONE",
                    Consultant = new Consultant() { TaxId = currentUser.Id },
                    OriginalAttendanceType = "BY_PHONE",
                    DataprevAllowanceType = null,
                    PostCode = dadosCliente.PostCode,
                    Birthday = dadosCliente.Birthday
                };

                auxAttendancesData.AdditionalDocuments.Add(new AdditionalDocumentsType() { Number = dadosCliente.Benefit.BenefitNumber, Type = "RG" });

                var auxPut = "{                                              " +
                             "   \"phone\": null,                            " +
                             "   \"additionalDocuments\": [                  " +
                             "      {                                        " +
                             "         \"number\": \"" + dadosCliente.Benefit.BenefitNumber + "\", " +
                             "         \"type\": \"RG\"                      " +
                             "      }                                        " +
                             "   ],                                          " +
                             "   \"benefit\": {                              " +
                             "      \"benefitKind\": {}                      " +
                             "   },                                          " +
                             "   \"document\": \"" + dadosCliente.Document + "\"," +
                             "   \"externalId\": \"" + keys["externalId"] + "\"," +
                             "   \"fullName\": \"" + dadosCliente.FullName + "\"," +
                             "   \"income\": {},                             " +
                             "   \"hasValidToken\": false,                   " +
                             "   \"attendanceType\": \"BY_PHONE\",           " +
                             "   \"consultant\": {                           " +
                             "      \"taxId\": \"" + attendancesData.Consultant.TaxId + "\"" +
                             "   },                                          " +
                             "   \"originalAttendanceType\": \"BY_PHONE\",   " +
                             "   \"dataprevAllowanceType\": null,            " +
                             "   \"postCode\": \"" + dadosCliente.PostCode + "\"," +
                             "   \"birthday\": \"" + dadosCliente.Birthday + "\"" +
                             "}";

                var responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                    body: auxPut,
                                    headers: hdrs,
                                    _accept: "*/*",
                                    _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                    _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool EtapaDadosBeneficios(DataClientPutRequest dadosCliente, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                #region GET /simulator-service/v3/customer-proposals/31951228120/benefits/1823046018/income?benefitSpecieNumber=41 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "GET_CALCULATED_INCOME");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_BENEFIT");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                try
                {
                    response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/customer-proposals/" + dadosCliente.Document + "/benefits/" + dadosCliente.AdditionalDocuments[0].Number + "/income?benefitSpecieNumber=41",
                                     headers: hdrs,
                                     _accept: "application/json, text/plain, */*",
                                     _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                     _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                }
                catch (Exception ex) { }
                #endregion

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_BENEFIT");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var auxAttendancesData = new AttendancesData()
                {
                    Phone = null,
                    AdditionalDocuments = new List<AdditionalDocumentsType>(),
                    Benefit = new Benefit()
                    {
                        BenefitKind = new BenefitKind()
                        {
                            Code = "41"
                        },
                        BenefitNumber = dadosCliente.Benefit.BenefitNumber,
                        DispatchYear = dadosCliente.Benefit.DispatchYear.Value.ToString(),
                        AvaliableMargin = dadosCliente.Benefit.AvailableMargin,
                        AvailableCardMargin = dadosCliente.Benefit.AvailableCardMargin,
                        OwnsLawfulAgent = dadosCliente.Benefit.OwnsLawfulAgent
                    },
                    Birthday = dadosCliente.Birthday,
                    Document = dadosCliente.Document,
                    ExternalId = dadosCliente.ExternalId,
                    FullName = dadosCliente.FullName,
                    Income = new Income(),
                    PostCode = dadosCliente.PostCode,
                    HasValidToken = false,
                    AttendanceType = "BY_PHONE",
                    Consultant = new Consultant() { TaxId = currentUser.Id },
                    OriginalAttendanceType = "BY_PHONE",
                    DataprevAllowanceType = null
                };

                auxAttendancesData.AdditionalDocuments.Add(new AdditionalDocumentsType() { Number = dadosCliente.Benefit.BenefitNumber, Type = "RG" });

                var auxPut = "{                                              " +
                             "   \"phone\": null,                            " +
                             "   \"additionalDocuments\": [                  " +
                             "      {                                        " +
                             "         \"type\": \"RG\",                     " +
                             "         \"number\": \"" + dadosCliente.Document + "\"            " +
                             "      }                                        " +
                             "   ],                                          " +
                             "   \"benefit\": {                              " +
                             "      \"benefitKind\": {                       " +
                             "         \"code\": \"" + dadosCliente.Benefit.BenefitKind.Code + "\"                      " +
                             "      },                                       " +
                             "      \"benefitNumber\": \"" + dadosCliente.Benefit.BenefitNumber + "\",       " +
                             "      \"dispatchYear\": \"" + dadosCliente.Benefit.DispatchYear + "\",              " +
                             "      \"availableMargin\": null,               " +
                             "      \"availableCardMargin\": null,           " +
                             "      \"ownsLawfulAgent\": false               " +
                             "   },                                          " +
                             "   \"birthday\": \"" + dadosCliente.Birthday + "\",               " +
                             "   \"document\": \"" + dadosCliente.Document + "\",              " +
                             "   \"externalId\": \"" + keys["externalId"] + "\",               " +
                             "   \"fullName\": \"" + dadosCliente.FullName + "\"," +
                             "   \"income\": {},                             " +
                             "   \"postCode\": \"" + dadosCliente.PostCode + "\",                 " +
                             "   \"hasValidToken\": false,                   " +
                             "   \"attendanceType\": \"BY_PHONE\",           " +
                             "   \"consultant\": {                           " +
                             "      \"taxId\": \"" + attendancesData.Consultant.TaxId + "\"               " +
                             "   },                                          " +
                             "   \"originalAttendanceType\": \"BY_PHONE\",   " +
                             "   \"dataprevAllowanceType\": null,             " +
                             "   \"dataprevAllowanceType\": null             " +
                             "}";

                var responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                   body: auxPut,
                                   headers: hdrs,
                                   _accept: "application/json, text/plain, */*",
                                   _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                   _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                #region GET /simulator-service/v1/banks HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_CALCULATED_INCOME");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_ADDITIONAL");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v1/banks",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public bool EtapaDadosRenda(DataClientPutRequest dadosCliente, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                #region GET /simulator-service/v3/simulations/2022-01-05 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_CALCULATED_INCOME");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_ADDITIONAL");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/" + dadosCliente.Income.DatePayday.Value.ToString("yyyy-MM-dd"),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_ADDITIONAL");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var auxAttendancesData = new AttendancesData()
                {
                    Phone = null,
                    AdditionalDocuments = new List<AdditionalDocumentsType>(),
                    Benefit = new Benefit()
                    {
                        BenefitKind = new BenefitKind()
                        {
                            Code = "41"
                        },
                        DispatchYear = dadosCliente.Benefit.DispatchYear.Value.ToString(),
                        BenefitNumber = dadosCliente.Benefit.BenefitNumber,
                        OwnsLawfulAgent = dadosCliente.Benefit.OwnsLawfulAgent,
                        CBCIfPayer = dadosCliente.Benefit.CBCIfPayer
                    },
                    Birthday = dadosCliente.Birthday,
                    Document = dadosCliente.Document,
                    ExternalId = dadosCliente.ExternalId,
                    FullName = dadosCliente.FullName,
                    Income = new Income()
                    {
                        GrossIncome = dadosCliente.Income.GrossIncome,
                        NetIncome = dadosCliente.Income.NetIncome,
                        Discount = dadosCliente.Income.Discount,
                        Payday = dadosCliente.Income.Payday,
                        CalculatedPayday = dadosCliente.Income.CalculatedPayday,
                    },
                    PostCode = dadosCliente.PostCode,
                    HasValidToken = false,
                    AttendanceType = "BY_PHONE",
                    Consultant = new Consultant() { TaxId = currentUser.Id },
                    OriginalAttendanceType = "BY_PHONE",
                    DataprevAllowanceType = null
                };

                auxAttendancesData.AdditionalDocuments.Add(new AdditionalDocumentsType() { Number = dadosCliente.Benefit.BenefitNumber, Type = "RG" });

                var auxPut = "{                                              " +
                            "   \"phone\": null,                            " +
                            "   \"additionalDocuments\": [                  " +
                            "      {                                        " +
                            "         \"type\": \"RG\",                     " +
                            "         \"number\": \"" + dadosCliente.Benefit.BenefitNumber + "\"            " +
                            "      }                                        " +
                            "   ],                                          " +
                            "   \"benefit\": {                              " +
                            "      \"benefitKind\": {                       " +
                            "         \"code\": " + dadosCliente.Benefit.BenefitKind.Code + "                          " +
                            "      },                                       " +
                            "      \"dispatchYear\": " + dadosCliente.Benefit.DispatchYear + ",                  " +
                            "      \"benefitNumber\": \"" + dadosCliente.Benefit.BenefitNumber + "\",       " +
                            "      \"ownsLawfulAgent\": false,              " +
                            "      \"cbcIfPayer\": \"" + dadosCliente.Benefit.CBCIfPayer + "\"                  " +
                            "   },                                          " +
                            "   \"birthday\": \"" + dadosCliente.Birthday + "\",               " +
                            "   \"document\": \"" + dadosCliente.Document + "\",              " +
                            "   \"externalId\": \"" + dadosCliente.ExternalId + "\",               " +
                            "   \"fullName\": \"" + dadosCliente.FullName + "\"," +
                            "   \"income\": {                               " +
                            "      \"grossIncome\": " + dadosCliente.Income.GrossIncome + ",                   " +
                            "      \"netIncome\": " + dadosCliente.Income.NetIncome + ",                     " +
                            "      \"discount\": " + dadosCliente.Income.Discount + ",                         " +
                            "      \"payday\": \"" + dadosCliente.Income.Payday + "\",              " +
                            "      \"calculatedPayday\": false              " +
                            "   },                                          " +
                            "   \"postCode\": \"" + dadosCliente.PostCode + "\",                 " +
                            "   \"hasValidToken\": false,                   " +
                            "   \"attendanceType\": \"BY_PHONE\",           " +
                            "   \"consultant\": {                           " +
                            "      \"taxId\": \"" + attendancesData.Consultant.TaxId + "\"               " +
                            "   },                                          " +
                            "   \"originalAttendanceType\": \"BY_PHONE\",   " +
                            "   \"dataprevAllowanceType\": null             " +
                            "}";

                var responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                   //body: "{\"person\":{},\"products\":[{\"id\":\"COMPLETE_OFFER\",\"title\":\"Oferta GEV 1.0\",\"subtitle\":\"Conta corrente + Cartão de crédito + produtos Agibank.\",\"income\":{\"benefit\":{}},\"autoSelected\":false,\"hidden\":false,\"checked\":true}]}",
                                   body: auxPut,
                                   headers: hdrs,
                                   _accept: "application/json, text/plain, */*",
                                   _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                   _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                #region GET /simulator-service/v1/banks HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_CALCULATED_INCOME");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_CONFIRM");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v1/banks",
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                #region GET /simulator-service/v3/simulations/2022-01-05 HTTP/1.1
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                //hdrs.Add("Action", "GET_CALCULATED_INCOME");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_CONFIRM");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                response = DoGet("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/" + dadosCliente.Income.DatePayday.Value.ToString("yyyy-MM-dd"),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        /// <summary>
        /// Etapa Está tudo certo
        /// </summary>
        /// <param name="dadosCliente"></param>
        /// <param name="erro"></param>
        /// <returns></returns>
        public bool EtapaConferencia(DataClientPutRequest dadosCliente, ref string erro)
        {
            try
            {
                var hdrs = new Dictionary<string, string>();

                #region PUT /simulator-service/v3/clients/92691925 HTTP/1.1
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");

                hdrs.Add("Action", "SAVE_PERSON");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "DATA_CONFIRM");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var auxAttendancesData = new AttendancesData()
                {
                    Phone = null,
                    AdditionalDocuments = new List<AdditionalDocumentsType>(),
                    Benefit = new Benefit()
                    {
                        BenefitKind = new BenefitKind()
                        {
                            Code = "41"
                        },
                        DispatchYear = dadosCliente.Benefit.DispatchYear.Value.ToString(),
                        BenefitNumber = dadosCliente.Benefit.BenefitNumber,
                        OwnsLawfulAgent = dadosCliente.Benefit.OwnsLawfulAgent,
                        CBCIfPayer = dadosCliente.Benefit.CBCIfPayer
                    },
                    Birthday = dadosCliente.Birthday,
                    Document = dadosCliente.Document,
                    ExternalId = dadosCliente.ExternalId,
                    FullName = dadosCliente.FullName,
                    Income = new Income()
                    {
                        GrossIncome = dadosCliente.Income.GrossIncome,
                        NetIncome = dadosCliente.Income.NetIncome,
                        Discount = dadosCliente.Income.Discount,
                        Payday = dadosCliente.Income.Payday,
                        CalculatedPayday = dadosCliente.Income.CalculatedPayday,
                    },
                    PostCode = dadosCliente.PostCode,
                    HasValidToken = false,
                    AttendanceType = "BY_PHONE",
                    Consultant = new Consultant() { TaxId = currentUser.Id },
                    OriginalAttendanceType = "BY_PHONE",
                    DataprevAllowanceType = null
                };

                auxAttendancesData.AdditionalDocuments.Add(new AdditionalDocumentsType() { Number = dadosCliente.Benefit.BenefitNumber, Type = "RG" });

                var auxPut = "{                                              " +
                            "   \"phone\": null,                            " +
                            "   \"additionalDocuments\": [                  " +
                            "      {                                        " +
                            "         \"type\": \"RG\",                     " +
                            "         \"number\": \"" + dadosCliente.Benefit.BenefitNumber + "\"            " +
                            "      }                                        " +
                            "   ],                                          " +
                            "   \"benefit\": {                              " +
                            "      \"benefitKind\": {                       " +
                            "         \"code\": " + dadosCliente.Benefit.BenefitKind.Code + "                          " +
                            "      },                                       " +
                            "      \"dispatchYear\": " + dadosCliente.Benefit.DispatchYear + ",                  " +
                            "      \"benefitNumber\": \"" + dadosCliente.Benefit.BenefitNumber + "\",       " +
                            "      \"ownsLawfulAgent\": false,              " +
                            "      \"cbcIfPayer\": \"" + dadosCliente.Benefit.CBCIfPayer + "\"                  " +
                            "   },                                          " +
                            "   \"birthday\": \"" + dadosCliente.Birthday + "\",               " +
                            "   \"document\": \"" + dadosCliente.Document + "\",              " +
                            "   \"externalId\": \"" + dadosCliente.ExternalId + "\",               " +
                            "   \"fullName\": \"" + dadosCliente.FullName + "\"," +
                            "   \"income\": {                               " +
                            "      \"grossIncome\": " + dadosCliente.Income.GrossIncome + ",                   " +
                            "      \"netIncome\": " + dadosCliente.Income.NetIncome + ",                     " +
                            "      \"discount\": " + dadosCliente.Income.Discount + ",                         " +
                            "      \"payday\": \"" + dadosCliente.Income.Payday + "\",              " +
                            "      \"calculatedPayday\": false              " +
                            "   },                                          " +
                            "   \"postCode\": \"" + dadosCliente.PostCode + "\",                 " +
                            "   \"hasValidToken\": false,                   " +
                            "   \"attendanceType\": \"BY_PHONE\",           " +
                            "   \"consultant\": {                           " +
                            "      \"taxId\": \"" + attendancesData.Consultant.TaxId + "\"               " +
                            "   },                                          " +
                            "   \"originalAttendanceType\": \"BY_PHONE\",   " +
                            "   \"dataprevAllowanceType\": null             " +
                            "}";

                var responsePut = DoPut("https://prd-gateway.agibank.com.br/simulator-service/v3/clients/" + keys["externalId"],
                                   body: auxPut,
                                   headers: hdrs,
                                   _accept: "application/json, text/plain, */*",
                                   _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                   _referer: "https://offer-engine-ui-comercial.agibank-prd.in/");

                attendancesData = JsonConvert.DeserializeObject<AttendancesData>(responsePut);
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
                return false;
            }

        }

        public DadosClienteProduto Simular(DataClientPutRequest dadosCliente, ref string erro)
        {
            DadosClienteProduto retornoDadosCliente = new DadosClienteProduto();
            var LinhaErro = 0;

            try
            {
                var hdrs = new Dictionary<string, string>();
                var auxURL = "";

                #region POST /simulator-service/v3/simulations/92691925/connectDocument/true HTTP/1.1
                LinhaErro = 5251;
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "prd-gateway.agibank.com.br");
                hdrs.Add("Origin", "https://offer-engine-ui-comercial.agibank-prd.in");
                hdrs.Add("Content-Type", "application/json");

                hdrs.Add("Action", "SIMULATED");
                hdrs.Add("actualStoreId", keys["actualStoreId"]);
                hdrs.Add("attendanceStatus", "");
                hdrs.Add("externalId", keys["externalId"]);
                hdrs.Add("step", "SIMULATE");
                hdrs.Add("storeId", keys["storeId"]);
                hdrs.Add("userId", keys["userId"]);

                var strPost = "";

                response = DoPost("https://prd-gateway.agibank.com.br/simulator-service/v3/simulations/" + keys["externalId"] + "/connectDocument/true",
                           strPost,
                           headers: hdrs,
                           _referer: "https://offer-engine-ui-comercial.agibank-prd.in/",
                           _accept: "application/json, text/plain, */*");
                #endregion

                #region POST /apexremote HTTP/1.1
                LinhaErro = 5277;
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/json");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");
                hdrs.Add("X-User-Agent", "Visualforce-Remoting");

                string auxReferer = "https://agibank.force.com//apex/OriginationPage?url=https%3A%2F%2Forigination-product-sale-originacao.agibank-prd.in%3FattendanceNumber%3D" + keys["attendanceNumber"] +
                                    "&taskId=" + keys["taskId"] + "&id=" + recordResponse.Account.Record.Id + "&corban=true&enableScroll=true";

                strPost = "{\"action\": \"OriginationTabController\"," +
                   "\"method\": \"changeStep\"," +
                   "\"data\": [\"" + keys["taskId"] + "\"," +
                   "\"GEV\"]," +
                   "\"type\": \"rpc\"," +
                   "\"tid\": 3," +
                   "\"ctx\": {" +
                   "\"csrf\": \"" + VFRMRemotingProviderImpl.actions.OriginationTabController.ms[0].csrf + "\"," +
                   "\"vid\": \"0665A000005ySZc\"," +
                   "\"ns\": \"\"," +
                   "\"ver\":48}}";

                response = DoPost("https://agibank.force.com/apexremote",
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*");

                hdrs.Remove("X-User-Agent");
                UpdateKeys("GevAtendimentoDetailSrcUrl", RetornaAuxSubstring(response.Content, "GevAtendimentoDetailSrcUrl\":\"", "\""));
                UpdateKeys("SimulatorPhoneSrcUrl", RetornaAuxSubstring(response.Content, "SimulatorPhoneSrcUrl\":\"", "\""));
                #endregion

                #region POST /OriginationPage?id=0018Z00002hGxfeQAC HTTP/1.1
                LinhaErro = 5314;
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "agibank.force.com");
                hdrs.Add("Origin", "https://agibank.force.com");
                hdrs.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");

                strPost = "AJAXREQUEST=_viewRoot" +
                          "&thepage%3Aform=thepage%3Aform" +
                          "&com.salesforce.visualforce.ViewState=" + WebUtility.UrlEncode(keys["ViewState"]) +
                          "&com.salesforce.visualforce.ViewStateVersion=" + WebUtility.UrlEncode(keys["ViewStateVersion"]) +
                          "&com.salesforce.visualforce.ViewStateMAC=" + WebUtility.UrlEncode(keys["ViewStateMAC"]) +
                          "&com.salesforce.visualforce.ViewStateCSRF=" + WebUtility.UrlEncode(keys["ViewStateCSRF"]) +
                          "&newUrl=https%3A%2F%2Foffer-engine-ui-comercial.agibank-prd.in%2F" + keys["GevAtendimentoDetailSrcUrl"].Substring(keys["GevAtendimentoDetailSrcUrl"].LastIndexOf('/') + 1) +
                          "%2Fcomplete-offer" + keys["SimulatorPhoneSrcUrl"].Substring(keys["SimulatorPhoneSrcUrl"].IndexOf('?')) +
                          "&thepage%3Aform%3Aj_id37=thepage%3Aform%3Aj_id37&";

                response = DoPost("https://agibank.force.com/OriginationPage?id=" + recordResponse.Account.Record.Id,
                           strPost,
                           headers: hdrs,
                           _referer: auxReferer,
                           _accept: "*/*");

                UpdateKeys("ViewState", RetornaAuxSubstring(response.Content, "ViewState\" value=\"", "\""));
                UpdateKeys("ViewStateVersion", RetornaAuxSubstring(response.Content, "=\"com.salesforce.visualforce.ViewStateVersion\" value=\"", "\""));
                UpdateKeys("ViewStateCSRF", RetornaAuxSubstring(response.Content, "ViewStateCSRF\" value=\"", "\""));
                UpdateKeys("ViewStateMAC", RetornaAuxSubstring(response.Content, "ViewStateMAC\" value=\"", "\""));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/Embedded/2888d8a46b41665abd91407bea0d8908/ HTTP/1.1
                LinhaErro = 5345;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet(keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')),
                           headers: hdrs,
                           _accept: "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: "https://agibank.force.com/");

                auxReferer = response.ResponseUri.ToString();
                #endregion

                #region GET /Venda.UI.Web/Agenda/ConsultarEventos?from=1656644400000&to=1659322800000&utc_offset=180&browser_timezone=America%2FArgentina%2FBuenos_Aires HTTP/1.1
                LinhaErro = 5362;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Agenda/ConsultarEventos?from=1656644400000&to=1659322800000&utc_offset=180&browser_timezone=America%2FArgentina%2FBuenos_Aires",
                           headers: hdrs,
                           _accept: "application/json, text/javascript, */*; q=0.01",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: response.ResponseUri.ToString());
                #endregion

                #region GET /Venda.UI.Web/Atendimento/Embedded/2888d8a46b41665abd91407bea0d8908/Content/html/calendar/month.html?_=1658373058914 HTTP/1.1
                LinhaErro = 5378;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");

                response = DoGet(keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')) + "/Content/html/calendar/month.html?_=1658373058914",
                           headers: hdrs,
                           _accept: "text/html, */*; q=0.01",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));

                var auxURLPost = RetornaAuxSubstring(response.Content, "data-dtconfig=\"", "\"></script>").Split('|');
                #endregion

                #region GET /Venda.UI.Web/Atendimento/Detail/92691925 HTTP/1.1
                LinhaErro = 5396;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/Detail/" + keys["externalId"], //+ keys["attendanceNumber"],
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));


                auxURL = response.Content.Substring(response.Content.IndexOf("var atendimentoViewModel = ") + 27);
                auxURL = auxURL.Substring(0, auxURL.LastIndexOf("}") + 1);

                dynamic atendimentoViewModel = JsonConvert.DeserializeObject(auxURL);
                #endregion

                #region POST /Venda.UI.Web/rb_33a41a92-bf71-4a55-a467-2755110f1449?type=js3&flavor=post&vi=HVIMBMMLOEKMEOAFEBHQUVCIFAHLVBJW-0&modifiedSince=1657347058020&rf=https%3A%2F%2Fportal.agiplan.com.br%2FVenda.UI.Web%2FAtendimento%2FEmbedded%2F2888d8a46b41665abd91407bea0d8908%2F%23%2FDetail%2F92691925&bp=3&app=a3174ac70aa0aab7&crc=1458136519&en=5vhk3ioo&end=1 HTTP/1.1
                LinhaErro = 5417;
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "text/plain;charset=UTF-8");

                strPost = "$a=1|1|_load_|_load_|-|1658373057393|1658373060553|dn|84|svtrg|1|svm|i1^sk0^sh0|tvtrg|1|tvm|i1^sk0^sh0|lr|https://agibank.force.com/," +
                          "2|9|_event_|1658373057393|_vc_|V|-1^pc|VCD|1048|VCDS|0|VCS|3217|VCO|4226|VCI|0|S|-1," +
                          "2|10|_event_|1658373057393|_wv_|lcpT|-5|fcp|-5|fp|1563|cls|0|lt|379," +
                          "2|2|this.options.templates[this.options.view] is not a function|_error_|-|1658373060511|1658373060511|dn|-1," +
                          "3|3|TypeError|_type_|-|1658373060512|1658373060512|dn|-1," +
                          "3|4|https://portal.agiplan.com.br/Venda.UI.Web/bundles/calendar?v=ie4e_Sdne6fn7XESD7_8j69oiWmPYqxooXp9WYkYTMY1^p1^p8912|_location_|-|1658373060513|1658373060513|dn|-1," +
                          "3|5|TypeError: this.options.templates[this.options.view] is not a function^p    at t._render (https://portal.agiplan.com.br/Venda.UI.Web/bundles/calendar?v=ie4e_Sdne6fn7XESD7_8j69oiWmPYqxooXp9WYkYTMY1:1:8912)^p    at t.view (https://portal.agiplan.com.br/Venda.UI.Web/bundles/calendar?v=ie4e_Sdne6fn7XESD7_8j69oiWmPYqxooXp9WYkYTMY1:1:13901)^p    at new t (https://portal.agiplan.com.br/Venda.UI.Web/bundles/calendar?v=ie4e_Sdne6fn7XESD7_8j69oiWmPYqxooXp9WYkYTMY1:1:4248)^p    at n.fn.calendar (https://portal.agiplan.com.br/Venda.UI.Web/bundles/calendar?v=ie4e_Sdne6fn7XESD7_8j69oiWmPYqxooXp9WYkYTMY1:1:22652)^p    at https://portal.agiplan.com.br/Venda.UI.Web/bundles/calendar?v=ie4e_Sdne6fn7XESD7_8j69oiWmPYqxooXp9WYkYTMY1:1:23333^p    at https://portal.agiplan.com.br/Venda.UI.Web/bundles/calendar?v=ie4e_Sdne6fn7XESD7_8j69oiWmPYqxooXp9WYkYTMY1:1:24533|_stack_|-|1658373060515|1658373060515|dn|-1," +
                          "3|6|2007|_ts_|-|1658373060517|1658373060517|dn|-1," +
                          "3|7|1|_source_|-|1658373060518|1658373060518|dn|-1," +
                          "2|8|_onload_|_load_|-|1658373060553|1658373060553|dn|84|svtrg|1|svm|i1^sk0^sh0|tvtrg|1|tvm|i1^sk0^sh0," +
                          "1|11|_event_|1658373057393|_view_|tvtrg|1|tvm|i1^sk0^sh0$rId=" + auxURLPost.Where(i => i.Contains("rid=")).FirstOrDefault().Substring(("rid=").Length) +
                          "$rpid=" + auxURLPost.Where(i => i.Contains("rpid=")).FirstOrDefault().Substring(("rpid=").Length) +
                          "$domR =1658373060549$tvn=" + keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')) + "$tvt=1658373057393$tvm=i1;k0;h0" +
                          "$tvtrg=1$w=2400$h=988$sw=1920$sh=1080$nt=a0b1658373057393e1f1g1h7i771j100k771l999m1000o3129p3129q3157r3157s3160t3160u14113v13813w13813M993141879V0$ni=4g|1.15$fd=j2.1.1^sg1.2.23$url=" +
                          keys["GevAtendimentoDetailSrcUrl"] +
                          "$title=Atendimento$app=a3174ac70aa0aab7$vi=HVIMBMMLOEKMEOAFEBHQUVCIFAHLVBJW-0$fId=573058503_340$v=10235220309135426$" +
                          "vID=1658373058508H893VUDUMHVI4QODF44IJT881IDAH547$nV=1$nVAT=1$time=1658373061688";

                //PEGAR AS INFORMAÇÕES DOS COOKIES ^^^^^^^^ 

                auxURL = auxURLPost.Where(i => i.Contains("reportUrl=")).FirstOrDefault().Substring(("reportUrl=").Length) + "?type=js3" +
                         "&flavor=post" +
                         "&vi=HVIMBMMLOEKMEOAFEBHQUVCIFAHLVBJW-0" +
                         "&modifiedSince=" + auxURLPost.Where(i => i.Contains("lastModification=")).FirstOrDefault().Substring(("lastModification=").Length) +
                         "&" + WebUtility.UrlEncode(keys["GevAtendimentoDetailSrcUrl"]) +
                         "&bp=" + auxURLPost.Where(i => i.Contains("bp=")).FirstOrDefault().Substring(("bp=").Length) +
                         "&app=" + auxURLPost.Where(i => i.Contains("app=")).FirstOrDefault().Substring(("app=").Length) +
                         "&crc=1458136519" +
                         "&en=" + auxURLPost.Where(i => i.Contains("cuc=")).FirstOrDefault().Substring(("cuc=").Length) +
                         "&end=1";

                response = DoPost(auxURL,
                           strPost,
                           headers: hdrs,
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')),
                           _accept: "*/*");
                #endregion

                #region GET /Venda.UI.Web/Atendimento/SomarPropostaAditivoDesconto?atendimentoCodigo=92691925 HTTP/1.1
                LinhaErro = 5464;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/SomarPropostaAditivoDesconto?atendimentoCodigo=" + keys["externalId"],
                           headers: hdrs,
                           _accept: "*/*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/GetHistoricoOcorrencias?cpfCnpj=31951228120 HTTP/1.1
                LinhaErro = 5480;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("X-Requested-With", "XMLHttpRequest");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/GetHistoricoOcorrencias?cpfCnpj=" + dadosCliente.Document,
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/GetHistoricoFatura?cpfCnpj=31951228120 HTTP/1.1
                LinhaErro = 5496;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/GetHistoricoFatura?cpfCnpj=" + dadosCliente.Document,
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/ObterCidadesDoEstado HTTP/1.1 HTTP/1.1
                LinhaErro = 5511;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/ObterCidadesDoEstado",
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/GetHistoricoProposta?cpf=31951228120 HTTP/1.1
                LinhaErro = 5526;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/GetHistoricoProposta?cpf=" + dadosCliente.Document,
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/ConsultarHistoricoSeguros?cpf=31951228120 HTTP/1.1
                LinhaErro = 5541;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/ConsultarHistoricoSeguros?cpf=" + dadosCliente.Document,
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/ConsultarHistoricoSeguros?cpf=31951228120 HTTP/1.1
                LinhaErro = 5556;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/ConsultarHistoricoSeguros?cpf=" + dadosCliente.Document,
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region POST /Venda.UI.Web/Atendimento/AtendimentoVerificaPontoAptoTelefonica HTTP/1.1
                LinhaErro = 5571;
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");

                response = DoPost("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/AtendimentoVerificaPontoAptoTelefonica",
                                  "",
                                  headers: hdrs,
                                  _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')),
                                  _accept: "application/json, text/plain, */*");
                #endregion

                #region POST /Venda.UI.Web/Atendimento/VerificarAtendimentoFinalizado HTTP/1.1
                LinhaErro = 5586;
                hdrs = new Dictionary<string, string>();
                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");

                strPost = "{\"atendimentoCodigo\":" + keys["externalId"] + "}";

                response = DoPost("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/VerificarAtendimentoFinalizado",
                           strPost,
                           headers: hdrs,
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')),
                           _accept: "application/json, text/plain, */*");
                #endregion

                #region POST /Venda.UI.Web/Atendimento/SalvaDadosIdentificacao HTTP/1.1
                LinhaErro = 5604;
                SalvaDadosIdentificacaoRequest salvaDados = new SalvaDadosIdentificacaoRequest()
                {
                    DataNascimentoString = DateTime.Parse(dadosCliente.Birthday).ToString("dd/MM/yyyy"),
                    Confirma = true,
                    Etapa = 2,
                    AtendimentoCliente = new SalvaDadosIdentificacaoRequestAtendimentoCliente()
                };

                try
                {
                    //if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].regraPagamentoCodigo == null)
                    //    atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].regraPagamentoCodigo = 2033;

                    salvaDados.AtendimentoCliente.AtendimentoClienteCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoClienteCodigo; //ok

                    salvaDados.AtendimentoCliente.AtendimentoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].atendimentoCodigo;//ok
                    salvaDados.AtendimentoCliente.RegraPagamentoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].regraPagamentoCodigo;
                    salvaDados.AtendimentoCliente.CpfCnpj = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].cpfCnpj;//ok
                    salvaDados.AtendimentoCliente.Nome = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].nome;//ok
                    salvaDados.AtendimentoCliente.DataNascimento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataNascimento.ToString("yyyy-MM-dd") + "T00:00:00";
                    salvaDados.AtendimentoCliente.DataNascimentoString = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].dataNascimentoString;
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
                    salvaDados.AtendimentoCliente.AtendimentoClienteTestemunhaList = new List<object>();

                    //if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial != null)
                    //{
                    //    salvaDados.AtendimentoCliente.EnderecoResidencial = new AtendimentoClienteEndereco()
                    //    {
                    //        AtendimentoClienteEnderecoCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.atendimentoClienteEnderecoCodigo,
                    //        AtendimentoClienteCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.atendimentoClienteCodigo,
                    //        Cep = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.cep,
                    //        EstadoUf = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.estadoUF,
                    //        CidadeCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.cidadeCodigo,
                    //        BairroCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.bairroCodigo,
                    //        OutroBairroDescricao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.outroBairroDescricao,
                    //        TipoLogradouroCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoLogradouroCodigo,
                    //        Logradouro = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.logradouro,
                    //        Numero = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.numero,
                    //        SemNumero = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.semNumero,
                    //        Complemento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.complemento,
                    //        TipoResidenciaCodigo = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoResidenciaCodigo,
                    //        ValorParcelaFinanciamento = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.valorParcelaFinanciamento,
                    //        ValorParcelaFinanciamentoString = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.valorParcelaFinanciamentoString,
                    //        TipoEndereco = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoEndereco,
                    //        //AtendimentoCliente = new AtendimentoClienteEnderecoAtendimentoCliente() { },
                    //        TemDados = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.temDados,
                    //        EstadoUfDescricao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.estadoUfDescricao,
                    //        CidadeNome = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.cidadeNome,
                    //        BairroNome = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.bairroNome,
                    //        TipoLogradouroDescricao = atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteList[0].enderecoResidencial.tipoLogradouroDescricao
                    //    };
                    //}

                    if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteEnderecoList != null)
                    {
                        salvaDados.AtendimentoCliente.AtendimentoClienteEnderecoList = new List<AtendimentoClienteEndereco>() { };
                        foreach (var ende in atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteEnderecoList)
                        {
                            salvaDados.AtendimentoCliente.AtendimentoClienteEnderecoList.Add(new AtendimentoClienteEndereco()
                            {
                                AtendimentoClienteEnderecoCodigo = ende.atendimentoClienteEnderecoCodigo,
                                AtendimentoClienteCodigo = ende.atendimentoClienteCodigo,
                                Cep = ende.cep,
                                EstadoUf = ende.estadoUF,
                                CidadeCodigo = ende.cidadeCodigo,
                                BairroCodigo = ende.bairroCodigo,
                                OutroBairroDescricao = ende.outroBairroDescricao,
                                TipoLogradouroCodigo = ende.tipoLogradouroCodigo,
                                Logradouro = ende.logradouro,
                                Numero = ende.numero,
                                SemNumero = ende.semNumero,
                                Complemento = ende.complemento,
                                TipoResidenciaCodigo = ende.tipoResidenciaCodigo,
                                ValorParcelaFinanciamento = ende.valorParcelaFinanciamento,
                                ValorParcelaFinanciamentoString = ende.valorParcelaFinanciamentoString,
                                TipoEndereco = ende.tipoEndereco,
                                AtendimentoCliente = ende.atendimentoCliente,
                                TemDados = ende.temDados,
                                EstadoUfDescricao = ende.estadoUfDescricao,
                                CidadeNome = ende.cidadeNome,
                                BairroNome = ende.bairroNome,
                                TipoLogradouroDescricao = ende.tipoLogradouroDescricao
                            });
                        }
                    }

                    if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteTelefoneList != null)
                    {
                        salvaDados.AtendimentoCliente.AtendimentoClienteTelefoneList = new List<AtendimentoClienteTelefoneList>() { };

                        foreach (var tel in atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteTelefoneList)
                        {
                            salvaDados.AtendimentoCliente.AtendimentoClienteTelefoneList.Add(new AtendimentoClienteTelefoneList()
                            {
                                AtendimentoClienteTelefoneCodigo = tel.atendimentoClienteTelefoneCodigo,
                                AtendimentoClienteCodigo = tel.atendimentoClienteCodigo,
                                TipoTelefoneCodigo = tel.tipoTelefoneCodigo,
                                Ddd = tel.ddd,
                                Numero = tel.numero,
                                Ramal = tel.ramal,
                                Classificacao = tel.classificacao,
                                Ativo = tel.ativo,
                                TipoTelefone = new AtendimentoClienteTelefoneListTipoTelefone()
                                {
                                    TipoTelefoneCodigo = tel.tipoTelefone.tipoTelefoneCodigo,
                                    Nome = tel.tipoTelefone.nome,
                                    Situacao = tel.tipoTelefone.situacao,
                                    Validar = tel.tipoTelefone.validar,
                                    TelefoneFaixaList = tel.tipoTelefone.telefoneFaixaList,
                                    DataCriacao = tel.tipoTelefone.dataCriacao,
                                    DataAtualizacao = tel.tipoTelefone.dataAtualizacao,
                                    UsuarioProprietario = tel.tipoTelefone.usuarioProprietario,
                                    GrupoProprietario = tel.tipoTelefone.grupoProprietario,
                                },
                                AtendimentoCliente = tel.atendimentoCliente,
                                Principal = tel.principal,
                                Origem = tel.origem,
                                RestricaoCodigo = tel.restricaoCodigo,
                                Oculto = tel.oculto,
                                StatusValidacao = tel.statusValidacao,
                                DataHoraAtualizacao = tel.dataHoraAtualizacao,
                            });
                        }
                    }

                    if (atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteReferenciaList != null)
                    {
                        salvaDados.AtendimentoCliente.AtendimentoClienteReferenciaList = new List<AtendimentoClienteReferenciaList>() { };

                        foreach (var refe in atendimentoViewModel.atendimentoModel.atendimento.atendimentoClienteReferenciaList)
                        {
                            salvaDados.AtendimentoCliente.AtendimentoClienteReferenciaList.Add(new AtendimentoClienteReferenciaList()
                            {
                                AtendimentoClienteReferenciaCodigo = refe.atendimentoClienteReferenciaCodigo,
                                AtendimentoClienteCodigo = refe.atendimentoClienteCodigo,
                                Nome = refe.nome,
                                GrauRelacionamentoCodigo = refe.grauRelacionamentoCodigo,
                                TipoTelefoneCodigo = refe.tipoTelefoneCodigo,
                                Ddd = refe.ddd,
                                Numero = refe.numero,
                                AtendimentoCliente = refe.atendimentoCliente,
                            });
                        }
                    }

                    if (atendimentoViewModel.atendimentoModel.atendimentoClienteEndereco != null)
                    {
                        salvaDados.AtendimentoCliente.AtendimentoClienteEndereco = new AtendimentoClienteEndereco()
                        {
                            AtendimentoClienteEnderecoCodigo = atendimentoViewModel.atendimentoModel.atendimentoClienteEnderecoCodigo,
                            AtendimentoClienteCodigo = atendimentoViewModel.atendimentoModel.atendimentoClienteCodigo,
                            Cep = atendimentoViewModel.atendimentoModel.cep,
                            EstadoUf = atendimentoViewModel.atendimentoModel.estadoUF,
                            CidadeCodigo = atendimentoViewModel.atendimentoModel.cidadeCodigo,
                            BairroCodigo = atendimentoViewModel.atendimentoModel.bairroCodigo,
                            OutroBairroDescricao = atendimentoViewModel.atendimentoModel.outroBairroDescricao,
                            TipoLogradouroCodigo = atendimentoViewModel.atendimentoModel.tipoLogradouroCodigo,
                            Logradouro = atendimentoViewModel.atendimentoModel.logradouro,
                            Numero = atendimentoViewModel.atendimentoModel.numero,
                            SemNumero = atendimentoViewModel.atendimentoModel.semNumero,
                            Complemento = atendimentoViewModel.atendimentoModel.complemento,
                            TipoResidenciaCodigo = atendimentoViewModel.atendimentoModel.tipoResidenciaCodigo,
                            ValorParcelaFinanciamento = atendimentoViewModel.atendimentoModel.valorParcelaFinanciamento,
                            ValorParcelaFinanciamentoString = atendimentoViewModel.atendimentoModel.valorParcelaFinanciamentoString,
                            TipoEndereco = atendimentoViewModel.atendimentoModel.tipoEndereco,
                            AtendimentoCliente = atendimentoViewModel.atendimentoModel.atendimentoCliente,
                            TemDados = atendimentoViewModel.atendimentoModel.temDados,
                            EstadoUfDescricao = atendimentoViewModel.atendimentoModel.estadoUfDescricao,
                            CidadeNome = atendimentoViewModel.atendimentoModel.cidadeNome,
                            BairroNome = atendimentoViewModel.atendimentoModel.bairroNome,
                            TipoLogradouroDescricao = atendimentoViewModel.atendimentoModel.tipoLogradouroDescricao,
                        };
                    }
                }
                catch (Exception ex)
                {
                    var x = ex;
                }


                strPost = JsonConvert.SerializeObject(salvaDados);

                //strPost = strPost.Replace("\"erroList\":null", "\"erroList\":[]");
                //strPost = strPost.Replace("\"referenciaList\":null", "\"referenciaList\":[]");
                //strPost = strPost.Replace("\"contratoHistoricoList\":null", "\"contratoHistoricoList\":[]");
                //strPost = strPost.Replace("\"atendimentoClienteEmailList\":null", "\"atendimentoClienteEmailList\":[]");
                //strPost = strPost.Replace("\"atendimentoClienteTelefoneList\":null", "\"atendimentoClienteTelefoneList\":[]");
                //strPost = strPost.Replace("\"atendimentoClienteTestemunhaList\":null", "\"atendimentoClienteTestemunhaList\":[]");

                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");

                try
                {
                    response = DoPost("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/SalvaDadosIdentificacao",
                                      strPost,
                                      headers: hdrs,
                                      _accept: "application/json, text/plain, */*",
                                      _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                      _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                }
                catch (Exception ex)
                {
                    var teste = ex;
                }

                #endregion

                #region GET /Venda.UI.Web/Atendimento/BuscarMensagemCartoes?cpfCnpj=31951228120 HTTP/1.1
                LinhaErro = 5874;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/BuscarMensagemCartoes?cpfCnpj=" + dadosCliente.Document,
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/ObterMensagemMaisDeUmaContaAgibank?atendimentoCodigo=92691925&cpfCnpj=31951228120 HTTP/1.1
                LinhaErro = 5889;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/ObterMensagemMaisDeUmaContaAgibank?atendimentoCodigo=" + keys["externalId"] + "&cpfCnpj=" + dadosCliente.Document,
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                #endregion

                #region GET /Venda.UI.Web/Atendimento/ObterUltimaOperacao?atendimentoCodigo=92691925&atualizar=false HTTP/1.1
                LinhaErro = 5904;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");

                response = DoGet("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/ObterUltimaOperacao?atendimentoCodigo=" + keys["externalId"] + "&atualizar=false",
                           headers: hdrs,
                           _accept: "application/json, text/plain, */*",
                           _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.63 Safari/537.36 Edg/102.0.1245.33",
                           _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));
                dynamic ultOp = JsonConvert.DeserializeObject(response.Content);

                #endregion

                #region POST 18
                LinhaErro = 5921;
                hdrs = new Dictionary<string, string>();

                hdrs.Add("Accept-Encoding", "gzip, deflate, br");
                hdrs.Add("Accept-Language", "pt-BR,pt;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
                hdrs.Add("Host", "portal.agiplan.com.br");
                hdrs.Add("Origin", "https://portal.agiplan.com.br");
                hdrs.Add("Content-Type", "application/json;charset=UTF-8");

                #region MONTA POST
                JSONObjects.SimularRequest SimularRequestContext = new SimularRequest()
                {
                    Cpf = dadosCliente.Document,
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

                response = DoPost("https://portal.agiplan.com.br/Venda.UI.Web/Atendimento/Simular",
                                JsonConvert.SerializeObject(SimularRequestContext),
                                 headers: hdrs,
                                 _accept: "application/json, text/plain, */*",
                                 _userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36 Edg/103.0.1264.37",
                                 _referer: keys["GevAtendimentoDetailSrcUrl"].Substring(0, keys["GevAtendimentoDetailSrcUrl"].IndexOf('#')));

                if (response.Headers.Where(h => h.Name == "x-mensageerror").Count() > 0)
                {
                    erro = response.Headers.Where(h => h.Name == "x-mensageerror").FirstOrDefault().Value.ToString();
                    return retornoDadosCliente;
                }

                var simular = JsonConvert.DeserializeObject<SimularResponse>(response.Content);

                if (simular.Data.ErroList != null && simular.Data.ErroList.Count > 0)
                {
                    erro = String.Join(" | ", simular.Data.ErroList);
                    return retornoDadosCliente;
                }

                var auxProdutos = response.Content.Substring(response.Content.IndexOf("\"produtoList\":") + 14);
                auxProdutos = auxProdutos.Substring(0, auxProdutos.IndexOf("\"produtoRemovidoList"));
                auxProdutos = auxProdutos.Substring(0, auxProdutos.LastIndexOf("],") + 1);

                List<ProdutoResponse> produtos = JsonConvert.DeserializeObject<List<ProdutoResponse>>(auxProdutos);
                retornoDadosCliente.Produtos = produtos.ToList();
                #endregion

            }
            catch (Exception ex)
            {
                erro = "Simular " + LinhaErro.ToString() + " - " + ex.Message;
                if (ex.InnerException != null)
                    erro += " - " + ex.InnerException.Message;
            }

            return retornoDadosCliente;
        }

        #region WEBREQUEST
        public async Task<HttpResponseMessage> DoGetTask(string url, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null, CookieCollection cookies = null)
        {
            HttpClient httpClient = new HttpClient();

            foreach (var h in headers)
                httpClient.DefaultRequestHeaders.Add(h.Key, h.Value);

            if (_accept != "" && _accept != accept)
                httpClient.DefaultRequestHeaders.Add("Accept", _accept);

            if (_referer != "" && _referer != referer)
                httpClient.DefaultRequestHeaders.Add("Referer", _referer);

            if (keepAlive)
                httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");

            httpClient.DefaultRequestHeaders.Add("User-Agent", _userAgent);


            var responseString = await httpClient.GetAsync(url);

            return responseString;
        }

        private RestResponse DoGet(string url, string _accept = "", string _userAgent = "", string _referer = "", bool keepAlive = true, Dictionary<string, string> headers = null, CookieCollection cookies = null)
        {
            UpdateHeaders(_userAgent);

            var rqst = new RestRequest(url);

            if (_accept != "" && _accept != accept)
                rqst.AddOrUpdateHeader("Accept", _accept);

            if (_referer != "" && _referer != referer)
                rqst.AddOrUpdateHeader("Referer", _referer);

            //rqst.AddOrUpdateHeader("KeepAlive", keepAlive);
            if (keepAlive)
                rqst.AddOrUpdateHeader("Connection", "keep-alive");

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

            //rqst.AddOrUpdateHeader("KeepAlive", keepAlive);
            if (keepAlive)
                rqst.AddOrUpdateHeader("Connection", "keep-alive");

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
                //byte[] toBytes = System.Text.Encoding.ASCII.GetBytes(body);

                //using (var client = new System.Net.WebClient())
                //{
                //    if (_accept != "" && _accept != accept)
                //        client.Headers.Add("Accept", _accept);

                //    if (_referer != "" && _referer != referer)
                //        client.Headers.Add("Referer", _referer);

                //    //////if (keepAlive)
                //    //////   client.Headers.Add("Connection", "keep-alive");

                //    client.Headers.Add("User-Agent", userAgent);

                //    if (headers != null)
                //        foreach (var h in headers)
                //            client.Headers.Add(h.Key, h.Value);

                //    return System.Text.Encoding.ASCII.GetString(client.UploadData(url, "PUT", toBytes));
                //}

                UpdateHeaders(_userAgent);

                var rqst = new RestRequest(url);

                if (_accept != "" && _accept != accept)
                    rqst.AddOrUpdateHeader("Accept", _accept);

                if (_referer != "" && _referer != referer)
                    rqst.AddOrUpdateHeader("Referer", _referer);

                //rqst.AddOrUpdateHeader("KeepAlive", keepAlive);
                if (keepAlive)
                    rqst.AddOrUpdateHeader("Connection", "keep-alive");

                rqst.AddOrUpdateHeader("User-Agent", userAgent);

                if (headers != null)
                    foreach (var h in headers)
                        rqst.AddOrUpdateHeader(h.Key, h.Value);

                rqst.AddBody(body);

                return Put(rqst).Content;
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

                //if (keepAlive)
                //    client.Headers.Add("Connection", "keep-alive");

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

                    if (keepAlive)
                        client.Headers.Add("Connection", "keep-alive");

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

        private string RetornaAuxSubstring(string textAux, string strBegin, string strEnd)
        {
            var aux = textAux.Substring(textAux.IndexOf(strBegin) + strBegin.Length);
            aux = aux.Substring(0, aux.IndexOf(strEnd));
            return aux;
        }

        #endregion
    }
}
