using Project.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        public List<Article> GetAll();

        public Article GetById(int id);
        public Article GetByTitle(string title);
        public Article GetByTag(string tag);

        public void SaveChanges();

        public Article CreateArticle(Article article);

        public Article UpdateArticle(int id, Article newArticle);
        public Article Delete(int id);
    }
}
