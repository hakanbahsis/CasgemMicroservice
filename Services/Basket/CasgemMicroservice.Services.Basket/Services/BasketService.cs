using CasgemMicroservice.Services.Basket.Dtos;
using CasgemMicroservice.Shared.Dtos;
using System.Text.Json;

namespace CasgemMicroservice.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> DeleteBasket(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet Bulunamadı!",404);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var exisBasket=await _redisService.GetDb().StringGetAsync(userId);
            if (String.IsNullOrEmpty(exisBasket))
            {
                return Response<BasketDto>.Fail("Sepet Bulunamadı!", 404);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(exisBasket),200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId,JsonSerializer.Serialize(basketDto));
            return status
                ? Response<bool>.Success(204)
                : Response<bool>.Fail("Sepet güncelleme veya ekleme yapılamadı", 500);
        }
    }
}
