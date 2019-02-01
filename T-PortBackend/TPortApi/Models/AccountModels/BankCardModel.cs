using System;
using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class BankCardModel
    {
        [Required]
        [RegularExpression("^[0-9]{15}(?:[0-9]{1})?$")]
        public string CardNumber { get; set; }
        
        [Required]
        public DateTime Validity { get; set; }
    }
}