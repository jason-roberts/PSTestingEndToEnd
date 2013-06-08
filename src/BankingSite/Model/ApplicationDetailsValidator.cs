using System.Collections.Generic;
using BankingSite.Model.DomainEntities;

namespace BankingSite.Model
{
    public class ApplicationDetailsValidator : IApplicationDetailsValidator
    {
        private readonly IAirlineMembershipNumberValidator _airlineNumberValidator;

        public ApplicationDetailsValidator(IAirlineMembershipNumberValidator airlineNumberValidator)
        {
            _airlineNumberValidator = airlineNumberValidator;
        }

        public List<string> Validate(CreditCardApplication application)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(application.ApplicantName))
            {
                errors.Add("Name cannot be blank.");
            }

            if (! _airlineNumberValidator.IsValid(application.AirlineFrequentFlyerNumber))
            {
                errors.Add("Airline membership number is invalid");
            }

            return errors;
        }
    }
}