# Api Design


## Products

### `POST /products` adds a product

### `GET /products` returns a list of all products



### `GET /products/{id}` Gives us that product or a 404.

### I want to have a way for the api to return all the products for a particular "Manager" that added them.


### `GET /managers/{id}/summary`

```json
{


    // all sorts of crap about the manager, but
    "productsAdded": [
        // a list of the all the products they've added
    ]
}

```

In your API, "map" external IDs to "internal" ids.

We have a *reference* to some data from some other service - identity.


When a request is made where we need to "track" who did it -

Look for the `sub` claim on the request

Look that up in a table to see if you have this person.


if you don't, add them (or redirect them to onboard, whatever)
    - generate an "internal" id that you can use in your messages /urls, all that stuff.
