using BlogProject.Models.Domain;

namespace BlogProject.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        Task<ICollection<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
        //Task<BlogPostComment> GetAsync(Guid id);
        // Task<BlogPostComment> UpdateAsync(BlogPostComment blogPostComment);
        // Task DeleteAsync(Guid id);

        // Task<ICollection<BlogPostComment>> GetAllForBlogPostAsync(Guid blogPostId);
    }
}
