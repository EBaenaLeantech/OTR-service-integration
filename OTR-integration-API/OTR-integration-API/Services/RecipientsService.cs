using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OTR_integration_API.ApiSettings;
using OTR_integration_API.Contracts.Errors;
using OTR_integration_API.Contracts.Requests;
using OTR_integration_API.Contracts.Responses;
using OTR_integration_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OTR_integration_API.Services
{
    public class RecipientsService : IRecipientsService
    {
        private readonly ILogger<RecipientsService> _logger;
        private readonly IOptions<InterchecksApiSettings> _interchecksApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public RecipientsService(
            ILogger<RecipientsService> logger,
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

        public async Task<RecipientDTO> GetRecipientById(string recipientId)
        {
            if (String.IsNullOrEmpty(recipientId)) return null;
            else
            {
                var urlRequest = $"{_interchecksApiSettings.Value.ApiRecipientsGetCall.Replace("{{PayerId}}", _interchecksApiSettings.Value.PayerId).Replace("{{RecipientId}}", recipientId)}";
                var response = await _httpClient.GetAsync(urlRequest);
                if (response.IsSuccessStatusCode)
                {
                    RecipientDTO recipientDTO = JsonConvert.DeserializeObject<RecipientDTO>(response.Content.ReadAsStringAsync().Result);
                    return recipientDTO;
                }
                else
                {
                    string respError = response.Content.ReadAsStringAsync().Result;
                    InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientDTO)IntercheckApiErrorHandler.Handle(apiError);
                }
            }
        }

        public async Task<RecipientDTO> CreateRecipient(RecipientCreateRequest recipientCreateRequest)
        {
            if (recipientCreateRequest == null)
            {
                throw new ArgumentNullException(nameof(recipientCreateRequest));
            }
            else
            {
                var urlRequest = $"{_interchecksApiSettings.Value.ApiRecipientsCreateCall}/{_interchecksApiSettings.Value.PayerId}";
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(recipientCreateRequest).ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(urlRequest, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    RecipientDTO recipientDTO = JsonConvert.DeserializeObject<RecipientDTO>(response.Content.ReadAsStringAsync().Result);
                    return recipientDTO;
                }
                else
                {
                    string respError = response.Content.ReadAsStringAsync().Result;
                    InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientDTO)IntercheckApiErrorHandler.Handle(apiError);
                }
            }
        }

        public async Task<RecipientDTO> CreateIntegralRecipient(RecipientCreateRequest recipientCreateRequest)
        {
            if (recipientCreateRequest == null)
            {
                throw new ArgumentNullException(nameof(recipientCreateRequest));
            }
            else
            {
                RecipientSearchRequest recipientSearchRequest = _mapper.Map<RecipientSearchRequest>(recipientCreateRequest);
                RecipientDTO recipientSearched = await this.SearchRecipient(recipientSearchRequest);
                if (recipientSearched == null)
                {
                    RecipientDTO recipientCreated = await this.CreateRecipient(recipientCreateRequest);
                    return recipientCreated;
                }
                else
                {
                    return recipientSearched;
                }
            }
        }

        public async Task<RecipientW9DTO> CreateRecipientW9Data(RecipientCreateW9Request recipientCreateW9Request)
        {
            if (recipientCreateW9Request == null)
            {
                throw new ArgumentNullException(nameof(recipientCreateW9Request));
            }
            else
            {
                var urlRequest = $"{_interchecksApiSettings.Value.ApiRecipientsCreateW9DataCall}/{_interchecksApiSettings.Value.PayerId}";
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(recipientCreateW9Request).ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(urlRequest, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var strResult = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(strResult);
                    RecipientW9DTO recipientDTO = JsonConvert.DeserializeObject<RecipientW9DTO>(strResult);
                    return recipientDTO;
                }
                else
                {
                    string respError = response.Content.ReadAsStringAsync().Result;
                    InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientW9DTO)IntercheckApiErrorHandler.Handle(apiError);
                }
            }
        }

        public async Task<RecipientDTO> SearchRecipient(RecipientSearchRequest recipientSearchRequest)
        {
            if (recipientSearchRequest == null)
            {
                throw new ArgumentNullException(nameof(recipientSearchRequest));
            }
            else
            {
                var urlRequest = $"{_interchecksApiSettings.Value.ApiRecipientsSearchCall.Replace("{{PayerId}}", _interchecksApiSettings.Value.PayerId)}";
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(recipientSearchRequest).ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(urlRequest, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    RecipientDTO recipientDTO = JsonConvert.DeserializeObject<RecipientDTO>(response.Content.ReadAsStringAsync().Result);
                    return recipientDTO;
                }
                else
                {
                    string respError = response.Content.ReadAsStringAsync().Result;
                    InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientDTO)IntercheckApiErrorHandler.Handle(apiError);
                }
            }
        }

        public async Task<RecipientDTO> UpdateRecipient(string recipientId, RecipientUpdateRequest recipientUpdateRequest)
        {
            if (recipientUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(recipientUpdateRequest));
            }
            else
            {
                var urlRequest = $"{_interchecksApiSettings.Value.ApiRecipientsUpdateCall.Replace("{{PayerId}}", _interchecksApiSettings.Value.PayerId).Replace("{{RecipientId}}", recipientId)}";
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(recipientUpdateRequest).ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(urlRequest, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    RecipientDTO recipientDTO = JsonConvert.DeserializeObject<RecipientDTO>(response.Content.ReadAsStringAsync().Result);
                    return recipientDTO;
                }
                else
                {
                    string respError = response.Content.ReadAsStringAsync().Result;
                    InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientDTO)IntercheckApiErrorHandler.Handle(apiError);
                }
            }
        }

        public async Task<RecipientW9DTO> UpdateRecipientW9Data(string recipientId, RecipientUpdateW9Request recipientUpdateW9Request)
        {
            if (recipientUpdateW9Request == null)
            {
                throw new ArgumentNullException(nameof(recipientUpdateW9Request));
            }
            else
            {
                var urlRequest = $"{_interchecksApiSettings.Value.ApiRecipientsUpdateW9DataCall.Replace("{{PayerId}}", _interchecksApiSettings.Value.PayerId).Replace("{{RecipientId}}", recipientId)}";
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(recipientUpdateW9Request).ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(urlRequest, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    RecipientW9DTO recipientDTO = JsonConvert.DeserializeObject<RecipientW9DTO>(response.Content.ReadAsStringAsync().Result);
                    return recipientDTO;
                }
                else
                {
                    string respError = response.Content.ReadAsStringAsync().Result;
                    InterchecksApiError apiError = JsonConvert.DeserializeObject<InterchecksApiError>(respError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientW9DTO)IntercheckApiErrorHandler.Handle(apiError);
                }
            }
        }
    }
}
