using CasgemMicroservice.Services.Catalog.Dtos.ProductDtos;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Services.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDto>>> GetProductListsAsync();
        Task<Response<ResultProductDto>> GetProductByIdAsync(string id);
        Task<Response<NoContent>> CreateProductAsync(CreateProductDto product);
        Task<Response<NoContent>> UpdateProductAsync(UpdateProductDto product);
        Task<Response<NoContent>> DeleteProductAsync(string id);
        Task<Response<List<ResultProductDto>>> GetProductListWithCategoryAsync();
    }
}
