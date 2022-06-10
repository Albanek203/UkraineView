using Microsoft.AspNetCore.Identity.UI.Services;
using Serilog;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri("https://ukraineviewvault.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
builder.Host.UseSerilog((hostContext,services, configuration) => {
    configuration.WriteTo.File(builder.Environment.WebRootPath+"/Log.txt");
});

var connectionString = builder.Configuration.GetValue(typeof(string),"DefaultConnection").ToString() ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
var identityBuilder = builder.Services.AddDefaultIdentity<User>(op =>
{
    op.SignIn.RequireConfirmedAccount = true;
    op.User.RequireUniqueEmail = true;
}).AddRoles<IdentityRole>();

builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();
BLL.Infrastructure.Configuration.ConfigurationService(builder.Services, connectionString, identityBuilder);
View.Infrastructure.Configuration.ConfigurationService(builder.Services);
builder.Services.AddControllersWithViews();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddApplicationInsightsTelemetry();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { app.UseMigrationsEndPoint(); }
else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "MyAreaAdmin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "MyAreaManager",
    areaName: "Manager",
    pattern: "Manager/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();