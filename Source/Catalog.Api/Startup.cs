using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Configuration.Json;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using MongoDB.Driver;

namespace Catalog.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv) {
            
            Configuration = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .Build();
        }
        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            var cs = this.Configuration.GetChildren().Where(i => i.Key == "CatalogDatabaseConnectionString").First().Value;
            var db = (new MongoClient(new MongoUrl(cs))).GetDatabase("catalog");
            
            services.AddSingleton(typeof(IMongoDatabase), (s) => db);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
