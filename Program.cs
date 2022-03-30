using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);
// string  connString = builder.Configuration.GetConnectionString("DefaultConnectionString");
string DefaultConnectionString =  @"Server=localhost; Database=ECommerce; Integrated Security=false; User=sa; Password=Kumar@danicha123; TrustServerCertificate=true";

builder.Services.AddDbContext<AppDbContext>(options =>  options.UseSqlServer(DefaultConnectionString));

//Services configration
builder.Services.AddScoped<IActorsService, ActorsService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
AppDbInitializer.Seed(app);
app.Run();
