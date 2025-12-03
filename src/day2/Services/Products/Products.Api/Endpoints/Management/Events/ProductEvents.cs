using Facet;
using Products.Api.Endpoints.Management.Handlers;

namespace Products.Api.Endpoints.Management.Events;

// Things that have happened. So we use past-tense in the naming.
// And these are usually the things the "business" cares about.




public record ProductCreated(Guid Id, string Name, decimal Price, int Qty);

public record ProductPriceAdjusted(decimal NewPrice);

[Facet(typeof(IncreaseProductQty))]
public partial record ProductQtyIncreased;

[Facet(typeof(DecreaseProductQty))]
public partial record ProductQtyDecreased;

public record ProductDiscontinued(Guid Id);