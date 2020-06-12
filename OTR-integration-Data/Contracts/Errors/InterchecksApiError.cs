using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_Data.Contracts.Errors
{
    /// <summary>
    /// Represent the object response for any Interchecks Api error.
    /// </summary>
    [DataContract]
    public class InterchecksApiError
    {
        /// <summary>
        /// Represent error data response, boolean value of api's error
        /// </summary>
        [DataMember(Name = "error", EmitDefaultValue = false)]
        public bool Error { get; set; }
        /// <summary>
        /// Represent error_code data response, error code belong to Interchecks Api 
        /// </summary>
        [DataMember(Name = "error_code", EmitDefaultValue = false)]
        public string ErrorCode { get; set; }
        /// <summary>
        /// Represent error_message data response, error message belong to Interchecks Api 
        /// </summary>
        [DataMember(Name = "error_message", EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Represent errors data response, error collection belong to Interchecks Api 
        /// </summary>
        [DataMember(Name = "errors", EmitDefaultValue = false, IsRequired = false)]
        public string[] Errors { get; set; }
    }
}
