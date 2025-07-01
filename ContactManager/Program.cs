using ContactManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var UseProdDb = builder.Configuration.GetValue<bool>("UseProdDb");
var connectionString = UseProdDb ?
                        builder.Configuration.GetConnectionString("MariaDB_Prod") :
                        builder.Configuration.GetConnectionString("MariaDB_Dev");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 6))));


// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/AccessDenied";
                });

builder.Services.AddAuthorization();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    if (context != null && context.Database.GetDbConnection().State != ConnectionState.Open)
    {
        context.Database.OpenConnection();

        // Run EnsureCreated() to create the database and any pending migrations
        context.Database.EnsureCreated();
    }
    // Ensures that the bank is created
    context.Database.EnsureCreated();
    // Initialize the data
    DbInitializer.Initialize(context);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json/", "API V1");
        // c.RoutePrefix = string.Empty; // opcional se quiser UI na raiz
    });
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
