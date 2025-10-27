using BugStore.Api.Models;
using MediatR;

namespace BugStore.Api.Requests.Customers;

public record Create(Customer Customer) :IRequest<Responses.Customers.Create>;