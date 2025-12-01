var builder = DistributedApplication.CreateBuilder(args);

// My Environment
var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithImage("postgres:17.5"); // You can use "custom" images too.

// My Apis

var ordersDb = postgres.AddDatabase("orders");

var ordersApi = builder.AddProject<Projects.Orders_Api>("ordersapi")
    .WithReference(ordersDb)
    .WaitFor(ordersDb); // don't start this until the database is ready.

builder.Build().Run();
