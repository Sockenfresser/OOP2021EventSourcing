using CarSharing.Value;

namespace CarSharing.Command
{
    public class ChangeCustomerEmailAddress
    {
        public ChangeCustomerEmailAddress(string id, string newEmailAddress)
        {
            Id = new ID(id);
            EmailAddress = new EmailAddress(newEmailAddress);
            Hash = new CustomHash();
        }

        public ID Id { get; }
        public EmailAddress EmailAddress { get; }
        public CustomHash Hash { get; }
    }
}