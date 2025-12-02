using Marten;
using Products.Api.Endpoints.Events;
using Products.Api.Endpoints.Operations;

namespace Products.Api.Endpoints.Handlers;


public record CreateProduct(Guid Id, string Name, decimal Price, int Qty);


public class ProductsHandler
{

    public async Task HandleAsync(CreateProduct command, IDocumentSession session)
    {
        var (id, name,price, qty ) = command;
        session.Events.StartStream<ProductCreated>(id, new ProductCreated(id, name, price, qty) );
        
        // session.Events.Append(command.CreatedBy, ...);
        
        await session.SaveChangesAsync();
    }
}