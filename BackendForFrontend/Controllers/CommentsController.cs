using BackendForFrontend.Models;
using BackendForFrontend.Models.EFModels;
using BackendForFrontend.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BackendForFrontend.Models.DTOs.BlogDto;

namespace BackendForFrontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CreateCommentDto CreateCommentDto)
        {
            var comment = new Comment
            {
                PostId = CreateCommentDto.PostId,
                UserId = CreateCommentDto.UserId,
                EmployeeId = CreateCommentDto.EmployeeId,
                Content = CreateCommentDto.Content,
                CreatedDate = DateTime.UtcNow
            };

            await _commentRepository.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateComment(int id, UpdateCommentDto UpdateCommentDto)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);

            if (comment == null)
                return NotFound();

            if (comment.UserId != UpdateCommentDto.UserId && !User.IsInRole("Employee"))
                return Forbid();

            comment.Content = UpdateCommentDto.Content;

            await _commentRepository.UpdateCommentAsync(comment);
            return NoContent();
        }

        [HttpPatch("{id}/publish")]
        [Authorize]
        public async Task<IActionResult> PublishComment(int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id); if (comment == null)
                return NotFound();

            if (comment.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) && !User.IsInRole("Employee"))
                return Forbid();

            comment.IsPublished = true;
            //add     public bool IsPublished { get; internal set; } in EFModels/Comment.cs

            await _commentRepository.UpdateCommentAsync(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);

            if (comment == null)
                return NotFound();

            if (comment.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) && !User.IsInRole("Employee"))
                return Forbid();

            await _commentRepository.DeleteCommentAsync(comment);
            return NoContent();
        }

        [HttpGet("posts/{postId}/comments")]
        public async Task<IActionResult> GetCommentsByPostId(int postId)
        {
            var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpGet("{id}", Name = "GetCommentById")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }
    }
}
