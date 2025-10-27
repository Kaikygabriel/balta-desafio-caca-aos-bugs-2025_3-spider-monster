using BugStore.Repository.Interfaces;

namespace BugStore.Handlers;

public abstract class HandlerBase
{
    protected readonly IUnitOfWork _unitOfWork;
    protected HandlerBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}