
using Poodle_E_Learning_Platform.Models;
using System.Collections.Generic;
namespace Poodle_E_Learning_Platform.Repositories
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();

        public Course GetById(int id);
        public Course GetByTitle(string title);
        public void SaveChanges();
        public List<Course> GetCoursesFiltered(CourseQueryParameters parameters);

        public Course CreateCourse(Course course);
        
        public Course UpdateCourse(int id, Course courseChanges);

        public Course Delete(int id);
    }
}