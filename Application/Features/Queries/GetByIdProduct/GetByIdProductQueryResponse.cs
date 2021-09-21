﻿using Core.Application.Features.Queries.GetByIdCategory;

namespace Core.Application.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public GetByIdCategoryQueryResponse Category { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string PathToImage { get; set; }

    }
}
