using System.Collections.Generic;
using System.Linq;

using CarSharing.Command;
using CarSharing.Event;
using CarSharing.Value;

namespace CarSharing
{
    public class Customer
    {
        private Customer()
        {
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
            var result = new Customer();

            foreach (var @event in events)
            {
                switch (@event)
                {
                    case CustomerRegistered customerRegistered:
                        result.Id = customerRegistered.CustomerId;
                        result.PersonName = customerRegistered.PersonName;
                        result.Hash = customerRegistered.Hash;
                        result.EmailAddress = customerRegistered.EmailAddress;
                        break;
                }
            }


            return result;
        }

        public ID Id { get; private set; }
        public EmailAddress EmailAddress { get; set; }
        public CustomHash Hash { get; set; }
        public PersonName PersonName { get; set; }

        public IEvent ConfirmCustomerEmailAddress(ConfirmCustomerEmailAddress confirmCustomerEmailAddressEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}