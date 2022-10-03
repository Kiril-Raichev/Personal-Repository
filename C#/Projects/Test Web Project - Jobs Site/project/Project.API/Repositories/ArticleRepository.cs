using Project.API.Data;
using Project.API.Models;
using Project.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationContext context;
        public ArticleRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public List<Article> GetAll()
        {
            var courses = this.context.Articles.ToList();
            return courses;
        }

        public Article GetById(int id)
        {
            return this.context.Articles.Where(c => c.Id == id).FirstOrDefault();
        }
        public Article GetByTitle(string title)
        {
            return this.context.Articles.Where(c => c.Title == title).FirstOrDefault();
        }
        public Article GetByTag(string tag)
        {
            return this.context.Articles.Where(c => c.Tags.Contains(tag)).FirstOrDefault();
        }
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        public Article CreateArticle(Article article)
        {
            this.context.Add(article);
            context.SaveChanges();
            return article;
        }
        public Article UpdateArticle(int id, Article newArticle)
        {

            var articleToUpdate = this.context.Articles.Where(c => c.Id == id).FirstOrDefault();

            if (articleToUpdate == null)
            {
                throw new Exception($"Article with id {id} was not found");
            }

            articleToUpdate.Title = newArticle.Title;
            articleToUpdate.Body = newArticle.Body;
            articleToUpdate.Job = newArticle.Job;
            articleToUpdate.Position = newArticle.Position;
            articleToUpdate.Visibility = newArticle.Visibility;

            this.context.SaveChanges();

            return articleToUpdate;
        }

        public Article Delete(int id)
        {
            var articleToDelete = GetById(id);
            this.context.Remove(articleToDelete);
            context.SaveChanges();
            return articleToDelete;
        }
    }
}
