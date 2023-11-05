using Microsoft.AspNetCore.Identity;

namespace BlogProject.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
