
using CodePulse.API.Data;
using CodePulse.API.NEW.Models.Domain;
using CodePulse.API.NEW.Models.DTO;
using CodePulse.API.NEW.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.NEW.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		ICategoryRepository categoryRepository;
		public CategoryController(ICategoryRepository _categoryRepository) {
			categoryRepository= _categoryRepository;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto createCategoryRequestDto)
		{
			CategoryDto response = null;

			if (createCategoryRequestDto != null)
			{
				try
				{
					response = await categoryRepository.CreateAsync(createCategoryRequestDto);
					return Ok(response);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}
			var error = new {ErrorCode= StatusCodes.Status400BadRequest ,  ErrorMessage = "Request is Null" };

			return Ok(error);
		}
	}
}
