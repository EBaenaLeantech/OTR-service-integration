using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OTR_integration_API.ApiSettings;
using OTR_integration_Data.Contracts.Errors;
using OTR_integration_Data.Contracts.Requests;
using OTR_integration_Data.Contracts.Responses;
using OTR_integration_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OTR_integration_API.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly ILogger<AccountsService> _logger;
        private readonly IOptions<InterchecksApiSettings> _interchecksApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public AccountsService(
            ILogger<AccountsService> logger,
            IOptions<InterchecksApiSettings> interchecksApiSettings,
            IHttpClientFactory httpClientFactory,
            IMapper mapper
        )
        {
            _logger = logger;
            _interchecksApiSettings = interchecksApiSettings;
            _httpClient = httpClientFactory.CreateClient("InterchecksApi");
            _mapper = mapper;
        }

        public async Task<AccountCardDTO> CreateAccount(AccountCardCreateRequest accountCardCreateRequest)
        {
            if (accountCardCreateRequest == null)
            {
                throw new ArgumentNullException(nameof(accountCardCreateRequest));
            }
            else 
            {
                var urlRequest = $"{_interchecksApiSettings.Value.ApiAccountsCreateCall.Replace("{{PayerId}}", _interchecksApiSettings.Value.PayerId).Replace("{{RecipientId}}", accountCardCreateRequest.RecipientID)}";
                var accountCardCreateInterchecksRequest = _mapper.Map<AccountCardCreateInterchecksRequest>(accountCardCreateRequest);
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(accountCardCreateInterchecksRequest).ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(urlRequest, httpContent);
                var responseResult = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode || responseResult.Contains("error"))
                {
                    string respError = response.Content.ReadAsStringAsync().Result;
                    InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (AccountCardDTO)IntercheckApiErrorHandler.Handle(apiError);
                }
                else
                {
                    AccountCardDTO accountCardDTO = JsonConvert.DeserializeObject<AccountCardDTO>(response.Content.ReadAsStringAsync().Result);
                    return accountCardDTO;
                }
            }
        }
    }
}
