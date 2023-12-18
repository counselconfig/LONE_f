using LONE.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LONEDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "GetPaymentStatus",
pattern: "Transaction/{id}",
    defaults: new { controller = "Requests", action = "GetPaymentStatus", id = UrlParameter.Optional });
app.Run();
