using BugStore.Api.Models;
using BugStore.Models;
using MediatR;

namespace BugStore.Requests.Products;

public record Update(Product Product) : IRequest<Responses.Products.Update>;