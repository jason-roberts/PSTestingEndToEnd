using System;
using NUnit.Framework;
using WatiN.Core;

namespace BankingSite.UITests.LogicalFunctionalModelStyle
{
    [TestFixture]    
    public class CreditCardApplicationTests
    {
        [Test]
        [STAThread]
        [Category("smoke")]
        public void ShouldShowCorrectApplicantDetailsOnSuccessPage()
        {
              using (var browser =
                new IE(UiAutomationSettings.ApplyPageUrl))
            {
                var applyPage = browser.Page<ApplyForCreditCardPage>();

                applyPage.ApplyForCreditCard(name: "Jason",
                                age: "30",
                                airlineNumber: "A1234567");

                Assert.That(browser.Url.Contains("ApplicationAccepted.aspx"));

                var acceptedPage = browser.Page<AcceptedPage>();

                Assert.That(acceptedPage.Document.Url.Contains("ApplicationAccepted.aspx"));

                Assert.That(acceptedPage.Name, Is.EqualTo("Jason"));
            }
        }


        [Test]
        [STAThread]
        public void ShouldShowValidationErrors()
        {
            using (var browser =
                new IE(UiAutomationSettings.ApplyPageUrl))
            {
                var applyPage = browser.Page<ApplyForCreditCardPage>();

                applyPage.ApplyForCreditCard(name: "Jason",
                                             age: "30",
                                             airlineNumber: "BadNumber");
                
                Assert.That(browser.Text.Contains("Airline membership number is invalid"));
            }
        }
    }
}
