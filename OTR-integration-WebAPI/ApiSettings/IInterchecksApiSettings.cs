using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_WebAPI.ApiSettings
{
    /// <summary>
    /// Represent the Intercheck settings object, these contains api setup information and api methods calls.
    /// </summary>
    public interface IInterchecksApiSettings
    {
        //Setup
        string BaseUrl { get; set; }
        string PayerId { get; set; }
        string AccountId { get; set; }
        string SecretKey { get; set; }
        //Recipients Calls
        string ApiRecipientsCreateCall { get; set; }
        string ApiRecipientsSearchCall { get; set; }
        string ApiRecipientsGetCall { get; set; }
        string ApiRecipientsUpdateCall { get; set; }
        string ApiRecipientsCreateW9DataCall { get; set; }
        string ApiRecipientsUpdateW9DataCall { get; set; }
        //Accounts Calls
        string ApiAccountsCreateCall { get; set; }
        //Transactions Calls
        string ApiTransactionsCreateDebitCall { get; set; }
        string ApiTransactionsCreateCreditCall { get; set; }
    }
}
