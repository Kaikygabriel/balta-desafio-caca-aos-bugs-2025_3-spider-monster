using BugStore.Api.Models;
using BugStore.Api.Requests.Customers;
using BugStore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Create = BugStore.Api.Requests.Products.Create;
using Delete = BugStore.Api.Requests.Products.Delete;

namespace BugStore.Api.Extesions;

public static class MapProducts
{
    public static void UseMapProducts(this WebApplication app)
    {
        
        app.MapGet("/v1/products",async (IMediator mediator)
            => await mediator.Send(new Get()));
        app.MapGet("/v1/products/{id}", async (IMediator mediator,[FromRoute]Guid id)
            => await mediator.Send(new GetById(id)));
        app.MapPost("/v1/products", async (IMediator mediator, [FromBody] Product product) =>
        {
            var request = new  Create(product);
            var response= await mediator.Send(request);
            return response.Result ? Results.Created() : Results.BadRequest();
        });
        app.MapPut("/v1/products/{id}", async (IMediator mediator, [FromRoute] Guid id, [FromBody] Product product) =>
        {
            var resultGetById = await mediator.Send(new BugStore.Requests.Products.GetById(id));
            if (resultGetById is null|| id != product.Id)
                Results.NotFound();
    
            var resultUpdateCostumer = await mediator.Send(new BugStore.Requests.Products.Update(resultGetById.product));
            return resultUpdateCostumer.Result ? Results.Ok() : Results.BadRequest();

        });
        app.MapDelete("/v1/products/{id}", async (IMediator mediator, [FromRoute] Guid id) =>
        {
            var resultGetById = await mediator.Send(new BugStore.Requests.Products.GetById(id));
            if (resultGetById is null)
                Results.NotFound();
            var resultDeleteCostumer = await mediator.Send(new Delete(resultGetById.product));
            return resultDeleteCostumer.Result ? Results.Ok() : Results.BadRequest();
        });


    }
}