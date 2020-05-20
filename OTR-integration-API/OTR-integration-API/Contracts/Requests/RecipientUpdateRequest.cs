using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_API.Contracts.Requests
{
    /// <summary>
    /// Represent the object Request for 'UpdateRecipient' method.
    /// </summary>
    [DataContract]
    public class RecipientUpdateRequest
    {
        /// <summary>
        /// Represent recipient_email data parameter, e-mail of user's recipient
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DataMember(Name = "recipient_email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Represent recipient_first_name data parameter, first name of user's recipient
        /// </summary>
        [Required]
        [DataMember(Name = "recipient_first_name", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Represent recipient_last_name data parameter, last name of user's recipient
        /// </summary>
        [Required]
        [DataMember(Name = "recipient_last_name", EmitDefaultValue = false)]
        public string LastName { get; set; }
    }
}
