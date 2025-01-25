using librarySystem.Models;
using librarySystem.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILiberaryRepository<Author>, AuthorDBRepo>();
builder.Services.AddScoped<ILiberaryRepository<Book>, BookDBRepo>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with connection string
builder.Services.AddDbContext<LibrarySystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));


// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware configuration
app.UseHttpsRedirection();
app.UseStaticFiles();

// Configure MVC default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");



app.Run();


