namespace BankingSite.Model.ExternalComponentGateways
{
    /// <summary>
    /// Simulation of a web service reference proxy
    /// </summary>
    public class ThirdPartyCreditCheckWebServiceProxy
    {
        public int CrdChk(string n)
        {            
            if (n == "Jason")
            {
                return 1;
            }

            return 0;
        }
    }
}