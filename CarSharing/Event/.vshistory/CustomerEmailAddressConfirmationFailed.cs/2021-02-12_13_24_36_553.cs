using CarSharing.Value;

namespace CarSharing.Event
{
    public class CustomerEmailAddressConfirmationFailed
    {
        public CustomerEmailAddressConfirmationFailed(ID id)
        {
            Id = id;
        }

        public ID Id { get; set; }
    }
}