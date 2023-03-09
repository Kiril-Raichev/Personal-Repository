using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using Poodle_E_Learning_Platform.Repositories;
using Poodle_E_Learning_Platform.Repositories.Contracts;
using Poodle_E_Learning_Platform.Services.Contracts;
using System;

namespace Poodle_E_Learning_Platform.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository repository;
        private readonly ICourseRepository courseRepository;
        public SectionService(ISectionRepository repository, ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
            this.repository = repository;
        }
        public Section GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public Section CreateSection(Section section, int courseId)
        {
            var course = this.courseRepository.GetById(courseId);
            foreach(var sections in course.Sections)
            {
                if(sections.Title == section.Title)
                {
                    throw new DuplicateEntityException("Course already has section with this title.");
                }
            }
            var currentSection = this.repository.CreateSection(section, courseId);
            return currentSection;
        }

        public Section UpdateSection(int id, Section sectionChanges)
        {
            bool duplicateExists = true;
            try
            {
                Section existingSection = this.repository.GetById(id);
                if (existingSection != null)
                {
                    duplicateExists = false;
                }
            }
            catch (DuplicateEntityException)
            {
                duplicateExists = false;
            }
            if (duplicateExists)
            {
                throw new DuplicateEntityException("Section with this title already exists!");
            }
            var updatedSection = this.repository.UpdateSection(id, sectionChanges);
            return updatedSection;
        }

        public Section Delete(int id)
        {
            var sectionToDelete = this.repository.GetById(id);
            return this.repository.Delete(sectionToDelete.Id);
        }
    }
}
