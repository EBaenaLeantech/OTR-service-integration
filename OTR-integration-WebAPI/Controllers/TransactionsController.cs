using OTR_integration_WebAPI.Contracts.Requests;
using OTR_integration_WebAPI.Exceptions;
using OTR_integration_WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OTR_integration_WebAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpPost]
        [ActionName("CreateDebitTransactionAsync")]
        public async Task<HttpResponseMessage> CreateDebitTransactionAsync(TransactionDebitRequest transactionDebitRequest)
        {
            try
            {
                var transactionDTO = await _transactionsService.CreateDebitTransaction(transactionDebitRequest);
                return Request.CreateResponse(HttpStatusCode.OK, transactionDTO);

            }
            catch (IntercheckApiException apiException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, apiException.Error);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
            }
        }


        [HttpPost]
        [ActionName("CreateCreditTransactionAsync")]
        public async Task<HttpResponseMessage> CreateCreditTransactionAsync(TransactionCreditRequest transactionCreditRequest)
        {
            try
            {
                var transactionDTO = await _transactionsService.CreateCreditTransaction(transactionCreditRequest);
                return Request.CreateResponse(HttpStatusCode.OK, transactionDTO);

            }
            catch (IntercheckApiException apiException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, apiException.Error);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}
