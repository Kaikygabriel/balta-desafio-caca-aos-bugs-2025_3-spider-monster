using BugStore.Api.Models;
using MediatR;

namespace BugStore.Api.Requests.Orders;

public record Create(Order Order): IRequest<Responses.Orders.Create>;