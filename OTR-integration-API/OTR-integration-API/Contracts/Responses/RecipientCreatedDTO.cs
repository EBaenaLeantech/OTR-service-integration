namespace OTR_integration_API.Contracts.Responses
{
    /// <summary>
    /// Represent the object response for 'Create' method.
    /// </summary>
    public class RecipientCreatedDTO : RecipientDTO
    {
        /// <summary>
        /// Represent
        /// </summary>
        public bool W9VerifiedDTO { get; set; }

        /// <summary>
        /// Represent
        /// </summary>
        public bool W9RequiredDTO { get; set; }
    }
}
