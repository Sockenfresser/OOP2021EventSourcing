using System;

namespace CarSharing.Value
{
    public class ID
    {
        public ID()
        {
            Value = Guid.NewGuid();
        }

        public ID(string id)
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