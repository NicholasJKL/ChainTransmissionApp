using Microsoft.EntityFrameworkCore;
using ChainTransmissionAPI.Models.Contexts;
using ChainTransmissionAPI.Managers;


var builder = WebApplication.CreateBuilder(args);

string? connectionChainTransmission = builder.Configuration.GetConnectionString("ChainTransmissionConnection");

string? connectionStaticVariables = builder.Configuration.GetConnectionString("StaticVariablesConnection");


builder.Services.AddDbContext<ChainTransmissionContext>(options => options
	.UseNpgsql(connectionChainTransmission)
	.UseLazyLoadingProxies()
);

builder.Services.AddDbContext<StaticVariablesContext>(options => options
	.UseNpgsql(connectionStaticVariables)
);

builder.Services.AddScoped<IChainTransmissionManager, ChainTransmissionManager>();

builder.Services.AddCors();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder
	.WithOrigins("http://localhost:3000", "https://localhost:3000")
	.AllowAnyHeader()
	.AllowAnyMethod()
);

app.Run();
