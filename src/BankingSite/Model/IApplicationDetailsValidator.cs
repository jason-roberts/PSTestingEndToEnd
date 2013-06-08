using System.Collections.Generic;
using BankingSite.Model.DomainEntities;

namespace BankingSite.Model
{
    public interface IApplicationDetailsValidator
    {
        List<string> Validate(CreditCardApplication application);
    }
}