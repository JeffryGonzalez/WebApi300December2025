using Wolverine;

namespace Products.Api.Endpoints.Operations;

// if you are using a controller, fine... 

// What are the models?
public record ProductCreateRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}



// What are the commands?

public record CreateProduct
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required decimal Price { get; set; }

    public required int Qty { get; set;  }
    //public Guid ManagerId { get; set; } 
}



public static class PostProduct
{
    public static async Task<IResult> AddProductToInventoryAsync(
        ProductCreateRequest request,
        IMessageBus messaging
        
        )
    {

        var command = new CreateProduct
        {

            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price,
            Qty = request.Quantity

        };
        await messaging.PublishAsync( command );
        return TypedResults.Ok(command);
    }
}
