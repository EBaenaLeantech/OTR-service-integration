using AutoMapper;
using Newtonsoft.Json;
using OTR_integration_WebAPI.ApiSettings;
using OTR_integration_WebAPI.Contracts.Errors;
using OTR_integration_WebAPI.Contracts.Requests;
using OTR_integration_WebAPI.Contracts.Responses;
using OTR_integration_WebAPI.Exceptions;
using OTR_integration_WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OTR_integration_WebAPI.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IInterchecksApiSettings _interchecksApiSettings;

        public TransactionsService(IInterchecksApiSettings interchecksApiSettings)
        {
            _interchecksApiSettings = interchecksApiSettings;
        }

        public async Task<TransactionDebitDTO> CreateDebitTransaction(TransactionDebitRequest transactionDebitRequest)
        {

            if (transactionDebitRequest == null)
            {
                throw new ArgumentNullException(nameof(transactionDebitRequest));
            }
            else 
            {
                var urlRequest = _interchecksApiSettings.BaseUrl
                + _interchecksApiSettings
                .ApiTransactionsCreateDebitCall
                .Replace("{{PayerId}}", _interchecksApiSettings.PayerId)
                .Replace("{{RecipientId}}", transactionDebitRequest.RecipientId);
                using (var _httpClient = HttpClientHelper.GetClient(_interchecksApiSettings.AccountId, _interchecksApiSettings.SecretKey))
                {
                    TransactionDebitIntercheckRequest requestObject = Mapper.Map<TransactionDebitRequest, TransactionDebitIntercheckRequest>(transactionDebitRequest);
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(requestObject).ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync(urlRequest, httpContent);
                    var responseResult = response.Content.ReadAsStringAsync().Result;
                    if (!response.IsSuccessStatusCode || responseResult.Contains("error"))
                    {
                        string respError = response.Content.ReadAsStringAsync().Result;
                        InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                        throw new IntercheckApiException(apiError);
                    }
                    else
                    {
                        string responseValue = response.Content.ReadAsStringAsync().Result;
                        TransactionDebitDTO transactionDTO = JsonConvert.DeserializeObject<TransactionDebitDTO>(responseValue);
                        return transactionDTO;
                    }

                }
            }
        }

        public async Task<TransactionCreditDTO> CreateCreditTransaction(TransactionCreditRequest transactionCreditRequest)
        {
            if (transactionCreditRequest == null)
            {
                throw new ArgumentNullException(nameof(transactionCreditRequest));
            }
            else
            {
                var urlRequest = _interchecksApiSettings.BaseUrl
               + _interchecksApiSettings
               .ApiTransactionsCreateCreditCall
               .Replace("{{PayerId}}", _interchecksApiSettings.PayerId)
               .Replace("{{RecipientId}}", transactionCreditRequest.RecipientId);
                using (var _httpClient = HttpClientHelper.GetClient(_interchecksApiSettings.AccountId, _interchecksApiSettings.SecretKey))
                {
                    TransactionCreditIntercheckRequest requestObject = Mapper.Map<TransactionCreditRequest, TransactionCreditIntercheckRequest>(transactionCreditRequest);
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(requestObject).ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PostAsync(urlRequest, httpContent);
                    var responseResult = response.Content.ReadAsStringAsync().Result;
                    if (!response.IsSuccessStatusCode || responseResult.Contains("error"))
                    {
                        string respError = response.Content.ReadAsStringAsync().Result;
                        InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                        throw new IntercheckApiException(apiError);
                    }
                    else
                    {
                        string responseValue = response.Content.ReadAsStringAsync().Result;
                        TransactionCreditDTO transactionDTO = JsonConvert.DeserializeObject<TransactionCreditDTO>(responseValue);
                        return transactionDTO;
                    }
                }
            }
        }
    }
}