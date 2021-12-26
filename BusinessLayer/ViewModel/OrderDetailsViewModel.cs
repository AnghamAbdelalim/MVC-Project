using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.ViewModel
{
   public  class OrderDetailsViewModel
    {
        [Required]
        public int Id { get; set; }
     
        public int ProductId { get; set; }
        public int OrderNumber { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string BillDate { get; set; }
        [DataType(DataType.DateTime)]
        public string Shipdate { get; set; }
        public int TotalPrice { get; set; }
        public int discount { get; set; }
    }
}
