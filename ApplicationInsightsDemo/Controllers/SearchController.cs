using ApplicationInsightsDemo.Models;
using ApplicationInsightsDemo.Providers;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationInsightsDemo.Controllers
{
    public class SearchController : Controller
    {
        private ISearchProvider _searchProvider;

        public SearchController(ISearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
        }
        
        // GET: Search
        public ActionResult Index()
        {
            var model = new SearchModel();

            TelemetryClient client = new TelemetryClient();
            client.TrackPageView("Search");

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            model.Results = _searchProvider.Search(model.SearchText);

            // Send the event
            TelemetryClient client = new TelemetryClient();

            var properties = new Dictionary<string, string>
                {{"searchText", model.SearchText}};
            var measurements = new Dictionary<string, double>
                {{"results", model.Results.Count}};

            Random r = new Random();
            int rInt = r.Next(0, 100);

            if (rInt > 80)
            {
                var exception = new IndexOutOfRangeException();
                client.TrackException(exception, properties, measurements);
            }
            
            client.TrackEvent("Search Screen", properties, measurements);

            return View(model);
        }
    }
}