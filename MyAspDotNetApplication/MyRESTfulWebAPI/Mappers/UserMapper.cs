using MyRESTfulWebAPI.DTOs.UserDTOs;
using MyRESTfulWebAPI.Models;

namespace MyRESTfulWebAPI.Mappers
{
    public static class UserMapper
    {
        public static UserGetDTO ToUserGetDTO(this User user)
        {
            return new UserGetDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                RegisteredOn = user.RegisteredOn
            };
        }
    }
}
