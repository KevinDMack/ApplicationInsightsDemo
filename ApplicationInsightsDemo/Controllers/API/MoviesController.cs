using ApplicationInsightsDemo.Models;
using ApplicationInsightsDemo.Providers;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationInsightsDemo.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ISearchProvider _searchProvider;

        public MoviesController(ISearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
        }

        public List<Models.SearchItem> Get(string id)
        {
            Stopwatch timer = new Stopwatch();
            // Send the event
            TelemetryClient client = new TelemetryClient();

            List<SearchItem> list = new List<SearchItem>();
            try
            {
                timer.Start();
                list = _searchProvider.Search(string.Empty);

            }
            catch (Exception ex)
            {
                client.TrackException(ex);
            }
            finally
            {
                timer.Stop();

                var runTime = timer.Elapsed;

                // Set up some properties:
                var properties = new Dictionary<string, string>
                {{"searchText", id}, { "runtime",runTime.TotalSeconds.ToString() } };
                var measurements = new Dictionary<string, double>
                {{"results", list.Count}};

                
                client.TrackEvent("SearchAPI", properties, measurements);
            }
            
            

            return list;
        }
    }
}
