using System;
using System.Text.RegularExpressions;

namespace CarSharing.Value
{
    public class EmailAddress
    {
        private static Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public EmailAddress(string emailAddress)
        {
            if (!regex.IsMatch(emailAddress))
            {
                throw new ArgumentException("Email Address Invalid!", nameof(emailAddress));
            }

            Value = emailAddress;
        }

        public string Value { get; }
    }
}