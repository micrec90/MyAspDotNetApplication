using MyRESTfulWebAPI.DTOs.UserDTOs;
using MyRESTfulWebAPI.Models;
using MyRESTfulWebAPI.Queries;

namespace MyRESTfulWebAPI.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllAsync(UserQueryObject queryObject);
        Task<User?> GetByIdAsync(int id);
        Task<User> PostAsync(User user);
        Task<User?> PutAsync(int id, UserPutDTO userDTO);
        Task<User?> DeleteAsync(int id);
        Task<bool> UserExists(int id);

    }
}
