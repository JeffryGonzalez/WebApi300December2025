## Adding a new product

Concurrency - we forget about this often.

- Change the Resource

POST https://localhost:4100/products-additions


It creates a new stream and puts on that stream the Product Created event.



```http
POST https://localhost:4100/products
Content-Type: application/json

{
    "name": "Chocolate Syrup",
    "price": 4.87,
    "qty": 12
}
```

// "Safe" - GET requests don't change anything about the
// thing you are getting. 

## Get that product

```http
GET https://localhost:4100/products/11bc5680-e298-4905-b9aa-e4e5b04e2845
Accept: application/json

```

## Update the Qty 


```http
POST https://localhost:4100/products/11bc5680-e298-4905-b9aa-e4e5b04e2845/inventory-adjustments
Content-Type: application/json

{
    "id": "11bc5680-e298-4905-b9aa-e4e5b04e2845",
    "newQty": 1200,
    "version": 1
}
```


```http
GET https://localhost:4100/products/11bc5680-e298-4905-b9aa-e4e5b04e2845/inventory-change-history
```

```http
DELETE https://localhost:4100/products/11bc5680-e298-4905-b9aa-e4e5b04e2845
```



The web (http) handles this with conditional POST/PUT/DELETE

the header for a version is "E-Tag" (entity tag)

It can be ANYTHING

And then you can program your API to say:

If you are going to modify a thing, you can do it conditionally on the fact that the E-Tag is still the same.


