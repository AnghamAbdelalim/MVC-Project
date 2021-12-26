using System;
using System.Collections.Generic;
using System.Text;
using Data_access_Layer;
namespace Business_layer.ViewModel
{
   public class categoryViewModelcs
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string CategoryImage { get; set; }
    }
}
