namespace CreatePoint.Dto.Request
{
    public class UpdatePointsRequest
    {
        public long Id { get; set; }
        public decimal QuantityPoint { get; set; }
        public string UserName { get; set; }
    }
}