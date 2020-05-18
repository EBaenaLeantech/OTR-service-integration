using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OTR_integration_API.ApiSettings;
using OTR_integration_API.Contracts.Requests;
using OTR_integration_API.Contracts.Responses;
using OTR_integration_API.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OTR_integration_API.Repositories
{
    public class HttpApiRecipientsRepo : IRecipientsRepo
    {
        private readonly ILogger<HttpApiRecipientsRepo> _logger;
        private readonly IOptions<InterchecksApiSettings> _interchecksApiSettings;
        private readonly HttpClient _httpClient;

        public HttpApiRecipientsRepo(
            ILogger<HttpApiRecipientsRepo> logger,
            IOptions<InterchecksApiSettings> interchecksApiSettings,
            IHttpClientFactory httpClientFactory
        )
        {
            _logger = logger;
            _interchecksApiSettings = interchecksApiSettings;
            _httpClient = httpClientFactory.CreateClient("InterchecksApi");
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
                var jsonData = JsonConvert.SerializeObject(new
                {
                    recipient_email = recipientCreateRequest.Email,
                    recipient_first_name = recipientCreateRequest.FirstName,
                    recipient_last_name = recipientCreateRequest.LastName
                });
                HttpContent httpContent = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(urlRequest, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonRecipientDTO = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    return JsonToResponseDto.JsonToRecipientDTO(jsonRecipientDTO);
                }
                else
                {
                    var jsonError = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    var apiError = JsonToResponseDto.JsonToInterchecksApiError(jsonError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientDTO)IntercheckApiErrorHandler.Handle(apiError);
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
                var jsonData = JsonConvert.SerializeObject(new
                {
                    recipient_email = recipientSearchRequest.Email
                });
                HttpContent httpContent = new StringContent(jsonData.ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(urlRequest, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonRecipientDTO = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    return JsonToResponseDto.JsonToRecipientDTO(jsonRecipientDTO);
                }
                else
                {
                    var jsonError = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                    var apiError = JsonToResponseDto.JsonToInterchecksApiError(jsonError);
                    _logger.LogError($"Interchecks Api Error, Error Code:{apiError.ErrorCode}:{apiError.ErrorMessage}");
                    return (RecipientDTO)IntercheckApiErrorHandler.Handle(apiError);
                }
            }
        }
    }
}
