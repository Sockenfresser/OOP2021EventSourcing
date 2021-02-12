using System;

namespace CarSharing.Value
{
    public class ID
    {
        public Guid Guid1 { get; }

        public ID()
        {
            Guid1 = Guid.NewGuid();
        }
    }
}