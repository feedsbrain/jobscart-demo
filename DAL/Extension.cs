using JobsCart.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace JobsCart.DAL {
    public static class Extension {
        public static IWebHost Seed (this IWebHost webhost) {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory> ().CreateScope ()) {
                // alternatively resolve UserManager instead and pass that if only think you want to seed are the users
                using (var dbContext = scope.ServiceProvider.GetRequiredService<JobsDbContext> ()) {
                    SeedData.SeedAsync (dbContext).GetAwaiter ().GetResult ();
                }
            }
            return webhost;
        }
    }
}