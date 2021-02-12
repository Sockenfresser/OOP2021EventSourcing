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
        private ID _customerId;
        private EmailAddress _emailAddress;
        private CustomHash _hash;
        private PersonName _personName;

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
            Assert.NotEqual(Guid.Empty, customerRegisteredEvent.CustomerId.Value);
            Assert.NotEqual(Guid.Empty, customerRegisteredEvent.Hash.Value);
        }

        [Fact]
        public void Reconstitute_CorrectCustomerRegisteredEvent_CustomerCreated()
        {
            // arrange
            var customerRegisteredEvent = CreateCustomerRegisteredEvent();

            // act
            var reconstituteResult = Customer.Reconstitute(new List<IEvent> { customerRegisteredEvent });

            // assert
            Assert.Equal(_customerId.Value, reconstituteResult.Id.Value);
            Assert.Equal(_emailAddress.Value, reconstituteResult.EmailAddress.Value);
            Assert.Equal(_hash.Value, reconstituteResult.Hash.Value);
            Assert.Equal(_personName.GivenName, reconstituteResult.PersonName.GivenName);
            Assert.Equal(_personName.FamilyName, reconstituteResult.PersonName.FamilyName);
        }

         [Fact]
        public void Reconstitute_EmailComfirmed_CustomerCreated()
        {
            // arrange
            var customerRegisteredEvent = CreateCustomerRegisteredEvent();
            var customerEmailAddressConfirmedEvent = new CustomerEmailAddressConfirmed(_customerId);

            // act
            var reconstituteResult = Customer.Reconstitute(
                new List<IEvent> { customerRegisteredEvent, customerEmailAddressConfirmedEvent });

            // assert
            Assert.Equal(_customerId.Value, reconstituteResult.Id.Value);
            Assert.Equal(_emailAddress.Value, reconstituteResult.EmailAddress.Value);
            Assert.Equal(_hash.Value, reconstituteResult.Hash.Value);
            Assert.Equal(_personName.GivenName, reconstituteResult.PersonName.GivenName);
            Assert.Equal(_personName.FamilyName, reconstituteResult.PersonName.FamilyName);
        }

        [Fact]
        public void ConfirmCustomerEmailAddress_RightHash_CorrectConfirmationEventReturned()
        {
            // given
            var customerRegisteredEvent = CreateCustomerRegisteredEvent();
            var customer = Customer.Reconstitute(new[] { customerRegisteredEvent });

            var confirmCustomerEmailAddressEvent = new ConfirmCustomerEmailAddress(
                _customerId.Value.ToString(),
                _hash.Value.ToString());

            // when
            var resultEvent = customer.ConfirmCustomerEmailAddress(confirmCustomerEmailAddressEvent);

            // then
            Assert.NotNull(resultEvent);
            Assert.IsType<CustomerEmailAddressConfirmed>(resultEvent);

            var confirmedEvent = (CustomerEmailAddressConfirmed)resultEvent;
            Assert.Equal(_customerId.Value, confirmedEvent.Id.Value);
        }

        [Fact]
        public void ConfirmCustomerEmailAddress_WrongHash_ConfirmationFailedEventReturned()
        {
            // given
            var customerRegisteredEvent = CreateCustomerRegisteredEvent();
            var customer = Customer.Reconstitute(new[] { customerRegisteredEvent });

            var wrongHash = Guid.NewGuid().ToString();

            var confirmCustomerEmailAddressEvent = new ConfirmCustomerEmailAddress(
                _customerId.Value.ToString(),
                wrongHash);

            // when
            var resultEvent = customer.ConfirmCustomerEmailAddress(confirmCustomerEmailAddressEvent);

            // then
            Assert.NotNull(resultEvent);
            Assert.IsType<CustomerEmailAddressConfirmationFailed>(resultEvent);

            var confirmationFailed = (CustomerEmailAddressConfirmationFailed)resultEvent;
            Assert.Equal(_customerId.Value, confirmationFailed.Id.Value);
        }

        [Fact]
        public void
            ConfirmCustomerEmailAddress_CorrectHashAfterPreviousCorrectConfirmation_NoEventReturned()
        {
            // given
            var customerRegisteredEvent = CreateCustomerRegisteredEvent();
            var customerEmailAddressConfirmedEvent = new CustomerEmailAddressConfirmed(_customerId);

            var customer = Customer.Reconstitute(
                new IEvent[] { customerRegisteredEvent, customerEmailAddressConfirmedEvent });

            var wrongHash = Guid.NewGuid().ToString();

            var confirmCustomerEmailAddressEvent = new ConfirmCustomerEmailAddress(
                _customerId.Value.ToString(),
                wrongHash);

            // when
            var resultEvent = customer.ConfirmCustomerEmailAddress(confirmCustomerEmailAddressEvent);

            // then
            Assert.NotNull(resultEvent);
            Assert.IsType<CustomerEmailAddressConfirmationFailed>(resultEvent);

            var confirmationFailed = (CustomerEmailAddressConfirmationFailed)resultEvent;
            Assert.Equal(_customerId.Value, confirmationFailed.Id.Value);
        }

        private CustomerRegistered CreateCustomerRegisteredEvent()
        {
            _customerId = new ID();
            _emailAddress = new EmailAddress("foo@bar.com");
            _hash = new CustomHash();
            _personName = new PersonName("given", "fam");
            var customerRegisteredEvent = new CustomerRegistered(
                _customerId,
                _emailAddress,
                _hash,
                _personName);
            return customerRegisteredEvent;
        }
    }
}