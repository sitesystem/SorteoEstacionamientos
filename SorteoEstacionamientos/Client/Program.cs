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

// Inyección de Dependencias - Módulo de Login
builder.Services.AddAuthorizationCore();

// Radzen Components and Services
builder.Services.AddRadzenComponents();
// builder.Services.AddScoped<ContextMenuService>();
// builder.Services.AddScoped<DialogService>();
// builder.Services.AddScoped<NotificationService>();
// builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<RColorService>();
builder.Services.AddScoped<RCarreraService>();
builder.Services.AddScoped<REdoRepMexService>();
builder.Services.AddScoped<REscuelaService>();
builder.Services.AddScoped<RGanadorService>();
builder.Services.AddScoped<RLinkService>();
builder.Services.AddScoped<RParticipanteService>();
builder.Services.AddScoped<RPeriodoRegistroService>();
builder.Services.AddScoped<RRolService>();
builder.Services.AddScoped<RSemestreService>();
builder.Services.AddScoped<RTipoParticipanteService>();
builder.Services.AddScoped<RTipoPlacaService>();
builder.Services.AddScoped<RTipoVehiculoService>();
builder.Services.AddScoped<RArchivosService>();
builder.Services.AddLogging();

await builder.Build().RunAsync();
