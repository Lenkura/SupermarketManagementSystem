using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public   class Product
    {
        public int ProductID { get; set; }
        [Required]
        public int? CategoryID {get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }   

        public Category Category { get; set; }
    }
}
