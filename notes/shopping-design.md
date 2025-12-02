# Shopping Design


## Orders API
###  Customer Places an Order

They have:

- Identity
- And a shopping cart.
    - The cart is a list of products with quantities.

```http 
POST /orders
Authorization: Bearer {{jwt}}
Content-Type: application/json

{
    "items": [
        { "id": "100", "qty": 3, "price": 2.99},
        { "id": "99", "qty": 1, "price": 22.32}
    ]
}
```

```http
GET https://localhost:4000/products
```

```http
GET https://localhost:4000/cart
```

```http
GET https://localhost:4000/orders
```

Through the identity, we can get the credit card information. 
(We'll go into this later)

The code making this request needs a list of things -

## Products 

We need an endpoint that allows customers to retrieve a list of products.
Maybe search? category?

Oh, and we are going to need a way for internal people to add, remove, etc.
products.

## Shopping Cart

Probably going to need a "Store" resource for the shopping cart.
More on this later.

