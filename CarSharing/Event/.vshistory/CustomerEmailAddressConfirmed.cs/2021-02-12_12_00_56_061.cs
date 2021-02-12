using System;

using CarSharing.Value;

namespace CarSharing.Event
{
    public class CustomerEmailAddressConfirmed : IEvent
    {
        public ID Id { get; set; }
    }
}