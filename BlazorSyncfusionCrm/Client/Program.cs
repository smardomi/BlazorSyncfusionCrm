using BlazorSyncfusionCrm.Client;
using BlazorSyncfusionCrm.Client.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.Services.AddSyncfusionBlazor();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorSyncfusionCrm.ServerAPI",
                            client => client
                                         .BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp
                                    .GetRequiredService<IHttpClientFactory>()
                                    .CreateClient("BlazorSyncfusionCrm.ServerAPI"));

builder.Services.AddSingleton<ToastService>();

builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
