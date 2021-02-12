using CarSharing.Value;

namespace CarSharing.Command
{
    public class ChangeCustomersName
    {
        public ID Id { get; private set; }
        public PersonName PersonName { get; private set; }

        public ChangeCustomersName(string id, string givenName, string familyName)
        {
            Id = new ID(id);
            PersonName = new PersonName(givenName, familyName);
            
        }
    }
}