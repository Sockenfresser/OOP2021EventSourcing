using System;

namespace CarSharing.Value
{
    public class PersonName
    {
        public string GivenName { get; }
        public string FamilyName { get; }

        public PersonName(string givenName, string familyName)
        {
            if (string.IsNullOrWhiteSpace(givenName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(givenName));
            }
            if (string.IsNullOrWhiteSpace(familyName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(familyName));
            }

            GivenName = givenName;
            FamilyName = familyName;
        }
    }
}
