using Dashboard.Data;
using Microsoft.EntityFrameworkCore;
using Dashboard.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    );

builder.Services.AddDbContext<userContext>(
        options =>
        {

            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

        }



    );


builder.Services.AddDefaultIdentity<DashboardUser>
    (
    options =>
    options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<userContext>();
builder.Services.AddRazorPages();
builder.Services.AddSession(); //step1
builder.Services.AddSession();
var app = builder.Build();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); // step2
app.UseRouting();

app.UseAuthorization();
//app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
app.Run();
