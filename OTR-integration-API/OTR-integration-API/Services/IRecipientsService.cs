using OTR_integration_API.Contracts.Requests;
using OTR_integration_API.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.Services
{
    /// <summary>
    /// Interface IRecipientsService for Recipients logic API methods Creation, Update, Search by email and Get by recipient id
    /// </summary>
    public interface IRecipientsService
    {
        /// <summary>
        /// Create recipient with first name, last name, and email.
        /// </summary>
        /// <param name="recipientCreateRequest">
        /// request object that contains the parameters for using the api method of Interchecks Api Create Recipients
        /// </param>
        /// <returns>
        /// response object Recipient Created
        /// </returns>
        public Task<RecipientDTO> CreateRecipient(RecipientCreateRequest recipientCreateRequest);
        /// <summary>
        /// First search a recipient by email, if Recimpient doesn't exist then
        /// this method create a recipient with first name, last name, and email
        /// if Recimpient does exist will be returned
        /// </summary>
        /// <param name="recipientCreateRequest">
        /// request object that contains the parameters for using the api method of Interchecks Api Search and Create Recipients
        /// </param>
        /// <returns>
        /// response object Recipient Searched or Created
        /// </returns>
        public Task<RecipientDTO> CreateIntegralRecipient(RecipientCreateRequest recipientCreateRequest);
        /// <summary>
        /// Create recipient with first name, last name, email, TIN, and address.
        /// </summary>
        /// <param name="recipientCreateW9Request">
        /// request object that contains the parameters for using the api method of Interchecks Api Create w9 Data Recipients
        /// </param>
        /// <returns>
        /// response object Recipient w9 Data Created
        /// </returns>
        public Task<RecipientW9DTO> CreateRecipientW9Data(RecipientCreateW9Request recipientCreateW9Request);
        /// <summary>
        /// Search for a recipient using an email address. will return a Not Found exception if Recimpient doesn't exist
        /// </summary>
        /// <param name="recipientSearchRequest">
        /// request object that contains the parameters for using the api method of Interchecks Api Searc Recipients
        /// </param>
        /// <returns>
        /// /// response object Recipient Searched or a Not Found exception if Recimpient doesn't exist
        /// </returns>
        public Task<RecipientDTO> SearchRecipient(RecipientSearchRequest recipientSearchRequest);
        /// <summary>
        /// Get recipient using the recipient ID.
        /// </summary>
        /// <param name="recipient_id">
        /// Recipient id
        /// </param>
        /// <returns>
        /// response object Recipient 
        /// </returns>
        public Task<RecipientDTO> GetRecipientById(string recipientId);
        /// <summary>
        /// Update recipient first name, last name, and email using the recipient ID.
        /// </summary>
        /// <param name="recipient_id">
        /// Recipient id
        /// </param>
        /// <param name="recipientUpdateRequest">
        /// request object that contains the parameters for using the api method of Interchecks Api Update Recipients
        /// </param>
        /// <returns>
        /// response object Recipient Updated
        /// </returns>
        public Task<RecipientDTO> UpdateRecipient(string recipientId, RecipientUpdateRequest recipientUpdateRequest);
        /// <summary>
        /// Update recipient with TIN and address. using the recipient ID.
        /// </summary>
        /// <param name="recipient_id">
        /// Recipient id
        /// </param>
        /// <param name="recipientUpdateW9Request">
        /// request object that contains the parameters for using the api method of Interchecks Api Update Recipients
        /// </param>
        /// <returns>
        /// response object Recipient Updated
        /// </returns>
        public Task<RecipientW9DTO> UpdateRecipientW9Data(string recipientId, RecipientUpdateW9Request recipientUpdateW9Request);
    }
}
