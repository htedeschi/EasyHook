using Easy.Hook.Helpers;
using Easy.Hook.Models;
using System.Threading.Tasks;

namespace Easy.Hook
{
    public class WebHook<T>
    {
        private readonly Requests<T> _requests;

        public WebHook(Requests<T> requests)
        {
            _requests = requests;
        }

        public async Task<EasyHookResponse> Send(T item)
        {
            return await _requests.PostRequest(item);
        }
    }
}
