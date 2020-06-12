using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace OTR_integration_WebAPI.ApiSettings
{
    /// <summary>
    /// Represent the Intercheck settings object, these contains api setup information and api methods calls.
    /// </summary>
    public class InterchecksApiSettings : IInterchecksApiSettings
    {
        //Setup
        public string BaseUrl { get; set; }
        public string PayerId { get; set; }
        public string AccountId { get; set; }
        public string SecretKey { get; set; }
        //Recipients Calls
        public string ApiRecipientsCreateCall { get; set; }
        public string ApiRecipientsSearchCall { get; set; }
        public string ApiRecipientsGetCall { get; set; }
        public string ApiRecipientsUpdateCall { get; set; }
        public string ApiRecipientsCreateW9DataCall { get; set; }
        public string ApiRecipientsUpdateW9DataCall { get; set; }
        //Accounts Calls
        public string ApiAccountsCreateCall { get; set; }
        //Transactions Calls
        public string ApiTransactionsCreateDebitCall { get; set; }
        public string ApiTransactionsCreateCreditCall { get; set; }

        public InterchecksApiSettings()
        {
            //Setup
            this.BaseUrl = WebConfigurationManager.AppSettings["Interchecks_BaseUrl"];
            this.PayerId = WebConfigurationManager.AppSettings["Interchecks_PayerId"];
            this.AccountId = WebConfigurationManager.AppSettings["Interchecks_AccountId"];
            this.SecretKey = WebConfigurationManager.AppSettings["Interchecks_SecretKey"];
            //Recipients Calls
            this.ApiRecipientsCreateCall = WebConfigurationManager.AppSettings["Interchecks_ApiRecipientsCreateCall"];
            this.ApiRecipientsSearchCall = WebConfigurationManager.AppSettings["Interchecks_ApiRecipientsSearchCall"];
            this.ApiRecipientsGetCall = WebConfigurationManager.AppSettings["Interchecks_ApiRecipientsGetCall"];
            this.ApiRecipientsUpdateCall = WebConfigurationManager.AppSettings["Interchecks_ApiRecipientsUpdateCall"];
            //Accounts Calls
            this.ApiAccountsCreateCall = WebConfigurationManager.AppSettings["Interchecks_ApiAccountsCreateCall"];
            //Transactions Calls
            this.ApiTransactionsCreateDebitCall = WebConfigurationManager.AppSettings["Interchecks_ApiTransactionsCreateDebitCall"];
            this.ApiTransactionsCreateCreditCall = WebConfigurationManager.AppSettings["Interchecks_ApiTransactionsCreateCreditCall"];
        }
    }
}
