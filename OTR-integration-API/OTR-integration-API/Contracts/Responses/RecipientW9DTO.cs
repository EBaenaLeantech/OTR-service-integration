using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_API.Contracts.Responses
{
    /// <summary>
    /// Represent the object response for 'Create','Search' W9 Data method.
    /// </summary>
    [DataContract]
    public class RecipientW9DTO
    {
        /// <summary>
        /// Represent recipient_id data response, id of user's recipient
        /// </summary>
        [DataMember(Name = "recipient_id", EmitDefaultValue = false)]
        public string RecipientID { get; set; }

        /// <summary>
        /// Represent  "recipient_reference_id" data response, id of user's recipient
        /// </summary>
        [DataMember(Name = "recipient_reference_id", EmitDefaultValue = false)]
        public string RecipientReferenceID { get; set; }

        /// <summary>
        /// Represent recipient_email data response, e-mail of user's recipient
        /// </summary>
        [DataMember(Name = "recipient_email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Represent recipient_first_name data response, first name of user's recipient
        /// </summary>
        [DataMember(Name = "recipient_first_name", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Represent recipient_last_name data response, last name of user's recipient
        /// </summary>
        [DataMember(Name = "recipient_last_name", EmitDefaultValue = false)]
        public string LastName { get; set; }

        /// <summary>
        /// Represent "recipient_w9_verified" data response, it's optional data
        /// </summary>
        [DataMember(Name = "recipient_w9_verified", EmitDefaultValue = false, IsRequired = false)]
        public bool? Verified { get; set; }

        /// <summary>
        /// Represent "recipient_w9_required" data response, it's optional data
        /// </summary>
        [DataMember(Name = "recipient_w9_required", EmitDefaultValue = false, IsRequired = false)]
        public bool? Required { get; set; }
    }
}
