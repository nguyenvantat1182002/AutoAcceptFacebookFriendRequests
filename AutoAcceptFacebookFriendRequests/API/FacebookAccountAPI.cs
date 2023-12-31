﻿using System.Net;
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
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(30);

        private bool _disposed = false;

        private const string GRAPHQL_URL = "https://www.facebook.com/api/graphql/";

        public FacebookAccountAPI(string cookie, string userAgent, string proxy)
        {
            Cookie = cookie;
            UserAgent = userAgent;
            State = new AccountState();

            string[] parts = proxy.Split(':');
            string proxyHost = parts[0];
            string proxyPort = parts[1];
            string proxyUsername = parts[2];
            string proxyPassword = parts[3];

            _httpHandler = new HttpClientHandler();
            _httpHandler.CookieContainer = new CookieContainer();
            _httpHandler.Proxy = new WebProxy($"http://{proxyHost}:{proxyPort}");
            _httpHandler.DefaultProxyCredentials = new NetworkCredential(proxyUsername, proxyPassword);

            _http = new HttpClient(_httpHandler, true);
            _http.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            _http.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");

            foreach (Cookie item in ParseCookieString(cookie))
                _httpHandler.CookieContainer.Add(item);
        }

        public async Task CreatePost(string message, string link)
        {
            string dtsg = await GetDTSG("https://www.facebook.com/");
            string userId = GetActorId();

            string? shareScrapeData = await GetShareScrapeData(link, dtsg);
            if (shareScrapeData == null)
                return;

            List<string> emptyList = new List<string>();
            List<object> attachments = new List<object>();

            attachments.Add(new
            {
                link = new
                {
                    share_scrape_data = shareScrapeData,
                }
            });

            string variables = JsonSerializer.Serialize(new
            {
                input = new
                {
                    composer_entry_point = "inline_composer",
                    composer_source_surface = "newsfeed",
                    composer_type = "feed",
                    idempotence_token = Guid.NewGuid() + "_FEED",
                    source = "WWW",
                    audience = new
                    {
                        privacy = new
                        {
                            allow = emptyList,
                            base_state = "EVERYONE",
                            deny = emptyList,
                            tag_expansion_state = "UNSPECIFIED"
                        }
                    },
                    message = new
                    {
                        ranges = emptyList,
                        text = message
                    },
                    attachments = attachments,
                    actor_id = userId,
                    client_mutation_id = "1"
                }
            });

            await RequestAPI(dtsg, variables, "24475754388740032");
        }

        private async Task<string?> GetShareScrapeData(string link, string dtsg)
        {
            string? nullstr = null;
            string variables = JsonSerializer.Serialize(new
            {
                feedLocation = "FEED_COMPOSER",
                focusCommentID = nullstr,
                goodwillCampaignId = "",
                goodwillCampaignMediaIds = new List<string>(),
                goodwillContentType = nullstr,
                ___params = new
                {
                    url = link
                },
                privacySelectorRenderLocation = "COMET_COMPOSER",
                renderLocation = "composer_preview",
                parentStoryID = nullstr,
                scale = 1,
                useDefaultActor = false,
                shouldIncludeStoryAttachment = false,
            });
            variables = variables.Replace("___params", "params");

            string responseContent = await RequestAPI(dtsg, variables, "7051327781650639");
            JObject responseObject = JObject.Parse(responseContent);
            JToken? data = responseObject["data"];
            JToken? linkPreview = data?["link_preview"];
            JToken? shareScrapeData = linkPreview?["share_scrape_data"];

            return shareScrapeData == null ? null : shareScrapeData.ToString();
        }

        public async Task<bool> DownloadCover()
        {
            string userId = GetActorId();

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://www.facebook.com/{userId}"))
            {
                request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
                request.Headers.Add("Sec-Fetch-Site", "same-origin");

                using (HttpResponseMessage response = await HttpSend(request))
                {
                    string responseContent = await EnsureNoCheckpoint(response).Content.ReadAsStringAsync();
                    Match imageMatch = Regex.Match(responseContent, "\"photo\":{\"id\":\"\\d+\",\"image\":{\"uri\":\"(.*?)\".*}");

                    string imageLink = imageMatch.Groups[1].Value.Replace("\\", "");
                    if (string.IsNullOrWhiteSpace(imageLink))
                        return false;

                    CancellationToken token = CreateCancellationToken();
                    byte[] imageBytes = await _http.GetByteArrayAsync(imageLink, token);
                    string outputPath = $"{Directory.GetCurrentDirectory()}\\covers\\cover_{userId}.png";
                    File.WriteAllBytes(outputPath, imageBytes);
                }
            }

            return true;
        }

        public string ExportCookies()
        {
            CookieCollection cookies = _httpHandler.CookieContainer.GetAllCookies();
            string cookie = string.Empty;

            foreach (Cookie item in cookies)
                cookie += $"{item.Name}={item.Value};";

            return cookie;
        }

        public async IAsyncEnumerable<FriendInfo> GetGroupNewMenbers(string groupId, int maxMembers = 30)
        {
            groupId = await GetRealGroupID(groupId);

            string dtsg = await GetDTSG($"https://www.facebook.com/groups/{groupId}");

            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
            values.Add("count", 10);
            values.Add("groupID", groupId);
            values.Add("recruitingGroupFilterNonCompliant", false);
            values.Add("scale", 1);
            values.Add("id", groupId);

            int members = 0;

            bool hasNextPage = true;

            while (hasNextPage)
            {
                if (members >= maxMembers)
                    break;

                DateTime startTime = DateTime.Now;

                string variables = Newtonsoft.Json.JsonConvert.SerializeObject(values);
                string responseContent = await RequestAPI(dtsg, variables, "6621621524622624");

                JObject responseObject = JObject.Parse(responseContent);

                JToken newMenbers = responseObject["data"]!["node"]!["new_members"]!;
                JToken pageInfo = newMenbers["page_info"]!;

                JArray menber = (JArray)newMenbers["edges"]!;
                hasNextPage = Convert.ToBoolean(pageInfo["has_next_page"]!);

                if (hasNextPage)
                {
                    if (!values.ContainsKey("cursor"))
                        values.Add("cursor", "");
                    values["cursor"] = pageInfo["end_cursor"]!.ToString();
                }

                foreach (JToken item in menber)
                {
                    if (members >= maxMembers)
                        break;

                    JToken node = item["node"]!;

                    string id = node["id"]!.ToString();
                    string name = node["name"]!.ToString();

                    members++;

                    yield return new FriendInfo(id, name);
                }

                await Task.Delay((int)(DateTime.Now - startTime).TotalMilliseconds);
            }
        }

        public async Task<bool> DeletePost(PostInfo info)
        {
            string dtsg = await GetDTSG($"https://www.facebook.com/{info.Id}");
            string actorId = GetActorId();
            string _null = null!;
            string variables = JsonSerializer.Serialize(new
            {
                input = new
                {
                    story_id = info.Hash,
                    story_location = "TIMELINE",
                    actor_id = actorId,
                    client_mutation_id = 1
                },
                groupID = _null,
                inviteShortLinkKey = _null,
                renderLocation = _null,
                scale = 1
            });
            string responseContent = await RequestAPI(dtsg, variables, "6103177226450446");
            Console.WriteLine(responseContent);

            return true;
        }

        public async Task<PostInfo?> GetPost()
        {
            string dtsg = await GetDTSG($"https://www.facebook.com/profile.php");
            string actorId = GetActorId();
            string _null = null!;

            string variables = JsonSerializer.Serialize(new
            {
                count = 3,
                feedLocation = "TIMELINE",
                feedbackSource = 0,
                focusCommentID = _null,
                memorializedSplitTimeFilter = _null,
                omitPinnedPost = true,
                postedBy = _null,
                privacy = _null,
                privacySelectorRenderLocation = "COMET_STREAM",
                renderLocation = "timeline",
                scale = 1,
                stream_count = 1,
                taggedInOnly = _null,
                useDefaultActor = false,
                id = actorId,
            });

            string responseContent = await RequestAPI(dtsg, variables, "7193989197280434");
            string[] items = responseContent.Split('\n');

            JObject responseObject = JObject.Parse(items[0]);

            JArray? posts = (JArray)responseObject["data"]?["node"]?["timeline_list_feed_units"]?["edges"]!;
            if (posts == null || posts.Count < 1)
                return null;

            JToken post = posts![0]!["node"]!;

            string postId = post["post_id"]!.ToString();
            string hash = post["id"]!.ToString();

            return new PostInfo(postId, hash);
        }

        public async Task<string?> GetLinkAttachment(string dtsg, string surl)
        {
            string id = null!;

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://m.facebook.com/share_preview/?surl={surl}"))
            {
                request.Headers.Add("Sec-Fetch-Site", "same-origin");
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "fb_dtsg", dtsg }
                });

                using (HttpResponseMessage response = await HttpSend(request))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    content = content.Replace("for (;;);", "");

                    JObject data = JObject.Parse(content);
                    JToken? action = data["payload"]?["actions"]?[0];
                    if (action == null)
                        return null;

                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(action["html"]!.ToString());

                    HtmlAgilityPack.HtmlNode? _params = doc.DocumentNode.SelectSingleNode(".//input[@name=\"attachment[params][0]\"]");
                    HtmlAgilityPack.HtmlNode type = doc.DocumentNode.SelectSingleNode(".//input[@name=\"attachment[type]\"]");

                    id = $"{_params.Attributes["value"].Value}|{type.Attributes["value"].Value}";
                }
            }

            return id;
        }

        //public async Task CreatePost(string status, string link)
        //{
        //    string dtsg = await GetDTSG("https://m.facebook.com/?soft=composer");
        //    string userId = GetActorId();
        //    string? id = await GetLinkAttachment(dtsg, link);
        //    if (id == null)
        //        return;

        //    string[] parts = id.Split("|");
        //    string attachmentParams = parts[0];
        //    string attachmentType = parts[1];

        //    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://m.facebook.com/a/home.php"))
        //    {
        //        request.Headers.Add("Sec-Fetch-Site", "same-origin");
        //        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        //        {
        //            { "fb_dtsg", dtsg },
        //            { "attachment[params][0]", attachmentParams },
        //            { "attachment[type]", attachmentType },
        //            { "target", userId },
        //            { "linkUrl", link },
        //            { "status", status },
        //            { "privacyx", "300645083384735" }
        //        });

        //        using (HttpResponseMessage response = await HttpSend(request)) { }
        //    }
        //}

        //public async Task<bool> CreatePost(string message)
        //{
        //    string responseContent;

        //    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://mbasic.facebook.com/"))
        //    {
        //        request.Headers.Add("Sec-Fetch-Site", "same-origin");
        //        request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");

        //        using (HttpResponseMessage response = await HttpSend(request))
        //            responseContent = await EnsureNoCheckpoint(response).Content.ReadAsStringAsync();
        //    }

        //    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        //    doc.LoadHtml(responseContent);

        //    HtmlAgilityPack.HtmlNode composerForm = doc.DocumentNode.SelectSingleNode(".//form[@id=\"mbasic-composer-form\"]");
        //    HtmlAgilityPack.HtmlNode? fb_dtsg = doc.DocumentNode.SelectSingleNode(".//input[@name=\"fb_dtsg\"]");
        //    HtmlAgilityPack.HtmlNode jazoest = doc.DocumentNode.SelectSingleNode(".//input[@name=\"jazoest\"]");
        //    //HtmlAgilityPack.HtmlNode privacyx = doc.DocumentNode.SelectSingleNode(".//input[@name=\"privacyx\"]");
        //    HtmlAgilityPack.HtmlNode c_src = doc.DocumentNode.SelectSingleNode(".//input[@name=\"c_src\"]");
        //    HtmlAgilityPack.HtmlNode target = doc.DocumentNode.SelectSingleNode(".//input[@name=\"target\"]");
        //    HtmlAgilityPack.HtmlNode cwevent = doc.DocumentNode.SelectSingleNode(".//input[@name=\"cwevent\"]");
        //    HtmlAgilityPack.HtmlNode referrer = doc.DocumentNode.SelectSingleNode(".//input[@name=\"referrer\"]");
        //    HtmlAgilityPack.HtmlNode cver = doc.DocumentNode.SelectSingleNode(".//input[@name=\"cver\"]");
        //    HtmlAgilityPack.HtmlNode view_post = doc.DocumentNode.SelectSingleNode(".//input[@name=\"view_post\"]");

        //    if (fb_dtsg == null)
        //        throw new InvalidCookie();

        //    FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
        //    {
        //        { "fb_dtsg", fb_dtsg.Attributes["value"].Value },
        //        { "jazoest", jazoest.Attributes["value"].Value },
        //        { "privacyx", "300645083384735" },
        //        //{ "privacyx", privacyx.Attributes["value"].Value },
        //        { "target", target.Attributes["value"].Value },
        //        { "c_src", c_src.Attributes["value"].Value },
        //        { "cwevent", cwevent.Attributes["value"].Value },
        //        { "referrer", referrer.Attributes["value"].Value },
        //        { "cver", cver.Attributes["value"].Value },
        //        { "xc_message", message },
        //        { "view_post", view_post.Attributes["value"].Value }
        //    });

        //    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://mbasic.facebook.com/{composerForm.Attributes["action"].Value}"))
        //    {
        //        request.Content = content;
        //        request.Headers.Add("Sec-Fetch-Site", "same-origin");

        //        using (HttpResponseMessage response = await HttpSend(request))
        //            responseContent = await EnsureNoCheckpoint(response).Content.ReadAsStringAsync();
        //    }

        //    return true;
        //}

        public async Task<List<FriendInfo>> GetSuggestedMembers(string groupId, int maxSuggestedMembers = 10)
        {
            string dtsg = await GetDTSG($"https://www.facebook.com/groups/{groupId}");

            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
            values.Add("count", 10);
            values.Add("name", null!);
            values.Add("scale", 1);
            values.Add("id", groupId);

            List<FriendInfo> friends = new List<FriendInfo>();

            bool hasNextPage = true;

            while (hasNextPage && friends.Count < maxSuggestedMembers)
            {
                DateTime startTime = DateTime.Now;

                string variables = Newtonsoft.Json.JsonConvert.SerializeObject(values);
                string responseContent = await RequestAPI(dtsg, variables, "6783565111701846");

                JObject responseObject = JObject.Parse(responseContent);

                JToken suggestedMembers = responseObject["data"]!["node"]!["suggested_members"]!;
                JToken pageInfo = suggestedMembers["page_info"]!;

                JArray menber = (JArray)suggestedMembers["edges"]!;
                hasNextPage = Convert.ToBoolean(pageInfo["has_next_page"]!);

                if (hasNextPage)
                {
                    if (!values.ContainsKey("after_cursor"))
                        values.Add("after_cursor", "");
                    values["after_cursor"] = pageInfo["end_cursor"]!.ToString();
                }

                foreach (JToken item in menber)
                {
                    if (friends.Count > maxSuggestedMembers)
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

        public async Task<string> GetRealGroupID(string groupId)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://www.facebook.com/groups/{groupId}"))
            {
                request.Headers.Add("Sec-Fetch-Site", "same-origin");
                request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");

                using (HttpResponseMessage response = await HttpSend(request))
                {
                    string responseContent = await EnsureNoCheckpoint(response).Content.ReadAsStringAsync();

                    Match match = Regex.Match(responseContent, "{\"__typename\":\"Group\",\"id\":\"(\\d+)\"}");
                    if (!match.Success)
                        throw new GroupIdNotFound(groupId);

                    return match.Groups[1].Value;
                }
            }
        }

        public async Task<bool> InviteFriendToGroup(string groupId, List<FriendInfo> friends)
        {
            string dtsg = await GetDTSG($"https://www.facebook.com/{groupId}");
            string actorId = GetActorId();

            List<string> friendIDs = friends.Select(item => item.Id).ToList();

            string variables = JsonSerializer.Serialize(new
            {
                input = new
                {
                    email_addresses = new string[] { },
                    group_id = groupId,
                    source = "comet_invite_friends",
                    user_ids = friendIDs,
                    actor_id = actorId,
                    client_mutation_id = "1",
                },
                groupID = groupId
            });

            string responseContent = await RequestAPI(dtsg, variables, "6628217590557977");
            Console.WriteLine(responseContent.Substring(0, 100));

            return true;
        }

        public async Task<bool> AddFriend(FriendInfo friend)
        {
            string dtsg = await GetDTSG($"https://www.facebook.com/{friend.Id}");
            string actorId = GetActorId();
            string variables = JsonSerializer.Serialize(new
            {
                input = new
                {
                    people_you_may_know_location = "netego",
                    refs = new string[] { null! },
                    source = "netego_pymk",
                    warn_ack_for_ids = new string[] { },
                    actor_id = actorId,
                    client_mutation_id = "1",
                    friend_requestee_ids = new string[] { friend.Id },
                },
                scale = 1
            });

            string responseContent = await RequestAPI(dtsg, variables, "6523509764398491");
            Console.WriteLine(responseContent.Substring(0, 100));

            return true;
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

        public async Task<string> GetFriendRequestData()
        {
            string dtsg = await GetDTSG("https://www.facebook.com/friends/requests");
            return await RequestAPI(dtsg, "{\"scale\":1}", "4851458921570237");
        }

        public int GetFriendRequestCount(string friendRequestData)
        {
            JObject responseObject = JObject.Parse(friendRequestData);
            return Convert.ToInt32(responseObject["data"]!["viewer"]!["friend_requests"]!["count"]!);
        }

        public List<FriendInfo> GetFriendRequests(string friendRequestData)
        {
            List<FriendInfo> friends = new List<FriendInfo>();

            JObject responseObject = JObject.Parse(friendRequestData);                                 
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
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Add("Sec-Fetch-Site", "same-origin");
                request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");

                using (HttpResponseMessage response = await HttpSend(request))
                {
                    string responseContent = await EnsureNoCheckpoint(response).Content.ReadAsStringAsync();

                    Match match = Regex.Match(responseContent, "\\[\"DTSGInitialData\",\\[],{\"token\":\"(.*?)\"},\\d+]");
                    if (!match.Success)
                    {
                        match = Regex.Match(responseContent, "name=\"fb_dtsg\" value=\"(.*?)\"");
                        if (match.Success)
                            return match.Groups[1].Value;

                        throw new InvalidCookie();

                    }

                    return match.Groups[1].Value;
                }
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

                using (HttpResponseMessage response = await HttpSend(request))
                    responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }

            return responseContent;
        }

        private CancellationToken CreateCancellationToken()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(_timeout);

            return cts.Token;
        }

        private async Task<HttpResponseMessage> HttpSend(HttpRequestMessage request)
        {
            CancellationToken token = CreateCancellationToken();
            return await _http.SendAsync(request, token);
        }
    }
}
