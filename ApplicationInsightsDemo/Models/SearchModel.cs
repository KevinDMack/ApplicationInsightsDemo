using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationInsightsDemo.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            Results = new List<SearchItem>();
        }
        public string SearchText { get; set; }

        public List<SearchItem> Results { get; set; }
    }

    public class SearchItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int QuantityOnHand { get; set; }
    }

    
}