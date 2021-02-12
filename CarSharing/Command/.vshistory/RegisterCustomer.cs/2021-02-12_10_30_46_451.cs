namespace CarSharing.Command
{
    public class RegisterCustomer
    {
        public RegisterCustomer(string eMailAddress, string givenName, string familyName)
        {
            EMailAddress = eMailAddress;
            GivenName = givenName;
            FamilyName = familyName;
        }

        public string EMailAddress { get; }
        public string GivenName { get; }
        public string FamilyName { get; }
    }
}