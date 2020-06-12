namespace OTR_integration_Data.Contracts.Requests
{
    /// <summary>
    /// Represent the object Request for 'CreateCreditTransation' method.
    /// </summary>
    public class CreditTransactionRequest
    {
        /// <summary>
        /// Represent
        /// </summary>
        public string RequestReferenceID { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// class constructor.
        /// </summary>
        public CreditTransactionRequest()
        {
            this.Method = "INSTANT_DEPOSIT";
        }
    }
}
