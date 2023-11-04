using BlogProject.Models.Domain;

namespace BlogProject.Repositories
{
    public interface IBlogPostRepository
    {
        //create de definition of the methods
        Task<IEnumerable<BlogPost>> GetAllAsync();

        //can be null becouse of that add the ?
        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost?> GetByurlHandleAsync(string urlHandle);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);
    }
}
