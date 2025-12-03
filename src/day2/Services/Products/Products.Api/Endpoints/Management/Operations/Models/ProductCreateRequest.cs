using Facet;
using Products.Api.Endpoints.Management.Handlers;

namespace Products.Api.Endpoints.Management.Operations.Models;


[Facet(typeof(CreateProduct), exclude: ["Id"])]
public partial record ProductCreateRequest;