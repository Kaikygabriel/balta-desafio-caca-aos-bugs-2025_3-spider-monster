using BugStore.Api.Models;
using MediatR;

namespace BugStore.Api.Requests.Products;

public record Delete(Product Product) : IRequest<Responses.Products.Delete>;