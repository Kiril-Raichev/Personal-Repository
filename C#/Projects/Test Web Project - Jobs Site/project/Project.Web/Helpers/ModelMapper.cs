using Project.API.Models;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Helpers
{
    public class ModelMapper
    {
        public User Convert(RegisterViewModel viewModel)
        {
            return new User()
            {
                Username = viewModel.Username,
                Email = viewModel.Email,
                Password = viewModel.Password,
                Job = viewModel.Job,
                Position = viewModel.Position,

            };
        }
        public Article Convert(ArticleEditViewModel viewModel)
        {
            return new Article()
            {
                Title = viewModel.Title,
                Body = viewModel.Body,
                Job = viewModel.Job,
                Position = viewModel.Position,
                Visibility = viewModel.Visibility
            };
        }
        public ArticleEditViewModel Convert(Article article)
        {
            return new ArticleEditViewModel()
            {
                Title = article.Title,
                Body = article.Body,
                Job = article.Job,
                Position = article.Position,
                Visibility = article.Visibility,
            };
        }
        public User Convert(UserEditViewModel viewModel)
        {
            return new User()
            {
                Username = viewModel.Username,
                Email = viewModel.Email,
                Job = viewModel.Job,
                Position = viewModel.Position,
                Password=viewModel.Password
            };
        }
        public UserEditViewModel Convert(User user)
        {
            return new UserEditViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Job = user.Job,
                Position=user.Position
            };
        }
    }
}
