using Easy.Hook.Helpers;

namespace Easy.Hook
{
    public class EasyWebHook<T>
    {
        public WebHook<T> WebHook { get; set; }
        public EasyWebHook(EasyWebHookSettings settings)
        {
            Requests<T> request = new Requests<T>(settings);
            
            WebHook = new WebHook<T>(request);
        }
    }
}
