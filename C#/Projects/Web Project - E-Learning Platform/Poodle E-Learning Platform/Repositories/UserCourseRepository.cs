using Microsoft.EntityFrameworkCore;
using Poodle_E_Learning_Platform.Data;
using Poodle_E_Learning_Platform.Models;
using System.Collections.Generic;
using System.Linq;

namespace Poodle_E_Learning_Platform.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly ApplicationContext context;
        public UserCourseRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public UserCourse GetById(int id)
        {
            return this.context.UserCourse.Include(x => x.User).Include(x => x.Course).Where(x => x.CourseId == id).FirstOrDefault();
        }
        public UserCourse GetByBothIds(int courseId, int? userId)
        {
            if (userId != null)
            {
                return this.context.UserCourse.Include(x => x.User).Include(x => x.Course).Where(x => x.CourseId == courseId).Where(x => x.UserId == userId).FirstOrDefault();
            }
            return null;
        }
        public List<UserCourse> GetByTeacher(int courseId)
        {
            return this.context.UserCourse.Include(x => x.User).Include(x => x.Course).Where(x => x.CourseId == courseId).ToList();
        }
        public void AddUserToCourse(int userId, int courseId)
        {
            var entity = new UserCourse()
            {
                CourseId = courseId,
                UserId = userId
            };
            this.context.UserCourse.Add(entity);
            this.context.SaveChanges();
        }
        public void RemoveCourseFromUser(int courseId, int userId)
        {
            var userCourse = GetByBothIds(courseId, userId);
            this.context.UserCourse.Remove(userCourse);
            this.context.SaveChanges();
        }

        public bool IsUserAlreadyInCourse(int userId, int courseId)
        {
            return this.context.UserCourse.Any(x => x.CourseId == courseId && x.UserId == userId);
        }
    }
}
