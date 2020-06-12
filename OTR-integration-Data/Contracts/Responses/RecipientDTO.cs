using System.Runtime.Serialization;

namespace OTR_integration_Data.Contracts.Responses
{
    /// <summary>
    /// Represent the object response for 'Create','Search' method.
    /// </summary>
    [DataContract]
    public class RecipientDTO
    {
        /// <summary>
        /// Represent recipient_id data response, id of user's recipient
        /// </summary>
        [DataMember(Name = "recipient_id", EmitDefaultValue = false)]
        public string RecipientID { get; set; }

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
    }
}
