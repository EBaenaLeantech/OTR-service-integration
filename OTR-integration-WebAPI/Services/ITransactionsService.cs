using OTR_integration_WebAPI.Contracts.Requests;
using OTR_integration_WebAPI.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTR_integration_WebAPI.Services
{
    public interface ITransactionsService
    {
        Task<TransactionDebitDTO> CreateDebitTransaction(TransactionDebitRequest transactionDebitRequest);
        Task<TransactionCreditDTO> CreateCreditTransaction(TransactionCreditRequest transactionCreditRequest);
    }
}
