using Facet;
using Products.Api.Endpoints.Handlers;
using Wolverine;

namespace Products.Api.Endpoints.Operations;



[Facet(typeof(CreateProduct), exclude: ["Id"])]
public partial record ProductCreateRequest;

[Facet(typeof(CreateProduct))]
public partial record ProductCreatResponse
{ 
    public string Status => "Pending";
}


public static class PostProduct
{
    public static async Task<IResult> AddProductToInventoryAsync(
        ProductCreateRequest request,
        IMessageBus messaging
        )
    {
        var command = new CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Qty);
        
        await messaging.PublishAsync( command );
        return TypedResults.Ok(new ProductCreatResponse(command));
    }
}
