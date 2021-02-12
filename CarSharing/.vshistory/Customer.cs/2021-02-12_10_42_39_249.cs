using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarSharing.Event;
using CarSharing.Value;

using ConsoleApp1.Domain.Customer.Value;

namespace CarSharing
{
    public class Customer
    {
        public static Event.CustomerRegistered Register(Command.RegisterCustomer registerCustomer)
        {
            return new CustomerRegistered(ID.Generate(), new EmailAddress(registerCustomer.EMailAddress), );
        }
    }
}
