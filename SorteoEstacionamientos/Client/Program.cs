using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Radzen;

using SorteoEstacionamientos.Client;
using SorteoEstacionamientos.Shared.CapaServices_BusinessLogic;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Inyecci�n de Dependencias - M�dulo de Login
builder.Services.AddAuthorizationCore();

// Radzen Components and Services
builder.Services.AddRadzenComponents();
// builder.Services.AddScoped<ContextMenuService>();
// builder.Services.AddScoped<DialogService>();
// builder.Services.AddScoped<NotificationService>();
// builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<RColorService>();
builder.Services.AddScoped<RCarreraService>();
builder.Services.AddLogging();

await builder.Build().RunAsync();
