using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankingSite.Pages
{
    public partial class ApplicationAccepted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var s = new CreditCardApplicationServiceReference.CreditCardApplicationServiceClient();

            var refNum = Request.QueryString["ref"];

            var name = s.GetSuccesfulApplicantsName(int.Parse(refNum));

            Name.InnerText = name;
            RefNum.InnerText = refNum;
        }
    }
}