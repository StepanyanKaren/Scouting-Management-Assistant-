using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using PL;
using Microsoft.Extensions.Configuration;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<ScoutingService>();



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


await builder.Build().RunAsync();



public partial class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.RootComponents.Add<App>("app");

        // Configure App Configuration
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.AddSingleton(sp => new HttpClient() { BaseAddress = new Uri("https://api-football-v1.p.rapidapi.com/v3/leagues") });
        // Register Database Context
        // builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddSingleton<ScoutingService>();

        await builder.Build().RunAsync();
    }
}

