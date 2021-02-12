using CarSharing.Command;

using Xunit;

namespace CarSharing.Test
{
    public class CustomerTests
    {
        [Fact]
        public void Register_New_CostumerRegisteredReturned()
        {
            // when
            var registerCustomerCommand = new RegisterCustomer("ich@irgendwo.com", "Foo", "Bar");
            var customerRegisteredEvent = Customer.Register(registerCustomerCommand);

            // then
            Assert.NotNull(customerRegisteredEvent);
        }
    }
}