using BugStore.Api.Models;
using MediatR;

namespace BugStore.Api.Requests.Customers;

public record Delete(Customer Customers) : IRequest<Responses.Customers.Delete>;