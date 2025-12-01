using Orders.Api.Endpoints.Orders;
using Orders.Api.Endpoints.Orders.Operation;
using System.Text.Json;
using Wolverine;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWolverine(); // add a few services, one in particular is IMessageBus.
var db2ConnectionString = builder.Configuration.GetConnectionString("db2");


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddOrders();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddValidation(); // turn on validation for all my API endpoints.
builder.Services.AddProblemDetails(); // return 400s with standard problems json format.
var app = builder.Build(); // one world above the build, one after.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapOrders(); // This will add all the operations for the "/orders" resource.
 
app.Run();
