namespace Core.Application.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public int Number { get; set; }
    }
}
