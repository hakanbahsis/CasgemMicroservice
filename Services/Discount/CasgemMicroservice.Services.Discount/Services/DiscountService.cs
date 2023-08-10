using AutoMapper;
using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Models;
using CasgemMicroservice.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public DiscountService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateDiscountCouponsAsync(CreateDiscountDto discountDto)
        {
            var discount = _mapper.Map<DiscountCoupons>(discountDto);
            discount.CreatedTime = DateTime.Now;
            await _context.DiscountCoupons.AddAsync(discount);
            _context.SaveChanges();

            return  Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteDiscountCouponsAsync(int id)
        {
            var values = _context.DiscountCoupons.Find(id);
            if (values == null)
            {
                return Response<NoContent>.Fail("Silinecek veri bulunamadı.", 404);
            }
            _context.DiscountCoupons.Remove(values);
           await _context.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync()
        {
            var values =await _context.DiscountCoupons.ToListAsync();
            return Response<List<ResultDiscountDto>>.Success(_mapper.Map<List<ResultDiscountDto>>(values), 200);
        }

        public async Task<Response<ResultDiscountDto>> GetByIdDiscountCouponsAsync(int id)
        {
            var result=await _context.DiscountCoupons.FindAsync(id);
            return Response<ResultDiscountDto>.Success(_mapper.Map<ResultDiscountDto>(result), 200);
        }

        public async Task<Response<NoContent>> UpdateDiscountCouponsAsync(UpdateDiscountDto discountDto)
        {
            var response = await _context.DiscountCoupons.FindAsync(discountDto.DiscountCouponsId);
            if (response ==null)
            {
                return Response<NoContent>.Fail("Güncellenecek veri bulunamadı.", 404);
            }
            _mapper.Map(response, discountDto);
            _context.DiscountCoupons.Update(response);
            await _context.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }
    }
}
