using BankingSite.Model.DomainEntities;

namespace BankingSite.Model.ExternalComponentGateways
{
    public interface IBankMainframeGateway
    {
        int CreateNew(CreditCardApplication application);
    }
}