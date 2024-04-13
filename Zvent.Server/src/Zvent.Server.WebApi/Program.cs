var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//add db context for sql server
app.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(app.Configuration.GetConnectionString("DefaultConnection"));
});

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