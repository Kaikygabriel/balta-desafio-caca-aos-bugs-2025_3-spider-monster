using BugStore.Api.Handlers.Customers;
using BugStore.Test.Mocks;

namespace BugStore.Test.Handlers.Customers.Command.Create;

public class HandlerCustomerCreateTest
{
    private readonly Handler _handler;

    public HandlerCustomerCreateTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    [Theory]
    [MemberData(nameof(CreateCustomerData))] 
    public async Task HandleCreateCustomer_ShouldReturnExpectedResult(Api.Requests.Customers.Create request, bool expectedResult)
    {
        var data = await _handler.Handle(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.result);
    }
    public static IEnumerable<object[]> CreateCustomerData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
        new object[]
        {
            new Api.Requests.Customers.Create
            (
                new Api.Models.Customer()
                {
                    Id = Guid.NewGuid(),
                    BirthDate   = DateTime.Now,
                    Email = "email@teste",
                    Name = "teste"
                }
            ),
            true
        }
    };
}