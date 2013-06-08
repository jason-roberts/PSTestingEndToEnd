using System.Linq;
using BankingSite.Model;
using BankingSite.Model.DomainEntities;

namespace BankingSite.Services
{
    public class CreditCardApplicationService : ICreditCardApplicationService
    {
        private readonly ICreditCardApplicationScorer _scorer;
        private readonly IApplicationDetailsValidator _validator;


        public CreditCardApplicationService(IApplicationDetailsValidator validator, ICreditCardApplicationScorer scorer)
        {
            _validator = validator;
            _scorer = scorer;
        }

        public SubmissionResult SubmitApplication(CreditCardApplication application)
        {
            var sr = new SubmissionResult {ValidationErrors = _validator.Validate(application)};

            var isValidApplication = !sr.ValidationErrors.Any();

            if (!isValidApplication)
            {
                return sr;
            }

            sr.ReferenceNumber = _scorer.ScoreApplication(application);

            return sr;
        }

        public string GetSuccesfulApplicantsName(int submissionReferenceResult)
        {
            // Simulate the service calling into the rest of the application
            return "Jason";
        }
    }
}