namespace View.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection services) {
        services.AddTransient<AdminService>();
        services.AddTransient<RegionService>();
        services.AddTransient<EntertainmentService>();
        services.AddTransient<MonumentService>();
        services.AddTransient<UserService>();
        services.AddTransient<ImageManager>();
    }
}