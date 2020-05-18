using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OTR_integration_API.Contracts.Requests;
using OTR_integration_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientsController : ControllerBase
    {
        private readonly ILogger<RecipientsController> _logger;
        private readonly IRecipientsRepo _recipientsRepo;


        public RecipientsController(
            ILogger<RecipientsController> logger,
            IRecipientsRepo recipientsRepo
        )
        {
            _logger = logger;
            _recipientsRepo = recipientsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Interchecks Recipients it's ONLINE");
        }

        [HttpPost("createRecipient")]
        public async Task<IActionResult> CreateRecipient(RecipientCreateRequest recipientCreateRequest)
        {
            var recipientDTO = await _recipientsRepo.CreateRecipient(recipientCreateRequest);
            return Ok(recipientDTO);
        }

        [HttpPost("searchRecipient")]
        public async Task<IActionResult> SearchRecipient(RecipientSearchRequest recipientSearchRequest)
        {
            var recipientDTO = await _recipientsRepo.SearchRecipient(recipientSearchRequest);
            if (recipientDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(recipientDTO);
            }
            
        }

    }
}
