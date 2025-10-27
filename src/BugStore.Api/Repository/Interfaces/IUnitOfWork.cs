using BugStore.Api.Models;
using BugStore.Api.Repository.Interfaces;
using BugStore.Models;

namespace BugStore.Repository.Interfaces;

public interface IUnitOfWork
{
    IRepository<Product> RepositoryProduct { get;}
    IRepository<Customer> RepositoryCustomer { get;}
    IRepository<Order> RepositoryOrder { get;}

    Task CommitAsync();
}