using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Easy.Hook.Models
{
    public class EasyHookResponse
    {
        public bool Success { get; private set; }
        public JObject Content { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; private set; }
        public DateTime ResponseDateTime { get; private set; }

        public EasyHookResponse()
        {
            Success = false;
            Content = null;
            HttpResponseMessage = null;
            ResponseDateTime = DateTime.Now;
        }

        public EasyHookResponse(HttpResponseMessage httpResponseMessage, JObject content)
        {
            Success = httpResponseMessage.IsSuccessStatusCode;
            Content = content;
            HttpResponseMessage = httpResponseMessage;
            ResponseDateTime = DateTime.Now;
        }
    }
}
