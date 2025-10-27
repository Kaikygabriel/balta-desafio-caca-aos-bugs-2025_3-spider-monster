using MediatR;

namespace BugStore.Api.Requests.Customers;

public record GetById(Guid Id) : IRequest<Responses.Customers.GetById>;