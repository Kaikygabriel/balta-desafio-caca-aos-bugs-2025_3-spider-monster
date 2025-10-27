using BugStore.Api.Models;
using BugStore.Api.Requests.Orders;
using BugStore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Api.Extesions;

public static class MapOrder
{
    public static void UseMapOrder(this WebApplication app)
    {
        app.MapGet("/v1/orders/{id}", async (IMediator mediator, [FromRoute]Guid id) 
            => await mediator.Send(new GetById(id)));
        app.MapPost("/v1/orders", async (IMediator mediator, [FromBody] Order order) =>
        {
            var request = new  Create(order);
            var response= await mediator.Send(request);
            return response.Result ? Results.Created() : Results.BadRequest();
        });
    } 
}