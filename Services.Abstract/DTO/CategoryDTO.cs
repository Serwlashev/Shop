﻿using System.Collections.Generic;

namespace Core.Application.DTO
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
