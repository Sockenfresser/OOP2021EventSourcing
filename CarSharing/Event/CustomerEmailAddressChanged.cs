using CarSharing.Value;

namespace CarSharing.Event
{
    public class CustomerEmailAddressChanged : IEvent
    {
        public ID CustomerId { get; }
        public EmailAddress EmailAddress { get; }
        public CustomHash ConfirmationHash { get; }

        public CustomerEmailAddressChanged(ID customerId, EmailAddress emailAddress, CustomHash confirmationHash)
        {
            CustomerId = customerId;
            EmailAddress = emailAddress;
            ConfirmationHash = confirmationHash;
        }
        
    }
}