using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var configTypeParameter = builder.AddParameter("ConfigType");
var jsonBasePathParameter = builder.AddParameter("JsonBasePath");

var identityService = builder
    .AddProject<Identity_WebApi>("IdentityService")
    .WithEnvironment("ConfigType", configTypeParameter)
    .WithEnvironment("JsonBasePath", jsonBasePathParameter);

var userNotificationProcessor = builder
    .AddProject<UserNotifications_Processor>("UserNotificationProcessor")
    .WithEnvironment("ConfigType", configTypeParameter)
    .WithEnvironment("JsonBasePath", jsonBasePathParameter);

builder.Build().Run();
