using MediatR;

namespace BugStore.Api.Requests.Orders;

public record GetById(Guid Id):IRequest<Responses.Orders.GetById>;