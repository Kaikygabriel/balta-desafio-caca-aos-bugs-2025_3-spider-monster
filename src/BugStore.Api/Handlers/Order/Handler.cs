using BugStore.Handlers;
using BugStore.Repository.Interfaces;
using MediatR;
using Create = BugStore.Api.Requests.Orders.Create;
using GetById = BugStore.Api.Requests.Orders.GetById;

namespace BugStore.Api.Handlers.Order;

public class Handler :
    HandlerBase,
    IRequestHandler<GetById,Responses.Orders.GetById>,
    IRequestHandler<Create,Responses.Orders.Create>
{
    public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Responses.Orders.GetById> Handle(GetById request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.RepositoryOrder.GetByPredicate(x => x.Id == request.Id);
        return new Responses.Orders.GetById(order);
    }

    public async Task<Responses.Orders.Create> Handle(Create request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.RepositoryOrder.Create(request.Order);
            await _unitOfWork.CommitAsync();
            return new Responses.Orders.Create(true);
        }
        catch (Exception e)
        {
            return new Responses.Orders.Create(false);
        }
    }
}