using Facet;
using Marten;
using Products.Api.Endpoints.Management.Events;
using Products.Api.Endpoints.Management.Handlers;
using Products.Api.Endpoints.Management.ReadModels;
using Wolverine;
using Wolverine.Attributes;

namespace Products.Api.Messaging;


public record SendOrdersProductDocument(Guid Id, ProductDetails? OrderProductDocument);



public static class OrderDocumentHandler
{
    
   public static async ValueTask Handle(ProductCreated command, IDocumentSession session, IMessageBus bus, ILogger logger)
   {
      var doc =await session.Events.FetchLatest<ProductDetails>(command.Id);
      if (doc is not null)
      {
        await bus.PublishAsync(new SendOrdersProductDocument(command.Id, doc));
      }
   }

   public static SendOrdersProductDocument Handle(ProductDiscontinued command)
   {
       return new SendOrdersProductDocument(command.Id, null);
   }
    
}