using Marten;
using Products.Api.Endpoints.Management.Events;
using Products.Api.Endpoints.Management.Handlers;
using Products.Api.Endpoints.Management.ReadModels;
using Wolverine;
using Wolverine.Attributes;

namespace Products.Api.Messaging;


public record SendOrdersProductDocument(ProductDetails? OrderProductDocument);

[WolverineHandler]

public static class OrderDocumentHandlers
{
    
   public static async ValueTask Handle(ProductsHandler.SendProductToOrders command, IDocumentSession session, IMessageBus bus, ILogger logger)
   {
      var doc =await session.Events.FetchLatest<ProductDetails>(command.Id);
      if (doc is not null)
      {
        await bus.PublishAsync(new SendOrdersProductDocument(doc), new DeliveryOptions()
        {
            PartitionKey = command.Id.ToString()
        });
      }
   }

   public static async Task Handle(ProductsHandler.SendTombstoneProductToOrders command, IMessageBus bus)
   {
       await bus.PublishAsync(new SendOrdersProductDocument(null), new DeliveryOptions()
       {
           PartitionKey = command.Id.ToString()
       });
   }
    
}