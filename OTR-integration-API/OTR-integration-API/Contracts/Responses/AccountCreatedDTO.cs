using System;

namespace OTR_integration_API.Contracts.Responses
{
    /// <summary>
    /// Represent the object response for 'CreateAccount' method.
    /// </summary>
    public class AccountCreatedDTO
    {
        /// <summary>
        /// Represent
        /// </summary>
        public string AccountID { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string Type{ get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public bool PushAvailable { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public bool PullAvailable { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string AvsReturnCode { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public string AvsSecurityCode { get; set; }
    }
}
