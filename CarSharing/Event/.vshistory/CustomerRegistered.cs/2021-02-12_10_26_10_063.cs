using ConsoleApp1.Domain.Customer.Value;

namespace CarSharing.Event
{
    public class CustomerRegistered
    {
        public ID CustomerId { get; }
        public EmailAddress EmailAddress { get; }
        public CustomHash Hash { get; }
        public PersonName PersonName { get; }

        public CustomerRegistered(ID customerId, EmailAddress emailAddress, CustomHash hash, PersonName personName)
        {
            CustomerId = customerId;
            EmailAddress = emailAddress;
            Hash = hash;
            PersonName = personName;
        }
    }
}