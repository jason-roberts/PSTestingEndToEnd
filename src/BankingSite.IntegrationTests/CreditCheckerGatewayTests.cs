using BankingSite.Model.ExternalComponentGateways;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class CreditCheckerGatewayTests
    {
        [Test]
        public void ShouldCreditCheckGoodPerson()
        {
            var sut = new CreditCheckerGateway();

            var isGoodCredit = sut.HasGoodCreditHistory("Jason");

            Assert.That(isGoodCredit, Is.True);
        }

        [Test]
        public void ShouldCreditCheckBadPerson()
        {
            var sut = new CreditCheckerGateway();

            var isGoodCredit = sut.HasGoodCreditHistory("Amrit");

            Assert.That(isGoodCredit, Is.False);
        }
    }
}
