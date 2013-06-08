namespace BankingSite.Model.ExternalComponentGateways
{
    public class CreditCheckerGateway : ICreditCheckerGateway
    {
        public bool HasGoodCreditHistory(string personsName)
        {
            var webService = new ThirdPartyCreditCheckWebServiceProxy();

            // note that by abstracting away the external service, we can shield
            // the rest of our code base from bad 3rd party APIs
            // like here a cryptic CrdChk method name and integer return value
            int resultCode = webService.CrdChk(personsName);

            return resultCode == 1;
        }
    }
}