using Poodle_E_Learning_Platform.Data;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Repositories.Contracts;
using System;
using System.Linq;

namespace Poodle_E_Learning_Platform.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationContext context;
        private readonly ICourseRepository courseRepository;
        public SectionRepository(ApplicationContext contex, ICourseRepository courseRepository)
        {
            this.context = contex;
            this.courseRepository = courseRepository;
        }
        public Section GetById(int Id)
        {
            var section = this.context.Sections.Where(x => x.Id == Id).FirstOrDefault();
            return section ?? throw new EntityNotFoundException($"Section with id {Id} was not found");
        }

        public Section GetByTitle(string title)
        {
            var section = this.context.Sections.Where(x => x.Title == title).FirstOrDefault();
            return section ?? throw new EntityNotFoundException($"Section with title {title} was not found");
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        public Section CreateSection(Section section, int courseId)
        {

            var course = this.courseRepository.GetById(courseId);
            course.Sections.Add(section);
            this.context.Add(section);
            context.SaveChanges();
            return section;
        }

        public Section UpdateSection(int id, Section sectionChanges)
        {

            var sectionToUpdate = this.context.Sections.Where(c => c.Id == id).FirstOrDefault();

            if (sectionToUpdate == null)
            {
                throw new EntityNotFoundException($"Course with id {id} was not found");
            }

            if (IsSectionExisting(sectionChanges.Title))
            {
                throw new DuplicateEntityException($"Course with title {sectionChanges.Title} already exist");
            }
            sectionToUpdate.LastEdit = sectionChanges.LastEdit;
            sectionToUpdate.Title = sectionChanges.Title;
            sectionToUpdate.Content = sectionChanges.Content;
            sectionToUpdate.Order = sectionChanges.Order;
            sectionToUpdate.StartDate = sectionChanges.StartDate;
            sectionToUpdate.EndDate = sectionChanges.EndDate;
            

            this.context.SaveChanges();

            return sectionToUpdate;
        }

        private bool IsSectionExisting(string title)
        {
            bool isExisting = true;
            try
            {
                var section = this.GetByTitle(title);
            }
            catch (EntityNotFoundException)
            {
                isExisting = false;
            }
            return isExisting;
        }

        public Section Delete(int id)
        {
            var sectionToDelete = GetById(id);
            if (sectionToDelete == null)
            {
                throw new EntityNotFoundException("Section not found 404");
            }
            this.context.Remove(sectionToDelete);
            context.SaveChanges();
            return sectionToDelete;
        }
    }
}
