using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.EntityFramework;
using DataAccsessLayer.Contexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ContainerDependencies();

builder.Services.AddDbContext<MyBookshelfContext>();

builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IBookDal, EfBookDal>();

builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IAuthorDal, EfAuthorDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddMvc();


builder.Services.AddAuthentication("AuthSchemeBooks")
    .AddCookie("AuthSchemeBooks", options =>
    {
        options.LoginPath = new PathString("/Login/Index/");
        //options.AccessDeniedPath = new PathString("/Home/Index/");
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
