using BugStore.Api.Models;
using MediatR;

namespace BugStore.Api.Requests.Products;

public record Create(Product Product): IRequest<Responses.Products.Create>;