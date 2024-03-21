using Azure;
using CodePulse.API.Data;
using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;
using CodePulse.API.NEW.Repositories.Interface;

namespace CodePulse.API.NEW.Repositories.Implementation
{
	public class CategoryRepository : ICategoryRepository
	{
		private ApplicationDbContext applicationDbContext;
		public CategoryRepository(ApplicationDbContext _applicationDbContext) {
			applicationDbContext = _applicationDbContext;
		}
		public async Task<CategoryDto> CreateAsync(CreateCategoryRequestDto category)
		{
			CategoryDto response = null;
			var _category = new Category
			{
				Name = category.Name,
				UrlHandle = category.UrlHandle
			};

			applicationDbContext.Categories.Add(_category);
			await applicationDbContext.SaveChangesAsync();

			response = new CategoryDto
			{
				Id = _category.Id,
				Name = _category.Name,
				UrlHandle = _category.UrlHandle
			};

			return response;
		}
	}
}
