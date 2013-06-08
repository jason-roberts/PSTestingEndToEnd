using BankingSite.Model;
using BankingSite.Model.DomainEntities;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class ApplicationDetailsValidatorTests
    {
        [Test]
        [Category("smoke")]
        public void ShouldValidateCorrectApplication()
        {
            // Example of internal classes being integration tested together

            var sut = new ApplicationDetailsValidator(new AirlineMembershipNumberValidator());

            var a = new CreditCardApplication
                                          {
                                              ApplicantName = "Lisa",
                                              ApplicantAgeInYears = 44,
                                              AirlineFrequentFlyerNumber = "A1234567"
                                          };
            var errors = sut.Validate(a);

            Assert.That(errors, Is.Empty);
        }

        [Test]        
        public void ShouldValidateInCorrectApplication()
        {
            // Example of internal classes being integration tested together

            var sut = new ApplicationDetailsValidator(new AirlineMembershipNumberValidator());

            var a = new CreditCardApplication
            {
                ApplicantName = "Lisa",
                ApplicantAgeInYears = 44,
                AirlineFrequentFlyerNumber = "badnumber"
            };
            var errors = sut.Validate(a);

            Assert.That(errors, Is.Not.Empty);
        }
    }
}
