using System;
using System.Net.Http;

namespace Easy.Hook.Helpers
{
    public class EasyHookSettings
    {
        public Uri UriWebhook { get; set; }
        public HttpClient HttpClient { get; set; }      
    }
}
