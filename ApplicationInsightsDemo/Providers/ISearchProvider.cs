using System.Collections.Generic;
using ApplicationInsightsDemo.Models;

namespace ApplicationInsightsDemo.Providers
{
    public interface ISearchProvider
    {
        List<SearchItem> Search(string text);
    }
}