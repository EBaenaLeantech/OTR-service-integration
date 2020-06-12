using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_Data.Contracts.Requests
{
    /// <summary>
    /// Represent the object Request for 'SearchRecipient' method.
    /// </summary>
    [DataContract]
    public class RecipientSearchRequest
    {
        /// <summary>
        /// Represent recipient_email data parameter, e-mail of user's recipient for search
        /// </summary>
        [Required(ErrorMessage = "recipient_email is Required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DataMember(Name = "recipient_email", EmitDefaultValue = false)]
        public string Email { get; set; }
    }
}
