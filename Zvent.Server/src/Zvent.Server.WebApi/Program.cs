using Zvent.Server.Usecase;
using Zvent.Server.Infrastructure;
using Zvent.Server.WebApi.Extensions;
using Zvent.Server.Infrastructure.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddUsecase(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingConfigurations));

var app = builder.Build();

app.RegisterEndpointDefinitions();
//add db context for sql server
// app.Services.AddDbContext<AppDbContext>(options =>
// {
//     options.UseSqlServer(app.Configuration.GetConnectionString("DefaultConnection"));
// });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
{
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();