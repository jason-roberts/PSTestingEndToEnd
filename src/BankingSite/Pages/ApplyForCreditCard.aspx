<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyForCreditCard.aspx.cs" Inherits="BankingSite.Pages.ApplyForCreditCard" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Credit Card Application</title>
    <link href="styles/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Credit Card Application</h1>
        <div id="validationErrorContainer" class="error">
            <asp:BulletedList runat="server" ID="ValidationErrorList"/>
        </div>
        <fieldset>
            <legend>Personal Details</legend>
            
            <select id="Title" name="Title">
                <option value="1">Mr</option>
                <option value="2">Miss</option>
                <option value="3">Mrs</option>
                <option value="4">Prof</option>
            </select>

            <label for="Name">Name</label>
            <asp:TextBox runat="server" ID="Name"/>

            <label for="Age">Age In Years</label>
            <asp:TextBox runat="server" ID="Age"/>
            
            <label for="EmailAddress">Email Address</label>
            <asp:TextBox runat="server" ID="EmailAddress"/>
        </fieldset>
        
        <fieldset>
            <legend>Financial Information</legend>
            
            <label for="AnnualIncome">Annual Income</label>
            <asp:TextBox runat="server" ID="AnnualIncome"/>
            
            <h3>Existing Credit Cards</h3>
            <div id="existingCards">
                <label for="CCLimit1">Card 1 Credit Limit</label>
                <asp:TextBox runat="server" ID="CCLimit1"/>
                
                <label for="CCLimit2">Card 2 Credit Limit</label>
                <asp:TextBox runat="server" ID="CCLimit2"/>

                <label for="CCLimit3">Card 3 Credit Limit</label>
                <asp:TextBox runat="server" ID="CCLimit3"/>

            </div>


        </fieldset>
        
        
          <fieldset>
            <legend>Other Information</legend>                
                <label for="AirlineRewardNumber">Airline Rewards Membership Number</label>              
                <asp:TextBox runat="server" ID="AirlineRewardNumber"/>
           </fieldset>
        
        <asp:Button runat="server" ID="ApplyNow" Text="Apply Now!" OnClick="ApplyNow_OnClick"></asp:Button>
        
        <a href="#" id="HelpLink">Help</a>

    </div>
    </form>
</body>
</html>

