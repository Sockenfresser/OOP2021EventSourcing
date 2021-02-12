using System;

namespace CarSharing.Value
{
    public class CustomHash
    {
        public Guid Value { get; }

        public CustomHash()
        {
            Value = Guid.NewGuid();
        }
    }
}
