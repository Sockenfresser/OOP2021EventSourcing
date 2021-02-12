namespace CarSharing.Value
{
    public class EmailAddress
    {
        public EmailAddress(string emailAddress)
        {
            Value = emailAddress;
        }

        public string Value { get; }
    }
}