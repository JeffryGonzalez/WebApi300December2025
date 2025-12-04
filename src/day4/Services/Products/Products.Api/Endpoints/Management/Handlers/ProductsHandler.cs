using System.Security.Claims;
using JasperFx.Events;
using Marten;
using Products.Api.Endpoints.Management.Events;

using Products.Api.Endpoints.Services;

namespace Products.Api.Endpoints.Management.Handlers;

public class ProductsHandler
{
   

    public record SendProductToOrders(Guid Id);

    public record SendTombstoneProductToOrders(Guid Id);

    // POST endpoint is the source of this command
    public async Task<(StreamAction, SendProductToOrders)> Handle(CreateProduct command, IDocumentSession session, IProvideUserInfo userProvider)
    {
        var (id, name, price, qty, bySub) = command;
        var creator = await userProvider.GetUserInfoFromSubAsync(bySub);
        var @event = new ProductCreated(id, name, price, qty, creator!.Id);
        return (session.Events.StartStream(id, @event), new SendProductToOrders(id));
    }

    public SendTombstoneProductToOrders Handle(DiscontinueProduct command, IDocumentSession session)
    {
        session.Events.Append(command.Id, new ProductDiscontinued(command.Id));
        return new SendTombstoneProductToOrders(command.Id);
    }

    public SendProductToOrders Handle(IncreaseProductQty command, IDocumentSession session)
    {
        session.Events.Append(command.Id, new ProductQtyIncreased(command.Id, command.Increase));
        return new SendProductToOrders(command.Id);
    }

    public SendProductToOrders Handle(DecreaseProductQty command, IDocumentSession session)
    {
        session.Events.Append(command.Id, new ProductQtyDecreased(command.Id, command.Decrease));
        return new SendProductToOrders(command.Id);
    }
}