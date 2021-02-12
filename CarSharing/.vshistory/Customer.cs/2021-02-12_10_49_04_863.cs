using CarSharing.Command;
using CarSharing.Event;
using CarSharing.Value;

namespace CarSharing
{
    public class Customer
    {
        public static CustomerRegistered Register(RegisterCustomer registerCustomer)
        {
            return new CustomerRegistered(
                new ID(),
                new EmailAddress(registerCustomer.EMailAddress),
                new CustomHash(),
                new PersonName(registerCustomer.GivenName, registerCustomer.FamilyName));
        }
    }
}