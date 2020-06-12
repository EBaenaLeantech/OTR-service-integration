using OTR_integration_Data.Contracts.Requests;
using OTR_integration_Data.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTR_integration_API.Services
{
    public interface IAccountsService
    {
        public Task<AccountCardDTO> CreateAccount(AccountCardCreateRequest accountCardCreateRequest);
    }
}
