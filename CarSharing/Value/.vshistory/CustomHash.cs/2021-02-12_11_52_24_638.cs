using System;

namespace CarSharing.Value
{
    public class CustomHash
    {
        public CustomHash()
        {
            Value = Guid.NewGuid();
        }

        public CustomHash(string id)
        {
            if (!Guid.TryParse(id, out var parseResult))
            {
                throw new ArgumentException("Invalid Guid", nameof(id));
            }

            Value = parseResult;
        }

        public Guid Value { get; }
    }
}