namespace BankingSite.Model
{
    public interface IAirlineMembershipNumberValidator
    {
        bool IsValid(string membershipNumber);
    }
}