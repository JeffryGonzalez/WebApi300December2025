# Quiz

## What are "Backing Services" and "Attached Resources"?

We get paid to write stateless services. That means we build APIs and stuff, but they don't want to to pay us
to write a "custom" relational database or something like that.

Also, HTTP is stateless.

Also, if you are running in many environments, you might be using load balancing, and containers are ephemeral.

- storing state (data) in a service between requests is a major HTTP party foul.
- Can be ok sometimes, but will lead to misery.
- Using an "attached resource" for that - like a database, a queue, a cache, etc.



Attached Resources - often "stateful" 
    - Databases, brokers, queues, etc.

Backing services are just other services that we use, like other people's APIs, etc.




## What is Configuration?

Configuration is what changes per environment.

We want to get away from having different builds of our application for different environments. 

REALLY big bad things happen because of that.

So, put that stuff in configuration as much as possible.



## How does Asp.Net Core handle configuration by default? Where does it look for stuff?

The default configuration provider is something like:

- `builder.Configuration.GetXXX`
- AppSettings.Json
- AppSettings.ENVIRONMENT.json (ASPNETCORE_ENVIRONMENT)
- Looks in "User Secrets" (you know how I feel about that - flaky.)
- Looks in actual environment variables on the machine (or pod) where it is running.
- Finally, in command line arguments.

The last place it is found, wins.

```
set $ConnectionStrings__Orders = "the real connection string goes here"
```


## What the heck is going on here?
