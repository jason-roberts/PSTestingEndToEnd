using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankingSite.Pages
{
    public partial class ApplyForCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ApplyNow_OnClick(object sender, EventArgs e)
        {
            var s = new CreditCardApplicationServiceReference.CreditCardApplicationServiceClient();

            var a = new CreditCardApplicationServiceReference.CreditCardApplication()
                                  {
                                      ApplicantName = Name.Text,
                                      ApplicantAgeInYears = int.Parse(Age.Text),
                                      AirlineFrequentFlyerNumber = AirlineRewardNumber.Text                                      
                                  };
            var result = s.SubmitApplication(a);

            if (result.ValidationErrors.Any())
            {
                ShowErrors(result.ValidationErrors);
            }
            else if (result.ReferenceNumber.HasValue)
            {
                RedirectToApplicationAcceptedPage(result.ReferenceNumber.Value);
            }
            else
            {
                RedirectToApplicationRejectedPage();
            }
        }

        private void RedirectToApplicationRejectedPage()
        {
            Response.Redirect("ApplicationFailed.aspx");
        }

        private void RedirectToApplicationAcceptedPage(int referenceNumber)
        {
            Response.Redirect("ApplicationAccepted.aspx?ref=" + referenceNumber.ToString());
        }

        private void ShowErrors(string[] validationErrors)
        {
            ValidationErrorList.DataSource = validationErrors;
            ValidationErrorList.DataBind();
        }
    }
}