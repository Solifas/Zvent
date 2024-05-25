using Zvent.Server.Usecase;
using Zvent.Server.Infrastructure;
using Zvent.Server.Infrastructure.MappingProfiles;
using Zvent.Server.Usecase.Exceptions;
using Amazon.DynamoDBv2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddUsecase(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingConfigurations));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();
//show me how i can use the AddAWSService method to register the IAmazonDynamoDB service with the container as a singleton service

app.UseSwagger();

// Configure the HTTP request pipeline.
app.UseSwaggerUI();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();