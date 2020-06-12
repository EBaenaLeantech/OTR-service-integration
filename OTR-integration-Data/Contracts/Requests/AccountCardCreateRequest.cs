using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_Data.Contracts.Requests
{
    [DataContract]
    public class AccountCardCreateRequest
    {
        [Required(ErrorMessage = "recipient_id is Required.")]
        [DataMember(Name = "recipient_id", EmitDefaultValue = false)]
        public string RecipientID { get; set; }

        [Required(ErrorMessage = "type is Required.")]
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [StringLength(16, MinimumLength = 16, ErrorMessage = "account_number must be a 16 Digit Debit Card number ")]
        [Required(ErrorMessage = "account_number is Required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "account_number must be numeric")]
        [DataMember(Name = "account_number", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }
        
        [StringLength(7, MinimumLength = 5)]
        [Required(ErrorMessage = "exp_date is Required.")]
        [RegularExpression("(^((0[1-9])|(1[0-2]))\\/(\\d{2})$)", ErrorMessage = "exp_date is invalid, required - format of MM/YY.")]
        [DataMember(Name = "exp_date", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        [StringLength(5, MinimumLength = 5)]
        [Required(ErrorMessage = "zip_code is Required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "zip_code must be numeric")]
        [DataMember(Name = "zip_code", EmitDefaultValue = false)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "security_code is Required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "security_code must be numeric")]
        [DataMember(Name = "security_code", EmitDefaultValue = false)]
        public string SecurityCode { get; set; }

        [DataMember(Name = "push_required", EmitDefaultValue = false, IsRequired = false)]
        public bool? PushRequired { get; set; }

        [DataMember(Name = "pull_required", EmitDefaultValue = false, IsRequired = false)]
        public bool? PullRequired { get; set; }
    }
}
