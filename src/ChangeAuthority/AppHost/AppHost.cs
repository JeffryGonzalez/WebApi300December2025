var builder = DistributedApplication.CreateBuilder(args);

var employeesApi = builder.AddProject<Projects.Employees_Api>("employeesapi");

builder.AddProject<Projects.ApiGateway>("apigateway")
    .WithReference(employeesApi);

builder.Build().Run();
