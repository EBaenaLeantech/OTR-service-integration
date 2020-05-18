using System.ComponentModel.DataAnnotations;

namespace OTR_integration_API.Contracts.Requests
{
    /// <summary>
    /// Represent the object Request for 'CreateRecipient' method.
    /// </summary>
    public class RecipientCreateRequest
    {
        /// <summary>
        /// Represent
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        [Required]
        public string LastName { get; set; }

    }
}
