using BugStore.Api.Models;
using BugStore.Api.Repository.Interfaces;
using BugStore.Data;
using BugStore.Models;
using BugStore.Repository.Interfaces;

namespace BugStore.Repository;

public class UnitOfWork : IUnitOfWork
{
    private Repository<Customer> _repositoryCustomer;
    private Repository<Product> _repositoryProduct;
    private Repository<Order> _repositoryOrder;
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<Product> RepositoryProduct
    {
        get
        {
            return _repositoryProduct = _repositoryProduct ?? new Repository<Product>(_context);
        }
    }

    public IRepository<Customer> RepositoryCustomer
    {
        get
        {
            return _repositoryCustomer = _repositoryCustomer ?? new Repository<Customer>(_context);
        }
    }

    public IRepository<Order> RepositoryOrder
    {
        get
        {
            return _repositoryOrder = _repositoryOrder ?? new Repository<Order>(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}