using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using SignalRClient.Properties;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection(Settings.Default.RemoteServer);
            var hub = hubConnection.CreateHubProxy("WebHook");
            hub.On<byte []>("Request", data =>
            {
                try
                {
                    var request = WebRequest.Create(Settings.Default.LocalServer) as HttpWebRequest;
                    request.Method = "POST";
                    request.ContentLength = data.Length;
                    var reqStream = request.GetRequestStream();
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                    var response = request.GetResponse() as HttpWebResponse;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            });
            hubConnection.Start();
            Console.Read();
        }
    }
}
