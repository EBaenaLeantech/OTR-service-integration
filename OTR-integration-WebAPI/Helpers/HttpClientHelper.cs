using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace OTR_integration_WebAPI.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient GetClient(string accountId, string secretKey)
        {
            var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{accountId}:{secretKey}")));

            var client = new HttpClient()
            {
                DefaultRequestHeaders = { Authorization = authValue }
            };
            return client;
        }
    }
}