using InventoryManagement.Presentation.Api;
using ShopManagement.Presentation.Api.Controller;
using ShopMangment.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("LampShadeDb");
ShopMangmentBoostrapper.Configure(builder.Services, connectionString);
//builder.Services.AddTransient<IFileUploader, FileUploader>();
//builder.Services.AddTransient<IAuthHelper, AuthHelper>();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.UseCors("MyPolicy");
app.Run();
