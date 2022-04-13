using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ZverGram.Common.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ZverGram.Api.Controllers.Comments.Models;
using ZverGram.CommentService;
using ZverGram.CommentService.Models;

namespace ZverGram.Api.Controllers.Comments
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CommentsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<CommentsController> logger;
        private readonly ICommentService commentService;

        public CommentsController(IMapper mapper,  ILogger<CommentsController> logger, ICommentService commentService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.commentService = commentService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<CommentResponse>> GetComments()
        {
            var exhibitions = await commentService.GetComments();
            var response = mapper.Map<IEnumerable<CommentResponse>>(exhibitions);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<CommentResponse> GetComment([FromRoute] int id)
        {
            var exhibition = await commentService.GetComment(id);
            var response = mapper.Map<CommentResponse>(exhibition);

            return response;
        }

        
        [HttpPost("")]
        [Authorize(AppScopes.CommentsWrite)]
        public async Task<CommentResponse> AddComment([FromBody] AddCommentRequest request)
        {
            var model = mapper.Map<AddCommentModel>(request);
            var exhibition = await commentService.AddComment(model);
            var response = mapper.Map<CommentResponse>(exhibition);

            return response;
        }

        
        [HttpPut("{id}")]
        [Authorize(AppScopes.CommentsWrite)]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentRequest request)
        {
            var model = mapper.Map<UpdateCommentModel>(request);
            await commentService.UpdateComment(id, model);

            return Ok();
        }

        
        [HttpDelete("{id}")]
        [Authorize(AppScopes.CommentsWrite)]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            await commentService.DeleteComment(id);

            return Ok();
        }

    }
}
