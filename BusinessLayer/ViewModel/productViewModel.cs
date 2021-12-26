using System;
using System.Collections.Generic;
using System.Text;

namespace Business_layer.ViewModel
{
    public class productViewModel
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        public float ProducteDiscount { get; set; }
        [Required]
        public string AutherName { get; set; }
        public int NumberOfPage { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public  int CategorysID { get; set; }
        [Required]
        public  int SuppliersID { get; set; }
        public int OrderDetailsID { get; set; }
    }
}
