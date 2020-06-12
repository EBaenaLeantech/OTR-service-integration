using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OTR_integration_Data.Contracts.Requests;
using OTR_integration_API.Services;
using OTR_integration_API.Utils;

namespace OTR_integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountsService _accountsService;

        public AccountsController(
            ILogger<AccountsController> logger,
            IAccountsService accountsService
        )
        {
            _logger = logger;
            _accountsService = accountsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Interchecks Accounts it's ONLINE");
        }

        [HttpPost("createAccount")]
        public async Task<IActionResult> CreateAccount(AccountCardCreateRequest accountCardCreateRequest)
        {
            var accountDTO = await _accountsService.CreateAccount(accountCardCreateRequest);
            return Ok(accountDTO);
        }
    }
}