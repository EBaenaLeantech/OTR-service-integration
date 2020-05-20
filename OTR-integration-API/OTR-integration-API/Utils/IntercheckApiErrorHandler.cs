using Microsoft.AspNetCore.Http;
using OTR_integration_API.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OTR_integration_API.Utils
{
    public static class IntercheckApiErrorHandler
    {
        public static object Handle(InterchecksApiError interchecksApiError)
        {
            if (interchecksApiError == null)
            {
                throw new ArgumentNullException(nameof(interchecksApiError));
            }
            else
            {
                if ("401".Equals(interchecksApiError.ErrorCode.ToUpper()))
                {
                    throw new UnauthorizedAccessException($"Interchecks Api Authorization Error, Error Code:{interchecksApiError.ErrorCode}|{interchecksApiError.ErrorMessage}");
    
                }
                else if ("R05".Equals(interchecksApiError.ErrorCode.ToUpper()))
                {
                    return null;
                }
                else
                {
                    throw new HttpRequestException($"Interchecks Api Error, Error Code:{interchecksApiError.ErrorCode}|{interchecksApiError.ErrorMessage}");
                }
            }
        }
    }
}
