using BugStore.Api.Models;
using MediatR;

namespace BugStore.Api.Requests.Customers;

public record Update(Customer Customer) : IRequest<Responses.Customers.Update>;