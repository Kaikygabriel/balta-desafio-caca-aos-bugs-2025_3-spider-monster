using Azure.Core;
using BugStore.Api.Handlers.Products;
using BugStore.Test.Mocks;

namespace BugStore.Test.Handlers.Product.Command.Create;

public class ProductHandlerTests
{
    private readonly Handler _handler;

    public ProductHandlerTests()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }

    [Theory]
    [MemberData(nameof(CreateProductData))] 
    public async Task HandleCreateProduct_ShouldReturnExpectedResult(Api.Requests.Products.Create request, bool expectedResult)
    {
        var data = await _handler.Handle(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> CreateProductData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
        new object[]
        {
            new Api.Requests.Products.Create
            (
                new Api.Models.Product
                {
                    Description = "teste",
                    Id = Guid.NewGuid(),
                    Price = 13,
                    Slug = "teste",
                    Title = "teste"
                }
            ),
            true
        },
        new object[]
        {
            new Api.Requests.Products.Create
            (
                new Api.Models.Product
                {
                    Description = "teste2",
                    Id = Guid.NewGuid(),
                    Price = 23,
                    Slug = "teste2",
                    Title = "teste2"
                }
            ),
            true
        }
    };
}