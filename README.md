# EasyHook
An easy way to implement WebHooks

This project is an attempt to help our fellow developers to implement webhooks in their projects. The idea is to simply call instantiate the object and shoot a webhook to wherever you want to. This is a simple project that I came up with when I was tired and not thinking super straight, so I am sure you'll find issues, but if so, please contribute to the project! We want to make it better!

> Note: The project currently accepts only **`POST`** HTTP Requests

## Usage
To get started hooking everything, you need to include/install the package in your project, you can do that by running the following code in your Package Manager Console:
```
PM> Install-Package EasyWebHook
```

> Note: You can get more information [here](https://www.nuget.org/packages/EasyWebHook)

Once installed, you are ready to roll. You now need to instantiate some objects to have it working nicely.

### Settings
You'll first need to set the settings of how your webhooks should work, you can do that by having an instance of `EasyWebHookSettings`, like this:
```c#
using Easy.Hook.Helpers;

EasyWebHookSettings hookSettings = new EasyWebHookSettings() 
{ 
  HttpClient = new HttpClient(), 
  UriWebhook = new Uri("https://httpbin.org/post") 
};
```
> Note: You don't need to create a new HttpClient everytime, if you have one already instantiated, just use that one.

### EasyWebHook
With the settings object created, we can now create an instance of `EasyWebHook`, like this:
```c#
using Easy.Hook;

EasyWebHook<T> easyHook = new EasyWebHook<T>(hookSettings);
```

### Send a hook
Now that we have the `EasyWebHookSettings` and the `EasyWebHook` objects, we can trigger our webhooks! Here's how you can do that:
```c#
easyHook.WebHook.Send(webhookEvent);
```

> Note: The `Send` Method returns a `Task` therefore, it is `awaitable` if needed. To have the response just do this:
> ```c# 
> var result = await easyHook.WebHook.Send(webhookEvent);
> ```

## Example
```c#
using Easy.Hook;
using Easy.Hook.Helpers;
using HookConsole.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HookConsole
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            EasyWebHookSettings hookSettings = new EasyWebHookSettings() { 
                HttpClient = new HttpClient(), 
                UriWebhook = new Uri("https://httpbin.org/post") 
            };
            EasyWebHook<WebhookEvent> easyHook = new EasyWebHook<WebhookEvent>(hookSettings);

            Person person = new Person() {
                Id = 556,
                FirstName = "Henrique", 
                LastName = "Tedeschi", 
                Gender = "Male", 
                DateOfBirth = DateTime.Parse("Jan 1, 1990") 
            };

            WebhookEvent webhookEvent = new WebhookEvent() { 
                UserInitiated = 1, 
                EventId = 10233, 
                Data = person 
            };

            var result = await easyHook.WebHook.Send(webhookEvent);
            // result looks like:
            // Success (bool) = true
            // Content (Newtonsoft.Json.Linq.JObject) = {{"args": { },"data": "{\"EventId\":10233,\"OccurredAt\":\"2021-08-17T21:03:28.8511005-06:00\",\"UserInitiated\":1,\"Data\":{\"Id\":556,\"FirstName\":\"Henrique\",\"LastName\":\"Tedeschi\",\"DateOfBirth\":\"1990-01-01T00:00:00\",\"Gender\":\"Male\"}}","files":{ },"form":{ },"headers":{ "Content-Length":"199","Host":"httpbin.org"},"json":{ "Data":{ "DateOfBirth":"1990-01-01T00:00:00","FirstName":"Henrique","Gender":"Male","Id":556,"LastName":"Tedeschi"},"EventId":10233,"OccurredAt":"2021-08-17T21:03:28.8511005-06:00","UserInitiated":1},"origin":"71.199.xx.xxx","url":"https://httpbin.org/post"}};
            // HttpResponseMessage (HttpResponseMessage) = {StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: System.Net.Http.HttpConnectionResponseContent, Headers:{Date: Wed, 18 Aug 2021 03:09:23 GMTConnection: keep - aliveServer: gunicorn / 19.9.0Access - Control - Allow - Origin: *Access - Control - Allow - Credentials: trueContent - Type: application / jsonContent - Length: 794}}
            // ResponseDateTime (DateTime) = {8/17/2021 9:09:23 PM}

            Console.WriteLine("Hello World!");
        }
    }
}
```

## Final Words
That's it! Hopefully by now you've managed to send your webhooks. Easy, isn't it?
If you want to help me out, contribute to this project, and use it in your development.
If you **REALLY** want to help me out, here's my [Venmo](https://account.venmo.com/u/Henrique-Tedeschi) so you can donate something, or you can also [Sponsor me in GitHub](https://github.com/sponsors/htedeschi/).

Thank you!
