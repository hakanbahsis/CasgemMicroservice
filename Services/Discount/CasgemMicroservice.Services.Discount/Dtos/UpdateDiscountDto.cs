﻿namespace CasgemMicroservice.Services.Discount.Dtos
{
    public class UpdateDiscountDto
    {
        public int DiscountCouponsId { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
    }
}
