namespace CasgemMicroservice.Services.Discount.Dtos
{
    public class ResultDiscountDto
    {
        public int DiscountCouponsId { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
