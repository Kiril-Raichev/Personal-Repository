using Poodle_E_Learning_Platform.Models;
using System.Collections.Generic;

namespace Poodle_E_Learning_Platform.Services
{
    public interface ICourseService
    {
        public List<Course> GetAll();
        public List<Course> GetAll(string email);
       
        public Course GetById(int id);
        public Course GetById(int id, string email);

        public Course GetByTitle(string title, string email);

        public List<Course> GetCoursesFiltered(CourseQueryParameters parameters);

        public Course CreateCourse(Course course,string email);
        public Course CreateCourse(Course course);


        public Course UpdateCourse(int id, string email, Course courseChanges);
        public Course UpdateCourse(int id, Course courseChanges);

        public Course Delete(int id, string email);
        public Course Delete(int id);
    }
}