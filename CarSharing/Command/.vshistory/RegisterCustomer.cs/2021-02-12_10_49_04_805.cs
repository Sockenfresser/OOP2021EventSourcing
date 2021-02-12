using CarSharing.Value;

namespace CarSharing.Command
{
    public class RegisterCustomer
    {
        public RegisterCustomer(string eMailAddress, string givenName, string familyName)
        {
            EMailAddress = new EmailAddress(eMailAddress);
            PersonName = new PersonName(givenName, familyName);

            
        }

        public EmailAddress EMailAddress { get; }
        public PersonName PersonName { get; }
        public ID ID { get; }
        public CustomerHash ConfirmationHash { get; }
    }
}