using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Models;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync();
        Task<Response<ResultDiscountDto>> GetByIdDiscountCouponsAsync(int id);
        Task<Response<NoContent>> CreateDiscountCouponsAsync(CreateDiscountDto discountDto);
        Task<Response<NoContent>> UpdateDiscountCouponsAsync(UpdateDiscountDto discountDto);
        Task<Response<NoContent>> DeleteDiscountCouponsAsync(int id);
        
    }
}
