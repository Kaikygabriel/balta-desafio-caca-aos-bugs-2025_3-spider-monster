using BugStore.Api.Models;
using BugStore.Models.Abstraction;

namespace BugStore.Models;

public class OrderLine : Entity
{
    public Guid OrderId { get; set; }
    
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}