using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
	options.AddPolicy("DevCors", (CorsPolicyBuilder) =>
	{
		CorsPolicyBuilder.WithOrigins("http://127.0.0.1:4200", "http://127.0.0.1:3000", "http://127.0.0.1:8000")
		.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowCredentials();
	});
	options.AddPolicy("DevCors", (CorsPolicyBuilder) =>
	{
		CorsPolicyBuilder.WithOrigins("https://www.mywebsite.com/")
		.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowCredentials();
	});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
	app.UseCors("DevCors");
}
else
{
	app.UseCors("ProdCors");
	app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
