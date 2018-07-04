using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using EventsProvider.Data;
using EventsProvider.Data.Repository;
using EventsProvider.Data.Caches;

[assembly: OwinStartup(typeof(EventsService.Startup))]

namespace EventsService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var repository = new Repository();
            EventsProvider.Service.EventsService
                .Create(new EventsCache(repository), 
                     new MarketsCache(repository), 
                     new SelectionsCache(repository));
        }
    }
}
