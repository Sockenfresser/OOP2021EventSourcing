using System.Collections.Generic;
using System.Linq;

using CarSharing.Command;
using CarSharing.Event;
using CarSharing.Value;

namespace CarSharing
{
    public class Customer
    {
        public Customer(ID id)
        {
            Id = id;
        }

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
            var customerRegisteredEvents = from dddEvent in events
                   where dddEvent is CustomerRegistered
                   select dddEvent;
        }

        public ID Id { get; }
    }
}