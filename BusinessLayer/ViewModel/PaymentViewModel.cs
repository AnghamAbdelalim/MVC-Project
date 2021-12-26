using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_layer.ViewModel
{ 
  public  class PaymentViewModel
    {
        public int PaymentID { get; set; }
        public int Amount { get; set; }
        [Required]
        [MinLength(16), MaxLength(16)]
        [RegularExpression("[0-9]+", ErrorMessage = "Card must be numbers only ")]
        public int CreditCadrdNumber { get; set; }
        public string UserId { get; set; }
        public string Bank { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Expire_Date { get; set; }
        [MinLength(3), MaxLength(3)]
        [RegularExpression("[0-9]+", ErrorMessage = "CVV must be numbers only ")]
        public int CCV { get; set; }

    
    }
}
