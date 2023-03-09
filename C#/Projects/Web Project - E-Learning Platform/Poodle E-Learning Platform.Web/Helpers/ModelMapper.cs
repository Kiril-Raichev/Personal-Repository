using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Models.DTOs;
using Poodle_E_Learning_Platform.Web.Models;

namespace Poodle_E_Learning_Platform.Web.Helpers
{
    public class ModelMapper
    {
        public User Convert(UserEditViewModel viewModel)
        {
            return new User()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Password = viewModel.Password,
                Photo=viewModel.Photo
            };
        }
        public User Convert(RegisterViewModel viewModel)
        {
            return new User()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email=viewModel.Username,
                Password = viewModel.Password
            };
        }
        public UserEditViewModel Convert(User user)
        {
            return new UserEditViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Photo = user.Photo
            };
        }
        public Course Convert(CourseDto dto)
        {
            return new Course()
            {
                Title = dto.Title,
                Description = dto.Description,
                Duration = dto.Duration,
                Visibility = dto.Visibility,
                ImgSource = dto.ImgSource,
            };
        }
        public Course Convert(CourseEditViewModel viewModel)
        {
            return new Course()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Duration = viewModel.Duration,
                Visibility = viewModel.Visibility,
                ImgSource = viewModel.ImgSource,
            };
        }
        public CourseEditViewModel Convert(Course course)
        {
            return new CourseEditViewModel()
            {
                Title = course.Title,
                Description = course.Description,
                Duration = course.Duration,
                Visibility = course.Visibility,
                ImgSource = course.ImgSource,
            };
        }
        public Section Convert(SectionEditViewModel viewModel)
        {
            return new Section()
            {
                LastEdit=viewModel.LastEdit,
                Title = viewModel.Title,
                Content = viewModel.Content,
                Order = viewModel.Order,
                StartDate= viewModel.StartDate,
                EndDate = viewModel.EndDate
            };
        }
        public SectionEditViewModel Convert(Section section)
        {
            return new SectionEditViewModel()
            {
                Title = section.Title,
                Content = section.Content,
                Order = section.Order,
                StartDate = section.StartDate,
                EndDate = section.EndDate
            };
        }

       
    }
}
