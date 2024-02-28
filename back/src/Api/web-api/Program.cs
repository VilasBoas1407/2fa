using Microsoft.Extensions.Configuration;
using TwoFactorAuthenticator.Dependency.DependecyInjection;
using TwoFactorAuthenticator.Dependency.Settings;
using TwoFactorAuthenticator.Infra.Mongo.Context;
using web_api.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Service>();

ConfigureService.Configure(builder.Services);
ConfigureRepository.Configure(builder.Services);

builder.Services.AddSingleton(provider =>
{
    var mongoDbSettings = builder.Configuration.GetValue<MongoDBSettings>("MongoDataBase");
    var connectionString = mongoDbSettings.ConnectionString; 
    var databaseName = mongoDbSettings.DatabaseName;
    return new MongoDbContext(connectionString, databaseName);
});

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
