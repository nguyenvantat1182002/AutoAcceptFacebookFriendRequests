using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.Models;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Utils;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class FriendAcceptor
    {
        private Queue<FacebookAccountAPI> _accountList;
        private Input _input;
        private CancellationToken _token;
        private MainFormService _service;

        private object _lockObject = new object();

        public FriendAcceptor(CancellationToken token)
        {
            _accountList = new Queue<FacebookAccountAPI>(MainForm.Instance!.AccountList);
            _input = MainForm.Instance!.Input;
            _token = token;
            _service = MainForm.Instance!.Service;
        }

        public async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < _input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Acceptor);
                tasks.Add(task);

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        async Task Acceptor()
        {
            while (_accountList.Count > 0)
            {
                FacebookAccountAPI accountAPI;

                lock (_lockObject)
                    accountAPI = _accountList.Dequeue();

                int requests = 0;

                try
                {
                    Queue<FriendInfo> friendRequests = new Queue<FriendInfo>(await accountAPI.GetFriendRequests());
                    _service.UpdateFriendRequests(accountAPI, friendRequests.Count);

                    if (friendRequests.Count < 1)
                    {
                        _service.UpdateCookieStatus(accountAPI, $"Không có lời mời kết bạn nào.");
                        continue;
                    }

                    long endTime = 0;

                    while (friendRequests.Count > 0)
                    {
                        FriendInfo friendRequest = friendRequests.Dequeue();

                        while (true)
                        {
                            if (TimeUtils.GetTimestamp() > endTime)
                                break;

                            int remainningTime = (int)(endTime - TimeUtils.GetTimestamp());
                            string formattedTime = TimeUtils.SecondsToFormattedTime(remainningTime);

                            _service.UpdateCookieStatus(accountAPI, $"Sẽ tiếp tục sau {formattedTime}");

                            await Task.Delay(1000, _token);
                        }

                        if (requests >= _input.RateLimit)
                        {
                            endTime = TimeUtils.GetTimestamp() + _input.RateLimitDuration;

                            while (true)
                            {
                                if (TimeUtils.GetTimestamp() > endTime)
                                    break;

                                int remainningTime = (int)(endTime - TimeUtils.GetTimestamp());
                                string formattedTime = TimeUtils.SecondsToFormattedTime(remainningTime);

                                _service.UpdateCookieStatus(accountAPI, $"Tạm dừng, sẽ tiếp tục sau {formattedTime}");

                                await Task.Delay(1000, _token);
                            }

                            requests = 0;
                        }

                        _service.UpdateCookieStatus(accountAPI, $"Chấp nhận kết bạn với {friendRequest.Name}");
                        await accountAPI.AcceptFriendRequest(friendRequest);

                        requests++;

                        _service.UpdateFriendRequests(accountAPI, friendRequests.Count);

                        endTime = TimeUtils.GetTimestamp() + _input.Duration;
                    }

                    _service.UpdateCookieStatus(accountAPI, $"Hoàn thành.");
                }
                catch (Exception ex)
                {
                    if (ex is TaskCanceledException || ex is InvalidCookie || ex is AccountCheckpointed)
                    {
                        if (ex is InvalidCookie)
                            accountAPI.State.IsInvalidCookie = true;

                        if (ex is AccountCheckpointed)
                        {
                            accountAPI.State.IsCheckpointed = true;
                            _service.UpdateCookieStatus(accountAPI, ex.Message);
                        }

                        break;
                    }
                    else
                        _service.UpdateCookieStatus(accountAPI, ex.Message);
                }
                finally
                {
                    if (accountAPI.State.IsInvalidCookie)
                        _service.UpdateCookieStatus(accountAPI, "Invalid cookie.");

                    if (_token.IsCancellationRequested)
                        _service.UpdateCookieStatus(accountAPI, "Đã dừng.");
                }
            }
        }
    }
}
