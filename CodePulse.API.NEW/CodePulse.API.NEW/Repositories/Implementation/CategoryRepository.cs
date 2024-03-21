using Azure;
using CodePulse.API.Data;
using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;
using CodePulse.API.NEW.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

		public async Task<List<CategoryDto>> GetAllAsync()
		{
			var CatoriesList =  await applicationDbContext.Categories.ToListAsync();
			var list = new List<CategoryDto>();

			CatoriesList.ForEach(c =>
				{
					list.Add(new CategoryDto { Id = c.Id, Name = c.Name, UrlHandle = c.UrlHandle });
				}
			);

			return list;
		}
	}
}
