using BugStore.Api.Requests.Products;
using BugStore.Handlers;
using BugStore.Repository.Interfaces;
using BugStore.Requests.Products;
using MediatR;

namespace BugStore.Api.Handlers.Products;

public class Handler:
    HandlerBase,
    IRequestHandler<Create,Responses.Products.Create>,
    IRequestHandler<Update,Responses.Products.Update>,
    IRequestHandler<Delete,Responses.Products.Delete>,
    IRequestHandler<GetById,Responses.Products.GetById>,
    IRequestHandler<Get,Responses.Products.Get>
{
    public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Responses.Products.Create> Handle(Create request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.RepositoryProduct.Create(request.Product);
            await _unitOfWork.CommitAsync();
            return new Responses.Products.Create(true);
        }
        catch (Exception e)
        {
            return new Responses.Products.Create(false);
        }
    }

    public async Task<Responses.Products.Update> Handle(Update request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.RepositoryProduct.Update(request.Product);
            await _unitOfWork.CommitAsync();
            return new Responses.Products.Update(true);
        }
        catch (Exception e)
        {
            return new Responses.Products.Update(false);
        }
    }

    public async Task<Responses.Products.Delete> Handle(Delete request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.RepositoryProduct.Delete(request.Product);
            await _unitOfWork.CommitAsync();
            return new Responses.Products.Delete(true);
        }
        catch (Exception e)
        {
            return new Responses.Products.Delete(false);
        }
    }

    public  async Task<Responses.Products.GetById> Handle(GetById request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var product = await _unitOfWork.RepositoryProduct.GetByPredicate(x => x.Id == id);
        return new Responses.Products.GetById(product);
    }

    public async Task<Responses.Products.Get> Handle(Get request, CancellationToken cancellationToken)
    {
        return new Responses.Products.Get(await _unitOfWork.RepositoryProduct.GetAll());
    }
    
}