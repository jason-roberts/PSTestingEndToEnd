using BankingSite.Model.DomainEntities;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class CreditCardApplicationServiceTests
    {
        private const string ApplicantName = "Jason";

        [Test]
        [Category("smoke")]
        public void ShouldSubmitValidApplication()
        {
            var submissionResult = SubmitAValidApplication();

            Assert.That(submissionResult.ValidationErrors, Is.Empty);
            Assert.That(submissionResult.ReferenceNumber, Is.Not.Null);
         
            var applicantNameForReferenceNumber = GetApplicantName(submissionResult.ReferenceNumber.Value);
            
            Assert.That(applicantNameForReferenceNumber, Is.EqualTo(ApplicantName));
        }

        private SubmissionResult SubmitAValidApplication()
        {
            var sut = new CreditCardApplicationServiceReference.CreditCardApplicationServiceClient();

            var a = new CreditCardApplication
            {
                ApplicantName = ApplicantName,
                ApplicantAgeInYears = 30,
                AirlineFrequentFlyerNumber = "A1234567"
            };

            return sut.SubmitApplication(a);
        }


        private string GetApplicantName(int refNumber)
        {
            var sut = new CreditCardApplicationServiceReference.CreditCardApplicationServiceClient();

            return sut.GetSuccesfulApplicantsName(refNumber);
        }
    }
}
