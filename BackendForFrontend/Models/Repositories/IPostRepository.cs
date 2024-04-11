using BackendForFrontend.Models.EFModels;

namespace BackendForFrontend.Models.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPublishedPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(Post post);
    }
}
