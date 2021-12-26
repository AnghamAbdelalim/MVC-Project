using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModel
{
    public class CartDetailsViewModel
    {
        public int CartDetailId { get; set; }
        
        public int ProductId { get; set; }
   
      
        public int ShoppingCartId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }
    }
}
