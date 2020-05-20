using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OTR_integration_API.Contracts.Requests
{
    /// <summary>
    /// Represent the object Request for 'CreateRecipient W9 Data' method.
    /// </summary>
    [DataContract]
    public class RecipientCreateW9Request
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

        /// <summary>
        /// Represent recipient_tin IRS TIN data parameter
        /// </summary>
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "TIN must be numeric")]
        [DataMember(Name = "recipient_tin", EmitDefaultValue = false)]
        public string TIN { get; set; }

        /// <summary>
        /// Represent "recipient_1099_delivery" data parameter
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        [DataMember(Name = "recipient_1099_delivery", EmitDefaultValue = false)]
        public string Delivery1099 { get; set; }

        /// <summary>
        /// Represent "recipient_1099_delivery" data parameter
        /// </summary>
        [Required]
        [DataMember(Name = "recipient_address", EmitDefaultValue = false)]
        public RecipientAddressRequest Address { get; set; }

    }
}
