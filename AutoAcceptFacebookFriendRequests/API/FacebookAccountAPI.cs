using System.Net;
using AutoAcceptFacebookFriendRequests.API.Model;
using System.Text.RegularExpressions;
using AutoAcceptFacebookFriendRequests.API.Exeptions;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace AutoAcceptFacebookFriendRequests.API
{
    public class FacebookAccountAPI : IDisposable
    {
        public string Cookie { get; }
        public string UserAgent { get; }

        private HttpClient _http;
        private HttpClientHandler _httpHandler;
        private bool _disposed = false;

        private const string GRAPHQL_URL = "https://www.facebook.com/api/graphql/";

        public FacebookAccountAPI(string cookie, string userAgent, string proxy)
        {
            Cookie = cookie;
            UserAgent = userAgent;

            string[] parts = proxy.Split(':');
            string proxyHost = parts[0];
            string proxyPort = parts[1];
            string proxyUsername = parts[2];
            string proxyPassword = parts[3];

            _httpHandler = new HttpClientHandler();
            _httpHandler.CookieContainer = new CookieContainer();
            _httpHandler.Proxy = new WebProxy($"http://{proxyHost}:{proxyPort}");
            _httpHandler.UseProxy = true;
            _httpHandler.DefaultProxyCredentials = new NetworkCredential(proxyUsername, proxyPassword);

            _http = new HttpClient(_httpHandler, true);
            _http.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            foreach (Cookie item in ParseCookieString(cookie))
                _httpHandler.CookieContainer.Add(item);
        }

        public async Task<bool> AcceptFriendRequest(FriendInfo info)
        {
            string dtsg = await GetDTSG("https://www.facebook.com/friends/requests");
            string actorId = GetActorId();

            string variables = JsonSerializer.Serialize(new
            {
                input = new
                {
                    friend_requester_id = info.Id,
                    source = "friends_tab",
                    actor_id = actorId,
                    client_mutation_id = "1"
                },
                scale = 1,
                refresh_num = 0
            });

            FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "variables", variables },
                { "fb_dtsg", dtsg },
                { "doc_id", "6862059640492684" }
            });


            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GRAPHQL_URL))
            {
                request.Headers.Add("Sec-Fetch-Site", "same-origin");
                request.Content = content;

                using (HttpResponseMessage response = await _http.SendAsync(request))
                {
                    string responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent.Substring(0, 100));
                }
            }

            return true;
        }

        public async Task<List<FriendInfo>> GetFriendRequests()
        {
            List<FriendInfo> friends = new List<FriendInfo>();

            string dtsg = await GetDTSG("https://www.facebook.com/friends/requests");

            FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "variables", "{\"scale\":1}" },
                { "fb_dtsg", dtsg },
                { "doc_id", "4851458921570237" }
            });

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GRAPHQL_URL))
            {
                request.Headers.Add("Sec-Fetch-Site", "same-origin");
                request.Content = content;

                using (HttpResponseMessage response = await _http.SendAsync(request))
                {
                    string responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                    JObject responseObject = JObject.Parse(responseContent);

                    JArray friendRequests = JArray.Parse(responseObject["data"]!["viewer"]!["friending_possibilities"]!["edges"]!.ToString());

                    foreach (JToken item in friendRequests)
                    {
                        JToken node = item["node"]!;

                        string id = node["id"]!.ToString();
                        string name = node["name"]!.ToString();

                        friends.Add(new FriendInfo(id, name));
                    }
                }
            }

            return friends;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _http.Dispose();
                }

                _disposed = true;
            }
        }

        async Task<string> GetDTSG(string url)
        {
            using (HttpResponseMessage response = await _http.GetAsync(url))
            {
                string responseContent = await EnsureNoCheckpoint(response).Content.ReadAsStringAsync();

                Match match = Regex.Match(responseContent, "\\[\"DTSGInitialData\",\\[],{\"token\":\"(.*?)\"},\\d+]");
                if (!match.Success)
                    throw new InvalidCookie();

                return match.Groups[1].Value;
            }
        }

        string GetActorId()
        {
            Dictionary<string, string> cookies = _httpHandler.CookieContainer
                .GetAllCookies()
                .ToDictionary(cookie => cookie.Name, cookie => cookie.Value);

            if (!cookies.ContainsKey("c_user"))
                throw new InvalidCookie();

            return cookies["c_user"];
        }

        HttpResponseMessage EnsureNoCheckpoint(HttpResponseMessage response)
        {
            string responseUrl = response.EnsureSuccessStatusCode().RequestMessage!.RequestUri!.OriginalString;

            if (responseUrl.Contains("checkpoint"))
                throw new AccountCheckpointed(responseUrl);

            return response;
        }

        IEnumerable<Cookie> ParseCookieString(string cookieString)
        {
            string[] cookiePairs = cookieString.Split(';');
            foreach (string cookiePair in cookiePairs)
            {
                string[] keyValue = cookiePair.Trim().Split('=');
                if (keyValue.Length != 2)
                    continue;

                string key = keyValue[0];
                string value = keyValue[1];

                yield return new Cookie(key, value, "/", ".facebook.com");
            }
        }
    }
}
