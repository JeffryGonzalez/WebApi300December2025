using Marten;
using Microsoft.AspNetCore.Http.HttpResults;
using Products.Api.Endpoints.ReadModels;

namespace Products.Api.Endpoints.Operations;

public static  class GetProduct
{
    public static async Task<IResult> GetProductByIdAsync(Guid id, IDocumentSession session)
    {

        // Go through EVERY event related to the stream with this id, and apply them to this read model
        var readModel = await session.Events.AggregateStreamAsync<ProductDetails>(id);

        if(readModel is null)
        {
            return TypedResults.NotFound();
        } else
        {
            return TypedResults.Ok(readModel);
        }

    }
}
