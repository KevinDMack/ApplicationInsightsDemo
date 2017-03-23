using ApplicationInsightsDemo.Models;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace ApplicationInsightsDemo.Providers
{
    public class SearchProvider : ISearchProvider
    {
        public List<SearchItem> Search(string text)
        {
            bool success = true;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<SearchItem> list = new List<SearchItem>();

            try
            {
                list.Add(new SearchItem() { ID = 1, Name = "Casino Royale", QuantityOnHand = 30 });
                list.Add(new SearchItem() { ID = 2, Name = "Spectre", QuantityOnHand = 40 });
                list.Add(new SearchItem() { ID = 3, Name = "Goldeneye", QuantityOnHand = 50 });
                list.Add(new SearchItem() { ID = 4, Name = "Skyfall", QuantityOnHand = 60 });
                list.Add(new SearchItem() { ID = 5, Name = "Quantum of Solace", QuantityOnHand = 70 });


                if (!(String.IsNullOrEmpty(text)))
                {
                    list = list.Where(i => i.Name.StartsWith(text)).ToList();
                }

            }
            catch (Exception ex)
            {
                success = false;
            }
            finally
            {
                timer.Stop();
            }

            var elapsed = timer.Elapsed;

            TelemetryClient client = new TelemetryClient();
            client.TrackDependency("Search Provider", "Search", DateTimeOffset.Now, elapsed, success);

            return list;
        }
    }
}