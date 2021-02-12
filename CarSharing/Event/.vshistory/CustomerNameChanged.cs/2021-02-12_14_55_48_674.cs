﻿using CarSharing.Value;

namespace CarSharing.Event
{
    public class CustomerNameChanged
    {
        public ID CustomerId { get; }
        public PersonName NewName { get; }

        public CustomerNameChanged(ID customerId, PersonName newName)
        {
            CustomerId = customerId;
            NewName = newName;
        }
    }
}