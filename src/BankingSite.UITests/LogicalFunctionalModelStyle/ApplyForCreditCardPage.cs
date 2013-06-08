using WatiN.Core;

namespace BankingSite.UITests.LogicalFunctionalModelStyle
{
    class ApplyForCreditCardPage : Page
    {
        private const string AgeId = "Age";
        private const string NameId = "Name";
        private const string AirlineNumberId = "AirlineRewardNumber";

        public string Name
        {
            get
            {
                return this.Document.TextField(Find.ById(NameId)).Text;
            }
            set
            {
                Document.TextField(Find.ById(NameId)).TypeText(value);
            }                
        }

        public string Age
        {
            get
            {
                return this.Document.TextField(Find.ById(AgeId)).Text;
            }
            set
            {
                Document.TextField(Find.ById(AgeId)).TypeText(value);
            }
        }

        public string AirlineNumber
        {
            get
            {
                return this.Document.TextField(Find.ById(AirlineNumberId)).Text;
            }
            set
            {
                Document.TextField(Find.ById(AirlineNumberId)).TypeText(value);
            }
        }

        public void ClickApplyButton()
        {
            Document.Button(Find.ById("ApplyNow")).Click();
        }

        public void ApplyForCreditCard(string name, string age, string airlineNumber)
        {
            this.Name = name;
            this.Age = age;
            this.AirlineNumber = airlineNumber;

            ClickApplyButton();
        }
    }
}
