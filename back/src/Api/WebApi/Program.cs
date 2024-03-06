using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using TwoFactorAuthenticator.Dependency.AutoMapper;
using TwoFactorAuthenticator.Dependency.DependecyInjection;
using TwoFactorAuthenticator.Infra.Mongo.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = (errorContext) =>
        {
            var errors = errorContext.ModelState.Values.SelectMany(e => e.Errors.Select(m => new
            {
                ErrorMessage = m.ErrorMessage
            })).ToList();
            var result = new
            {
                errors = errors.Select(e => e.ErrorMessage).ToList()
            };
            return new BadRequestObjectResult(result);
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSingleton(provider =>
{
    var connectionString = builder.Configuration.GetValue<string>("MongoDataBase:ConnectionString");
    var databaseName = builder.Configuration.GetValue<string>("MongoDataBase:DatabaseName");
    return new MongoDbContext(connectionString, databaseName);
});

var configAutoMapper = new MapperConfiguration(c =>
{
    c.AddProfile(new ModelToDtoProfile());
});

IMapper mapper = configAutoMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

ConfigureService.Configure(builder.Services);
ConfigureRepository.Configure(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
