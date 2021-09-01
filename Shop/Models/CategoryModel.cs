﻿using System.Collections.Generic;

namespace Shop.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}