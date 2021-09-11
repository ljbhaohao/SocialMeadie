using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Dtos;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _postService.GetAll();
            var postsDto = _mapper.Map < IEnumerable<PostDto>>(posts);
            return Ok(postsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            var postDto = _mapper.Map<PostDto>(post);
            // var response = new ApiResponse<PostDto>(postDto);
            return Ok(postDto);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postService.Add(post);
            postDto = _mapper.Map<PostDto>(post);
            // var response = new ApiResponse<PostDto>(postDto);
            return Ok(postDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            await _postService.Delete(id);
            // var response = new ApiResponse<PostDto>(postDto);
            return Ok(post);
        }
    }
}
