using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Web.Providers;
using Web.Static;
using Microsoft.AspNetCore.Components.Authorization;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string BaseServerAdress = APIEndpoints.ServerBaseUrl;

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<HttpClient>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(BaseServerAdress) });

            builder.Services.AddScoped<AppAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider
                => provider.GetRequiredService<AppAuthenticationStateProvider>());

            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
