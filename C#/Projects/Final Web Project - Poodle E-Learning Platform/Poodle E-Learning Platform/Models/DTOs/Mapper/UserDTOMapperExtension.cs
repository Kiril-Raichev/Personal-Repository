using Poodle_E_Learning_Platform.Models.Responses;

namespace Poodle_E_Learning_Platform.Models.DTOs.Mapper
{
    public static class UserDTOMapperExtension
    {
        public static UserResponse GetResponse(this User user)
        {
            return new UserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                Role = user.Role
            };
        }
    }
}
