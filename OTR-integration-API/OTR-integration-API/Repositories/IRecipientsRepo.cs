using OTR_integration_API.Contracts.Requests;
using OTR_integration_API.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.Repositories
{
    public interface IRecipientsRepo
    {
        public Task<RecipientDTO> CreateRecipient(RecipientCreateRequest recipientCreateRequest);
        public Task<RecipientDTO> SearchRecipient(RecipientSearchRequest recipientSearchRequest);
    }
}
