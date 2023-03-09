using Microsoft.EntityFrameworkCore;
using Poodle_E_Learning_Platform.Data;
using Poodle_E_Learning_Platform.Exceptions;
using Poodle_E_Learning_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poodle_E_Learning_Platform.Repositories
{
    public class CourseRepository : ICourseRepository
    {

        private readonly ApplicationContext context;
        public CourseRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Course> GetAll()
        {
            var courses = this.context.Courses.Include(c => c.Users).ThenInclude(x=>x.User).Include(c => c.Sections).ToList();
            return courses;
        }

        public Course GetById(int id)
        {
            return this.context.Courses.Include(c=>c.Users).ThenInclude(x => x.User).Include(c=>c.Sections).Where(c => c.Id == id).FirstOrDefault() ?? throw new EntityNotFoundException($"Course with id: {id} was not found!");
        }
        public Course GetByTitle(string title)
        {
            return this.context.Courses.Include(c => c.Users).ThenInclude(x => x.User).Include(c=>c.Sections).Where(c => c.Title == title).FirstOrDefault() ?? throw new EntityNotFoundException($"Course with title: {title} was not found");
        }

        public List<Course> GetCoursesFiltered(CourseQueryParameters parameters)
        {
            string title = !string.IsNullOrEmpty(parameters.Title) ? parameters.Title.ToLowerInvariant() : string.Empty;
            string visibility = !string.IsNullOrEmpty(parameters.CourseVisibility.ToString()) ? parameters.CourseVisibility.ToString().ToLowerInvariant() : string.Empty;


            IQueryable<Course> result = context.Courses;
            result = FilterByTitle(result, title);
            result = FilterByVisibility(result, visibility);
            return result.ToList();

        }
        private static IQueryable<Course> FilterByTitle(IQueryable<Course> result, string title)
        {
            return result.Where(c => c.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase));
        }

        private static IQueryable<Course> FilterByVisibility(IQueryable<Course> result, string visibility)
        {
            if (visibility.Equals("public", StringComparison.InvariantCultureIgnoreCase))
            {
                return result.Where(c => c.Visibility.ToString().Contains("public", StringComparison.InvariantCultureIgnoreCase));
            }
            else if (visibility.Equals("private", StringComparison.InvariantCultureIgnoreCase))
            {
                return result.Where(c => c.Visibility.ToString().Contains("private", StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return result;
            }
        }
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        public Course CreateCourse(Course course)
        {
            this.context.Add(course);
            context.SaveChanges();
            return course;
        }

        public Course UpdateCourse(int id, Course courseChanges)
        {
            
            var courseToUpdate = this.context.Courses.Where(c => c.Id == id).FirstOrDefault();

            if (courseToUpdate == null)
            {
                throw new EntityNotFoundException($"Course with id {id} was not found");
            }

            if (IsCourseExisting(courseChanges.Title))
            {
                throw new DuplicateEntityException($"Course with title {courseChanges.Title} already exist");
            }

            courseToUpdate.Title = courseChanges.Title;
            courseToUpdate.Description = courseChanges.Description;
            courseToUpdate.Duration = courseChanges.Duration;
            courseToUpdate.ImgSource = courseChanges.ImgSource;
            courseToUpdate.Visibility = courseChanges.Visibility;

            this.context.SaveChanges();

            return courseToUpdate;
        }

        private bool IsCourseExisting(string title)
        {
            try
            {
                var course = this.GetByTitle(title);
                if (course != null)
                {
                    return true;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public Course Delete(int id)
        {
            var courseToDelete = GetById(id);
            if (courseToDelete == null)
            {
                throw new EntityNotFoundException("Course not found 404");
            }
            this.context.Remove(courseToDelete);
            context.SaveChanges();
            return courseToDelete;
        }

    }
}
