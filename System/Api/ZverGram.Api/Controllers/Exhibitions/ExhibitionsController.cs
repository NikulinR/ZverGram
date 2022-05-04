using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ZverGram.Common.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ZverGram.Api.Controllers.Exhibitions.Models;
using ZverGram.ExhibitionService;
using ZverGram.ExhibitionService.Models;
using ZverGram.Api.Controllers.Comments.Models;

namespace ZverGram.Api.Controllers.Exhibitions
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ExhibitionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<ExhibitionsController> logger;
        private readonly IExhibitionService exhibitionService;

        public ExhibitionsController(IMapper mapper,  ILogger<ExhibitionsController> logger, IExhibitionService exhibitionService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.exhibitionService = exhibitionService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<ExhibitionResponse>> GetExhibitions()
        {
            var exhibitions = await exhibitionService.GetExhibitions();
            var response = mapper.Map<IEnumerable<ExhibitionResponse>>(exhibitions);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ExhibitionResponse> GetExhibition([FromRoute] int id)
        {
            var exhibition = await exhibitionService.GetExhibition(id);
            var response = mapper.Map<ExhibitionResponse>(exhibition);

            return response;
        }

        [HttpGet("{id}/comments")]
        public async Task<IEnumerable<CommentResponse>> GetComments([FromRoute] int id)
        {
            var comments = await exhibitionService.GetComments(id);
            var response = mapper.Map<IEnumerable<CommentResponse>>(comments);

            return response;
        }

        [HttpPost("")]
        [Authorize(AppScopes.ContentMaker)]
        public async Task<ExhibitionResponse> AddExhibition([FromBody] AddExhibitionRequest request)
        {
            var model = mapper.Map<AddExhibitionModel>(request);
            var exhibition = await exhibitionService.AddExhibition(model);
            var response = mapper.Map<ExhibitionResponse>(exhibition);

            return response;
        }

        
        [HttpPut("{id}")]
        [Authorize(AppScopes.ContentMaker)]
        public async Task<IActionResult> UpdateExhibition([FromRoute] int id, [FromBody] UpdateExhibitionRequest request)
        {
            var model = mapper.Map<UpdateExhibitionModel>(request);
            await exhibitionService.UpdateExhibition(id, model);

            return Ok();
        }

        
        [HttpDelete("{id}")]
        [Authorize(AppScopes.Moderator)]
        public async Task<IActionResult> DeleteExhibition([FromRoute] int id)
        {
            await exhibitionService.DeleteExhibition(id);

            return Ok();
        }

    }
}
