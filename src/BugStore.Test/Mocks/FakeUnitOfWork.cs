using BugStore.Api.Models;
using BugStore.Api.Repository.Interfaces;
using BugStore.Models;
using BugStore.Repository.Interfaces;

namespace BugStore.Test.Mocks;

public class FakeUnitOfWork : IUnitOfWork
{
    public IRepository<Product> RepositoryProduct { get; } = new FakeRepositoryProduct();
    public IRepository<Customer> RepositoryCustomer { get; } = new FakeRepositoryCustomer();
    public IRepository<Order> RepositoryOrder { get; }= new FakeRepositoryOrder();
    public async Task CommitAsync()
    {
        await Task.Delay(0);
    }
}