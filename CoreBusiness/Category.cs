﻿using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //ef navigation property
        public List<Product> Products { get; set; } 

    }
}