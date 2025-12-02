# Apps - What I Mean


- Your team is delivering something.

What we are delivering is:

An app that allows users to:

- Browse a catalog of products.
- Add those products to a shopping cart.
- Create a user account that has your billing information.
- Place orders.
- etc. etc.

- This will be available through an HTTP-based API (A "Web API") at a specific server "authority" (e.g. api.shopping-stuff.com/).
    - it could and probably would also be available through a user interface of some sort - but that's another course. (e.g. www.shopping-stuff.com/)
        - Consider a BFF - more on this later.


- we could build this as a "monolith"
    - One solution, one repo, one big old project with a bunch of API endpoints (controllers, whatever)
- we could build this a "monorepo"
    - One solution, one repo, several projects, some of which can be APIs that take on part of the responsibilities listed above.
        - Why would we do this?
    - Affected: https://github.com/leonardochaia/dotnet-affected
- we *could* do this as a bunch of separate solutions, repos, each with a bit of functionality.
    - this way leads to madness.