namespace ConsoleApp1.Domain.Customer.Value
{
    public class PersonName
    {
        public string GivenName { get; }
        public string FamilyName { get; }

        public PersonName(string givenName, string familyName)
        {
            GivenName = givenName;
            FamilyName = familyName;
        }
    }
}
