using BankingSite.Model;
using NUnit.Framework;

namespace BankingSite.UnitTests
{
    [TestFixture]
    public class AirlineMembershipNumberValidatorTests
    {
        [Test]
        public void ShouldBeInvalidWhenAllSpaces()
        {
            var sut = new AirlineMembershipNumberValidator();

            Assert.That(sut.IsValid("    "), Is.False);
        }

        [Test]
        public void ShouldBeInvalidWhenBlank()
        {
            var sut = new AirlineMembershipNumberValidator();

            Assert.That(sut.IsValid(""), Is.False);
        }

        [Test]
        public void ShouldBeInvalidWhenLessThan8Digits()
        {
            var sut = new AirlineMembershipNumberValidator();

            const string sevenDigitNumber = "1234567";

            Assert.That(sut.IsValid(sevenDigitNumber), Is.False);
        }

        [Test]
        public void ShouldBeInvalidWhenMoreThan8Digits()
        {
            var sut = new AirlineMembershipNumberValidator();

            const string nineDigitNumber = "123456789";

            Assert.That(sut.IsValid(nineDigitNumber), Is.False);
        }

        [Test]
        public void ShouldBeValidWhen8DigitsAndStartsWithLetter()
        {
            var sut = new AirlineMembershipNumberValidator();

            Assert.That(sut.IsValid("A5522123"), Is.True);
        }

        [Test]
        public void ShouldBeInvalidWhenLast7DigitsNotAllNumbers()
        {
            var sut = new AirlineMembershipNumberValidator();

            Assert.That(sut.IsValid("A552212A"), Is.False);
        }

        //refaactor to use data driven attrubutes?? - readability

    }
}
