using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using SignalRServer.Hubs;

namespace SignalRServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public HttpStatusCodeResult WebhookHandle()
        {
            var stream = Request.InputStream;
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                WebHookHub.SendRequest(ms.ToArray());
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}