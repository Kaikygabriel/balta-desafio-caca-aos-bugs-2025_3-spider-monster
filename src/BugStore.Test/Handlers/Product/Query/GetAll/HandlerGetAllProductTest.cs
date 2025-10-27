using BugStore.Api.Handlers.Products;
using BugStore.Api.Requests.Products;
using BugStore.Test.Mocks;
using Get = BugStore.Responses.Products.Get;

namespace BugStore.Test.Handlers.Product.Query.GetAll;

public class HandlerGetAllProductTest
{
    private readonly Handler _handler;

    public HandlerGetAllProductTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }

    [Fact]
    public async Task GetAllProducts_Return_ListProducts()
    {
        var result = await _handler.Handle(new Api.Requests.Products.Get(),CancellationToken.None);
        Assert.IsType<List<Api.Models.Product>>(result.Products);
    }
}