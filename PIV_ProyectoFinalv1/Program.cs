using Microsoft.EntityFrameworkCore;
using PIV_ProyectoFinalv1.Models;
using Microsoft.AspNetCore.Identity;
using PIV_ProyectoFinalv2.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("PivPfProyectoFinalv1Context");
builder.Services.AddDbContext<PivPfProyectoFinalv1Context>(x => x.UseSqlServer(connectionString));

//Conexion del Login
var connectionString2 = builder.Configuration.GetConnectionString("LoginContextConnection");
builder.Services.AddDbContext<LoginContext>(x => x.UseSqlServer(connectionString2));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LoginContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => {
    endpoints.MapRazorPages();
});

app.Run();
