using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using WebCar.Areas.Identity.Data;
using WebCar.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebCarDbContextConnection") ?? throw new InvalidOperationException("Connection string 'WebCarDbContextConnection' not found.");

builder.Services.AddDbContext<WebCarDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<WebCarUser>(options =>
{
	options.SignIn.RequireConfirmedAccount = true;
	options.Password.RequireDigit = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
})
	.AddEntityFrameworkStores<WebCarDbContext>();

// Add services to the container.
builder.Services.AddMailKit(config => config.UseMailKit(
builder.Configuration.GetSection("EmailSettings").Get<MailKitOptions>()));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
