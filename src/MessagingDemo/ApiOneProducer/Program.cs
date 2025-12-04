using Messages;
using Wolverine;
using Wolverine.Kafka;


var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenApi();


builder.Host.UseWolverine(options =>
{
    options.UseKafka("localhost:9092");
    options.PublishMessage<PublishMessage>().ToKafkaTopic("messages").PublishRawJson();
    
});
var app = builder.Build();

app.MapPost("/send", async (SomeMessage message, IMessageBus bus) =>
{
    await bus.PublishAsync(new PublishMessage(message.Content), new DeliveryOptions()
    {
        Headers = { {"dog", "cat"} },
        PartitionKey = "my-key"
        
    });
    return TypedResults.Ok("Sent");
});
app.MapOpenApi("/openapi/v1.json");
app.MapDefaultEndpoints();
app.Run();



public record PublishMessage(string Content);