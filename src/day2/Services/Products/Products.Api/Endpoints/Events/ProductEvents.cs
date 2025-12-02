namespace Products.Api.Endpoints.Events;

public record ProductCreated(Guid Id, string Name, decimal Price, int Qty);

public record ProductPriceAdjusted(decimal NewPrice);

public record ProductQtyInventoryAdjusted(decimal NewQty);

public record ProductSold(int Qty);

public record ProductDiscontinued();