using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
	options.AddPolicy("DevCors", CorsPolicyBuilder =>
	{
		CorsPolicyBuilder.AllowAnyOrigin().AllowCredentials().AllowAnyMethod().AllowAnyHeader();
	});
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("ProdCors", CorsPolicyBuilder =>
	{
		CorsPolicyBuilder.WithOrigins("https://www.myApplication.com/")
		.AllowCredentials().AllowAnyMethod().AllowAnyHeader();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHttpsRedirection();
	app.UseCors("ProdCors");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
else
{
	app.UseCors("DevCors");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
