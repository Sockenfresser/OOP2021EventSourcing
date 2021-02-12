using System;

using CarSharing.Value;

namespace CarSharing.Event
{
    public class CustomerEmailAddressConfirmed : IEvent
    {
        public CustomerEmailAddressConfirmed(ID id)
        {
            Id = id;
        }

        public ID Id { get; set; }
    }
}