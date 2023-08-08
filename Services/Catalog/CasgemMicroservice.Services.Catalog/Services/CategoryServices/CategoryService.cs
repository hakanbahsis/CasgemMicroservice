using AutoMapper;
using CasgemMicroservice.Services.Catalog.Dtos.CategoryDtos;
using CasgemMicroservice.Services.Catalog.Models;
using CasgemMicroservice.Services.Catalog.Settings;
using CasgemMicroservice.Shared.Dtos;
using MongoDB.Driver;

namespace CasgemMicroservice.Services.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;
        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        }


        public async Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDto category)
        {
            var values = _mapper.Map<Category>(category);
            await _categoryCollection.InsertOneAsync(values);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteCategoryAsync(string id)
        {
            var values = await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
            if (values.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Silinecek Kategori Bulunamadı!", 404);
            }
        }

        public async Task<Response<List<ResultCategoryDto>>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return Response<List<ResultCategoryDto>>.Success(_mapper.Map<List<ResultCategoryDto>>(values), 200);
        }

        public async Task<Response<ResultCategoryDto>> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return values == null 
                ? Response<ResultCategoryDto>.Fail("Böyle bir Id Bulunamadı", 404) 
                : Response<ResultCategoryDto>.Success(_mapper.Map<ResultCategoryDto>(values), 204);
        }

        public async Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDto category)
        {
            var values = _mapper.Map<Category>(category);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == category.CategoryId, values);
            return (result == null)
                ?Response<NoContent>.Fail("Böyle bir Id Bulunamadı", 404)
                :Response<NoContent>.Success(204);
        }
    }
}
