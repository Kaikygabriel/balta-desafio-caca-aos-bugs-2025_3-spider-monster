using BugStore.Api.Handlers.Customers;
using BugStore.Test.Mocks;

namespace BugStore.Test.Handlers.Customers.Command.Update;

public class HandlerCustomerUpdate
{
    private readonly Handler _handler;

    public HandlerCustomerUpdate()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    [Theory]
    [MemberData(nameof(UpdateCustomerData))] 
    public async Task HandleUpdateCustomer_ShouldReturnExpectedResult(Api.Requests.Customers.Update request, bool expectedResult)
    {
        var data = await _handler.Handle(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.Result);
    }
    public static IEnumerable<object[]> UpdateCustomerData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
       
        new object[]
        {
            new Api.Requests.Customers.Update
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