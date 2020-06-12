using System;

namespace OTR_integration_Data.Contracts.Responses
{
    /// <summary>
    /// Represent the object response for 'CreateCreditTransaction' method.
    /// </summary>
    public class CreditTransactionCreatedDTO
    {
        /// <summary>
        /// Represent
        /// </summary>
        public string RequestReferenceID { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string TransactionID { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string TransactionStatus { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public DateTime PaidDate { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string ProviderTransactionID { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string ProviderApprovalCode { get; set; }
    }
}
