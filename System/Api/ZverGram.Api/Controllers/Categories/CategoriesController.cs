using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ZverGram.Common.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ZverGram.Api.Controllers.Categories.Models;
using ZverGram.CategoryService;
using ZverGram.CategoryService.Models;

namespace ZverGram.Api.Controllers.Categories
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<CategoriesController> logger;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper,  ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<CategoryResponse>> GetCategories()
        {
            var exhibitions = await categoryService.GetCategories();
            var response = mapper.Map<IEnumerable<CategoryResponse>>(exhibitions);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<CategoryResponse> GetCategories([FromRoute] int id)
        {
            var exhibition = await categoryService.GetCategory(id);
            var response = mapper.Map<CategoryResponse>(exhibition);

            return response;
        }

        
        [HttpPost("")]
        [Authorize(AppScopes.CategoriesWrite)]
        public async Task<CategoryResponse> AddCategories([FromBody] AddCategoryRequest request)
        {
            var model = mapper.Map<AddCategoryModel>(request);
            var exhibition = await categoryService.AddCategory(model);
            var response = mapper.Map<CategoryResponse>(exhibition);

            return response;
        }

        
        [HttpPut("{id}")]
        [Authorize(AppScopes.CategoriesWrite)]
        public async Task<IActionResult> UpdateCategories([FromRoute] int id, [FromBody] UpdateCategoryRequest request)
        {
            var model = mapper.Map<UpdateCategoryModel>(request);
            await categoryService.UpdateCategory(id, model);

            return Ok();
        }

        
        [HttpDelete("{id}")]
        [Authorize(AppScopes.CategoriesWrite)]
        public async Task<IActionResult> DeleteCategories([FromRoute] int id)
        {
            await categoryService.DeleteCategory(id);

            return Ok();
        }

    }
}
