using Scalar.Aspire;

var builder = DistributedApplication.CreateBuilder(args);

var kafka = builder.AddKafka("broker", 9092)
    .WithKafkaUI(config =>
    {
        config.WithLifetime(ContainerLifetime.Persistent);
    })
    .WithLifetime(ContainerLifetime.Persistent);
var docs = builder.AddScalarApiReference("scalar-docs");

var app1 = builder.AddProject<Projects.ApiOneProducer>("app1")
        .WithReference(kafka)
        .WaitFor(kafka)
    ;
// scalarApis.WithApiReference(productsApi, options => { options.AddDocument("products.v1", "Product Management API"); });

docs.WithApiReference(app1, options => options.AddDocument("v1", "API One Producer"));

var client = builder.AddProject<Projects.ApiClient>("client")
    .WithReference(kafka)
    .WaitFor(kafka);
builder.Build().Run();