using DLL.Context;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString, IdentityBuilder builder) {
        serviceCollection.AddDbContext<UkraineContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("View")));
        builder.AddEntityFrameworkStores<UkraineContext>();
    }
}