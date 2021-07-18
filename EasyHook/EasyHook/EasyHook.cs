using Easy.Hook.Helpers;

namespace Easy.Hook
{
    public class EasyHook<T>
    {
        public WebHook<T> WebHook { get; set; }
        public EasyHook(EasyHookSettings settings)
        {
            Requests<T> request = new Requests<T>(settings);
            
            WebHook = new WebHook<T>(request);
        }
    }
}
