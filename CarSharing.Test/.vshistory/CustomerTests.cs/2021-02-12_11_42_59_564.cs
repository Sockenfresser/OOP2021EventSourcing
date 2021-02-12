using System;
using System.Collections.Generic;

using CarSharing.Command;
using CarSharing.Event;
using CarSharing.Value;

using Xunit;

namespace CarSharing.Test
{
    public class CustomerTests
    {
        [Fact]
        public void Register_New_CostumerRegisteredReturned()
        {
            // when
            var emailAddress = "ich@irgendwo.com";
            var givenName = "Foo";
            var familyName = "Bar";
            var registerCustomerCommand = new RegisterCustomer(emailAddress, givenName, familyName);
            var customerRegisteredEvent = Customer.Register(registerCustomerCommand);

            // then
            Assert.NotNull(customerRegisteredEvent);
            Assert.Equal(emailAddress, customerRegisteredEvent.EmailAddress.Value);
            Assert.Equal(givenName, customerRegisteredEvent.PersonName.GivenName);
            Assert.Equal(familyName, customerRegisteredEvent.PersonName.FamilyName);
            Assert.NotEqual(Guid.Empty, customerRegisteredEvent.CustomerId.Value ); 
            Assert.NotEqual(Guid.Empty, customerRegisteredEvent.Hash.Value);
        }

        [Fact]
        public void Reconstitute_CorrectCustomerRegisteredEvent_CustomerCreated()
        {
            // arrange
            ID customerId = new ID();
            EmailAddress emailAddress = new EmailAddress("foo@bar.com");
            CustomHash hash = new CustomHash();
            PersonName personName = new PersonName("given", "fam");
            var customerRegisteredEvent = new CustomerRegistered(customerId, emailAddress, hash, personName);

            // act
            var reconstituteResult = Customer.Reconstitute(new List<IEvent> { customerRegisteredEvent });

            // assert
            Assert.Equal(customerId, reconstituteResult.Id );
            Assert.Equal(emailAddress, reconstituteResult.EmailAddress );
            Assert.Equal(hash, reconstituteResult.Hash );
            Assert.Equal(PersonName, reconstituteResult.PersonName );
        }

        [Fact]
        public void ConfirmCustomerEmailAddress_CorrectConfirmation()
        {
            // given
            ID customerId = new ID();
            EmailAddress emailAddress = new EmailAddress("foo@bar.com");
            CustomHash hash = new CustomHash();
            PersonName personName = new PersonName("given", "fam");
            var customerRegisteredEvent = new CustomerRegistered(customerId, emailAddress, hash, personName);

            // when
            //Customer.ConfirmCustomerEmailAddress(customerRegisteredEvent)

            // then


        }
    }
}