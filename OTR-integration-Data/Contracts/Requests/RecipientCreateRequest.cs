using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OTR_integration_Data.Contracts.Requests
{
    /// <summary>
    /// Represent the object Request for 'CreateRecipient' method.
    /// </summary>
    [DataContract]
    public class RecipientCreateRequest
    {
        /// <summary>
        /// Represent recipient_email data parameter, e-mail of user's recipient
        /// </summary>
        [Required(ErrorMessage = "recipient_email is Required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DataMember(Name = "recipient_email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Represent recipient_first_name data parameter, first name of user's recipient
        /// </summary>
        [Required(ErrorMessage = "recipient_first_name is Required.")]
        [DataMember(Name = "recipient_first_name", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Represent recipient_last_name data parameter, last name of user's recipient
        /// </summary>
        [Required(ErrorMessage = "recipient_last_name is Required.")]
        [DataMember(Name = "recipient_last_name", EmitDefaultValue = false)]
        public string LastName { get; set; }

    }
}
