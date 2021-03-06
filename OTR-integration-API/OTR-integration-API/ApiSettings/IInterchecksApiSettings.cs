﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.ApiSettings
{
    /// <summary>
    /// Represent the Intercheck settings object, these contains api setup information and api methods calls.
    /// </summary>
    public interface IInterchecksApiSettings
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
    }
}
