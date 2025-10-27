using BugStore.Api.Handlers.Order;
using BugStore.Test.Mocks;

namespace BugStore.Test.Handlers.Order.Command.Create;

public class HandlerOrderCreate
{
    private readonly Handler _handler;

    public HandlerOrderCreate()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    
    [Theory]
    [MemberData(nameof(CreateOrderData))] 
    public async Task HandleCreateOrder_ShouldReturnExpectedResult(Api.Requests.Orders.Create request, bool expectedResult)
    {
        var data = await _handler.Handle(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> CreateOrderData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
        new object[]
        {
            new Api.Requests.Orders.Create
            (
                new Api.Models.Order()
                {
                    Id = Guid.NewGuid(),
                }
            ),
            true
        },
    };
} 