namespace Forum1.Models.Mappers
{
    public class UserMapper
    {
        public User ConvertToModel(UserDto dto)
        {
            User user = new User();
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;   
            user.Email = dto.Email;
            user.Password = dto.Password;
            return user;
                            
        }

        public User Convert(RegisterViewModel viewModel)
        {
            return new User()
            {
                Username = viewModel.Username,
                Password = viewModel.Password
            };
        }
    }
}
