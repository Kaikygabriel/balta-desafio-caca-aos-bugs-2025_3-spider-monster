using BugStore.Api.Handlers.Products;
using BugStore.Test.Mocks;

namespace BugStore.Test.Handlers.Product.Command.Update;

public class HandlerProductUpdateTest
{
    private readonly Handler _handler;

    public HandlerProductUpdateTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }

    [Theory]
    [MemberData(nameof(CreateProductData))]
    public async Task HandleUpdateProduct_ShouldReturnExpectedResult(Api.Requests.Products.Delete request,
        bool expectedResult)
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
            new Api.Requests.Products.Delete
            (
                new Api.Models.Product
                {
                    Id = Guid.NewGuid(),
                    Title = "Camiseta Básica",
                    Description = "Camiseta 100% algodão, confortável e leve.",
                    Slug = "camiseta-basica",
                    Price = 49.90m
                }
            ),
            true
        }
    };
}