using MediatR;

namespace BugStore.Api.Requests.Customers;

public record Get : IRequest<Responses.Customers.Get>;