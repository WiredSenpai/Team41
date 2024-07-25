using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Group41_Wired_Martians.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = true).
	AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StockLiason}/{action=DashBoard}/{id?}");

app.Run();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	await CreateAdminUser(services);
}

async Task CreateAdminUser(IServiceProvider serviceProvider)
{

	var userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
	var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

	string ImgUrl = "https://bootdey.com/img/Content/avatar/avatar7.png";
	string FirstName = "Lathitaa";
	string LastName = "Mjungula";
	string Status = "Active";
	DateTime CreatedAt = DateTime.Now;
	string adminEmail = "admin@example.com";
	string adminPassword = "Password150@";
	string adminRoleName = "Admin";

	// Check if the admin role exists
	if (!await roleManager.RoleExistsAsync(adminRoleName))
	{
		var role = new IdentityRole(adminRoleName);
		await roleManager.CreateAsync(role);
	}

	// Check if the admin user exists
	var adminUser = await userManager.FindByEmailAsync(adminEmail);
	if (adminUser == null)
	{
		adminUser = new Users { Status = Status, ImgUrl = ImgUrl, FirstName = FirstName, LastName = LastName, UserName = adminEmail, Email = adminEmail, CreatedAt = CreatedAt, PasswordHash = adminPassword };
		var result = await userManager.CreateAsync(adminUser, adminPassword);
		if (result.Succeeded)
		{
			await userManager.AddToRoleAsync(adminUser, adminRoleName);
		}
	}
	else
	{
		// Ensure the admin user is in the admin role
		if (!await userManager.IsInRoleAsync(adminUser, adminRoleName))
		{
			await userManager.AddToRoleAsync(adminUser, adminRoleName);
		}
	}
}
