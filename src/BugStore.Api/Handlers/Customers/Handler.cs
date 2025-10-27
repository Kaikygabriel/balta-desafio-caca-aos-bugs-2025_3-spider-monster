using BugStore.Handlers;
using BugStore.Repository.Interfaces;
using BugStore.Responses.Customers;
using BugStore.Api.Models;
using MediatR;

namespace BugStore.Api.Handlers.Customers;

public class Handler :
    HandlerBase,
    IRequestHandler<Requests.Customers.Create,Responses.Customers.Create>,
    IRequestHandler<Requests.Customers.Delete,Responses.Customers.Delete>,
    IRequestHandler<Requests.Customers.Update,Responses.Customers.Update>,
    IRequestHandler<Requests.Customers.GetById,Responses.Customers.GetById>,
    IRequestHandler<Requests.Customers.Get,Responses.Customers.Get>

{
    public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Create> Handle(Requests.Customers.Create request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.RepositoryCustomer.Create(request.Customer);
            await _unitOfWork.CommitAsync();
            return new Create(true);
        }
        catch (Exception e)
        {
            return new Create(false);
        }
    }

    public async Task<Delete> Handle(Requests.Customers.Delete request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.RepositoryCustomer.Delete(request.Customers);
            await _unitOfWork.CommitAsync();
            return new Delete(true);
        }
        catch (Exception e)
        {
            return new Delete(false);
        }
    }

    public async Task<Update> Handle(Requests.Customers.Update request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.RepositoryCustomer.Update(request.Customer);
            await _unitOfWork.CommitAsync();
            return new Update(true);
        }
        catch (Exception e)
        {
            return new Update(false);
        }
    }

    public async Task<GetById> Handle(Requests.Customers.GetById request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var customer = await _unitOfWork.RepositoryCustomer.GetByPredicate(x => x.Id == id);
        return new GetById(customer);
    }

    public async Task<Get> Handle(Requests.Customers.Get request, CancellationToken cancellationToken)
    {
        return new Get(await _unitOfWork.RepositoryCustomer.GetAll());
    }
}