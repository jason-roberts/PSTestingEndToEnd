using BankingSite.Model.DomainEntities;
using BankingSite.Model.ExternalComponentGateways;

namespace BankingSite.Model
{
    public class CreditCardApplicationScorer : ICreditCardApplicationScorer
    {
        private readonly ICreditCheckerGateway _creditCheckerGateway;
        private readonly IBankMainframeGateway _mainframeGateway;

        public CreditCardApplicationScorer(ICreditCheckerGateway creditCheckerGateway, IBankMainframeGateway mainframeGateway)
        {
            _creditCheckerGateway = creditCheckerGateway;
            _mainframeGateway = mainframeGateway;
        }

        public int? ScoreApplication(CreditCardApplication application)
        {
            var isApplicantTooYoung = application.ApplicantAgeInYears < 21;

            if (isApplicantTooYoung)
            {
                return null;
            }

            var hasGoodCreditHistory =  _creditCheckerGateway.HasGoodCreditHistory(application.ApplicantName);

            if (!hasGoodCreditHistory)
            {
                return null;
            }

            return _mainframeGateway.CreateNew(application);
        }
    }
}