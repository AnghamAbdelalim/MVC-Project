﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_layer.ViewModel
{
  public  class OrderViewModel
    {

        public int OrderId { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        public int paymentId { get; set; }
        public int shipperId { get; set; }
        [DataType(DataType.DateTime)]
        public string Orderdate { get; set; }
    }
}
