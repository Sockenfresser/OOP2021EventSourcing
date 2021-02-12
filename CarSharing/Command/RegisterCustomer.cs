using CarSharing.Value;

namespace CarSharing.Command
{
    public class RegisterCustomer
    {
        public RegisterCustomer(string eMailAddress, string givenName, string familyName)
        {
            EMailAddress = new EmailAddress(eMailAddress);
            PersonName = new PersonName(givenName, familyName);
            ID = new ID();
            ConfirmationHash = new CustomHash();
            
        }

        public EmailAddress EMailAddress { get; }
        public PersonName PersonName { get; }
        public ID ID { get; }
        public CustomHash ConfirmationHash { get; }
    }
}