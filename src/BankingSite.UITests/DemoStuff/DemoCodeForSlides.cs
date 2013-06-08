using System;
using NUnit.Framework;
using WatiN.Core;
using WatiN.Core.Native.Windows;

namespace BankingSite.UITests.DemoStuff
{
    public partial class DemoCodeForSlides
    {

        public void IeObjectCreation()
        {
using (var browser =
    new IE("http://www.pluralsight.com"))
{
    // test code here
}
        }


        public void LocatingThings()
        {
            using (var browser =
                new IE("http://www.pluralsight.com"))
            {
                //// Get a reference to a HTML input element, type=text, id=Name
                //TextField applicantName = browser.TextField(Find.ById("Name"));

                //// Get a reference to a HTML link element with id=HelpLink
                //Link helpHyperlink = browser.Link(Find.ById("HelpLink"));

                //// Get a reference to a HTML input element, type=submit, id=ApplyNow
                //Button applyButton = browser.Button(Find.ById("ApplyNow"));

                //// Get a reference to a HTML paragraph element, id=Name
                //Para nameParagraph = browser.Para(Find.ById("Name"));


                
TextField applicantName = browser.TextField(Find.ById("Name"));
                
Link helpHyperlink = browser.Link(Find.ById("HelpLink"));
                
Button applyButton = browser.Button(Find.ById("ApplyNow"));
                
Para nameParagraph = browser.Para(Find.ById("Name"));
            }
        }

  
        public void Navigating()
        {
            using (var browser =
                new IE())
            {                
                browser.AutoClose = false;                
                browser.ShowWindow(NativeMethods.WindowShowStyle.Minimize);
                browser.ShowWindow(NativeMethods.WindowShowStyle.Maximize);

browser.GoTo("http://www.bing.com");
   
browser.GoTo("http://www.pluralsight.com");

browser.Back();

browser.Forward();
            }
        }



     
        public void InteractingWithElement()
        {
            using (var browser =
                new IE("http://localhost:62727/Pages/ApplyForCreditCard.aspx"))            
            {
                browser.AutoClose = false;
                browser.ShowWindow(NativeMethods.WindowShowStyle.Minimize);
                browser.ShowWindow(NativeMethods.WindowShowStyle.Maximize);
                
TextField applicantName = browser.TextField(Find.ById("Name"));
applicantName.TypeText("Jason Roberts");

Link helpHyperlink = browser.Link(Find.ById("HelpLink"));
helpHyperlink.Click();

SelectList title = browser.SelectList(Find.ById("Title"));
title.Select("Prof");
title.SelectByValue("4");

Button applyButton = browser.Button(Find.ById("ApplyNow"));
applyButton.Click();

                
            }
        }



      
        public void LocatingThingsByNonId()
        {
            using (var browser =
                new IE("http://localhost:62727/Pages/ApplyForCreditCard.aspx"))
            {                
Div errorContainer = browser.Div(Find.ByClass("error"));

SelectList title = browser.SelectList(Find.ByName("Title"));

Label ageLabel = browser.Label(Find.ByFor("Age"));
TextField applicantAge = browser.TextField(Find.ByLabelText("Age In Years"));
                
TextField applicantAge2 = browser.TextField(Find.By("id", "Age"));


                

               // var something = browser.Div(Find.By("someattribute","somevalue"));
               // Assert.That(something, Is.Not.Null);

           //     Link helpHyperlink = browser.Link(Find.ById("HelpLink"));

             //   Button applyButton = browser.Button(Find.ById("ApplyNow"));

               // Para nameParagraph = browser.Para(Find.ById("Name"));
            }
        }


     
        public void ShouldShowCorrectApplicantDetailsOnSuccessPage()
        {
            using (var browser =
                new IE("http://localhost:62727/Pages/ApplyForCreditCard.aspx"))
            {
                // Leave the browser open after the test completes
                // to see what's happened for demo purposes
                browser.AutoClose = false;

                browser.TextField(Find.ById("Name")).TypeText("Jason");
                browser.TextField(Find.ById("Age")).TypeText("30");
                browser.TextField(Find.ById("AirlineRewardNumber")).TypeText("A1234567");

                browser.Button(Find.ById("ApplyNow")).Click();

                var name = browser.Para(Find.ById("Name")).Text;

                Assert.That(name, Is.EqualTo("Jason"));
            }
        }

    }
}
