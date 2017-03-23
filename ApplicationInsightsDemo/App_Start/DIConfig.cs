using ApplicationInsightsDemo.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyIoC;

namespace ApplicationInsightsDemo.App_Start
{
    public class DIConfig
    {
        public static void Register()
        {
            var container = TinyIoCContainer.Current;

            DependencyResolver.SetResolver(new TinyIocDependencyResolver(container));
        }
    }
}