using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_Data.Contracts.Responses
{
    [DataContract]
    public class AccountCardDTO
    {
        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string AccountID { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "account_type", EmitDefaultValue = false)]
        public string AccountType { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "account_number", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "created_date", EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "exp_date", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "push_available", EmitDefaultValue = false)]
        public bool PushAvailable { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "pull_available", EmitDefaultValue = false)]
        public bool PullAvailable { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "avs_return_code", EmitDefaultValue = false)]
        public string AvsReturnCode { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [DataMember(Name = "avs_security_code", EmitDefaultValue = false, IsRequired = false)]
        public string? AvsSecurityCode { get; set; }
    }
}
