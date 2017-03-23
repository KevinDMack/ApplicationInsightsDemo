using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ApplicationInsightsDemo.Controllers
{
    public class AccountDetailsController : Controller
    {
        // GET: AccountDetails
        public ActionResult Index()
        {
            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints

            rInt = rInt * 100;

            Thread.Sleep(rInt);

            TelemetryClient client = new TelemetryClient();
            client.TrackPageView("Action Details");

            return View();
        }
    }
}