global using SorteoEstacionamientos.Server.CapaDataAccess.DBContext;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

using Serilog;

using SorteoEstacionamientos.Shared.CapaEntities.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DBSorteoParkingContext>(optionsBuilder =>
{
    optionsBuilder.UseMySql(builder.Configuration.GetConnectionString("MySQL_Connection"),
    ServerVersion.Parse("8.0.22-mysql"), mySqlOptionsAction: null);
});

// LogReg (Archivo de Registros de Eventos)
// Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
//    .WriteTo.Console()
//    .WriteTo.File("wwwroot/Repositorio/Logs/log-.log", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss}")
//    .CreateLogger();
// Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog((hostingContext, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(hostingContext.Configuration);
});
// builder.Logging.AddConsole();

// Habilitar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // T�tulo Dise�o
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "serverWS", Version = "v1" });

    // Bot�n Authorize
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Servicios CORS
string? cors = "_cors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
        builder =>
        {
            builder.WithHeaders("*"); // POST
            builder.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); // GET
            builder.WithMethods("*"); // PUT DELETE
        });
});

builder.Services.AddAuthorization(options =>
{
    // options.AddPolicy("[Rol] Developer", policy => policy.RequireClaim("Rol", "1", "2"));
    // options.AddPolicy("RequireManagerRole", policy => policy.RequireRole("Manager"));
});

// JWT (Jason Web Token)
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppSettings>();
// var key = Encoding.ASCII.GetBytes(appSettings.Secreto);
var key = Encoding.UTF8.GetBytes(appSettings?.Secreto ?? string.Empty);

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false, // Emisor
        ValidateAudience = false, // Resource Server

        // ValidAudience = builder.Configuration["AuthSettings:Audince"],
        // ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
        // RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        IssuerSigningKey = new SymmetricSecurityKey(key),
    };
});

/******************************************************************************************************/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "serverWS v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(cors);

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// Middlewares para gestionar la Authentication y la Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
