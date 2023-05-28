using Hotel_MVC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Hotel_MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ApartmanStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ApartmanStoreDatabaseSettings)));

builder.Services.AddSingleton<IApartmanStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ApartmanStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ApartmanStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IApartmanService, ApartmanService>();

// Register the controllers
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
