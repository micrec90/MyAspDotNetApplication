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
                RegisteredOn = user.RegisteredOn,
                ForumPosts = user.ForumPosts.Select(x => x.ToForumPostGetDTO()).ToList()
            };
        }
        public static User ToUserFromPostDTO(this UserPostDTO userPostDTO)
        {
            return new User
            {
                Username = userPostDTO.Username,
                Email = userPostDTO.Email,
                Password = userPostDTO.Password
            };
        }
    }
}
