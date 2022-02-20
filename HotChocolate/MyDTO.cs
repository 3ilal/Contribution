namespace DTOs
{

    public class MyAggregateDTO
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public int Discount { get; set; }
        public int GrossTotal { get; set; }
    }
}