using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OTR_integration_API.Contracts.Requests;
using OTR_integration_API.Services;
using System.Threading.Tasks;

namespace OTR_integration_API.Controllers
{
    /// <summary>
    /// Rest Controller for Recipients API methods Creation, Update, Search by email and Get by recipient id
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientsController : ControllerBase
    {
        private readonly ILogger<RecipientsController> _logger;
        private readonly IRecipientsService _recipientsService;


        public RecipientsController(
            ILogger<RecipientsController> logger,
            IRecipientsService recipientsService
        )
        {
            _logger = logger;
            _recipientsService = recipientsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Interchecks Recipients it's ONLINE");
        }

        /// <summary>
        /// Get recipient using the recipient ID.
        /// </summary>
        /// <param name="recipient_id">
        /// Recipient id
        /// </param>
        /// <returns>
        /// response object Recipient 
        /// </returns>
        [HttpGet("{recipient_id}", Name = "GetRecipientById")]
        public async Task<IActionResult> GetRecipientById(string recipient_id)
        {
            var recipientDTO = await _recipientsService.GetRecipientById(recipient_id);
            if (recipientDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(recipientDTO);
            }
        }

        /// <summary>
        /// Create recipient with first name, last name, and email.
        /// </summary>
        /// <param name="recipientCreateRequest">
        /// request object that contains the parameters for using the api method of Interchecks Api Create Recipients
        /// </param>
        /// <returns>
        /// response object Recipient Created
        /// </returns>
        [HttpPost("createRecipient")]
        public async Task<IActionResult> CreateRecipient(RecipientCreateRequest recipientCreateRequest)
        {
            var recipientDTO = await _recipientsService.CreateRecipient(recipientCreateRequest);
            return Ok(recipientDTO);
        }

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
        [HttpPost("createIntegralRecipient")]
        public async Task<IActionResult> CreateIntegralRecipient(RecipientCreateRequest recipientCreateRequest)
        {
            var recipientDTO = await _recipientsService.CreateIntegralRecipient(recipientCreateRequest);
            return Ok(recipientDTO);
        }

        /// <summary>
        /// Create recipient with first name, last name, email, TIN, and address.
        /// </summary>
        /// <param name="recipientCreateW9Request">
        /// request object that contains the parameters for using the api method of Interchecks Api Create w9 Data Recipients
        /// </param>
        /// <returns>
        /// response object Recipient w9 Data Created
        /// </returns>
        [HttpPost("createRecipientW9Data")]
        public async Task<IActionResult> CreateRecipientW9Data(RecipientCreateW9Request recipientCreateW9Request)
        {
            var recipientDTO = await _recipientsService.CreateRecipientW9Data(recipientCreateW9Request);
            return Ok(recipientDTO);
        }


        /// <summary>
        /// Search for a recipient using an email address. will return a Not Found exception if Recimpient doesn't exist
        /// </summary>
        /// <param name="recipientSearchRequest">
        /// request object that contains the parameters for using the api method of Interchecks Api Searc Recipients
        /// </param>
        /// <returns>
        /// /// response object Recipient Searched or a Not Found exception if Recimpient doesn't exist
        /// </returns>
        [HttpPost("searchRecipient")]
        public async Task<IActionResult> SearchRecipient(RecipientSearchRequest recipientSearchRequest)
        {
            var recipientDTO = await _recipientsService.SearchRecipient(recipientSearchRequest);
            if (recipientDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(recipientDTO);
            }

        }

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
        [HttpPut("updateRecipient/{recipient_id}")]
        public async Task<IActionResult> UpdateRecipient(string recipient_id, RecipientUpdateRequest recipientUpdateRequest)
        {
            var recipientFromService = await _recipientsService.GetRecipientById(recipient_id);
            if (recipientFromService == null)
            {
                return NotFound();
            }
            else
            {
                var recipientUpdated = await _recipientsService.UpdateRecipient(recipient_id, recipientUpdateRequest);
                if (recipientUpdated == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(recipientUpdated);
                }
            }
        }

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
        [HttpPut("updateRecipientW9Data/{recipient_id}")]
        public async Task<IActionResult> UpdateRecipientW9Data(string recipient_id, RecipientUpdateW9Request recipientUpdateW9Request)
        {
            var recipientFromService = await _recipientsService.GetRecipientById(recipient_id);
            if (recipientFromService == null)
            {
                return NotFound();
            }
            else
            {
                var recipientUpdated = await _recipientsService.UpdateRecipientW9Data(recipient_id, recipientUpdateW9Request);
                if (recipientUpdated == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(recipientUpdated);
                }
            }
        }
    }
}
