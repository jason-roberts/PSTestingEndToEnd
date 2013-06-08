namespace BankingSite.Model.ExternalComponentGateways
{
    public interface ICreditCheckerGateway
    {
        bool HasGoodCreditHistory(string personsName);
    }
}