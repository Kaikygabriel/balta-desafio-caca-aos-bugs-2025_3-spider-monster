using BugStore.Api.Models;
using BugStore.Api.Requests.Customers;
using BugStore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Api.Extesions;

public static class MapCustomers
{
    public static void UseMapCustomers(this WebApplication app)
    {
        
        app.MapGet("/v1/customers", async (IMediator mediator)
            => await mediator.Send(new Get()));
        app.MapGet("/v1/customers/{id}", async (IMediator mediator,[FromRoute]Guid id) 
            => await mediator.Send(new GetById(id)));
        app.MapPost("/v1/customers", async (IMediator mediator,[FromBody] Customer customer) =>
        {
            var request = new  Create(customer);
            var response= await mediator.Send(request);
            return response.result ? Results.Created() : Results.BadRequest();
        });
        app.MapPut("/v1/customers/{id}",async (IMediator mediator,[FromRoute]Guid id,[FromBody]Customer customer)  =>
        {
            var resultGetById = await mediator.Send(new GetById(id));
            if (resultGetById is null|| id != customer.Id)
                Results.NotFound();
    
            var resultUpdateCostumer = await mediator.Send(new Update(resultGetById.Customer));
            return resultUpdateCostumer.Result ? Results.Ok() : Results.BadRequest();
        });
        app.MapDelete("/v1/customers/{id}", async (IMediator mediator,[FromRoute]Guid id)=>
        {
            var resultGetById = await mediator.Send(new GetById(id));
            if (resultGetById is null)
                Results.NotFound();
            var resultDeleteCostumer = await mediator.Send(new Delete(resultGetById.Customer));
            return resultDeleteCostumer.result ? Results.Ok() : Results.BadRequest();
        });

    } 
}