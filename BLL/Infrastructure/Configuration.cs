using DLL.Context;
using DLL.Repository;
using DLL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString, IdentityBuilder builder) {
        serviceCollection.AddDbContext<UkraineContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("View")));
        builder.AddEntityFrameworkStores<UkraineContext>();

        builder.Services.AddTransient<AboutRepository>();
        builder.Services.AddTransient<AddressRepository>();
        builder.Services.AddTransient<RegionRepository>();
        builder.Services.AddTransient<ContactRepository>();
        builder.Services.AddTransient<EntertainmentRepository>();
        builder.Services.AddTransient<ImageRepository>();
        builder.Services.AddTransient<MonumentRepository>();
        builder.Services.AddTransient<ReviewRepository>();
        builder.Services.AddTransient<UserRepository>();
        builder.Services.AddTransient<WorkTimeRepository>();
    }
}