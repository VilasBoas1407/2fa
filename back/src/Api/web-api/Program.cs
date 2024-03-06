using AutoMapper;
using TwoFactorAuthenticator.Dependency.AutoMapper;
using TwoFactorAuthenticator.Dependency.DependecyInjection;
using TwoFactorAuthenticator.Dependency.Settings;
using TwoFactorAuthenticator.Infra.Mongo.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configAutoMapper = new MapperConfiguration(c =>
{
    c.AddProfile(new ModelToDtoProfile());
});

IMapper mapper = configAutoMapper.CreateMapper();
builder.Services.AddSingleton(mapper); 

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
