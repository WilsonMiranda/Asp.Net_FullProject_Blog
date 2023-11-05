using BlogProject.Models.Domain;

namespace BlogProject.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);

        Task<IEnumerable<BlogPostLike>> GetLikeForBlog(Guid blogPostId);

        Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);
    }
}
