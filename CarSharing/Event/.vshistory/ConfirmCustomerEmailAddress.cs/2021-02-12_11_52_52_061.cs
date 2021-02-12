using CarSharing.Value;

namespace CarSharing.Event
{
    public class ConfirmCustomerEmailAddress
    {
        public ConfirmCustomerEmailAddress(string customerID, string confirmationHash)
        {
            Id = new ID(customerID);
            Hash = new CustomHash(confirmationHash);
        }

        public ID Id { get; private set; }
        public CustomHash Hash { get; private set; }
    }
}