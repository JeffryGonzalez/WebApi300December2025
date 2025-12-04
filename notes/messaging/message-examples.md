# Message Examples

## Event With References and Embedded

`CustomerPlacedOrder` on a topic about customers.

### Header

```json
"key": "{{customerid}}"
"datetime": "{{datetime}}"
```

### Value

```json

"links": [
    "products": [
        {
            "rel": "product", "value": 13
        },
         {
            "rel": "product", "value": 18
        }
    ]
],

"embedded": [
    "products": {
        "13": {
            "price": 3.23,
            "name": "Eggs",
            "qty": 8,
            "version": "{{version, timestamp, whatever}}"
        },
        "18": {
            "price": 5.23,
            "name": "Beer",
            "qty": 8,
            "version": "{{version, timestamp, whatever}}"
        }
    },
    "customer": {
        "id": 32,
        // anything else you want to "embed" about the state of the customer THEN
        "version": 3
    }
],

"totalAmountPaid": 299.23


```
