using System;

namespace CarSharing.Value
{
    public class ID
    {
        public ID()
        {
            Value = Guid.NewGuid();
        }

        public Guid Value { get; }
    }
}