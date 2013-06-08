namespace BankingSite.Model
{
    public class AirlineMembershipNumberValidator : IAirlineMembershipNumberValidator
    {
        public bool IsValid(string membershipNumber)
        {
            var isIncorrectLength = membershipNumber == "" || membershipNumber.Length != 8;

            if (isIncorrectLength)
            {
                return false;
            }

            if (StartsWithALetterFollowedBy7Numbers(membershipNumber))
            {
                return true;
            }

            return false;
        }

        private static bool StartsWithALetterFollowedBy7Numbers(string membershipNumber)
        {
            int dummy;

            return char.IsLetter(membershipNumber[0]) &&
                int.TryParse(membershipNumber.Substring(1), out dummy);
        }
    }
}
