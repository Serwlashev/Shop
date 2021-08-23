﻿using System.Collections.Generic;

namespace Services.DTO
{
    class CategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
