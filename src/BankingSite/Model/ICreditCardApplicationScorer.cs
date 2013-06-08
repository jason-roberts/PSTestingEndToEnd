using BankingSite.Model.DomainEntities;

namespace BankingSite.Model
{
    public interface ICreditCardApplicationScorer
    {
        int? ScoreApplication(CreditCardApplication application);
    }
}