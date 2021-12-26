using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business_layer.ViewModel
{
  public   class ShoppingCartViewModel
    {
        public int ShoppingCartId { get; set; }
        [Required]

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        
        public int UserId { get; set; }
    }
}
