using FrontToBack.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(connectionString)
    );

var app = builder.Build();

app.UseStaticFiles();


app.MapControllerRoute(
     name:"areas",
            pattern:"{area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=home}/{action=index}/{id?}"
    );


app.Run();
