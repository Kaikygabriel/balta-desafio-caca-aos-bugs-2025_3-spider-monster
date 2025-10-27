using BugStore.Api.Models;
using BugStore.Models;

namespace BugStore.Responses.Customers;

public record Get(IEnumerable<Customer> Customers);