using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.Services;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class MemberGetter : BaseTask
    {
        private readonly Queue<string> _groupIds;

        public MemberGetter(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
        {
            _groupIds = new Queue<string>(Service.GetGroupIDs(Service.MainForm.materialMultiLineTextBox24));
        }

        public override async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < Input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Getter);
                tasks.Add(task);

                await Task.Delay(800);
            }

            await Task.WhenAll(tasks);
        }

        private async Task Getter()
        {
            while (true)
            {
                FacebookAccountAPI api;

                string? groupId = null;

                int groupCount = 0;

                lock (LockObject)
                {
                    if (Accounts.Count < 1)
                        return;

                    api = Accounts.Dequeue();
                }

                try
                {
                    while (true)
                    {
                        lock (LockObject)
                        {
                            if (_groupIds.Count < 1)
                                return;

                            groupId = _groupIds.Dequeue();
                        }

                        await foreach (FriendInfo member in api.GetGroupNewMenbers(groupId, Input.MaxMembers))
                        {
                            Service.UpdateCookieStatus(GridView, api, $"Lấy UID của {member.Name}");

                            lock (LockObject)
                                Service.AddMemberId(member);

                            Token.ThrowIfCancellationRequested();
                        }

                        groupCount++;

                        Service.UpdateRequest(GridView, api, groupCount);
                        Service.UpdateCookieStatus(GridView, api, "");
                    }
                }
                catch (TaskCanceledException)
                {
                    lock (LockObject)
                    {
                        if (groupId != null)
                            _groupIds.Enqueue(groupId);
                    }

                    Service.UpdateCookieStatus(GridView, api, "Timeout");
                }
                catch (OperationCanceledException)
                {
                    Service.UpdateCookieStatus(GridView, api, "Đã dừng");
                    return;
                }
                catch (Exception ex)
                {
                    lock (LockObject)
                    {
                        if (groupId != null)
                            _groupIds.Enqueue(groupId);
                    }

                    Service.UpdateCookieStatus(GridView, api, ex.Message);
                }
            }
        }
    }
}
