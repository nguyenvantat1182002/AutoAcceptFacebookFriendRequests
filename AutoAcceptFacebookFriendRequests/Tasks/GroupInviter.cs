using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class GroupInviter : BaseTask
    {
        public GroupInviter(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
        {
            
        }

        public override async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < Input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Inviter);
                tasks.Add(task);

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        public async Task Inviter()
        {
            FacebookAccountAPI accountAPI = null!;
            Queue<string> groupList = new Queue<string>(Service.GetGroupIDs());

            bool nextAccount = true;

            int totalGroups = groupList.Count;
            int requestedCount = 0;
            int inviteCount = 0;

            while (true)
            {
                if (nextAccount)
                {
                    lock (LockObject)
                    {
                        if (Accounts.Count < 1)
                            break;

                        accountAPI = Accounts.Dequeue();
                    }

                    nextAccount = false;
                }

                try
                {
                    while (true)
                    {
                        if (groupList.Count < 1)
                            break;

                        string groupId;
                        lock (LockObject)
                            groupId = groupList.Dequeue();

                        string realGroupId = await accountAPI.GetRealGroupID(groupId);

                        while (inviteCount < Input.MaxInviteCounnt)
                        {
                            Queue<FriendInfo> menbers = new Queue<FriendInfo>(await accountAPI.GetSuggestedMembers(groupId));

                            if (menbers.Count < 1)
                            {
                                Service.UpdateCookieStatus(GridView, accountAPI, $"{groupList.Count}/{totalGroups} Không có gợi ý nào");
                                break;
                            }

                            long endTime = 0;

                            while (menbers.Count > 0)
                            {
                                FriendInfo suggestedMembers = menbers.Dequeue();

                                while (true)
                                {
                                    if (TimeUtils.GetTimestamp() > endTime)
                                        break;

                                    int remainningTime = (int)(endTime - TimeUtils.GetTimestamp());
                                    string formattedTime = TimeUtils.SecondsToFormattedTime(remainningTime);

                                    Service.UpdateCookieStatus(GridView, accountAPI, $"{groupList.Count}/{totalGroups} Sẽ tiếp tục sau {formattedTime}");

                                    await Task.Delay(1000, Token);
                                }

                                if (requestedCount >= Input.RateLimit)
                                {
                                    endTime = TimeUtils.GetTimestamp() + Input.RateLimitDuration;

                                    while (true)
                                    {
                                        if (TimeUtils.GetTimestamp() > endTime)
                                            break;

                                        int remainningTime = (int)(endTime - TimeUtils.GetTimestamp());
                                        string formattedTime = TimeUtils.SecondsToFormattedTime(remainningTime);

                                        Service.UpdateCookieStatus(GridView, accountAPI, $"{groupList.Count}/{totalGroups} Tạm dừng, sẽ tiếp tục sau {formattedTime}");

                                        await Task.Delay(1000, Token);
                                    }

                                    requestedCount = 0;
                                }

                                Service.UpdateCookieStatus(GridView, accountAPI, $"{groupList.Count}/{totalGroups} Mời {suggestedMembers.Name} vào nhóm {groupId}");
                                await accountAPI.InviteFriendToGroup(realGroupId, new List<FriendInfo> { suggestedMembers });

                                requestedCount++;
                                inviteCount++;

                                Service.UpdateRequest(GridView, accountAPI, inviteCount);

                                endTime = TimeUtils.GetTimestamp() + Input.Duration;
                            }
                        }
                    }

                    nextAccount = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    if (ex is TaskCanceledException || ex is InvalidCookie || ex is AccountCheckpointed)
                    {
                        if (ex is InvalidCookie)
                            accountAPI.State.IsInvalidCookie = true;

                        if (ex is AccountCheckpointed)
                        {
                            accountAPI.State.IsCheckpointed = true;
                            Service.UpdateCookieStatus(GridView, accountAPI, ex.Message);
                        }

                        break;
                    }
                    else
                        Service.UpdateCookieStatus(GridView, accountAPI, ex.Message);
                }
                finally
                {
                    if (accountAPI.State.IsInvalidCookie)
                        Service.UpdateCookieStatus(GridView, accountAPI, "Invalid cookie.");

                    if (Token.IsCancellationRequested)
                        Service.UpdateCookieStatus(GridView, accountAPI, "Đã dừng.");
                }
            }
        }
    }
}
