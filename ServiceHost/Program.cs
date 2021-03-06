using _0_Framework.Application;
using _0_Framework.Application.Email;
using _0_Framework.Application.Sms;
using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using AccountManagement.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Presentation.Api;
using InventoryManagment.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceHost;
using ShopManagement.Presentation.Api.Controller;
using ShopMangment.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

var connectionString = builder.Configuration.GetConnectionString("LampShadeDB");
ShopMangmentBootstrapper.Configure(builder.Services, connectionString);
DiscountManagementBootstrapper.Configure(builder.Services, connectionString);
AccountManagementBootstrapper.Configure(builder.Services, connectionString);
//InventoryManagmentBootstrapper.Configure(builder.Services, connectionString);

//add cookie login
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

//set cookie login
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });
//
//ست کردت دسترسی صفحه ها
//fo==
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea", builder => builder.RequireRole(new System.Collections.Generic.List<string> { Roles.Administator, Roles.ContentUploader }));
    options.AddPolicy("Shop", builder => builder.RequireRole(new System.Collections.Generic.List<string> { Roles.Administator }));
    options.AddPolicy("Discount", builder => builder.RequireRole(new System.Collections.Generic.List<string> { Roles.Administator }));
    options.AddPolicy("Account", builder => builder.RequireRole(new System.Collections.Generic.List<string> { Roles.Administator }));
}) ;
//policy page
builder.Services.AddRazorPages()
    //filter pages
    .AddMvcOptions(options=> options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options => {
    options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
    options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
    options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
    options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
});
/// 


builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.Balinese, UnicodeRanges.Arabic));
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<ISmsService, SmsService>();
builder.Services.AddTransient<IEmailService, EmailService>();


builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
   builder.WithOrigins("https://localhost:")
   .AllowAnyMethod()
   .AllowAnyHeader()
   ));

//Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -Version 6.0.2
builder.Services.AddRazorPages().AddRazorRuntimeCompilation()
// services.AddControllersWithViews().AddRazorRuntimeCompilation();
// 
.AddApplicationPart(typeof(ProductController).Assembly)
.AddApplicationPart(typeof(InventoryController).Assembly)
.AddNewtonsoftJson();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//اضافه کردن کوکی
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
//
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.UseCors("MyPolicy");
app.Run();
