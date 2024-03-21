using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;

namespace CodePulse.API.NEW.Repositories.Interface
{
	public interface ICategoryRepository
	{
		Task<CategoryDto> CreateAsync(CreateCategoryRequestDto category);
	}
}
