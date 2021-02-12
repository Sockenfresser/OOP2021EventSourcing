using System;

namespace CarSharing.Value
{
    public class CustomHash
    {
        public CustomHash()
        {
            Value = Guid.NewGuid();
        }

        public CustomHash(string hash)
        {
            if (!Guid.TryParse(hash, out var parseResult))
            {
                throw new ArgumentException("Invalid Guid", nameof(hash));
            }

            Value = parseResult;
        }

        public Guid Value { get; }
    }
}