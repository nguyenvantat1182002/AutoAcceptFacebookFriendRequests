using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.Services;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class MemberGetter : BaseTask
    {
        public MemberGetter(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
        {
        }

        public override async Task Start()
        {
            await Task.Run(Getter);
        }

        private async Task Getter()
        {
            DataGridViewRow row = GridView.CurrentRow;
            FacebookAccountAPI api = Service.MainForm.AccountList[row.Index];

            try
            {
                string[] groupIds = Service.GetGroupIDs(Service.MainForm.materialMultiLineTextBox24);
                int groupCount = 0;

                foreach (string groupId in groupIds)
                {
                    await foreach (FriendInfo member in api.GetGroupNewMenbers(groupId, Input.MaxMembers))
                    {
                        Console.WriteLine($"{member.Id} {member.Name}");

                        Service.UpdateCookieStatus(GridView, api, $"Lấy UID của {member.Name}");
                        Service.AddMemberId(member);

                        Token.ThrowIfCancellationRequested();
                    }

                    Service.UpdateRequest(GridView, api, ++groupCount);

                    Token.ThrowIfCancellationRequested();
                }

                Service.UpdateCookieStatus(GridView, api, "");
            }
            catch (OperationCanceledException)
            {
                Service.UpdateCookieStatus(GridView, api, "Đã dừng");
            }
            catch (Exception ex)
            {
                Service.UpdateCookieStatus(GridView, api, ex.Message);
            }
        }
    }
}
