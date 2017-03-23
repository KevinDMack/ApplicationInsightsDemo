using ApplicationInsightsDemo.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TinyIoC;

namespace ApplicationInsightsDemo.DI
{
    public class Bootstrap
    {
        private static Bootstrap _instance;

        public static Bootstrap Instance
        {
            get { return _instance ?? (_instance = new Bootstrap()); }
        }

        public void Register()
        {

            TinyIoCContainer.Current.Register<ISearchProvider, SearchProvider>().AsPerRequestSingleton();
            
            
        }
        
    }
}