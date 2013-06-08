using BankingSite.Model;
using BankingSite.Model.DomainEntities;
using BankingSite.Model.ExternalComponentGateways;
using NUnit.Framework;
using Moq;

namespace BankingSite.UnitTests
{
    [TestFixture]
    public class CreditCardApplicationScorerTests
    {
        [Test]
        public void ShouldDeclineUnderAgeApplicant()
        {
            var fakeGateway = new Mock<ICreditCheckerGateway>();
         
            var sut = new CreditCardApplicationScorer(fakeGateway.Object, null);

            var application = new CreditCardApplication
                                  {
                                      ApplicantAgeInYears = 20
                                  };

            var result = sut.ScoreApplication(application);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ShouldAskGatewayForCreditCheck()
        {
            var fakeGateway = new Mock<ICreditCheckerGateway>();
            var fakeMainframe = new Mock<IBankMainframeGateway>();

            var sut = new CreditCardApplicationScorer(fakeGateway.Object, fakeMainframe.Object);

            var application = new CreditCardApplication
            {
                ApplicantAgeInYears = 30,
                ApplicantName = "Jason"
            };

            sut.ScoreApplication(application);

            // check that the fake's HasGoodCreditHistory method was called with the parameter "Jason", exactly one time
            fakeGateway.Verify(x => x.HasGoodCreditHistory("Jason"),Times.Once());
        }

        [Test]
        public void ShouldAcceptCorrectAgedApplicantWithGoodCreditHistory()
        {
            const int expectedMainframeRefNum = 8376;

            var fakeGateway = new Mock<ICreditCheckerGateway>();
            var fakeMainframe = new Mock<IBankMainframeGateway>();
            
            fakeGateway.Setup(x => x.HasGoodCreditHistory(It.IsAny<string>())).Returns(true);            
            fakeMainframe.Setup(x => x.CreateNew(It.IsAny<CreditCardApplication>())).Returns(expectedMainframeRefNum);

            var sut = new CreditCardApplicationScorer(fakeGateway.Object, fakeMainframe.Object);

            var application = new CreditCardApplication
            {
                ApplicantAgeInYears = 30
            };

            var result = sut.ScoreApplication(application);

            Assert.That(result, Is.EqualTo(expectedMainframeRefNum));
        }
    }
}
