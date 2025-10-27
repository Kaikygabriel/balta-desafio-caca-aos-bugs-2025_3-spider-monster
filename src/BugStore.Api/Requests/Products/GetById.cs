using MediatR;

namespace BugStore.Requests.Products;

public record GetById(Guid Id):IRequest<Responses.Products.GetById>;