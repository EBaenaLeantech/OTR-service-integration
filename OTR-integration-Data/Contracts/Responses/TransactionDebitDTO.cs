using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace OTR_integration_Data.Contracts.Responses
{
    public class TransactionDebitDTO
    {
        [Required(ErrorMessage = "request_reference_id is Required.")]
        [DataMember(Name = "request_reference_id", EmitDefaultValue = false)]
        public string RequestReferenceId { get; set; }

        [Required(ErrorMessage = "transaction_id is Required.")]
        [DataMember(Name = "transaction_id", EmitDefaultValue = false)]
        public string TransactionId { get; set; }

        [Required(ErrorMessage = "paid_amount is Required.")]
        [DataMember(Name = "paid_amount", EmitDefaultValue = false)]
        public decimal PaidAmount { get; set; }

        [Required(ErrorMessage = "currency is Required.")]
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        [Required(ErrorMessage = "transaction_status is Required.")]
        [DataMember(Name = "transaction_status", EmitDefaultValue = false)]
        public string TransactionStatus { get; set; }

        [Required(ErrorMessage = "paid_date is Required.")]
        [DataMember(Name = "paid_date", EmitDefaultValue = false)]
        public DateTime PaidDate { get; set; }

        [Required(ErrorMessage = "detail is Required.")]
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public string Detail { get; set; }

        [Required(ErrorMessage = "account_id is Required.")]
        [DataMember(Name = "account_id", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        [Required(ErrorMessage = "provider_transaction_id is Required.")]
        [DataMember(Name = "provider_transaction_id", EmitDefaultValue = false)]
        public string ProviderTransactionId { get; set; }
    }
}
