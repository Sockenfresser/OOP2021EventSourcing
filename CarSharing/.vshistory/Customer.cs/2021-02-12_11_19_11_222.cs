using System.Collections.Generic;

using CarSharing.Command;
using CarSharing.Event;

namespace CarSharing
{
    public class Customer
    {
        public static CustomerRegistered Register(RegisterCustomer registerCustomer)
        {
            return new CustomerRegistered(
                registerCustomer.ID,
                registerCustomer.EMailAddress,
                registerCustomer.ConfirmationHash,
                registerCustomer.PersonName);
        }

        public static Customer Reconstitute(IEnumerable<IEvent> events)
        {

        }
    }
}