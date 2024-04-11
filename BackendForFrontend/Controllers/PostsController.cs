using BackendForFrontend.Models.Repositories;
using BackendForFrontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BackendForFrontend.Models.DTOs.BlogDto;
using BackendForFrontend.Models.EFModels;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostRepository _postRepository;

    public PostsController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> CreatePost(CreatePostDto CreatePostDto)
    {
        var post = new Post
        {
            Title = CreatePostDto.Title,
            Content = CreatePostDto.Content,
            AuthorId = CreatePostDto.AuthorId,
            PublishDate = DateTime.UtcNow,
            Slug = CreatePostDto.Slug,
            IsPublished = CreatePostDto.IsPublished
        };

        await _postRepository.CreatePostAsync(post);
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> UpdatePost(int id, UpdatePostDto UpdatePostDto)
    {
        var post = await _postRepository.GetPostByIdAsync(id);

        if (post == null)
            return NotFound();

        post.Title = UpdatePostDto.Title;
        post.Content = UpdatePostDto.Content;
        post.UpdatedDate = DateTime.UtcNow;
        post.Slug = UpdatePostDto.Slug;
        post.IsPublished = UpdatePostDto.IsPublished;

        await _postRepository.UpdatePostAsync(post);
        return NoContent();
    }

    [HttpPatch("{id}/publish")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> PublishPost(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null)
            return NotFound();

        post.IsPublished = true;
        await _postRepository.UpdatePostAsync(post);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Employee")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);

        if (post == null)
            return NotFound();

        await _postRepository.DeletePostAsync(post);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postRepository.GetAllPublishedPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}", Name = "GetPostById")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);

        if (post == null)
            return NotFound();

        return Ok(post);
    }
}