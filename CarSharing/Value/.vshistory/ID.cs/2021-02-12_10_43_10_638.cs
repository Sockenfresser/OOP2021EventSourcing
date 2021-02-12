using System;

namespace CarSharing.Value
{
    public class ID
    {
        private Guid _guid;

        public ID()
        {
            _guid = Guid.NewGuid();
        }
    }
}