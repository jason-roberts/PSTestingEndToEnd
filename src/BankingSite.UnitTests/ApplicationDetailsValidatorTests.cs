using BankingSite.Model;
using BankingSite.Model.DomainEntities;
using Moq;
using NUnit.Framework;

namespace BankingSite.UnitTests
{
    [TestFixture]
    public class ApplicationDetailsValidatorTests
    {
        [Test]
        public void ShouldDetectBlankName()
        {
            var fakeValidator = new Mock<IAirlineMembershipNumberValidator>();           

            var a = new CreditCardApplication
                                          {
                                              ApplicantName=""
                                          };

            var sut = new ApplicationDetailsValidator(fakeValidator.Object);

            var errors = sut.Validate(a);

            Assert.That(errors,Has.Exactly(1).EqualTo("Name cannot be blank."));
        }

        [Test]
        public void ShouldDetectUseAirlineValidatorToCheckNumber()
        {
            var fakeValidator = new Mock<IAirlineMembershipNumberValidator>();            

            var a = new CreditCardApplication
            {
                AirlineFrequentFlyerNumber = "x123"
            };

            var sut = new ApplicationDetailsValidator(fakeValidator.Object);

            sut.Validate(a);

            fakeValidator.Verify(x => x.IsValid("x123"),Times.Once());
        }

        [Test]
        public void ShouldDetectInvalidAirlineNumber()
        {
            var fakeValidator = new Mock<IAirlineMembershipNumberValidator>();
            fakeValidator.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);


            var a = new CreditCardApplication();

            var sut = new ApplicationDetailsValidator(fakeValidator.Object);

            var errors = sut.Validate(a);

            Assert.That(errors, Has.Exactly(1).EqualTo("Airline membership number is invalid"));
        }   
    }
}
    