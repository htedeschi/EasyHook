using Easy.Hook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Easy.Hook.Helpers
{
    public class Requests<T>
    {
        public EasyHookSettings _settings { get; set; }

        public Requests(EasyHookSettings settings)
        {
            _settings = settings;
        }

        public async Task<EasyHookResponse> PostRequest(T item)
        {
            ByteArrayContent byteContent = null;

            if (item != null)
            {
                string myContent = JsonConvert.SerializeObject(item);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                byteContent = new ByteArrayContent(buffer);
            }            

            using HttpResponseMessage response = await _settings.HttpClient.PostAsync(_settings.UriWebhook, byteContent);
            {
                string content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                JObject dynamicContent = JObject.Parse(content);

                EasyHookResponse easyHookResponse = new EasyHookResponse(response, dynamicContent);

                return easyHookResponse;
            }
        }

        public async Task<string> PostRequestString(T item)
        {
            ByteArrayContent byteContent = null;

            if (item != null)
            {
                string myContent = JsonConvert.SerializeObject(item);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                byteContent = new ByteArrayContent(buffer);
            }

            using var response = await _settings.HttpClient.PostAsync(_settings.UriWebhook, byteContent);
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }
    }
}
