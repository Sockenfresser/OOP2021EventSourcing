using CarSharing.Value;

namespace CarSharing.Event
{
    public class CustomerEmailAddressConfirmationFailed : IEvent
    {
        public CustomerEmailAddressConfirmationFailed(ID id)
        {
            Id = id;
        }

        public ID Id { get; set; }
    }
}