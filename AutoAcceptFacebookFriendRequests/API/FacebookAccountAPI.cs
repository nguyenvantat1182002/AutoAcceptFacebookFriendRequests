using System.Net;
using AutoAcceptFacebookFriendRequests.API.Model;
using System.Text.RegularExpressions;
using AutoAcceptFacebookFriendRequests.API.Exeptions;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using AutoAcceptFacebookFriendRequests.API.Models;

namespace AutoAcceptFacebookFriendRequests.API
{
    public class FacebookAccountAPI : IDisposable
    {
        public string Cookie { get; }
        public string UserAgent { get; }
        public AccountState State { get; }

        private readonly HttpClient _http;
        private readonly HttpClientHandler _httpHandler;

        private bool _disposed = false;

        private const string GRAPHQL_URL = "https://www.facebook.com/api/graphql/";

        public FacebookAccountAPI(string cookie, string userAgent, string proxy)
        {
            Cookie = cookie;
            UserAgent = userAgent;
            State = new AccountState();

            //string[] parts = proxy.Split(':');
            //string proxyHost = parts[0];
            //string proxyPort = parts[1];
            //string proxyUsername = parts[2];
            //string proxyPassword = parts[3];

            _httpHandler = new HttpClientHandler();
            _httpHandler.CookieContainer = new CookieContainer();
            //_httpHandler.Proxy = new WebProxy($"http://{proxyHost}:{proxyPort}");
            //_httpHandler.DefaultProxyCredentials = new NetworkCredential(proxyUsername, proxyPassword);

            _http = new HttpClient(_httpHandler, true);
            _http.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            foreach (Cookie item in ParseCookieString(cookie))
                _httpHandler.CookieContainer.Add(item);
        }

        public async Task<bool> Unfriend(FriendInfo friend)
        {
            string dtsg = await GetDTSG($"https://www.facebook.com/{friend.Id}");
            string actorId = GetActorId();
            string variables = JsonSerializer.Serialize(new
            {
                input = new
                {
                    source = "bd_profile_button",
                    unfriended_user_id = friend.Id,
                    actor_id = actorId,
                    client_mutation_id = "1"
                },
                scale = 1
            });

            string responseContent = await RequestAPI(dtsg, variables, "8752443744796374");
            Console.WriteLine(responseContent);

            return true;
        }

        public async Task<List<FriendInfo>> GetFriends(int maxFriends = 50)
        {
            List<FriendInfo> friends = new List<FriendInfo>();

            string dtsg = await GetDTSG("https://www.facebook.com/friends/list");

            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
            values.Add("count", 30);
            values.Add("name", null!);
            values.Add("scale", 1);

            bool hasNextPage = true;

            while (hasNextPage && friends.Count < maxFriends)
            {
                DateTime startTime = DateTime.Now;

                string variables = Newtonsoft.Json.JsonConvert.SerializeObject(values);
                string responseContent = await RequestAPI(dtsg, variables, "4854590387990555");

                JObject responseObject = JObject.Parse(responseContent);

                JToken allFriends = responseObject["data"]!["viewer"]!["all_friends"]!;
                JToken pageInfo = allFriends["page_info"]!;

                JArray suggestionFriends = (JArray)allFriends["edges"]!;
                hasNextPage = Convert.ToBoolean(pageInfo["has_next_page"]!);

                if (hasNextPage)
                {
                    if (!values.ContainsKey("cursor"))
                        values.Add("cursor", "");
                    values["cursor"] = pageInfo["end_cursor"]!.ToString();
                }

                foreach (JToken item in suggestionFriends)
                {
                    if (friends.Count > maxFriends)
                        break;

                    JToken node = item["node"]!;

                    string id = node["id"]!.ToString();
                    string name = node["name"]!.ToString();

                    friends.Add(new FriendInfo(id, name));
                }

                await Task.Delay((int)(DateTime.Now - startTime).TotalMilliseconds);
            }

            return friends;
        }

        public async Task<List<FriendInfo>> GetSuggestionFriends(int maxSuggestions = 30)
        {
            List<FriendInfo> friends = new List<FriendInfo>();

            string dtsg = await GetDTSG("https://www.facebook.com/friends/suggestions");
            
            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
            values.Add("count", 30);
            values.Add("location", "FRIENDS_CENTER");
            values.Add("scale", 1);

            bool hasNextPage = true;

            while (hasNextPage && friends.Count < maxSuggestions)
            {
                DateTime startTime = DateTime.Now;

                string variables = Newtonsoft.Json.JsonConvert.SerializeObject(values);
                string responseContent = await RequestAPI(dtsg, variables, "7426902770683771");
                
                JObject responseObject = JObject.Parse(responseContent);

                JToken peopleYouMayKnow = responseObject["data"]!["viewer"]!["people_you_may_know"]!;
                JToken pageInfo = peopleYouMayKnow["page_info"]!;

                JArray suggestionFriends = (JArray)peopleYouMayKnow["edges"]!;
                hasNextPage = Convert.ToBoolean(pageInfo["has_next_page"]!);

                if (hasNextPage)
                {
                    if (!values.ContainsKey("cursor"))
                        values.Add("cursor", "");
                    values["cursor"] = pageInfo["end_cursor"]!.ToString();
                }

                foreach (JToken item in suggestionFriends)
                {
                    if (friends.Count > maxSuggestions)
                        break;

                    JToken node = item["node"]!;

                    string id = node["id"]!.ToString();
                    string name = node["name"]!.ToString();

                    friends.Add(new FriendInfo(id, name));
                }

                await Task.Delay((int)(DateTime.Now - startTime).TotalMilliseconds);
            }
            
            return friends;
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

            string responseContent = await RequestAPI(dtsg, variables, "6862059640492684");
            Console.WriteLine(responseContent.Substring(0, 100));

            return true;
        }

        public async Task<List<FriendInfo>> GetFriendRequests()
        {
            List<FriendInfo> friends = new List<FriendInfo>();

            string dtsg = await GetDTSG("https://www.facebook.com/friends/requests");
            string responseContent = await RequestAPI(dtsg, "{\"scale\":1}", "4851458921570237");

            JObject responseObject = JObject.Parse(responseContent);

            JArray friendRequests = JArray.Parse(responseObject["data"]!["viewer"]!["friending_possibilities"]!["edges"]!.ToString());

            foreach (JToken item in friendRequests)
            {
                JToken node = item["node"]!;

                string id = node["id"]!.ToString();
                string name = node["name"]!.ToString();

                friends.Add(new FriendInfo(id, name));
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

        private async Task<string> RequestAPI(string dtsg, string variables, string docId)
        {
            string responseContent;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GRAPHQL_URL))
            {
                request.Headers.Add("Sec-Fetch-Site", "same-origin");
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "variables", variables },
                    { "fb_dtsg", dtsg },
                    { "doc_id", docId }
                });

                using (HttpResponseMessage response = await _http.SendAsync(request))
                    responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }

            return responseContent;
        }
    }
}
