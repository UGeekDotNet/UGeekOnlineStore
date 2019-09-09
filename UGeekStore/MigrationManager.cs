using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UGeekStore.DAL;

namespace UGeekStore
{
    public static class DataManager
    {
        public static StoreContext DbContext { get; private set; }
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {

            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var hostingEnvironment = services.GetRequiredService<IHostingEnvironment>();

                DbContext = services.GetRequiredService<StoreContext>();

                DbContext.Database.Migrate();

                CheckStaticData();
            }

            return webHost;
        }


        private static void CheckStaticData()
        {
            // seed data here ...

            // example
            //if(!DbContext.Roles.Any())
            //{
            //    DbContext.Roles.Add(new Core.Entities.Role { Name = "admin" });
            //}
        }
    }
}