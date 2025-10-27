using BugStore.Models;
using BugStore.Models.Abstraction;

namespace BugStore.Api.Models;

public class Order : Entity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<OrderLine> Lines { get; set; } = null;
}