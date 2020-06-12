using OTR_integration_WebAPI.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTR_integration_WebAPI.Exceptions
{
    public class IntercheckApiException : Exception
    {
        public InterchecksApiError Error { get; set; }

        public IntercheckApiException(InterchecksApiError error)
        {
            Error = error;
        }
    }
}