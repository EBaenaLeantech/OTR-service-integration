using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OTR_integration_Data.Contracts.Requests
{
    [DataContract]
    public class AccountCardCreateInterchecksRequest
    {
        [Required(ErrorMessage = "type is Required.")]
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [Required(ErrorMessage = "account_number is Required.")]
        [DataMember(Name = "account_number", EmitDefaultValue = false)]
        public long AccountNumber { get; set; }

        [StringLength(7, MinimumLength = 5)]
        [Required(ErrorMessage = "exp_date is Required.")]
        [RegularExpression("(^((0[1-9])|(1[0-2]))\\/(\\d{2})$)", ErrorMessage = "exp_date is invalid, required - format of MM/YY.")]
        [DataMember(Name = "exp_date", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "zip_code is Required.")]
        [DataMember(Name = "zip_code", EmitDefaultValue = false)]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "security_code is Required.")]
        [DataMember(Name = "security_code", EmitDefaultValue = false)]
        public int SecurityCode { get; set; }

        [DataMember(Name = "push_required", EmitDefaultValue = false, IsRequired = false)]
        public bool? PushRequired { get; set; }

        [DataMember(Name = "pull_required", EmitDefaultValue = false, IsRequired = false)]
        public bool? PullRequired { get; set; }
    }
}
