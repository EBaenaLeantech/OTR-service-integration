using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_API.Contracts.Requests
{
    [DataContract]
    public class RecipientAddressRequest
    {
        [Required]
        [DataMember(Name = "address_1", EmitDefaultValue = false)]
        public string Address1 { get; set; }
		
        [Required]
        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }
		
        [Required]
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [StringLength(10, MinimumLength = 5)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")]
        [Required(ErrorMessage = "Zip Code is Required.")]
        [DataMember(Name = "zip", EmitDefaultValue = false)]
        public string Zip { get; set; }
    }
}
