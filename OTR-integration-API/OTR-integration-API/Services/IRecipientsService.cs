using OTR_integration_API.Contracts.Requests;
using OTR_integration_API.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.Services
{
    public interface IRecipientsService
    {
        public Task<RecipientDTO> CreateRecipient(RecipientCreateRequest recipientCreateRequest);
        public Task<RecipientDTO> CreateIntegralRecipient(RecipientCreateRequest recipientCreateRequest);
        public Task<RecipientW9DTO> CreateRecipientW9Data(RecipientCreateW9Request recipientCreateW9Request);
        public Task<RecipientDTO> SearchRecipient(RecipientSearchRequest recipientSearchRequest);
        public Task<RecipientDTO> GetRecipientById(string recipientId);
        public Task<RecipientDTO> UpdateRecipient(string recipientId, RecipientUpdateRequest recipientUpdateRequest);
        public Task<RecipientW9DTO> UpdateRecipientW9Data(string recipientId, RecipientUpdateW9Request recipientUpdateW9Request);
    }
}
