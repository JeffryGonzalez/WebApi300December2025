using JasperFx.Events;
using Marten;
using Products.Api.Endpoints.Management.Events;

namespace Products.Api.Endpoints.Management.Handlers;

public class ProductsHandler
{
    public StreamAction Handle(CreateProduct command, IDocumentSession session)
    {
        var (id, name,price, qty ) = command;
        return session.Events.StartStream(id, new ProductCreated(id, name, price, qty) );
    }

    public void Handle(DiscontinueProduct command, IDocumentSession session)
    {
        session.Events.Append(command.Id, new ProductDiscontinued(command.Id));
    }

    public void Handle(IncreaseProductQty command, IDocumentSession session)
    {
        session.Events.Append(command.Id, new ProductQtyIncreased(command.Id, command.Increase));
    }
    
    public void Handle(DecreaseProductQty command, IDocumentSession session)
    {
        session.Events.Append(command.Id, new ProductQtyDecreased(command.Id, command.Decrease));
    }
}