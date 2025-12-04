using Confluent.Kafka;
using Messages;
using Wolverine;
using Wolverine.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWolverine(options =>
{
    options.UseKafka("localhost:9092").ConfigureClient(client =>
    {

    }).ConfigureConsumers(consumer =>
    {
        consumer.GroupId = "new2";
        consumer.AutoOffsetReset = AutoOffsetReset.Earliest;
    });
    

    options.ListenToKafkaTopic("messages").ReceiveRawJson<SomeMessage>();
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

public static class MessageHandler
{
    public static void Handle(SomeMessage message, ILogger logger)
    {
        logger.LogInformation($"Received message: {message.Content}");
    }
}