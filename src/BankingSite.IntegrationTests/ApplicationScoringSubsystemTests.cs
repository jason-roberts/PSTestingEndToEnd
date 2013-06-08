using BankingSite.Model;
using BankingSite.Model.DomainEntities;
using BankingSite.Model.ExternalComponentGateways;
using Moq;
using NUnit.Framework;
using Ninject;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    [Category("subsystem_application_scoring")]
    public class ApplicationScoringSubsystemTests
    {
        [Test]
        public void ShouldScoreApplicationCorrectly()
        {
            // Create and configure our fakes that we want to use
            var fakeMainframe = new Mock<IBankMainframeGateway>();
            fakeMainframe.Setup(x => x.CreateNew(It.IsAny<CreditCardApplication>())).Returns(42);

            // Create our DI container
            var kernel = new StandardKernel();

            // Tell the DI container to use the real CreditCheckerGateway
            kernel.Bind<ICreditCheckerGateway>().To<CreditCheckerGateway>();

            // Tell the DI container to use the fake IBankMainframeGateway
            kernel.Bind<IBankMainframeGateway>().ToConstant(fakeMainframe.Object);

            // Use the DI container to create the object graph, rather than new keyword
            var sut = kernel.Get<CreditCardApplicationScorer>();

            var a = new CreditCardApplication
                        {
                            ApplicantName = "Jason",
                            ApplicantAgeInYears = 44,
                            AirlineFrequentFlyerNumber = "A1234567"
                        };

            var result = sut.ScoreApplication(a);

            Assert.That(result, Is.Not.Null);

            // Note that this seems more complex than the below. For this example this is true,
            // but if we were creating a larger/complex subsystem object graph, then using a DI container
            // actually simplifies things.
        }



        // The below is the original version before introducing a DI Container to create the object graph for us

        //[Test]
        //public void ShouldScoreApplicationCorrectly()
        //{
        //    // We define a logical subsystem of "application scoring".
        //    // The mainframe dependency isn't part of the "application scoring" subsystem
        //    // so we fake that rather than using the real one

        //    var realCreditCheckerGateway = new CreditCheckerGateway();

        //    var fakeMainframe = new Mock<IBankMainframeGateway>();

        //    fakeMainframe.Setup(x => x.CreateNew(It.IsAny<CreditCardApplication>())).Returns(42);

        //    var sut = new CreditCardApplicationScorer(realCreditCheckerGateway, fakeMainframe.Object);

        //    var a = new CreditCardApplication
        //    {
        //        ApplicantName = "Jason",
        //        ApplicantAgeInYears = 44,
        //        AirlineFrequentFlyerNumber = "A1234567"
        //    };

        //    var result = sut.ScoreApplication(a);

        //    Assert.That(result, Is.Not.Null);
        //}
    }
}
