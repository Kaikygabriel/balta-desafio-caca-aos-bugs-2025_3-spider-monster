using BugStore.Api.Models;
using BugStore.Models;

namespace BugStore.Responses.Products;

public record Get(IEnumerable<Product>Products);