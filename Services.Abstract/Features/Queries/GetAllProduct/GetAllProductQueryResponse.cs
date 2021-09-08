using Core.Application.DTO;

namespace Core.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public int Number { get; set; }
    }
}
