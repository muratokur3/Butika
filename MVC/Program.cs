using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MVC.Helpers;
using MVC.Models;
using MVC.Resources;
using OfficeOpenXml;
using Okta.AspNetCore;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;
using static QRCoder.PayloadGenerator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OktaDefaults.MvcAuthenticationScheme;
}).AddCookie(options =>
   {
       options.AccessDeniedPath = "/Account/AccessDenied";
   })
   .AddOktaMvc(new OktaMvcOptions
   {
       OktaDomain = builder.Configuration["Okta:Domain"],
       ClientId = builder.Configuration["Okta:ClientId"],
       ClientSecret = builder.Configuration["Okta:ClientSecret"],
       AuthorizationServerId = builder.Configuration["Okta:AuthorizationServerId"],
       PostLogoutRedirectUri = builder.Configuration["Okta:PostLogoutRedirectUri"],
       Scope = new List<string> { "openid", "profile", "email", "supply_qr_roles" },
       GetClaimsFromUserInfoEndpoint = true,

   });
builder.Services.Configure<OpenIdConnectOptions>(OktaDefaults.MvcAuthenticationScheme, options =>
{
    options.Events = new OpenIdConnectEvents
    {
        OnTokenValidated = async context =>
        {
            var identity = context.Principal.Identity as ClaimsIdentity;
            var supplyQrRoleClaim = identity.Claims.FirstOrDefault(c => c.Type == "supply_qr_roles" && (c.Value == "User" || c.Value == "SupplyAdmin"));
            identity.AddClaim(new Claim(ClaimTypes.Role, supplyQrRoleClaim.Value));

            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                
                var logService = scope.ServiceProvider.GetRequiredService<LogService>();
                await logService.LoginAsync();
            }
        },
        OnSignedOutCallbackRedirect = async context =>
        {
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var logService = scope.ServiceProvider.GetRequiredService<LogService>();
                await logService.LogoutAsync();
            }
        }

    };
});





builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LogService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<CustomHttpClientHandler>();
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("tr-TR"),
        new CultureInfo("en-US"),

    };
    options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
    options.RequestCultureProviders.Insert(1, new CookieRequestCultureProvider());
});


builder.Services.AddHttpClient("api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7120/api/");
})
.AddHttpMessageHandler<CustomHttpClientHandler>();

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
var loca = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(loca.Value);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();