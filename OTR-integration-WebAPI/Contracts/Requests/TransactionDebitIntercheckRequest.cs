using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace OTR_integration_WebAPI.Contracts.Requests
{
    [DataContract]
    public class TransactionDebitIntercheckRequest
    {
        [Required(ErrorMessage = "request_reference_id is Required.")]
        [DataMember(Name = "request_reference_id", EmitDefaultValue = false)]
        public string RequestReferenceId { get; set; }

        [Required(ErrorMessage = "account_id is Required.")]
        [DataMember(Name = "account_id", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        [Required(ErrorMessage = "amount is Required.")]
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "type is Required.")]
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
    }
}
