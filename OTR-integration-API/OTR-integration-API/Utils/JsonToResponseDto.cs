using Newtonsoft.Json.Linq;
using OTR_integration_API.Contracts.Errors;
using OTR_integration_API.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.Utils
{
    public static class JsonToResponseDto
    {
        
        public static RecipientDTO JsonToRecipientDTO(JObject jsonRecipientDTO)
        {
            if (jsonRecipientDTO == null)
            {
                throw new ArgumentNullException(nameof(jsonRecipientDTO));
            }
            else
            {
                return new RecipientDTO
                {
                    RecipientID = jsonRecipientDTO["recipient_id"].Value<string>(),
                    Email = jsonRecipientDTO["recipient_email"].Value<string>(),
                    FirstName = jsonRecipientDTO["recipient_first_name"].Value<string>(),
                    LastName = jsonRecipientDTO["recipient_last_name"].Value<string>()
                };
            }
        }

        public static InterchecksApiError JsonToInterchecksApiError(JObject jsonApiError)
        {
            if (jsonApiError == null)
            {
                throw new ArgumentNullException(nameof(jsonApiError));
            }
            else
            {
                return new InterchecksApiError
                {
                    Error = jsonApiError["error"].Value<bool>(),
                    ErrorCode = jsonApiError["error_code"].Value<string>(),
                    ErrorMessage = !jsonApiError.ContainsKey("error_message") ? string.Empty : jsonApiError["error_message"].Value<string>()
                };
            }
        }
        
    }
}
