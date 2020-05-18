using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.ApiSettings
{
    public class InterchecksApiSettings
    {
        //Setup
        public string BaseUrl { get; set; }
        public string PayerId { get; set; }
        public string AccountId { get; set; }
        public string SecretKey { get; set; }
        //Calls
        public string ApiRecipientsCreateCall { get; set; }
    }
}
