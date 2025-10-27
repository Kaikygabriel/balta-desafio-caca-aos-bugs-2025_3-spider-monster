using MediatR;

namespace BugStore.Api.Requests.Products;

public record Get : IRequest<Responses.Products.Get>;