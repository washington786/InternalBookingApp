using InternalBookingApp.Data;
using InternalBookingApp.Interfaces;
using InternalBookingApp.Repositories;
using InternalBookingApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var DbConnectionString = builder.Configuration.GetConnectionString("BookingDB");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(DbConnectionString));

// adding services and repositories in scope
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IResourceRepo, ResourceRepo>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<IStatsService, DashboardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
