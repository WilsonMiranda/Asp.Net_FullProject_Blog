using BlogProject.Models.Domain;


namespace BlogProject.Repositories
{
    public interface ITagRepository
    {
        //create de definition of the methods
        Task<IEnumerable<Tag>> GetAllAsync();

        //can be null becouse of that add the ?
        Task<Tag?> GetAsync(Guid id);

        Task<Tag> AddAsync(Tag tag);

        Task<Tag?> UpdateAsync(Tag tag);

        Task<Tag?> DeleteAsync(Guid id);
    }
}
