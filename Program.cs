using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using rar.Extensions;
using rar.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMvcWithDefaultRoute();

app.UseRouting();

app.UseAuthorization();

app.UseMvc(routes =>
{
   

    // routes.MapRoute(
    //     name: null,
    //     template: "{accidentType}/Page{Page:int}",
    //     defaults: new { controller = "AccidentReport", action = "LatestAccidents" }
    //     );

    // routes.MapRoute(
    //     name: null,
    //     template: "{sortUser}/Page{Page:int}",
    //     defaults: new { controller = "AccidentReport", action = "LatestAccidents" }
    //     );

    // routes.MapRoute(
    //     name: null,
    //     template: "{sortOrder}/Page{Page:int}",
    //     defaults: new { controller = "AccidentReport", action = "LatestAccidents" }
    //     );

    // routes.MapRoute(
    //     name:null,
    //     template:"Page{Page:int}",
    //     defaults: new { Controller = "AccidentReport", action="LatestAccidents", Page=1}                   
    //     );

    //  routes.MapRoute(
    //         name:null,
    //         template:"{default2}",
    //         defaults: new { Controller = "AccidentReport",
    //                     action="LatestAccidents", Page=1}
    //         );
   
    
     routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Home}/{id?}");
});

//Seed Data
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<AppIdentityDbContext>();

    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    //IConfiguration configuration;

    //await context.Database.MigrateAsync();
    //context.Connections.RemoveRange(context.Connections);
    //await context.Database.ExecuteSqlRawAsync("Delete From [Connections]");
    AppIdentityDbContext.CreateAdminAccount(userManager, roleManager, builder.Configuration).Wait();
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

//AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();

app.Run();
