using Microsoft.AspNetCore.Cors.Infrastructure;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors((options) =>
{
	options.AddPolicy("DevCors", CorsPolicyBuilder =>
	{
		CorsPolicyBuilder.WithOrigins("http://127.0.0.1:4200", "http://127.0.0.1:3000", "http://127.0.0.1:8000")
		.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowCredentials();
	});
	options.AddPolicy("ProdCors", CorsPolicy =>
	{
		CorsPolicy.WithOrigins("http://127.0.0.1:4200", "http://127.0.0.1:3000", "http://127.0.0.1:8000")
		.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowCredentials();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseCors("DevCors");
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
	app.UseCors("ProdCors");
	app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
