using System.Collections.Generic;

using CarSharing.Command;
using CarSharing.Event;
using CarSharing.Value;

namespace CarSharing
{
    public class Customer
    {
        private Customer() { }

        public ID Id { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public CustomHash Hash { get; private set; }
        public PersonName PersonName { get; private set; }
        public bool IsEmailAddressConfirmed { get; set; }

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
                    case CustomerEmailAddressConfirmed _:
                        result.IsEmailAddressConfirmed = true;
                        break;
                }
            }

            return result;
        }

        public IEvent ConfirmCustomerEmailAddress(
            ConfirmCustomerEmailAddress confirmCustomerEmailAddressEvent)
        {
            if (Hash.Value != confirmCustomerEmailAddressEvent.Hash.Value)
            {
                return new CustomerEmailAddressConfirmationFailed(Id);
            }

            if (IsEmailAddressConfirmed)
            {
                return null;
            }

            return new CustomerEmailAddressConfirmed(confirmCustomerEmailAddressEvent.Id);
        }

        public IEvent ChangeCustomerEmailAddress(ChangeCustomerEmailAddress changeCustomerEmailAddress)
        {
            return null
        }
    }
}