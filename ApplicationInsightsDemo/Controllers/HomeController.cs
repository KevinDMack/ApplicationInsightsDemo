using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationInsightsDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TelemetryClient client = new TelemetryClient();
            client.TrackPageView("Home_Index");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            TelemetryClient client = new TelemetryClient();
            client.TrackPageView("Home_About");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            TelemetryClient client = new TelemetryClient();
            client.TrackPageView("Home_Contact");

            return View();
        }
    }
}