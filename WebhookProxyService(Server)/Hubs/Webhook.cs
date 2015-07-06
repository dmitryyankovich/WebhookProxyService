using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRServer.Hubs
{
    [HubName("WebHook")]
    public class WebHookHub : Hub
    {
        public static void SendRequest(byte[] data)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<WebHookHub>();
            hubContext.Clients.All.Request(data);
        }
    }
}