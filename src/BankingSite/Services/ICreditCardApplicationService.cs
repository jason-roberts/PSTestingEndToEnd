using System.ServiceModel;
using BankingSite.Model.DomainEntities;

namespace BankingSite.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICreditCardApplicationService" in both code and config file together.
    [ServiceContract]
    public interface ICreditCardApplicationService
    {
        [OperationContract]
        SubmissionResult SubmitApplication(CreditCardApplication application);

        [OperationContract]
        string GetSuccesfulApplicantsName(int submissionReferenceResult);
    }
}
