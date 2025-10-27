using BugStore.Api.Handlers.Customers;
using BugStore.Test.Mocks;

namespace BugStore.Test.Handlers.Customers.Command.Delete;

public class HandlerCustomerDeleteTest
{
    private readonly Handler _handler;

    public HandlerCustomerDeleteTest()
    {
        _handler = new Handler(new FakeUnitOfWork());
    }
    [Theory]
    [MemberData(nameof(DeleteCustomerData))] 
    public async Task HandleDeleteCustomer_ShouldReturnExpectedResult(Api.Requests.Customers.Delete request, bool expectedResult)
    {
        var data = await _handler.Handle(request, CancellationToken.None);
        Assert.Equal(expectedResult, data.result);
    }
    public static IEnumerable<object[]> DeleteCustomerData => new List<object[]>
    {
        new object[]
        {
            null,
            false
        },
       
        new object[]
        {
            new Api.Requests.Customers.Delete
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